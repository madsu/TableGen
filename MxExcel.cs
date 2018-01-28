using System;
using System.Collections.Generic;
using System.Diagnostics;
using FastExcel;
using System.IO;

namespace MxExcelTool
{
    class MxExcel
    {
        const  int NumberOfRecords = 100000;

        static private void FastExcelWrite(FileInfo outputFile, List<Worksheet> sheets )
        {
            Stopwatch stopwatch = new Stopwatch();
            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(outputFile))
            {
                List<Row> objectList = new List<Row>();

                for (int num = 0; num < sheets.Count; num++)
                {
                    objectList.AddRange(sheets[num].Rows);
                }
                stopwatch.Start();
                Log("Writing using IEnumerable<MyObject>...");
                fastExcel.Write(objectList, "sheet1", true);
            }

            Log(string.Format("Writing IEnumerable<MyObject> took {0} seconds", stopwatch.Elapsed.TotalSeconds));
        }

        static public List<Worksheet> FastExcelRead(FileInfo inputFile ,bool readOnly = true )
        {
            List<Worksheet> sheets = new List<Worksheet>();
            Stopwatch stopwatch = Stopwatch.StartNew();

            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(inputFile, readOnly))
            {
                for (int i = 1; i < fastExcel.MaxSheetNumber; i++)
                {
                    Worksheet worksheet = fastExcel.Read(sheetNames[i]);
                    if ( null == worksheet ) continue;
//                     var row =worksheet.Rows.GetEnumerator();
//                     while ( row.MoveNext() ) {
//                         Row  rw= row.Current;
//                         Log(string.Format("行 {0} " , rw.RowNumber ));
//                         var cell = rw.Cells.GetEnumerator();
//                         while ( cell.MoveNext() ) {
//                             Cell  cel =cell.Current;
//                             Log(string.Format("列 {0}  值 {1}" , cel.ColumnNumber , cel.Value.ToString()));
//                         }
//                     }
                    sheets.Add(worksheet);
                }
            }

            Log(string.Format("Reading data took {0} seconds", stopwatch.Elapsed.TotalSeconds));
            return sheets;
        }

        static public List<Worksheet> FastExcelRead(FileInfo inputFile , bool readOnly = true)
        {
            List<Worksheet> sheets = new List<Worksheet>();
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Open excel file using read only is much faster, but you cannot perfrom any writes
            using ( FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(inputFile , readOnly) ) {
                for ( int i = 1 ; i < sheetCount ; i++ ) {
                    Worksheet worksheet = fastExcel.Read(i);
                    if ( null == worksheet ) continue;
                    //                     var row =worksheet.Rows.GetEnumerator();
                    //                     while ( row.MoveNext() ) {
                    //                         Row  rw= row.Current;
                    //                         Log(string.Format("行 {0} " , rw.RowNumber ));
                    //                         var cell = rw.Cells.GetEnumerator();
                    //                         while ( cell.MoveNext() ) {
                    //                             Cell  cel =cell.Current;
                    //                             Log(string.Format("列 {0}  值 {1}" , cel.ColumnNumber , cel.Value.ToString()));
                    //                         }
                    //                     }
                    sheets.Add(worksheet);
                }
            }

            Log(string.Format("Reading data took {0} seconds" , stopwatch.Elapsed.TotalSeconds));
            return sheets;
        }

        static public void Log(string str)
        {
            Program.Log(str);
        }

        private class GenericObject
        {
            public int IntegerColumn1 { get; set; }
            public int IntegerColumn2 { get; set; }
            public int IntegerColumn3 { get; set; }
            public int IntegerColumn4 { get; set; }
            public int IntegerColumn5 { get; set; }
            public double DoubleColumn6 { get; set; }
            public string StringColumn7 { get; set; }
            public string ObjectColumn8 { get; set; }
        }
    }

}
