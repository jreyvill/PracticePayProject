using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Add the following references
using System.IO;
using CsvHelper;
using System.Globalization;

namespace PracticePayProjectSANT
{
    /// <summary>
    /// Class responsible for writing an aggregate collection of PayRecord objects to a comma delimited file (csv - comma separated file).
    /// </summary>
    public class PayRecordWriter
    {
        /// <summary>
        /// Static method for writing a collection of PayRecord objects to a comma delimited file and
        /// provides the option to also write the values to the Console.
        /// </summary>
        /// <param name="file">string: The name of the file to create and write the records to.</param>
        /// <param name="records">List&gt;PayRecord&lt;: The collection of PayRecord objects.</param>
        /// <param name="writeToConsole">bool: Optional named parameter for writing to the console.</param>
        public static void Write(string file, List<PayRecord> records, bool writeToConsole = false)
        {
            //Youtube Tutorial Detailing the Import of the CsvHelper library
            //Search YouTube for: The BEST Way to Read a CSV File in C# | CsvHelper Tutorial

            //'using' - The 'using' keyword provides for invocation of the memory garbage collector, such that
            //when an object (in the case below, the 'StreamWriter' object), goes out of scope, it is removed
            //from memory asap.
            //'$' allows string interpolation '@' delimits any '\' backslashes so that that are take as literal backslashes and not delimiters.
            using (var stream = new StreamWriter(Path.GetFullPath($@"..\..\..\Export\{file}.csv"))) 
            using (var csv = new CsvWriter(stream, CultureInfo.InvariantCulture)) 
            {
                csv.WriteRecords(records);
            }

            if (writeToConsole)
            {
                Console.WriteLine();
                foreach (var recrd in records)
                {
                    Console.WriteLine($" {recrd.GetDetails()}");
                }
            }
        }
    }
}