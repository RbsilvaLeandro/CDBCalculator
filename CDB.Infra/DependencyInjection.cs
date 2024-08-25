using CDB.Services.Interfaces;
using CDB.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CDB.Infra;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICalculationService, CalculationService>();
    }
}