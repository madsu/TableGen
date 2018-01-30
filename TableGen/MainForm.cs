using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableGen
{
    public partial class MainForm : Form
    {
        private DataManger mDataMgr = new DataManger();

        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            RefreshFileList(InputDir.Text);
        }

        public void Log(string str)
        {
            richTextBox1.Text += str;
            richTextBox1.Text += "\n";
        }

        private void SelInputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择源文件文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                DialogResult dr = MessageBox.Show("确定选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    InputDir.Text = foldPath;
                }
            }
        }

        private void SelOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择输出文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                DialogResult dr = MessageBox.Show("确定选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    OutputDir.Text = foldPath;
                }
            }
        }

        private void InputDir_TextChanged(object sender, EventArgs e)
        {
            RefreshFileList(InputDir.Text);
        }

        private void RefreshFileList(string foldPath)
        {
            if (Directory.Exists(foldPath))
            {
                var fileinfos = Directory.GetFiles(foldPath, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx"));
                if (null != fileinfos)
                {
                    ExcelFileList.Items.Clear();
                    foreach (var item in fileinfos)
                    {
                        FileAttributes fileAtt = File.GetAttributes(item);
                        if (((fileAtt & FileAttributes.Hidden) != FileAttributes.Hidden) &&
                            ((fileAtt & FileAttributes.Temporary) != FileAttributes.Temporary))
                            ExcelFileList.Items.Add(item);
                    }
                }
            }
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ExcelFileList.Items.Count; i++)
                ExcelFileList.SetItemChecked(i, true);
        }

        private void DisSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ExcelFileList.Items.Count; i++)
                ExcelFileList.SetItemChecked(i, false);
        }

        private void InvertSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ExcelFileList.Items.Count; i++)
                ExcelFileList.SetItemChecked(i, !ExcelFileList.GetItemChecked(i));
        }

        private void Build_Click(object sender, EventArgs e)
        {
            List<String> selFileList = new List<String>();
            for (int i = 0; i < ExcelFileList.CheckedItems.Count; i++)
            {
                selFileList.Add(ExcelFileList.CheckedItems[i].ToString());
            }

            if (selFileList.Count <= 0)
            {
                MessageBox.Show("未选择输入文件!");
                return;
            }

            if(OutputDir.Text.Equals(""))
            {
                MessageBox.Show("请设置输出目录!");
                return;
            }

            richTextBox1.Text = "";
            Build.Enabled = false;

            Program.Options options = new Program.Options();
            options.readFilePaths = selFileList;
            options.OutFilePath = OutputDir.Text;

            this.backgroundWorker1.RunWorkerAsync(options);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (this.mDataMgr)
            {
                try
                {
                    this.mDataMgr.LoadExcel((Program.Options)e.Argument);
                }
                catch (Exception ex)
                {
                    this.Log(ex.ToString());
                }
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Build.Enabled = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
    }
}
