using Microsoft.EntityFrameworkCore;

namespace WebApplicationApiTest02.Models
{
    public class CurrencyDbContext : DbContext
    {
        public CurrencyDbContext(DbContextOptions<CurrencyDbContext> options) : base(options) { }

        public DbSet<Currency> r_currency { get; set; }
    }
}
