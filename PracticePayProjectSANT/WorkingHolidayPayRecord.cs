using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePayProjectSANT
{
    /// <summary>
    /// Specialisation of Payrecord for a Working Holiday Employee
    /// </summary>
    public class WorkingHolidayPayRecord : PayRecord
    {

        #region Field/Member Variables
        /// <summary>
        /// Backing (field) variables for Employee's Visa Category Number and 
        /// Year to Date Earnings.
        /// </summary>
        private int _visa, _yearToDate;
        #endregion Field/Member Variables

        #region Properties (Accessors)
        /// <summary>
        /// Property for the Employee Visa Classification
        /// </summary>
        public int Visa 
        {
            get 
            {
                return _visa;
            }
            private set 
            {
                _visa = value;
            }
        }
        /// <summary>
        /// Property for storing the total gross amount that the Employee has earned
        /// in the current financial year.
        /// </summary>
        public int YearTodate 
        {
            get 
            {
                return _yearToDate;
            }
            private set 
            {
                _yearToDate = value;
            }
        }

        /// <summary>
        /// Property that overrides the Tax property in the base class.
        /// </summary>
        public override double Tax 
        {
            get 
            {
                return TaxCalculator.CalculateWorkingHolidayTax(Gross, YearTodate);
            }
        }
        #endregion Properties (Accessors)

        #region Constructor
        /// <summary>
        /// Constructor, implmeenting additional 'initialisation' requirements in this derived
        /// class (WorkingHolidayPayRecord), Visa and YearToDate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        /// <param name="visa"></param>
        /// <param name="yearToDate"></param>
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates) 
        {
            this.Visa = visa;
            this.YearTodate = yearToDate;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Override of the base class GetDetails() method that additionally inclues the Visa
        /// and Year to Date values.
        /// </summary>
        /// <returns>string: Details of the Working Holiday Employee's Pay Record.</returns>
        public override string GetDetails()
        {
            var builder = new StringBuilder(base.GetDetails());
            builder.AppendLine($" VISA:\t {this.Visa}");
            builder.AppendLine($" YTD:\t {this.YearTodate + this.Gross}");
            return builder.ToString();
        }
        #endregion Public Methods

    }
}
