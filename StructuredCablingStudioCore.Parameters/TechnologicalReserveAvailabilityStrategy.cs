﻿using static StructuredCablingStudioCore.Parameters.Properties.Resources;
using static System.Convert;
using static System.Globalization.CultureInfo;

namespace StructuredCablingStudioCore.Parameters
{
    //Encapsulates in ValueContext class

    /// <summary>
    /// Class for work with technological reserve coefficient value, if it availability is enabled
    /// </summary>
    internal class TechnologicalReserveAvailabilityStrategy : ITechnologicalReserveStrategy
    {
        private double? technologicalReserve;

        public TechnologicalReserveAvailabilityStrategy()
        {
            technologicalReserve = null;
        }

        /// <summary>
        /// Value of technological reserve coefficient
        /// </summary>
        public double TechnologicalReserve
        {
            get
            {
                if (technologicalReserve != null)
                {
                    return (double)technologicalReserve;
                }
                else
                {
                    technologicalReserve = ToDouble(TechnologicalReserveAvailability_TechnologicalReserve_Default, InvariantCulture);
                    return (double)technologicalReserve;
                }
            }
            set
            {
                technologicalReserve = value;
            }
        }
    }
}