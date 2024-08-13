using System.Runtime.CompilerServices;

namespace EmployeeDemographics.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins()
                           .WithMethods("POST", "GET")
                           .WithHeaders("accept", "content-type");
                });
            });
        }
    }

    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {

        });
    
    }
    
}
