using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOWebMarket.Data
{

    public class MarketItem
    {
        public int mainKey { get; set; }
        public int sumCount { get; set; }
        public string name { get; set; }
        public int grade { get; set; }
        public long minPrice { get; set; }
    }

    public class MarketList :Result
    {
        public List<MarketItem> marketList { get; set; }

    }
}
