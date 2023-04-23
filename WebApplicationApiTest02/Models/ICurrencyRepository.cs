using System.Collections.Generic;

namespace WebApplicationApiTest02.Models
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> r_currency { get; }
        //Currency currency (int id);
        void SaveItem(Currency currency);
    }
}
