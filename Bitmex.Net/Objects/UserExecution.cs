using Bitmex.Net.Client.Converters;
using Newtonsoft.Json;

namespace Bitmex.Net.Client.Objects
{
    /// <summary>UserExecutionHistory</summary>
    public class UserExecution
    {
        [JsonProperty("account")]
        public int? Account { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("timestamp")]
        public System.DateTime? Timestamp { get; set; }

        [JsonProperty("execID", Required = Required.Always)]
        public string ExecID { get; set; }

        [JsonProperty("orderID")]
        public string OrderID { get; set; }

        [JsonProperty("clOrdID")]
        public string ClOrdID { get; set; }

        [JsonProperty("side"), JsonConverter(typeof(BitmexOrderSideConverter))]
        public BitmexOrderSide Side { get; set; }

        [JsonProperty("lastQty")]
        public decimal? LastQty { get; set; }

        [JsonProperty("lastPx")]
        public decimal? LastPx { get; set; }

        [JsonProperty("orderQty")]
        public decimal? OrderQty { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        [JsonProperty("execType")]
        public string ExecType { get; set; }

        [JsonProperty("ordType")]
        public string OrdType { get; set; }

        [JsonProperty("leavesQty")]
        public decimal? LeavesQty { get; set; }

        [JsonProperty("commission")]
        public decimal? Commission { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("trdMatchID")]
        public string TrdMatchID { get; set; }

        [JsonProperty("execCost")]
        public decimal? ExecCost { get; set; }

        [JsonProperty("execComm")]
        public decimal? ExecComm { get; set; }

        [JsonProperty("transactTime")]
        public System.DateTime? TransactTime { get; set; }

        [JsonProperty("execGrossPnl")]
        public decimal? ExecGrossPnl { get; set; }

        [JsonProperty("currentQty")]
        public decimal? CurrentQty { get; set; }

        [JsonProperty("avgEntryPrice")]
        public decimal? AvgEntryPrice { get; set; }

        [JsonProperty("realisedPnl")]
        public decimal? RealizedPNL { get; set; }

        [JsonProperty("unrealisedPnl")]
        public decimal? UnrealisedPnl { get; set; }
    }
}

