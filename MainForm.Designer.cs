namespace USB_Stealer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ConsoleRichText = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.StartButton = new System.Windows.Forms.Button();
            this.SettingButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ExtTextBox = new System.Windows.Forms.TextBox();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ConsoleRichText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 480;
            this.splitContainer1.TabIndex = 0;
            // 
            // ConsoleRichText
            // 
            this.ConsoleRichText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleRichText.BackColor = System.Drawing.SystemColors.WindowText;
            this.ConsoleRichText.Cursor = System.Windows.Forms.Cursors.Default;
            this.ConsoleRichText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConsoleRichText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ConsoleRichText.HideSelection = false;
            this.ConsoleRichText.Location = new System.Drawing.Point(1, 2);
            this.ConsoleRichText.Margin = new System.Windows.Forms.Padding(0);
            this.ConsoleRichText.Name = "ConsoleRichText";
            this.ConsoleRichText.ReadOnly = true;
            this.ConsoleRichText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ConsoleRichText.Size = new System.Drawing.Size(475, 447);
            this.ConsoleRichText.TabIndex = 0;
            this.ConsoleRichText.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 440);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.StartButton);
            this.flowLayoutPanel1.Controls.Add(this.SettingButton);
            this.flowLayoutPanel1.Controls.Add(this.StopButton);
            this.flowLayoutPanel1.Controls.Add(this.ExitButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 224);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(302, 211);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartButton.Location = new System.Drawing.Point(8, 8);
            this.StartButton.Margin = new System.Windows.Forms.Padding(8);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(101, 51);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start Monitoring";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // SettingButton
            // 
            this.SettingButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SettingButton.Location = new System.Drawing.Point(125, 8);
            this.SettingButton.Margin = new System.Windows.Forms.Padding(8);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(101, 51);
            this.SettingButton.TabIndex = 0;
            this.SettingButton.Text = "Apply Setting";
            this.SettingButton.UseVisualStyleBackColor = true;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopButton.Location = new System.Drawing.Point(8, 75);
            this.StopButton.Margin = new System.Windows.Forms.Padding(8);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(101, 51);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop Monitoring";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExitButton.Location = new System.Drawing.Point(125, 75);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(8);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(101, 51);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Stop and Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ExtTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.PathTextBox, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(277, 199);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // ExtTextBox
            // 
            this.ExtTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExtTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.ExtTextBox.Location = new System.Drawing.Point(3, 36);
            this.ExtTextBox.Name = "ExtTextBox";
            this.ExtTextBox.Size = new System.Drawing.Size(271, 26);
            this.ExtTextBox.TabIndex = 1;
            this.ExtTextBox.Text = "扩展名列表";
            this.ExtTextBox.Click += new System.EventHandler(this.ExtTestBox_Click);
            this.ExtTextBox.Leave += new System.EventHandler(this.ExtTestBox_Leave);
            // 
            // PathTextBox
            // 
            this.PathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PathTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.PathTextBox.Location = new System.Drawing.Point(3, 3);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(271, 26);
            this.PathTextBox.TabIndex = 0;
            this.PathTextBox.Text = "目标路径";
            this.PathTextBox.Click += new System.EventHandler(this.PathTextBox_Click);
            this.PathTextBox.Leave += new System.EventHandler(this.PathTextBox_Leave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(20, 39);
            this.Name = "MainForm";
            this.Text = "USB Stealer Platinum Edition 2022";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox ConsoleRichText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button SettingButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TextBox ExtTextBox;
        public System.Windows.Forms.TextBox PathTextBox;
    }
}

