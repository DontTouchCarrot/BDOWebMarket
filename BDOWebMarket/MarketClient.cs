using BDOWebMarket.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BDOWebMarket
{
    public class MarketClient : IDisposable
    {
        private readonly static IReadOnlyDictionary<string, string> _regions = new Dictionary<string, string>()
        {
            { "na","https://na-trade.naeu.playblackdesert.com" },
            { "eu","https://eu-trade.naeu.playblackdesert.com" },
            { "sea","https://menua-trade.sea.playblackdesert.com" },
            { "mena","https://mena-trade.tr.playblackdesert.com" },
            { "kr","https://kr-trade.kr.playblackdesert.com" },
            { "ru","https://ru-trade.ru.playblackdesert.com" },
            { "jp","https://jp-trade.jp.playblackdesert.com" },
            { "tw","https://tw-trade.tw.playblackdesert.com" },
            { "sa","https://blackdesert-tradeweb.playredfox.com" },
            { "console_eu", "https://eu-trade.console.playblackdesert.com" },
            { "console_na", "https://eu-trade.console.playblackdesert.com" },
            { "console_asia", "https://asia-trade.console.playblackdesert.com" },
        };
        private const string TRADE_AUTH_SESSION = "TradeAuth_Session";
        private const string REQUEST_VERIFICATION = "__RequestVerificationToken";
        private readonly string _QUERY_REQUEST_VERFICATION_TOKEN = "";
        private readonly string _region;
        private readonly HttpClient _httpClient = new HttpClient();
        public MarketClient(string COOKIE_TRADE_AUTH,
            string COOKIE_REQUEST_VERIFICATION_TOKEN,
            string QUERY_REQUEST_VERFICATION_TOKEN,
            string region)
        {

            _QUERY_REQUEST_VERFICATION_TOKEN = QUERY_REQUEST_VERFICATION_TOKEN;
            _region = region;
            _httpClient.DefaultRequestHeaders.Add("Cookie", $"{TRADE_AUTH_SESSION}={COOKIE_TRADE_AUTH}; {REQUEST_VERIFICATION}={COOKIE_REQUEST_VERIFICATION_TOKEN}");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.45 Safari/537.36");

        }
        public async ValueTask<WaitItems?> GetWaitItemsAsync()
        {
            var url = _regions[_region] + "/Home/GetWorldMarketWaitList";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);

            var response = await _httpClient.SendAsync(httpRequestMessage);
            using var contentStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<WaitItems>(contentStream);
            if (result != null && result.resultCode != 0) throw new PAException(result);
            return result;
        }
        public  WaitItems? GetWaitItems()
        {
            string url = _regions[_region] + "/Home/GetWorldMarketWaitList";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);

            var response =  _httpClient.Send(httpRequestMessage);
            var contentStream = response.Content.ReadAsStream();
            var result = JsonSerializer.Deserialize<WaitItems>(contentStream);
            if (result != null && result.resultCode != 0) throw new PAException(result);
            return result;
        }
        public async ValueTask<SellItemInfo?> GetSellItemInfoAsync(int mainKey, int subKey)
        {

            string url = _regions[_region] + "/Home/GetItemSellBuyInfo";
            Dictionary<string, string> searchParams = new Dictionary<string, string>()
            {
                { REQUEST_VERIFICATION,_QUERY_REQUEST_VERFICATION_TOKEN },
                { "keyType","0" },
                { "mainKey",mainKey.ToString() },
                { "subKey",subKey.ToString() },
                { "isUp","true"}
            };
            using (var content = new FormUrlEncodedContent(searchParams))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                var contentStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<SellItemInfo>(contentStream);

                if (result != null && result.resultCode != 0) throw new PAException(result);
                return result;

            }
         
        }
        public SellItemInfo? GetSellItemInfo(int mainKey, int subKey)
        {

            string url = _regions[_region] + "/Home/GetItemSellBuyInfo";
            Dictionary<string, string> searchParams = new Dictionary<string, string>()
            {
                { REQUEST_VERIFICATION,_QUERY_REQUEST_VERFICATION_TOKEN },
                { "keyType","0" },
                { "mainKey",mainKey.ToString() },
                { "subKey",subKey.ToString() },
                { "isUp","true"}
            };
            using (var content = new FormUrlEncodedContent(searchParams))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var reqMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };
                HttpResponseMessage response =  _httpClient.Send(reqMessage);
                var contentStream =  response.Content.ReadAsStream();
                var result = JsonSerializer.Deserialize<SellItemInfo>(contentStream);
                if (result != null && result.resultCode != 0) throw new PAException(result);
                return result;

            }

        }
        public async ValueTask<SearchList?> GetWorldMarketSearchListAsync(string search)
        {
            string url = _regions[_region] + "/Home/GetWorldMarketSearchList";
            Dictionary<string, string> searchParams = new Dictionary<string, string>()
            {
                { REQUEST_VERIFICATION,_QUERY_REQUEST_VERFICATION_TOKEN },
                { "searchText", search },       
            };
            using (var content = new FormUrlEncodedContent(searchParams))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                var contentStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<SearchList>(contentStream);
                if (result != null && result.resultCode != 0) throw new PAException(result);
                return result;
            }
        }
        public SearchList? GetWorldMarketSearchList(string search)
        {
            string url = _regions[_region] + "/Home/GetWorldMarketSearchList";
            Dictionary<string, string> searchParams = new Dictionary<string, string>()
            {
                { REQUEST_VERIFICATION,_QUERY_REQUEST_VERFICATION_TOKEN },
                { "searchText", search },
            };
            using (var content = new FormUrlEncodedContent(searchParams))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var reqMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };
                HttpResponseMessage response = _httpClient.Send(reqMessage);
                var contentStream =  response.Content.ReadAsStream();
                var result = JsonSerializer.Deserialize<SearchList>(contentStream);
                if (result != null && result.resultCode != 0) throw new PAException(result);
                return result;
            }
        }
        public async ValueTask<SubList?> GetWorldMarketSubListAsync(int mainKey)
        {
            var url = _regions[_region] + "/Home/GetWorldMarketSubList";
            Dictionary<string, string> searchParams = new Dictionary<string, string>()
            {
                { REQUEST_VERIFICATION,_QUERY_REQUEST_VERFICATION_TOKEN },
                { "mainKey",mainKey.ToString() },
                { "usingCleint","0"}
            };
            using (var content = new FormUrlEncodedContent(searchParams))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                var contentStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<SubList>(contentStream);
                if (result != null && result.resultCode != 0) throw new PAException(result);
                return result;

            }
        }
        public SubList? GetWorldMarketSubList(int mainKey)
        {
            string url = _regions[_region] + "/Home/GetWorldMarketSubList";
            Dictionary<string, string> searchParams = new Dictionary<string, string>()
            {
                { REQUEST_VERIFICATION,_QUERY_REQUEST_VERFICATION_TOKEN },
                { "mainKey",mainKey.ToString() },
                { "usingCleint","0"}
            };
            using (var content = new FormUrlEncodedContent(searchParams))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var reqMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                HttpResponseMessage response =  _httpClient.Send(reqMessage);
                var contentStream = response.Content.ReadAsStream();
                var result = JsonSerializer.Deserialize<SubList>(contentStream);
                if(result!=null && result.resultCode!=0) throw new PAException(result);
                return result;

            }
        }
        public async ValueTask<MarketList?> GetWorldMarketListAsync(int mainCategory,int subCategory = 1)
        {

            var url = _regions[_region] + "/Home/GetWorldMarketSubList";
            Dictionary<string, string> searchParams = new Dictionary<string, string>()
            {
                { REQUEST_VERIFICATION,_QUERY_REQUEST_VERFICATION_TOKEN },
                { "mainCategory", mainCategory.ToString() },
                { "subCategory",subCategory.ToString()}
            };
            using (var content = new FormUrlEncodedContent(searchParams))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                var contentStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<MarketList>(contentStream);
                if (result != null && result.resultCode != 0) throw new PAException(result);
                return result;
            }
        }
        public MarketList? GetWorldMarketList(int mainCategory, int subCategory = 1)
        {

            var url = _regions[_region] + "/Home/GetWorldMarketSubList";
            Dictionary<string, string> searchParams = new Dictionary<string, string>()
            {
                { REQUEST_VERIFICATION,_QUERY_REQUEST_VERFICATION_TOKEN },
                { "mainCategory", mainCategory.ToString() },
                { "subCategory",subCategory.ToString()}
            };
            using (var content = new FormUrlEncodedContent(searchParams))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var reqMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                HttpResponseMessage response = _httpClient.Send(reqMessage);
                var contentStream =  response.Content.ReadAsStream();
                var result =  JsonSerializer.Deserialize<MarketList>(contentStream);
                if (result != null && result.resultCode != 0) throw new PAException(result);
                return result;
            }
        }

        public void Dispose()
        {
           _httpClient.Dispose();
        }

        public class PAException : Exception
        {
            public int ResultCode => _resultCode;
            private int _resultCode;
            public PAException(Result result) : base(result.resultMsg) => _resultCode = result.resultCode;
        }
    }
}
