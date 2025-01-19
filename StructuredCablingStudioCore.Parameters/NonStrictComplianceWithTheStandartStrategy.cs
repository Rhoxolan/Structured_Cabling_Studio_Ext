﻿using static StructuredCablingStudioCore.Parameters.Properties.Resources;
using static System.Convert;
using static System.Globalization.CultureInfo;

namespace StructuredCablingStudioCore.Parameters
{
    //Encapsulates in DiapasonContext

    /// <summary>
    /// Class for determine of calculate structured cabling configuration input parameters diapasons if compliance with ISO/IEC 11801 standard is not strict
    /// </summary>
    internal class NonStrictComplianceWithTheStandartStrategy : IStrictComplianceWithTheStandartStrategy
    {
        private (decimal Min, decimal Max) minPermanentLinkDiapason;
        private (decimal Min, decimal Max) maxPermanentLinkDiapason;

        public NonStrictComplianceWithTheStandartStrategy()
        {
			minPermanentLinkDiapason = (ToDecimal(NonStrictComplianceWithTheStandart_MinPermanentLinkDiapason_Min, InvariantCulture), 
                ToDecimal(NonStrictComplianceWithTheStandart_MinPermanentLinkDiapason_Max, InvariantCulture));
            maxPermanentLinkDiapason = (ToDecimal(NonStrictComplianceWithTheStandart_MaxPermanentLinkDiapason_Min, InvariantCulture),
                ToDecimal(NonStrictComplianceWithTheStandart_MaxPermanentLinkDiapason_Max, InvariantCulture));
        }

        /// <summary>
        /// Determines the diapason of minimal permanent link length input values if compliance with ISO/IEC 11801 standard is not strict
        /// </summary>
        public (decimal Min, decimal Max) MinPermanentLinkDiapason
        {
            get => minPermanentLinkDiapason;
        }

        /// <summary>
        /// Determines the diapason of maximal permanent link length input values if compliance with ISO/IEC 11801 standard is not strict
        /// </summary>
        public (decimal Min, decimal Max) MaxPermanentLinkDiapason
        {
            get => maxPermanentLinkDiapason;
        }
    }
}
