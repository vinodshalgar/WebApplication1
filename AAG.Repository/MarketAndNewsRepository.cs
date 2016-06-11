using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAG.Model;
using System.Configuration;
using AAG.Repository.Helpers;

namespace AAG.Repository
{
    public class MarketAndNewsRepository : RepositoryBase<AccountAtAGlance>, IMarketsAndNewsRepository
    {
        bool localDataOnly = Boolean.Parse(ConfigurationManager.AppSettings["LocalDataOnly"]);
        string[] _MarketIndexSymbols = new string[] {".DJI",".IXIC",".INX" };

        public List<string> GetMarketNews()
        {
            throw new NotImplementedException();
        }

        public MarketQuotes GetMarkets()
        {
            List<MarketIndex> markets = null;
            if(localDataOnly)
            {
                using (DataContext)
                {
                    markets = DataContext.MarketIndexes.ToList();
                }
            }
            else
            {
                var engine = new StockEngine();
                markets = engine.GetMarketQuotes(_MarketIndexSymbols);
            }
            return BuildMarketQuotes(markets);
        }

        private MarketQuotes BuildMarketQuotes(List<MarketIndex> markets)
        {
            throw new NotImplementedException();
        }

        public List<TickerQuote> GetMarketTickerQuotes()
        {
            throw new NotImplementedException();
        }
    }
}
