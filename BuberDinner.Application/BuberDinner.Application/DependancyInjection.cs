using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependancyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssemblies( typeof(DependancyInjection).Assembly));
        return services;
    }
}
