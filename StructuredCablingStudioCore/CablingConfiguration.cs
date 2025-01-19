﻿namespace StructuredCablingStudioCore
{
    /// <summary>
    /// Record of structured cabling configuration
    /// </summary>
    public record CablingConfiguration
    {
        /// <summary>
        /// Record time of the structured cabling configuration record
        /// </summary>
        public required DateTime RecordTime { get; init; }

        /// <summary>
        /// Value of permanent link minimum length in the structured cabling configuration record
        /// </summary>
        public required double MinPermanentLink { get; init; }

        /// <summary>
        /// Value of permanent link maximum length in the structured cabling configuration record
        /// </summary>
        public required double MaxPermanentLink { get; init; }

        /// <summary>
        /// Value of permanent link average length in the structured cabling configuration record
        /// </summary>
        public required double AveragePermanentLink { get; init; }

        /// <summary>
        /// Value of workplaces count in the structured cabling configuration record
        /// </summary>
        public required int NumberOfWorkplaces { get; init; }

        /// <summary>
        /// Value of ports count per 1 workplace in the structured cabling configuration record
        /// </summary>
        public required int NumberOfPorts { get; init; }

        /// <summary>
        /// Value of necessary cable meterage for structured cabling installation, in the structured cabling configuration record.
        /// Is present if structured cabling configuration was calculated with cable hank meterage
        /// </summary>
        public double? CableQuantity { get; init; } = null;

        /// <summary>
        /// Value of cable hank meterage in the structured cabling configuration record
        /// Is present if structured cabling configuration was calculated with cable hank meterage
        /// </summary>
        public int? CableHankMeterage { get; init; } = null;

        /// <summary>
        /// Value of cable hank count in the structured cabling configuration record
        /// Is present if structured cabling configuration was calculated with cable hank meterage
        /// </summary>
        public int? HankQuantity { get; init; } = null;

        /// <summary>
        /// Value of the total necessary cable meterage for structured cabling installation, in the structured cabling configuration record.
        /// </summary>
        public required double TotalCableQuantity { get; init; }

		/// <summary>
		/// Recommendations for cable selection in the structured cabling configuration record.
		/// Represents the key "Insulation Type" for the cable insulation type recommendation, the key "Insulation Material" for the cable insulation material recommendation,
        /// the key "Shielding" for the cable shielding type recommendation, and the key "Standard" for the cable standard recommendation
		/// </summary>
		public required Dictionary<string, string> Recommendations { get; init; }
    }
}