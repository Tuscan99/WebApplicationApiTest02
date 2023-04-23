using System.Linq;

namespace WebApplicationApiTest02.Models
{
    public class DbCurrencyRepository : ICurrencyRepository
    {
        private CurrencyDbContext context;
        public DbCurrencyRepository(CurrencyDbContext _context) 
        { 
            context = _context;
        }

        public IEnumerable<Currency> r_currency => context.r_currency;

        public void SaveItem(Currency currency)
        {
            context.r_currency.Add(currency);
            context.SaveChanges();
        }
    }
}
