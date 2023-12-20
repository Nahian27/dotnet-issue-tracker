using dotnet_issue_tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_issue_tracker.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Issue> Issues { get; set; }

    }
}
