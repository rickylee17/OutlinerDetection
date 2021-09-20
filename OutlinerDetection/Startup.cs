using System;
using Microsoft.Extensions.DependencyInjection;
using OutlinerDetection.Infrastructure.Repositories;
using OutlinerDetection.Infrastructure.BusinessLogic;

namespace OutlinerDetection
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();


            services.AddScoped<IRepository, CsvRepository>()
                    .AddScoped<IOutlinerDetectorFactory, OutlinerDectorFactory>()
                    .AddTransient<Start>();

            return services;
        }
    }
}
