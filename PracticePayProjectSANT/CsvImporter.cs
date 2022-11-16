using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Add the following using directives
using System.IO;

namespace PracticePayProjectSANT
{
    /// <summary>
    /// Class for importing comma delimited data from .csv file and returns a collection of
    /// PayRecord objects. It does this by declaring it two methods, ImportPayRecords()
    /// and CreatePayRecords() as static methods.
    /// </summary>
    public class CsvImporter
    {

        /// <summary>
        /// Imports the data from a csv file specified in the fileName parameter argument.
        /// Reads through each row in the .csv file and builds up a List of <see cref="PayRecord"/> objects.
        /// </summary>
        /// <param name="fileName"><see cref="string"/>The filename of the (comma delimited data values .csv) file to import the records from.</param>
        /// <returns><see cref="List{PayRecord}"/>A new instance of a <see cref="List{Payrecord}"/> object for each pay shift that was imported from the specified comma delimited file.</returns>
        public static List<PayRecord> ImportPayrecords(string fileName) 
        {
            //Instantiate a list for storing the imported record objects.
            List<PayRecord> records = new List<PayRecord>();


            //Open (load into memory buffer) the .csv file from which we are going to read the data. We can do this
            //using a System.IO.StreamReader class.
            //The 'using' keyword/directive is used in two very different ways. At the top of our code, we use it
            //to 'import' class libraries that have been developed previously. The 'using' block however, is a 
            //mechanism of the C# Language that allows us to define a 'scope' within which any classes the IDisposable interface
            //will forceably be disposed when the leave the scoped defined by the 'using' block.
            using (StreamReader stream = new StreamReader(Path.GetFullPath($@"..\..\Import\{fileName}.csv"))) 
            {
                //Read past the first line
                stream.ReadLine();

                //Variables used to store the each of the values read from each line of the shift.
                //We will initialise the id with -1 to indicate it is the first employee.
                int id = -1;
                string visa = string.Empty;
                string yearToDate = string.Empty;

                //Using a List<> here because it has a Very convenient .Add() method.
                List<double> hours = new List<double>();
                List<double> rates = new List<double>();

                //Iterate through each line of the imported .csv file in the loop below is the sentinel variable
                //i.e. the counter variable.
                for (string line = stream.ReadLine(); line != null; line = stream.ReadLine())
                {
                    //Split the line that we've read from the .csv file on the ','
                    string[] columns = line.Split(',');

                    //Check if the record is for an employee other than the first employee in file i.e. id = -1
                    if (int.Parse(columns[0]) != id && id != -1) 
                    {
                        //add a new record  pay record object to the result
                        //by calling the createPayrecord() method
                        records.Add(CreatePayRecord(id, hours.ToArray(), rates.ToArray(), visa, yearToDate));

                        //clear the Lists of hours and rates ready for the next employee.
                        hours.Clear();
                        rates.Clear();
                    }
                    //Extract the id, hours, rates, visa and yearToDate from the .csv file for the current pay object
                    id = int.Parse(columns[0]);
                    hours.Add(double.Parse(columns[1]));
                    rates.Add(double.Parse(columns[2]));
                    visa = columns[3];
                    yearToDate = columns[4];
                }
                //If the id is NOT - 1 at least one record has been read, in tihs case a PayRecord object containing
                //the record(s) for the last Employee in the file to be added to the List<records>
                if (id != -1)
                {
                    records.Add(CreatePayRecord(id, hours.ToArray(), rates.ToArray(), visa, yearToDate));
                }
                
            }

            //return the imported list of PayRecord objects.
            return records;

        }
        /// <summary>
        /// A private static method that is invoked by the ImportPayRecords() method and provides
        /// code re-use for instantiating a new PayRecord object that is added to the <see cref="List{PayRecord}"/>
        /// instance returned by the ImportPayRecords() method.
        /// </summary>
        /// <param name="id"><see cref="int"/>: The id of the Employee for the imported <see cref="PayRecord"/> instance.</param>
        /// <param name="hours"><see cref="T:double[]"/>: The hours of each shift for the Employee of the imported <see cref="PayRecord"/> instance.</param>
        /// <param name="rates"><see cref="T:double[]"/>: The pay rates for the hours worked in the shift for the Employee of the imported <see cref="PayRecord"/> instance.</param>
        /// <param name="visa"><see cref="string"/>: The Visa Category of the Employee. An empty string is passed for Resident Employee</param>
        /// <param name="yearToDate"><see cref="string"/>: The Year To Date earnings of the Working Holiday Employee. An empty string is passed for Resident Employees.</param>
        /// <returns><see cref="PayRecord"/>The PayRecord for the Employee.</returns>
        public static PayRecord CreatePayRecord(int id, double[] hours, double[] rates, string visa, string yearToDate) 
        {
            //Check which type of PayRecord Object to Instantiate, if Visa is an empty string
            //it is residential
            if (string.IsNullOrWhiteSpace(visa))
            {
                //Instantiate and add a new ResidentPayRecord object to the result.
                //return new ResidentPayRecord(id, hours.ToArray(), rates.ToArray());
                return new ResidentPayRecord(id, hours, rates);
            }
            else 
            {
                //Instantiate and add a new WorkingHolidayPayRecord object to the result.
                return new WorkingHolidayPayRecord(id, hours, rates, int.Parse(visa), int.Parse(yearToDate));
            }
        }

    }
}