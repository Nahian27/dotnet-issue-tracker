using dotnet_issue_tracker.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace dotnet_issue_tracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection"));
            dataSourceBuilder.UseNodaTime();
            var dataSource = dataSourceBuilder.Build();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dataSource, o => o.UseNodaTime()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
