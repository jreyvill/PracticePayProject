using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticePayProjectSANT
{
    /// <summary>
    /// Class for importing comma delimited data from .csv file and returns a collection of
    /// PayRecord objects. It does this by declaring it two methods, ImportPayRecords()
    /// and CreatePayRecords() as static methods.
    /// </summary>
    public class CsvImporter
    {
        public static List<PayRecord> ImportPayrecords(string fileName) 
        {
            //Instantiate a list for storing the imported record objects.
            List<PayRecord> records = new List<PayRecord>();
            
            //return the imported list of PayRecord objects.
            return records;



        }
    }
}