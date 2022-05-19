﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOWebMarket.Data
{
    public class HotItem
    {
        public int subtype { get; set; }
        public int pricePerOne { get; set; }
        public int totalTradeCount { get; set; }
        public int fluctuationType { get; set; }
        public int fluctuationPrice { get; set; }
        public int keyType { get; set; }
        public int mainKey { get; set; }
        public int subKey { get; set; }
        public int count { get; set; }
        public string name { get; set; }
        public int grade { get; set; }
        public int mainCategory { get; set; }
        public int subCategory { get; set; }
        public int chooseKey { get; set; }
    }
    internal class HotList : Result
    {
        public List<HotItem> hotList { get; set; }
    }
}
