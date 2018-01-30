using System;
using System.Collections.Generic;

namespace TableGen
{
    partial class Program
    {
        internal sealed class Options
        {
            public Options()
            {
                OutFilePath = "";
                readFilePaths = new List<String>();
            }

            public string OutFilePath
            {
                get;
                set;
            }


            public List<String> readFilePaths
            {
                get;
                set;
            }
        }
    }
}
