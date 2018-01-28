using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MxExcelTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mform = new Form1();
            Application.Run(mform);
        }

        static public void Log(string str)
        {
            mform.Log(str);
        }

        //static public void  OnExcute()
        //{
        //    if (string.IsNullOrEmpty(FilesPath))
        //    {
        //        Log("没有选择源数据路径");
        //        return;
        //    }

        //    var files =Directory.GetFiles(FilesPath, "*.*", IsFindChild ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
        //        .Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx"));

        //    List<Worksheet> sheets = new List<Worksheet>();
        //    foreach (var item in files)
        //    {
        //        List<Worksheet> sheet = MxExcel.FastExcelRead(new FileInfo(item),2);
        //        sheets.AddRange(sheet);
        //    }

        //    Log(string.Format("sheets count = {0}", sheets.Count));
        //}

        static Form1 mform;
    }
}
