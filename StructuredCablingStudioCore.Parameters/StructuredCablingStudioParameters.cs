﻿namespace StructuredCablingStudioCore.Parameters
{
    /// <summary>
    /// Class which presents access to configurable parameters of structured cabling configurations input values, for other application classes.
    /// </summary>
    public class StructuredCablingStudioParameters
    {
        private DiapasonContext diapasonContext;
        private ValueContext valueContext;
        private RecommendationContext recommendationContext;

        public StructuredCablingStudioParameters()
        {
            diapasonContext = new();
            valueContext = new();
            recommendationContext = new();
        }

        /// <summary>
        /// Input diapasons of structured cabling configuration
        /// </summary>
        public StructuredCablingStudioDiapasons Diapasons
        {
            get => diapasonContext.Diapasons;
        }

        /// <summary>
        /// Cable selection recommendations
        /// </summary>
        public CableSelectionRecommendations CableSelectionRecommendations
        {
            get => recommendationContext.CableSelectionRecommendations;
        }

        /// <summary>
        /// Technological reserve coefficient value
        /// </summary>
        public double TechnologicalReserve
        {
            get => valueContext.TechnologicalReserve;
            set => valueContext.TechnologicalReserve = value;
        }

        /// <summary>
        /// Arguments for getting of cable selection recommendations
        /// </summary>
        public RecommendationsArguments RecommendationsArguments
        {
            get => recommendationContext.RecommendationsArguments;
        }

        /// <summary>
        /// Enabled or disabled getting cable selection recommendations
        /// </summary>
        public bool? IsRecommendationsAvailability
        {
            get => recommendationContext.IsRecommendationsAvailability;
            set => recommendationContext.IsRecommendationsAvailability = value;
        }

        /// <summary>
        /// Allowed or not to enter values according to ISO/IEC 11801
        /// </summary>
        public bool? IsStrictComplianceWithTheStandart
        {
            get => diapasonContext.IsStrictСomplianceWithTheStandart;
            set => diapasonContext.IsStrictСomplianceWithTheStandart = value;
        }

        /// <summary>
        /// Allowed or not to enter values of ports count per 1 workplace
        /// </summary>
        public bool? IsAnArbitraryNumberOfPorts
        {
            get => diapasonContext.IsAnArbitraryNumberOfPorts;
            set => diapasonContext.IsAnArbitraryNumberOfPorts = value;
        }

        /// <summary>
        /// Is technological reserve coefficient value availability enabled or disabled
        /// </summary>
        public bool? IsTechnologicalReserveAvailability
        {
            get => valueContext.IsTechnologicalReserveAvailability;
            set => valueContext.IsTechnologicalReserveAvailability = value;
        }
    }
}