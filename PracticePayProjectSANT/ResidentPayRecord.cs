using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticePayProjectSANT
{
    /// <summary>
    /// Specialisation of the PayRecord class for Resident employee pay record.
    /// </summary>
    public class ResidentPayRecord : PayRecord
    {
        /// <summary>
        /// Constructor with parameters matching the base class, all parameters are passed to
        /// the base class constructor.
        /// </summary>
        /// <param name="id">int: The Employee Id</param>
        /// <param name="hours">double[]: Array of hours for employee shifts worked.</param>
        /// <param name="rates">double[]: Array of pay rates for employee shifts worked.</param>
        public ResidentPayRecord(int id, double[] hours, double[] rates) : base(id, hours, rates)
        {
            //Constructor, passes args up to the base class (parent class).
        }
        /// <summary>
        /// Property that overrides the Tax property in the base class. Invokes the
        /// TaxCalculator.CalculatorResidentialTax method to determine the Tax amount for 
        /// the resident employee's current pay record.
        /// </summary>
        public override double Tax
        {
            get
            {                
                
                return TaxCalculator.CalculateResidentialTax(Gross);
            }
        }

    }
}