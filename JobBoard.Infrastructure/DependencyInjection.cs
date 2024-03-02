using JobBoard.Application.Services;
using JobBoard.Infrastructure.BaseRepositories.UserRepositories;
using JobBoard.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobBoard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration conf)
    {
        services.AddDbContext<JobBoardDbContext>(options =>
        {
            options.UseNpgsql(conf.GetConnectionString("FutureProjectsConnectionString"));
        });
        
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
        return services;
    }
}