using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticePayProjectSANT
{
    /// <summary>
    /// Stores an instance of an employee pay record including hours worked and the pay rates for each
    /// shift as parallel arrays.
    /// </summary>
    public abstract class PayRecord  //When the 'abstract' modifier is we must inherit from the class to use it.
    {
        /// <summary>
        /// Protected fields for the parallel arrays that store the hours and pay rates for each employee shift.
        /// </summary>
        protected double[] _hours, _rates;
        

        /// <summary>
        /// Pay record constructor
        /// </summary>
        /// <param name="id">int: The employee identifier</param>
        /// <param name="hours">double[]: Array of the employee's shift hours worked.</param>
        /// <param name="rates">double[]: Array of the employee's pay rates for the shifts worked.</param>
        public PayRecord(int id, double[] hours, double[] rates)
        {
            this.Id = id;
            this._hours = hours;
            this._rates = rates;
        }

        /// <summary>
        /// Read only property that derives the Employee Gross pay by calculating
        /// the total of hours * rate of all shifts from the parallel arrays.
        /// </summary>
        public double Gross
        {
            get
            {
                double gross = 0;
                for (int i = 0; i < _hours.Length; i++)
                {
                    gross += _hours[i] * _rates[i];
                }
                return gross;
            }

        }

        /// <summary>
        /// Property for storing Employee id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Read only derived property that returns the net payment which is 'Gross - Tax'
        /// </summary>
        public double Net
        {
            get
            {
                return this.Gross - this.Tax;
            }
        }

        /// <summary>
        /// Abstract property that must be overriden by any class that inherits from PayRecord (derived class).
        /// </summary>
        public abstract double Tax { get; }
        
        /// <summary>
        /// Returns details of the PayRecord, including the Employee ID, Gross, Net, and Tax values. This method
        /// is declared as 'virtual' so that it can be overriden by any derived (inheriting) class if necessary.
        /// </summary>
        /// <returns>string: Details of the Pay Record.</returns>
        public virtual string GetDetails()
        {
            string separator = new string('-', 10);
            var builder = new StringBuilder();
            builder.AppendLine($" {separator} EMPLOYEE: {this.Id} {separator}");
            builder.AppendLine($" GROSS:\t {this.Gross:c}");
            builder.AppendLine($" NET:\t {this.Net:c}");
            builder.AppendLine($" TAX:\t {this.Tax:c}");

            return builder.ToString();
        }
    }
}