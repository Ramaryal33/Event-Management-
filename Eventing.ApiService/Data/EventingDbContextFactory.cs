using Eventing.ApiService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Eventing.ApiService.Data
{
    public class EventingDbContextFactory : IDesignTimeDbContextFactory<EventingDbContext>
    {
        public EventingDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<EventingDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new EventingDbContext(optionsBuilder.Options);
        }
    }
}
