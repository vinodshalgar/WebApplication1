using AAG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAG.Repository
{
    public interface ISecurityRepository
    {
        Security GetSecurity(string symbol);
        List<TickerQuote> GetSecurityTickerQuotes();
        OperationStatus UpdateSecurities();
    }
}
