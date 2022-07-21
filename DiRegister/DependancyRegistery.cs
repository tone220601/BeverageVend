using BeverageVend.Data;
using Blazored.Toast;

namespace BeverageVend.DiRegister
{
    public static class DependancyRegistery
    {
        public static IServiceCollection AddDI_Services(this IServiceCollection services)
        {
            services.AddBlazoredToast();
            services.AddScoped<Vend>();
            return services;
        }
    }
}
