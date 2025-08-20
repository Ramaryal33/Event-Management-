using Eventing.ApiService.Data;
using Eventing.ApiService.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Eventing.ApiService.Setup.DbContext;

public static class DbContextExtension
{
    public static void AddXDbContextExtension(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<DbContextOptionsBuilder>(options =>
        {
            if (builder.Environment.IsDevelopment())
            {
                options.EnableDetailedErrors()
                       .EnableSensitiveDataLogging();
            }

            // ✅ Keep seeding logic
            options.UseAsyncSeeding(async (context, _, ct) =>
            {
                await UserSeeder.SeedAsync(context, ct);
                await EventSeeder.SeedAsync(context, ct);
                await RolesSeeder.SeedAsync(context, ct);
            });
        });
    }
}
