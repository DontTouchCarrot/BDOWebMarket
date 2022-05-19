using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOWebMarket.Data
{
    public class MarketCondition
    {
        public int sellCount { get; set; }
        public int buyCount { get; set; }
        public int pricePerOne { get; set; }
    }
    public class SellItemInfo : Result
    {
        public List<int> priceList { get; set; }
        public List<MarketCondition> marketConditionList { get; set; }
        public int basePrice { get; set; }
        public int enchantGroup { get; set; }
        public int enchantMaxGroup { get; set; }
        public int enchantMaterialKey { get; set; }
        public int enchantMaterialPrice { get; set; }
        public int enchantNeedCount { get; set; }
        public int maxRegisterForWorldMarket { get; set; }
        public int countValue { get; set; }
        public int sellMaxCount { get; set; }
        public int buyMaxCount { get; set; }
        public bool isWaitItem { get; set; }

    }
}
