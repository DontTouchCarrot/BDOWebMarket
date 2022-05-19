using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOWebMarket.Data
{

    public class WaitItem
    {
        public ulong PricePerOne { get; set; }
        public ulong WaitEndTime { get; set; }
        public int KeyType { get; set; }
        public int MainKey { get; set; }
        public int SubKey { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int MainCategory { get; set; }
        public int SubCategory { get; set; }
        public int ChooseKey { get; set; }
    }
    public class WaitItems : Result
    {
        public List<WaitItem> WaitList { get; set; }
      
    }
}
