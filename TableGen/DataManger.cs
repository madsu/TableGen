using Excel;
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace TableGen
{
    class DataManger
    {
        //导出XML
        public void LoadExcel(Program.Options options)
        {
            Dictionary<String, DataTable> sheets = new Dictionary<string, DataTable>();

            Program.Log("开始加载EXECL文件");
            foreach (var file in options.readFilePaths)
            {
                string excelPath = file;
                string excelName = Path.GetFileNameWithoutExtension(excelPath);

                using (FileStream excelFile = File.Open(excelPath, FileMode.Open, FileAccess.Read))
                {
                    // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(excelFile);

                    // The result of each spreadsheet will be created in the result.Tables
                    excelReader.IsFirstRowAsColumnNames = true;
                    DataSet book = excelReader.AsDataSet();

                    // 数据检测
                    if (book.Tables.Count < 1)
                    {
                        throw new Exception("Excel file is empty: " + excelPath);
                    }

                    //// 取得数据
                    DataTable sheet = book.Tables[0];
                    if (sheet.Rows.Count <= 0)
                    {
                        throw new Exception("Excel Sheet is empty: " + excelPath);
                    }

                    Program.Log("读取" + Path.GetFileName(excelPath) + "完成!");
                    sheets.Add(excelName, sheet);
                }
            }


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

            Program.Log("生成XML...");
            foreach (KeyValuePair<String, DataTable> kvp in sheets)
            {
                DataTable sheet = kvp.Value;

                //先检查此table是否为客户端使用
                int clientUseCount = 0;
                for (int i = 0; i < sheet.Rows.Count; i++)
                {
                    DataRow row = sheet.Rows[i];

                    //在这一行数据中查找客户端用字段
                    bool isClientUse = false;
                    foreach (DataColumn column in sheet.Columns)
                    {
                        string fieldName = column.ToString();
                        if (fieldName != "客户端用")
                            continue;

                        object value = row[column];
                        if (value.ToString() != "")
                        {
                            try
                            {
                                if (int.Parse(value.ToString()) == 1)
                                    isClientUse = true;
                            }
                            catch (Exception ex)
                            {
                                Program.Log("当前文件名:" + kvp.Key.ToString());
                                Program.Log(ex.ToString());
                                return;
                            }
                        }

                        if (isClientUse)
                            clientUseCount++;
                    }
                }

                if (clientUseCount <= 1)
                    continue;

                string key1 = ""; string key2 = "";
                XmlElement data = xmlDoc.CreateElement("data");
                for (int i = 0; i < sheet.Rows.Count; i++)
                {
                    DataRow row = sheet.Rows[i];

                    bool isClientUse = false;
                    String name = ""; String type = ""; String comment = "";
                    foreach (DataColumn column in sheet.Columns)
                    {
                        object value = row[column];
                        string fieldName = column.ToString();
                        if (fieldName == "字段名")
                        {
                            name = value.ToString();
                        }
                        else if (fieldName == "数据类型")
                        {
                            if (Regex.Match(value.ToString(), "char").Success)
                                type = "string";
                            else if (Regex.Match(value.ToString(), "UINT8").Success)
                                type = "byte";
                            else if (Regex.Match(value.ToString(), "UINT16").Success)
                                type = "ushort";
                            else if (Regex.Match(value.ToString(), "UINT32").Success)
                                type = "uint";
                            else if (Regex.Match(value.ToString(), "UINT64").Success)
                                type = "ulong";
                            else if (Regex.Match(value.ToString(), "INT8").Success)
                                type = "char";
                            else if (Regex.Match(value.ToString(), "INT16").Success)
                                type = "short";
                            else if (Regex.Match(value.ToString(), "INT32").Success)
                                type = "int";
                            else if (Regex.Match(value.ToString(), "INT64").Success)
                                type = "long";
                            else
                                type = value.ToString();
                        }
                        else if (fieldName == "客户端用")
                        {
                            if (value.ToString() != "")
                            {
                                try
                                {
                                    if (int.Parse(value.ToString()) == 1)
                                        isClientUse = true;
                                }
                                catch (Exception ex)
                                {
                                    Program.Log("当前文件名:" + kvp.Key.ToString());
                                    Program.Log("当前字段名:" + name);
                                    Program.Log(ex.ToString());
                                    return;
                                }
                            }
                        }
                        else if (fieldName == "备注")
                        {
                            comment = value.ToString();
                        }
                        else if (fieldName == "主键")
                        {
                            if (value.ToString() != "")
                            {
                                if (key1 == "")
                                    key1 = name;
                                else if (key2 == "")
                                    key2 = name;
                            }
                        }
                    }

                    if (!isClientUse)
                        continue;

                    XmlElement field = xmlDoc.CreateElement("Field");
                    field.SetAttribute("Name", name);
                    field.SetAttribute("XmlName", name);
                    field.SetAttribute("Type", type);
                    field.SetAttribute("Default", "");
                    field.SetAttribute("Comment", comment);
                    data.AppendChild(field);
                }
                data.SetAttribute("Name", kvp.Key.ToString());
                data.SetAttribute("Comment", "");
                if (key2 != "")
                    data.SetAttribute("Type", "DictionaryEx");
                else
                    data.SetAttribute("Type", "Dictionary");
                data.SetAttribute("ItemName", "root/content");
                data.SetAttribute("DataPath", kvp.Key.ToString() + ".xml");
                data.SetAttribute("KeyName", key1);
                if (key2 != "")
                    data.SetAttribute("Key2Name", key2);
                data.SetAttribute("CfgType", "DB");
                xml.AppendChild(data);
            }

            string outfile = options.OutFilePath + "\\DataPoolDefine.xml";
            xmlDoc.Save(outfile);
            Program.Log("输出成功!路径:" + outfile);
        }
    }
}
