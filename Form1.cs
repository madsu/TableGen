using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MxExcelTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            RefreshFileList(textBox1.Text);
        }


        public void Log(string str)
        {
            richTextBox1.Text += str;
            richTextBox1.Text += "\n";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Program.FilesPath = textBox1.Text;
            RefreshFileList(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Program.OutsPath = textBox2.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Program.IsFindChild = checkBox1.Checked;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
      
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
                    textBox1.Text = foldPath;
                    Program.FilesPath = foldPath;
                    RefreshFileList(foldPath);
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
                    textBox2.Text = foldPath;
                    Program.OutsPath = foldPath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.OnExcute();
        }

        private void RefreshFileList(string foldPath)
        {
            if ( Directory.Exists(foldPath) ) {
                var fileinfos = Directory.GetFiles(foldPath , "*.*" , Program.IsFindChild ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
.Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx"));

                if ( null != fileinfos ) {
                    files.Items.Clear();
                    foreach ( var item in fileinfos ) {
                        FileAttributes fileAtt = File.GetAttributes(item);
                        if ( ((fileAtt & FileAttributes.Hidden) != FileAttributes.Hidden)  && 
                            ((fileAtt & FileAttributes.Temporary) != FileAttributes.Temporary) )
                         files.Items.Add(item);
                    }
                }
            }
        }

    }
}
