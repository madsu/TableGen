namespace MxExcelTool
{
    partial class Form1
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
            this.textInputDir = new System.Windows.Forms.TextBox();
            this.textOutputDir = new System.Windows.Forms.TextBox();
            this.textOutput = new System.Windows.Forms.RichTextBox();
            this.buttonSelInput = new System.Windows.Forms.Button();
            this.buttonSelOutput = new System.Windows.Forms.Button();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.checkedListFiles = new System.Windows.Forms.CheckedListBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.checkIsResursive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textInputDir
            // 
            this.textInputDir.Location = new System.Drawing.Point(19, 59);
            this.textInputDir.Margin = new System.Windows.Forms.Padding(5);
            this.textInputDir.Name = "textInputDir";
            this.textInputDir.Size = new System.Drawing.Size(241, 39);
            this.textInputDir.TabIndex = 0;
            this.textInputDir.Text = "F:\\test\\1";
            this.textInputDir.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textOutputDir
            // 
            this.textOutputDir.Location = new System.Drawing.Point(19, 115);
            this.textOutputDir.Margin = new System.Windows.Forms.Padding(5);
            this.textOutputDir.Name = "textOutputDir";
            this.textOutputDir.Size = new System.Drawing.Size(241, 39);
            this.textOutputDir.TabIndex = 1;
            this.textOutputDir.Text = "F:\\test";
            // 
            // textOutput
            // 
            this.textOutput.Location = new System.Drawing.Point(22, 284);
            this.textOutput.Margin = new System.Windows.Forms.Padding(5);
            this.textOutput.Name = "textOutput";
            this.textOutput.Size = new System.Drawing.Size(425, 459);
            this.textOutput.TabIndex = 2;
            this.textOutput.Text = "";
            // 
            // buttonSelInput
            // 
            this.buttonSelInput.AutoSize = true;
            this.buttonSelInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSelInput.Location = new System.Drawing.Point(278, 59);
            this.buttonSelInput.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSelInput.Name = "buttonSelInput";
            this.buttonSelInput.Size = new System.Drawing.Size(170, 44);
            this.buttonSelInput.TabIndex = 3;
            this.buttonSelInput.Text = "选择输入目录";
            this.buttonSelInput.UseVisualStyleBackColor = true;
            this.buttonSelInput.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSelOutput
            // 
            this.buttonSelOutput.AutoSize = true;
            this.buttonSelOutput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSelOutput.Location = new System.Drawing.Point(278, 115);
            this.buttonSelOutput.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSelOutput.Name = "buttonSelOutput";
            this.buttonSelOutput.Size = new System.Drawing.Size(170, 44);
            this.buttonSelOutput.TabIndex = 4;
            this.buttonSelOutput.Text = "选择输出目录";
            this.buttonSelOutput.UseVisualStyleBackColor = true;
            this.buttonSelOutput.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(278, 196);
            this.buttonBuild.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(142, 44);
            this.buttonBuild.TabIndex = 6;
            this.buttonBuild.Text = "生成";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkedListFiles
            // 
            this.checkedListFiles.FormattingEnabled = true;
            this.checkedListFiles.Location = new System.Drawing.Point(503, 21);
            this.checkedListFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkedListFiles.Name = "checkedListFiles";
            this.checkedListFiles.Size = new System.Drawing.Size(516, 616);
            this.checkedListFiles.TabIndex = 7;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(44, 196);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(142, 44);
            this.buttonLoad.TabIndex = 10;
            this.buttonLoad.Text = "加载";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.AutoSize = true;
            this.button5.Location = new System.Drawing.Point(503, 699);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(136, 44);
            this.button5.TabIndex = 13;
            this.button5.Text = "全选";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.AutoSize = true;
            this.button6.Location = new System.Drawing.Point(693, 699);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(136, 44);
            this.button6.TabIndex = 14;
            this.button6.Text = "取消全选";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.AutoSize = true;
            this.button7.Location = new System.Drawing.Point(883, 699);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(136, 44);
            this.button7.TabIndex = 14;
            this.button7.Text = "反选";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // checkIsResursive
            // 
            this.checkIsResursive.AutoSize = true;
            this.checkIsResursive.Location = new System.Drawing.Point(19, 14);
            this.checkIsResursive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkIsResursive.Name = "checkIsResursive";
            this.checkIsResursive.Size = new System.Drawing.Size(232, 35);
            this.checkIsResursive.TabIndex = 15;
            this.checkIsResursive.Text = "是否选择递归目录";
            this.checkIsResursive.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1036, 832);
            this.Controls.Add(this.checkIsResursive);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.checkedListFiles);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.buttonSelOutput);
            this.Controls.Add(this.buttonSelInput);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.textOutputDir);
            this.Controls.Add(this.textInputDir);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "表格生成工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textInputDir;
        private System.Windows.Forms.TextBox textOutputDir;
        private System.Windows.Forms.RichTextBox textOutput;
        private System.Windows.Forms.Button buttonSelInput;
        private System.Windows.Forms.Button buttonSelOutput;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.CheckedListBox checkedListFiles;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox checkIsResursive;
    }
}

