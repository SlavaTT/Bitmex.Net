using Bitmex.Net.Client.Objects.Requests;
using System;
using System.Text.Json;
using Xunit;
using Bitmex.Net.Client.Helpers.Extensions;
using System.Linq;
using Bitmex.Net.Client.Interfaces;
using Bitmex.Net.Client.Objects;
using Newtonsoft.Json;
using Bitmex.Net.Client.Converters;
using Bitmex.Net.Client.Attributes;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Bitmex.Net.Client.Tests
{
    public class BitmexClientIntegrationTests
    {
        IBitmexMarginClient _client = new BitmexClient().MarginClient;

        /*
        [Fact]
        public void ShouldReturnUserTrades() {
            var trades = _client.GetUserExecutionHistory(
                new BitmexRequestWithFilter() { Symbol = "XBTUSD", Timestamp = DateTime.UtcNow.AddDays(-1) }
                );
            Assert.True(trades);
        }
        */

        [Fact]
        public void ShouldReturnFourLastBuyTrades()
        {
            var trades = _client.GetTradesAsync(new BitmexRequestWithFilter()
                .WithSymbolFilter("XBTUSD")
                .WithSideFilter(BitmexOrderSide.Buy)
                .WithExactDateFilter(new DateTime(2019, 1, 1))
                .WithResultsCount(4)).Result;
            Assert.True(trades);
            Assert.True(trades.Data.Count == 4);
            Assert.True(trades.Data.All(c => c.Side == BitmexOrderSide.Buy && c.Symbol == "XBTUSD"));
        }
        [Fact]
        public void ShouldReturnFourLastTradeBins()
        {
            var tradeBuckets = _client.GetTradesBucketedAsync("1m", true, new BitmexRequestWithFilter()
                .WithSymbolFilter("XBTUSD")
                .WithNewestFirst()
                .WithResultsCount(402)).Result;
            Assert.True(tradeBuckets);
            Assert.True(tradeBuckets.Data.Count == 402);
            Assert.True(tradeBuckets.Data.All(c => c.Symbol == "XBTUSD"&&c.Close    >0));
        }
        [Fact]
        public void ShouldCreateDictionaryFromObject()
        {
            var o = new PlaceOrderRequest("XBTUSD")
            {
                BitmexOrderType = BitmexOrderType.Limit,
                Price = 42,
                Quantity = 10,
                Side = BitmexOrderSide.Buy
            };
            var dic = o.AsDictionary();
            Assert.Equal(5, dic.Count);
        }
        [Fact]
        public void ShouldParseBitmexError()
        {
            string error = "{ \"error\": { \"message\": \"Error message\", \"name\": \"Error name\" } }";
            JToken token = JToken.Parse(error);
            var e = token["error"];
            Assert.NotNull(e);
            Assert.Equal("Error message", e["message"]);
        }
        [Fact]
        public void ShoulThrowError()
        {
            var order = _client.PlaceOrderAsync(new PlaceOrderRequest("745242") { BitmexOrderType = BitmexOrderType.Limit, Price = 22000, Side = BitmexOrderSide.Sell, Quantity = 10 }).Result;
            Assert.False(order);
            Assert.NotNull(order.Error);
        }

        [Fact]
        public void UserExecHistory()
        {
            var options = new BitmexRestOptions("", "", outputOriginalData: true);
            var client = new BitmexClient(options);

            var filter = new BitmexRequestWithFilter() { Symbol = "XBTUSDT", Timestamp = new DateTime(2022, 10, 2, 12, 00, 00, 00)};
            var execHist = client.MarginClient.GetUserExecutionHistoryAsync(filter).Result;
          
            Assert.False(execHist);
            Assert.NotNull(execHist.Error);
        }
    }
}
