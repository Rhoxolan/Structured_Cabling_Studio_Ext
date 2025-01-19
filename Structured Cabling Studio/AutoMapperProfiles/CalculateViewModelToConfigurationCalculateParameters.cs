﻿using AutoMapper;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Calculation;

namespace StructuredCablingStudio.AutoMapperProfiles
{
    public class CalculateViewModelToConfigurationCalculateParameters : Profile
	{
		public CalculateViewModelToConfigurationCalculateParameters()
			=> CreateMap<CalculateViewModel, ConfigurationCalculateParameters>()
			.ForMember(dst => dst.CableHankMeterage, opt =>
			{
				opt.SetMappingOrder(2);
				opt.Condition(src => src.IsCableHankMeterageAvailability);
			});
	}
}
