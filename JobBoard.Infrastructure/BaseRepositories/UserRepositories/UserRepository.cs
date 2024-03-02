using JobBoard.Application.Services;
using JobBoard.Domain.Entities.Models;
using JobBoard.Infrastructure.Persistence;

namespace JobBoard.Infrastructure.BaseRepositories.UserRepositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(JobBoardDbContext context) : base(context)
    {
    }
}