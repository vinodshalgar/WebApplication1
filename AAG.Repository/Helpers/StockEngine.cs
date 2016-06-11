using System;
using System.Collections.Generic;
using AAG.Model;
using System.Xml.Linq;

namespace AAG.Repository.Helpers
{
    internal class StockEngine
    {
        private const string BASE_URL = "";
        private readonly string _Separator = "&stock=";

        public StockEngine()
        {
        }
        public List<Security> GetSecurityQuotes(params string[] symbols)
        {
            XDocument doc = CreateXDocument(symbols);
            return ParseSecurities(doc);

        }

        private List<Security> ParseSecurities(XDocument doc)
        {
            if (doc == null)
                return null;

            List<Security> securities = new List<Security>();
            IEnumerable<XElement> quotes = doc.Root.Descendants("finance");
            foreach (var quote in quotes)
            {
                var symbol = GetAttributeData(quote, "symbol");
                var exchange = GetAttributeData(quote, "exchange");
                var last = GetDecimal(quote, "last");
                var change = GetDecimal(quote, "change");
                var percentChange = GetDecimal(quote, "perc_change");
                var company = GetAttributeData(quote, "company");

                if(exchange.ToUpper()=="MUTF")
                {
                    var mf = new MutualFund();
                    mf.Symbol = symbol;
                    mf.Symbol = symbol;
                    mf.Last = last;
                    mf.Change = change;
                    mf.PercentChange = percentChange;
                    mf.RetrievalDateTime = DateTime.Now;
                    mf.Company = company;

                }
                else
                {

                }
            }

            return securities;
        }

       
        private decimal GetDecimal(XElement quote, string elemName)
        {
            var input = GetAttributeData(quote, elemName);
            if (input == null)
            {
                return 0.00M;
            }
            decimal value;
            if (Decimal.TryParse(input, out value))
            {
                return value;
            }
            return 0.00M;
        }

        private string GetAttributeData(XElement quote, string elemName)
        {
            return quote.Element(elemName).Attribute("data").Value;
        }

        internal List<MarketIndex> GetMarketQuotes(string[] _MarketIndexSymbols)
        {
            throw new NotImplementedException();
        }

        private XDocument CreateXDocument(string[] symbols)
        {
            string symbolList = String.Join(_Separator, symbols);
            string url = string.Concat(BASE_URL, _Separator, symbolList, "&Ticks", DateTime.Now.Ticks);
            try
            {
                XDocument doc = XDocument.Load(url);
                return doc;
            }
            catch { }
            return null;
        }
    }
}