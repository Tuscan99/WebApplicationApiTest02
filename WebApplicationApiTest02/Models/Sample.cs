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

            if (!context.r_currency.Any())
            {
                DateOnly testdate = new DateOnly(2001, 01, 01);
                context.r_currency.AddRange(
                    new Currency { Title = "Test1", Code = "CR1", Value = 20.012M, A_Date = testdate }
                );

                context.SaveChanges();
            }
        }
    }
}
