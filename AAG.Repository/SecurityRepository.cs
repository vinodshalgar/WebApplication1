using System;
using System.Collections.Generic;
using AAG.Model;
using System.Configuration;
using System.Linq;
using AAG.Repository.Helpers;

namespace AAG.Repository
{
    public class SecurityRepository : RepositoryBase<AccountAtAGlance>,ISecurityRepository
    {
        bool localDataOnly = Boolean.Parse(ConfigurationManager.AppSettings["LocalDataOnly"]);
        private readonly string[] _StockSymbols = {"AMZN", "BAC", "C", "DIS", "EMC", "FDX", "GE", "H", "INTC", "JPM", "K",
                                                   "LLY", "MSFT", "NKE", "ORCL", "PG", "Q", "RBS", "S", "T", "UL", "V", "WMT",
                                                   "XRX", "YHOO", "ZION", "AAPL", "IBM", "NOK", "CSCO", "FCX", "MTH", "SPF",
                                                   "CRM", "CAT", "LMT", "GD", "XOM", "CVX", "SLB", "BA", "F", "X", "AA",
                                                   "NOC", "RTN","FMAGX", "FDGFX", "FCNTX", "GOOG", "ITRGX", "EBAY", "AOL", "BIDU" };

        public Security GetSecurity(string symbol)
        {
            using (DataContext)
            {
                var sec = DataContext.Securities.SingleOrDefault(s => s.Symbol==symbol);
                if(sec ==null)
                {
                    var engine = new StockEngine();
                    sec = engine.GetSecurityQuotes(symbol).FirstOrDefault();
                    DataContext.Securities.Add(sec);
                    var opStatus = Save(sec);
                    if(!opStatus.Status)
                    {
                        sec = new Stock { Company="Error getting quote."};
                    }
                }
                if(sec is Stock)
                {
                    sec.DataPoints = new DataSimulator().GetDataPoints(sec.Last);
                }
                return sec;
            }
        }        

        public List<TickerQuote> GetSecurityTickerQuotes()
        {
            throw new NotImplementedException();
        }

        public OperationStatus UpdateSecurities()
        {
            throw new NotImplementedException();
        }
    }
}
