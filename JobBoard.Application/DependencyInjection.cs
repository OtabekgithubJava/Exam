using JobBoard.Application.Services.EmailServices;
using Microsoft.Extensions.DependencyInjection;

namespace JobBoard.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}