﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.DTOs;
using StructuredCablingStudio.Extensions.ISessionExtension;
using StructuredCablingStudio.Models.ViewModels.CalculationViewModels;
using StructuredCablingStudioCore.Parameters;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
    public class StructuredCablingStudioParametersResultFilter : IResultFilter
    {
        private readonly IMapper _mapper;

        public StructuredCablingStudioParametersResultFilter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var controller = (Controller)context.Controller;
            var model = (CalculateViewModel?)controller.ViewData.Model;
            if (model != null)
            {
                var structuredCablingStudioParameters = _mapper.Map<StructuredCablingStudioParameters>(model);
                controller.ViewData["Diapasons"] = structuredCablingStudioParameters.Diapasons;
                var structuredCablingParameters = _mapper.Map<StructuredCablingParameters>(structuredCablingStudioParameters);
                context.HttpContext.Session.SetStructuredCablingParameters(structuredCablingParameters);
            }
        }
    }
}