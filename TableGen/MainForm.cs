using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
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
        }

        public void Log(string str)
        {
            richTextBox1.Text += str;
            richTextBox1.Text += "\n";
        }

        private void LoadConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(@".\config.xml");
                XmlNode inputDir = xmlDoc.SelectSingleNode("//InputDir");
                if(inputDir != null)
                {
                    InputDir.Text = inputDir.InnerText;
                }

                XmlNode outputDir = xmlDoc.SelectSingleNode("//OutputDir");
                if(outputDir != null)
                {
                    OutputDir.Text = outputDir.InnerText;
                }
           
            }
            catch (Exception e)
            {
                Log(e.Message);
            }
        }

        private void SaveConfig()
        {
            //生成XML
            //创建XmlDocument对象
            XmlDocument xmlDoc = new XmlDocument();
            //XML的声明<?xml version="1.0" encoding="gb2312"?> 
            XmlDeclaration xmlSM = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            //追加xmldecl位置
            xmlDoc.AppendChild(xmlSM);
            //添加一个名为Gen的根节点
            XmlElement xml = xmlDoc.CreateElement("", "root", "");
            //追加Gen的根节点位置
            xmlDoc.AppendChild(xml);

            XmlElement inputDir = xmlDoc.CreateElement("InputDir");
            inputDir.InnerText = InputDir.Text;
            XmlElement outputDir = xmlDoc.CreateElement("OutputDir");
            outputDir.InnerText = OutputDir.Text;

            xml.AppendChild(inputDir);
            xml.AppendChild(outputDir);
            xmlDoc.Save(@".\config.xml");
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
            RefreshFileList(InputDir.Text);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveConfig();
            Dispose();
            Application.Exit();
        }
    }
}
