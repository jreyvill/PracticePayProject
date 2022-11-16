using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//To output the 'intellisense' XML commentary to an XML within the project you can specify
//in the project's properties dialogue, an output location for the XML file.  The setting can be
//found in the 'Build' section of project's properties dialogue.
namespace PracticePayProjectSANT
{
    internal class Program
    {
        static void Main()
        {
            //Import the pay records
            List<PayRecord> records = CsvImporter.ImportPayrecords("employee-payroll-data");


            //We'll generate a pseudo ish unique file name using the .Ticks property of the DateTime class.
            string exportedFileName = $"{DateTime.Now.Ticks}-records";

            //Call the PayRrecordWriter class's .Write() method to write the records.
            PayRecordWriter.Write(exportedFileName, records, true);

            //Hold the console in place.
            Console.ReadLine();                       

        }
    }
}
