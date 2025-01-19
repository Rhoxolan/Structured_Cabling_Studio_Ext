﻿using static StructuredCablingStudioCore.Parameters.Properties.Resources;
using static System.Convert;
using static System.Globalization.CultureInfo;

namespace StructuredCablingStudioCore.Parameters
{
    //Encapsulates in DiapasonContext class

    /// <summary>
    /// Class for determination of allowable ports count input value at ISO/IEC 11801 standard compliance
    /// </summary>
    internal class NotAnArbitraryNumberOfPortsStrategy : IAnArbitraryNumberOfPortsStrategy
    {
        private (decimal Min, decimal Max) numberOfPortsDiapason;

        public NotAnArbitraryNumberOfPortsStrategy()
        {
            numberOfPortsDiapason = (ToDecimal(NotAnArbitraryNumberOfPorts_NumberOfPortsDiapason_Min, InvariantCulture),
                ToDecimal(NotAnArbitraryNumberOfPorts_NumberOfPortsDiapason_Max, InvariantCulture));
        }

        /// <summary>
        /// Determines of allowable ports count input value at ISO/IEC 11801 standard compliance
        /// </summary>
        public (decimal Min, decimal Max) NumberOfPortsDiapason
        {
            get => numberOfPortsDiapason;
        }
    }
}
