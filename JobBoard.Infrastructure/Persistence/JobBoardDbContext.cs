using Microsoft.EntityFrameworkCore;

namespace JobBoard.Infrastructure.Persistence;

public class JobBoardDbContext : DbContext
{
    public JobBoardDbContext(DbContextOptions<JobBoardDbContext> options)
        : base(options)
    {
    }

   public DbSet<JobBoard.Domain.Entities.Models.User> Users { get; set; }
}