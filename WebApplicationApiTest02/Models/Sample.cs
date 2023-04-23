using Microsoft.EntityFrameworkCore;

namespace WebApplicationApiTest02.Models
{
    public static class Sample
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CurrencyDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CurrencyDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

        }
    }
}
