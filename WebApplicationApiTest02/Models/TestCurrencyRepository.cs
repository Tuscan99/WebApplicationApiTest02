using System.Collections.Generic;
using System.Linq;

namespace WebApplicationApiTest02.Models
{
    public class TestCurrencyRepository : ICurrencyRepository
    {
        public IEnumerable<Currency> r_currency => new List<Currency>
        {
            new Currency { Title = "Currency1", Code = "CR1", Value = 20.012M, A_Date = new DateOnly(2022, 01, 02) },
            new Currency { Title = "Currency2", Code = "CR2", Value = 20.022M, A_Date = new DateOnly(2023, 01, 02) },
            new Currency { Title = "Currency3", Code = "CR3", Value = 20.032M, A_Date = new DateOnly(2023, 03, 11) },
            new Currency { Title = "Currency4", Code = "CR4", Value = 20.042M, A_Date = new DateOnly(2023, 03, 02) }
        }.AsQueryable<Currency>();

        public void SaveItem(Currency currency)
        {
            r_currency.Append(currency);
        }
    }
}
