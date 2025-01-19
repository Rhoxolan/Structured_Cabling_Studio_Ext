using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.AutoMapperProfiles;
using StructuredCablingStudio.Binders.CalculationBinders;
using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;
using StructuredCablingStudio.Filters.CalculationFilters;
using StructuredCablingStudio.Services.FileLoggerService;
using StructuredCablingStudio.Services.SaveToTXTService;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(opt =>
{
	opt.ModelBinderProviders.Insert(0, new StructuredCablingStudioParametersModelBinderProvider());
	opt.ModelBinderProviders.Insert(0, new ConfigurationCalculateParametersModelBinderProvider());
	opt.ModelBinderProviders.Insert(0, new CalculateDTOModelBinderProvider());
})
	.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
	.AddDataAnnotationsLocalization();

builder.Services.AddIdentity<User, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddTransient<ISaveToTXTService, SaveToTXTService>()
	.AddSingleton<IFileLoggerService, FileLoggerService>()
	.AddAutoMapper(typeof(StructuredCablingParametersToStructuredCablingStudioParametersProfile),
	typeof(StructuredCablingStudioParametersToCalculateViewModelProfile),
	typeof(CalculateViewModelToStructuredCablingParametersProfile),
	typeof(CalculateParametersToConfigurationCalculateParametersProfile),
	typeof(CalculateViewModelToConfigurationCalculateParameters),
	typeof(CablingConfigurationToCablingConfigurationEntityProfile),
	typeof(CalculateDTOToCalculateViewModelProfile))
	.AddScoped<StructuredCablingStudioParametersResultFilter>()
	.AddScoped<ConfigurationCalculateParametersResultFilter>()
	.AddScoped<DiapasonActionFilter>()
	.AddScoped<CalculateDTOResultFilter>()
	.AddDbContext<ApplicationContext>(opt
	=> opt.UseSqlServer(builder.Configuration.GetConnectionString("CablingConfigurationsDB")))
	.AddLocalization(opt => opt.ResourcesPath = "Resources")
	.Configure<RequestLocalizationOptions>(opt =>
	{
		var supportedCultures = new[]
		{
			new CultureInfo("ru"),
			new CultureInfo("en"),
			new CultureInfo("uk")
		};
		opt.DefaultRequestCulture = new RequestCulture("en");
		opt.SupportedCultures = supportedCultures;
		opt.SupportedUICultures = supportedCultures;
	})
	.ConfigureApplicationCookie(opt =>
	{
		opt.LoginPath = "/Account/SignIn";
		opt.ReturnUrlParameter = "returnUrl";
	})
	.AddSession()
	.AddAuthentication()
	.AddGoogle(opt =>
	{
		var googleSection = builder.Configuration.GetSection("Authentication:Google");
		opt.ClientId = googleSection["ClientId"]!;
		opt.ClientSecret = googleSection["ClientSecret"]!;
	});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
}
app.UseHttpsRedirection();
app.UseRequestLocalization();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Calculation}/{action=Calculate}/{id?}");

app.Run();
