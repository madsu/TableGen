using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FastExcel;

namespace MxExcelTool
{
    public partial class Form1 : Form
    {
        private List<String> selFileList = new List<String>();
        private bool isResusivePath = false;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            RefreshFileList(textInputDir.Text);
            isResusivePath = checkIsResursive.Checked;
        }

        public void Log(string str)
        {
            textOutput.Text += str;
            textOutput.Text += "\n";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshFileList(textInputDir.Text);
        }

        private void RefreshFileList(string foldPath)
        {
            if (Directory.Exists(foldPath))
            {
                var fileinfos = Directory.GetFiles(foldPath, "*.*", isResusivePath ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx"));
                if (null != fileinfos)
                {
                    checkedListFiles.Items.Clear();
                    foreach (var item in fileinfos)
                    {
                        FileAttributes fileAtt = File.GetAttributes(item);
                        if (((fileAtt & FileAttributes.Hidden) != FileAttributes.Hidden) &&
                            ((fileAtt & FileAttributes.Temporary) != FileAttributes.Temporary))
                            checkedListFiles.Items.Add(item);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择源文件文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                DialogResult dr = MessageBox.Show("确定选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    textInputDir.Text = foldPath;
                    RefreshFileList(textInputDir.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择输出文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                DialogResult dr = MessageBox.Show("确定选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    textOutputDir.Text = foldPath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Worksheet> sheets = new List<Worksheet>();
            foreach (var item in selFileList)
            {
                List<Worksheet> sheet = MxExcel.FastExcelRead(new FileInfo(item));
                sheets.AddRange(sheet);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selFileList.Clear();
            for(int i = 0; i < checkedListFiles.CheckedItems.Count; i++)
            {
                selFileList.Add(checkedListFiles.CheckedItems[i].ToString());
            }

            if(selFileList.Count <= 0)
            {
                MessageBox.Show("未选择！");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListFiles.Items.Count; i++)
                checkedListFiles.SetItemChecked(i, true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListFiles.Items.Count; i++)
                checkedListFiles.SetItemChecked(i, false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < checkedListFiles.Items.Count; i++)
            {
                checkedListFiles.SetItemChecked(i, !checkedListFiles.GetItemChecked(i));
            }
        }
    }
}
