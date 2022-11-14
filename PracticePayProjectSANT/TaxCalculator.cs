using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticePayProjectSANT
{
    /// <summary>
    /// Class that calculates the two different Tax calculations as required for either a
    /// an Employee that is a resident, or an Employee that is a Working Holiday Employee.
    /// </summary>
    public class TaxCalculator
    {
        /// <summary>
        /// Static method for determining and returning the tax amount to be withheld for a Resident
        /// employee's pay record.
        /// </summary>
        /// <param name="gross"></param>
        /// <returns>double: The amount of Tax to withhold for a Resident Employee.</returns>
        public static double CalculateResidentialTax(double gross)
        {
            //TODO 2 - Thorough testing of the correctness of this logic is required.
            //The figures used in the following code are derived from, but not exactly
            //the same as "3.1.1 Schedule 1: Tax-free threshold is not claimed by employee"
            switch (gross)
            {
                case double n when (n < 72):
                    return 0.19 * gross - 0.19; //derived from the formula in the above pdf. i.e. y = ax − b
                case double n when (n < 361):
                    return 0.2342 * gross - 3.2130;
                case double n when (n < 932):
                    return 0.3477 * gross - 44.2476;
                case double n when (n < 1380):
                    return 0.3450 * gross - 41.7311;
                case double n when (n < 3111):
                    return 0.3900 * gross - 103.8657;
                default:
                    return 0.4700 * gross - 352.7888;
            }
        }

        /// <summary>
        /// Static method for determining and returning the tax amount withheld for a Working Holiday
        /// Employee's pay record.
        /// </summary>
        /// <param name="gross">double: The gross amount for the employee pay record</param>
        /// <param name="yearToDate">int: The year to date earnings amount for the employee pay record.</param>
        /// <returns>double: The amount of Tax to withhold for a Working Holiday Employee.</returns>
        public static double CalculateWorkingHolidayTax(double gross, int yearToDate)
        {
            if(yearToDate + gross <= 37000)
            {
                return gross * 0.15;
            }
            else if (yearToDate + gross <= 90000)
            {
                return gross * 0.32;
            }
            else if (yearToDate + gross <= 180000)
            {
                return gross * 0.37;
            }
            else
            {
                return gross * 0.45;
            }
        }
    }
}