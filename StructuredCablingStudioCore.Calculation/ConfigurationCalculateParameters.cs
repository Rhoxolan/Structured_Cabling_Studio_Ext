﻿using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudioCore.Calculation
{
    /// <summary>
    /// Presents parameters of structured cabling configuration calculating
    /// </summary>
    public class ConfigurationCalculateParameters
    {
        private ConfigurationCalculateContext configurationCalculateContext;

        public ConfigurationCalculateParameters()
        {
            configurationCalculateContext = new();
        }

        /// <summary>
        /// Calculating of structured cabling configuration
        /// </summary>
        /// <exception cref="StructuredCablingStudioCoreException"></exception>
        public CablingConfiguration Calculate(StructuredCablingStudioParameters parameters, DateTime recordTime, double minPermanentLink, double maxPermanentLink,
            int numberOfWorkplaces, int numberOfPorts)
            => configurationCalculateContext.Calculate(parameters, recordTime, minPermanentLink, maxPermanentLink, numberOfWorkplaces, numberOfPorts);

		/// <summary>
		/// Value of the cable hank meterage
		/// </summary>
		public int? CableHankMeterage
        {
            get => configurationCalculateContext.CableHankMeterage;
            set => configurationCalculateContext.CableHankMeterage = value;
        }

		/// <summary>
		/// Set and get of the value of 1 hank cable meterage consider when structured cabling configuration calculates
		/// </summary>
		public bool? IsCableHankMeterageAvailability
        {
			get => configurationCalculateContext.IsCableHankMeterageAvailability;
			set => configurationCalculateContext.IsCableHankMeterageAvailability = value;
		}
    }
}
