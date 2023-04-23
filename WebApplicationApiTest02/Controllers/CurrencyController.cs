using Microsoft.AspNetCore.Mvc;
using WebApplicationApiTest02.Models;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplicationApiTest02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private ICurrencyRepository repository;
        public CurrencyController(ICurrencyRepository _repository)
        {
            repository = _repository;
        }
        IEnumerable<Currency> emptyResult = new List<Currency>();

        //Method 1 : Saving parsing result        
        [HttpGet("save/{date}")]
        public JsonResult Get(string date)
        {
            string urlPart1 = "https://nationalbank.kz/rss/get_rates.cfm?fdate=";
            string urlPart2 = date;
            string url = urlPart1 + urlPart2;

            //string urlSample = "https://nationalbank.kz/rss/get_rates.cfm?fdate=23.02.2023";

            List<Currency> currencyList = new List<Currency>();

            JsonResult emptyJsonResult = new (new {});
            int numOfIns = 0;
            
            DateOnly adate = new DateOnly();
            IFormatProvider formatProvider = new NumberFormatInfo { NumberDecimalSeparator = "." };
            DateOnly dateChecked2 = new DateOnly();
            bool parseDateIsSuccessful = DateOnly.TryParse(date, out dateChecked2);

            if (parseDateIsSuccessful)
            {
                XmlDocument xmlDoc = new XmlDocument();
                try
                {
                    xmlDoc.Load(url);
                }
                catch
                {
                    //return View("Unavailable");
                    return emptyJsonResult;
                }

                XmlElement doc = xmlDoc.DocumentElement;

                if (doc != null)
                {
                    numOfIns = 0;
                    foreach (XmlElement xel in doc)
                    {
                        if (xel.Name == "date")
                        {
                            //adate = DateOnly.Parse(xel.InnerText, formatProvider);
                            adate = DateOnly.Parse(xel.InnerText);
                        }

                        if (xel.Name == "item")
                        {
                            Currency currency = new Currency();
                            currency.A_Date = adate;

                            foreach (XmlNode xcn in xel.ChildNodes)
                            {
                                if (xcn.Name == "fullname")
                                {
                                    currency.Title = xcn.InnerText;
                                }
                                if (xcn.Name == "title")
                                {
                                    currency.Code = xcn.InnerText;
                                }
                                if (xcn.Name == "description")
                                {
                                    currency.Value = Decimal.Parse(xcn.InnerText, formatProvider);
                                }

                                
                            }
                            repository.SaveItem(currency);
                            numOfIns++;
                        }
                    }
                    return new (new numOfInsertions { count = numOfIns });
                }
                return emptyJsonResult;
            }
            return emptyJsonResult;
        }
        

        //Method 2 : Receiving data from database
        [HttpGet("{date}/{code?}")]
        public IEnumerable<Currency> Get(string date, string? code=null)
        {
            DateOnly dateChecked2 = new DateOnly();
            bool parseDateIsSuccessful = DateOnly.TryParse(date, out dateChecked2);

            if(parseDateIsSuccessful)
            {
                if (code == null)
                {
                    try
                    {
                        return repository.r_currency.Where(cur => cur.A_Date == dateChecked2).ToList();
                        //throw new Exception();
                        //return null;
                    }
                    catch
                    {
                        return emptyResult;
                    }
                }
                else
                {
                    try
                    {
                        return repository.r_currency.Where(cur => (cur.A_Date == dateChecked2) && (cur.Code == code)).ToList();
                    }
                    catch
                    {
                        return emptyResult;
                    }
                }
            }

            return emptyResult;
        }
    }
}