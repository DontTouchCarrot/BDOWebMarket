using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOWebMarket.Data
{
    public class Item
    {
        public int mainKey { get; set; }
        public int sumCount { get; set; }
        public int totalSumCount { get; set; }
        public string name { get; set; }
        public int grade { get; set; }
    }
    public class SearchList : Result
    {
        public List<Item> list { get; set; }
    }
}
