using dotnet_issue_tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_issue_tracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Issue> Issues { get; set; }

    }
}
