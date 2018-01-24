using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FastExcel
{
    public class DisorderSortInt : IEqualityComparer<int>
    {
        public bool Equals(int x , int y)
        {
            return false;
        }

        public int GetHashCode(int obj)
        {
            return obj.GetHashCode();
        }
    }

    public class DisorderSortString : IEqualityComparer<string>
    {
        public bool Equals(string x , string y)
        {
            return false;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }

    /// <summary>
    /// Read and update xl/sharedStrings.xml file
    /// </summary>
    public class SharedStrings
    {
        //A dictionary is a lot faster than a list
        private Dictionary<string , int> StringDictionary
        {
            get { return m_StringDictionary; }
            set { m_StringDictionary = value; }
        }

        private Dictionary<int , string> StringArray
        {
            get { return m_StringArray; }
            set { m_StringArray = value; }
        }

        private Dictionary<string , int> m_StringDictionary = new Dictionary<string , int>(new DisorderSortString());

        private Dictionary<int , string> m_StringArray = new Dictionary<int , string>(new DisorderSortInt());

        private bool SharedStringsExists { get; set; }
        private ZipArchive ZipArchive { get; set; }

        public bool PendingChanges { get; private set; }

        public bool ReadWriteMode { get; set; }

        
        internal SharedStrings(ZipArchive archive)
        {
            this.ZipArchive = archive;

            this.SharedStringsExists = true;

            if ( !this.ZipArchive.Entries.Where(entry => entry.FullName == "xl/sharedStrings.xml").Any() ) {
                this.StringDictionary = new Dictionary<string , int>();
                this.SharedStringsExists = false;
                return;
            }

            using ( Stream stream = this.ZipArchive.GetEntry("xl/sharedStrings.xml").Open() ) {
                if ( stream == null ) {
                    this.StringDictionary = new Dictionary<string , int>();
                    this.SharedStringsExists = false;
                    return;
                }

                XDocument document = XDocument.Load(stream);

                if ( document == null ) {
                    this.StringDictionary = new Dictionary<string , int>();
                    this.SharedStringsExists = false;
                    return;
                }

                int i = 0;
                //this.StringDictionary = document.Descendants().Where(d => d.Name.LocalName == "t").Select(e => e.Value).ToDictionary(k=> k,v => i++);

                if ( this.StringDictionary == null ) {
                    this.StringDictionary = new Dictionary<string , int>();
                }


                int idx = 0;
                var descend = document.Descendants();
                if ( null != descend ) {
                    int cnt = descend.Count();
                    for ( i = 0 ; i < cnt ; i++ ) {
                        var item = descend.ElementAt(i);
                        if ( item.Name.LocalName == "t" ) {
                            StringDictionary.Add(item.Value , idx);
                            idx++;
                        }
                    }
                }
            }

        }

        internal int AddString(string stringValue)
        {
            if ( this.StringDictionary.ContainsKey(stringValue) ) {
                return this.StringDictionary[stringValue];
            } else {
                this.PendingChanges = true;
                this.StringDictionary.Add(stringValue , this.StringDictionary.Count);

                // Clear String Array used for retrieval
                if ( this.ReadWriteMode && this.StringArray != null ) {
                    this.StringArray.Add(this.StringDictionary.Count - 1 , stringValue);
                } else {
                    this.StringArray = null;
                }

                return this.StringDictionary.Count - 1;
            }
        }

        internal void Write()
        {
            // Only update if changes were made
            if ( !this.PendingChanges ) {
                return;
            }

            StreamWriter streamWriter = null;
            try {
                if ( this.SharedStringsExists ) {
                    streamWriter = new StreamWriter(this.ZipArchive.GetEntry("xl/sharedStrings.xml").Open());
                } else {
                    streamWriter = new StreamWriter(this.ZipArchive.CreateEntry("xl/sharedStrings.xml").Open());
                }

                // TODO instead of saving the headers then writing them back get position where the headers finish then write from there

                /* Note: the count attribute value is wrong, it is the number of times strings are used thoughout the workbook it is different to the unique count 
                 *       but because this library is about speed and Excel does not seem to care I am not going to fix it because I would need to read the whole workbook
                 */

                streamWriter.Write(string.Format("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                            "<sst uniqueCount=\"{0}\" count=\"{0}\" xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\">" , this.StringDictionary.Count));

                // Add Rows
                foreach ( var stringValue in this.StringDictionary ) {
                    streamWriter.Write(string.Format("<si><t>{0}</t></si>" , stringValue.Key));
                }

                //Add Footers
                streamWriter.Write("</sst>");
                streamWriter.Flush();
            }
            finally {
                streamWriter.Dispose();
                this.PendingChanges = false;
            }
        }

        internal string GetString(string position)
        {
            int pos = 0;
            if ( int.TryParse(position , out pos) ) {
                return GetString(pos + 1);
            } else {
                // TODO: should I throw an error? this is a corrupted excel document
                return string.Empty;
            }
        }

        internal string GetString(int position)
        {
            if ( this.StringArray == null || this.StringArray.Count <1 ) {

                if(null == this.StringArray )
                 this.StringArray = new Dictionary<int , string>();

                var iteor = this.StringDictionary.GetEnumerator();
                while ( iteor.MoveNext() ) {
                    this.StringArray.Add(iteor.Current.Value , iteor.Current.Key);
                }
            }

            int key =position -1;
            var iteorarr = this.StringArray.GetEnumerator();
            while ( iteorarr.MoveNext() ) {
                if ( iteorarr.Current.Key == key ) {
                    return iteorarr.Current.Value;
                }
            }

            return string.Empty;
            //return this.StringArray[key];
        }
    }
}
