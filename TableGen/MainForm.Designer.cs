namespace TableGen
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputDir = new System.Windows.Forms.TextBox();
            this.SelInputDir = new System.Windows.Forms.Button();
            this.OutputDir = new System.Windows.Forms.TextBox();
            this.SelOutputDir = new System.Windows.Forms.Button();
            this.ExcelFileList = new System.Windows.Forms.CheckedListBox();
            this.Build = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SelectAll = new System.Windows.Forms.Button();
            this.DisSelectAll = new System.Windows.Forms.Button();
            this.InvertSelect = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // InputDir
            // 
            this.InputDir.Location = new System.Drawing.Point(12, 29);
            this.InputDir.Name = "InputDir";
            this.InputDir.Size = new System.Drawing.Size(151, 21);
            this.InputDir.TabIndex = 0;
            this.InputDir.Text = "E:\\回合制\\design\\config";
            this.InputDir.TextChanged += new System.EventHandler(this.InputDir_TextChanged);
            // 
            // SelInputDir
            // 
            this.SelInputDir.AutoSize = true;
            this.SelInputDir.Location = new System.Drawing.Point(208, 29);
            this.SelInputDir.Name = "SelInputDir";
            this.SelInputDir.Size = new System.Drawing.Size(87, 23);
            this.SelInputDir.TabIndex = 1;
            this.SelInputDir.Text = "选择输入目录";
            this.SelInputDir.UseVisualStyleBackColor = true;
            this.SelInputDir.Click += new System.EventHandler(this.SelInputDir_Click);
            // 
            // OutputDir
            // 
            this.OutputDir.Location = new System.Drawing.Point(12, 71);
            this.OutputDir.Name = "OutputDir";
            this.OutputDir.Size = new System.Drawing.Size(151, 21);
            this.OutputDir.TabIndex = 0;
            this.OutputDir.Text = "E:\\回合制\\design\\config";
            // 
            // SelOutputDir
            // 
            this.SelOutputDir.AutoSize = true;
            this.SelOutputDir.Location = new System.Drawing.Point(208, 71);
            this.SelOutputDir.Name = "SelOutputDir";
            this.SelOutputDir.Size = new System.Drawing.Size(87, 23);
            this.SelOutputDir.TabIndex = 1;
            this.SelOutputDir.Text = "选择输入目录";
            this.SelOutputDir.UseVisualStyleBackColor = true;
            this.SelOutputDir.Click += new System.EventHandler(this.SelOutputDir_Click);
            // 
            // ExcelFileList
            // 
            this.ExcelFileList.FormattingEnabled = true;
            this.ExcelFileList.Location = new System.Drawing.Point(377, 29);
            this.ExcelFileList.Name = "ExcelFileList";
            this.ExcelFileList.Size = new System.Drawing.Size(383, 452);
            this.ExcelFileList.TabIndex = 2;
            // 
            // Build
            // 
            this.Build.Location = new System.Drawing.Point(208, 120);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(87, 23);
            this.Build.TabIndex = 3;
            this.Build.Text = "生成";
            this.Build.UseVisualStyleBackColor = true;
            this.Build.Click += new System.EventHandler(this.Build_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 166);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(341, 315);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // SelectAll
            // 
            this.SelectAll.Location = new System.Drawing.Point(406, 511);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(75, 23);
            this.SelectAll.TabIndex = 5;
            this.SelectAll.Text = "全选";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // DisSelectAll
            // 
            this.DisSelectAll.Location = new System.Drawing.Point(530, 511);
            this.DisSelectAll.Name = "DisSelectAll";
            this.DisSelectAll.Size = new System.Drawing.Size(75, 23);
            this.DisSelectAll.TabIndex = 5;
            this.DisSelectAll.Text = "取消全选";
            this.DisSelectAll.UseVisualStyleBackColor = true;
            this.DisSelectAll.Click += new System.EventHandler(this.DisSelectAll_Click);
            // 
            // InvertSelect
            // 
            this.InvertSelect.Location = new System.Drawing.Point(654, 511);
            this.InvertSelect.Name = "InvertSelect";
            this.InvertSelect.Size = new System.Drawing.Size(75, 23);
            this.InvertSelect.TabIndex = 5;
            this.InvertSelect.Text = "反选";
            this.InvertSelect.UseVisualStyleBackColor = true;
            this.InvertSelect.Click += new System.EventHandler(this.InvertSelect_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.InvertSelect);
            this.Controls.Add(this.DisSelectAll);
            this.Controls.Add(this.SelectAll);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Build);
            this.Controls.Add(this.ExcelFileList);
            this.Controls.Add(this.SelOutputDir);
            this.Controls.Add(this.SelInputDir);
            this.Controls.Add(this.OutputDir);
            this.Controls.Add(this.InputDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "表格生成工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputDir;
        private System.Windows.Forms.Button SelInputDir;
        private System.Windows.Forms.TextBox OutputDir;
        private System.Windows.Forms.Button SelOutputDir;
        private System.Windows.Forms.CheckedListBox ExcelFileList;
        private System.Windows.Forms.Button Build;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button SelectAll;
        private System.Windows.Forms.Button DisSelectAll;
        private System.Windows.Forms.Button InvertSelect;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

