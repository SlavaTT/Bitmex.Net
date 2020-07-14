﻿using Bitmex.Net.Client.Converters;
using Newtonsoft.Json;

namespace    Bitmex.Net.Client.Objects
{

    /// <summary>Raw Order and Balance Data</summary>

    public class Execution
    {
        [JsonProperty("execID", Required = Required.Always)]

        public string ExecID { get; set; }

        [JsonProperty("orderID")]
        public string OrderID { get; set; }

        [JsonProperty("clOrdID")]
        public string ClOrdID { get; set; }

        [JsonProperty("clOrdLinkID")]
        public string ClOrdLinkID { get; set; }

        [JsonProperty("account")]
        public decimal? Account { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("side"), JsonConverter(typeof(BitmexOrderSideConverter))]
        public BitmexOrderSide Side { get; set; }

        [JsonProperty("lastQty")]
        public decimal? LastQty { get; set; }

        [JsonProperty("lastPx")]
        public decimal? LastPx { get; set; }

        [JsonProperty("underlyingLastPx")]
        public decimal? UnderlyingLastPx { get; set; }

        [JsonProperty("lastMkt")]
        public string LastMkt { get; set; }

        [JsonProperty("lastLiquidityInd")]
        public string LastLiquidityInd { get; set; }

        [JsonProperty("simpleOrderQty")]
        public decimal? SimpleOrderQty { get; set; }

        [JsonProperty("orderQty")]
        public decimal? OrderQty { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        [JsonProperty("displayQty")]
        public decimal? DisplayQty { get; set; }

        [JsonProperty("stopPx")]
        public decimal? StopPx { get; set; }

        [JsonProperty("pegOffsetValue")]
        public decimal? PegOffsetValue { get; set; }

        [JsonProperty("pegPriceType")]
        public string PegPriceType { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("settlCurrency")]
        public string SettlCurrency { get; set; }

        [JsonProperty("execType")]
        public string ExecType { get; set; }

        [JsonProperty("ordType")]
        public string OrdType { get; set; }

        [JsonProperty("timeInForce")]
        public string TimeInForce { get; set; }

        [JsonProperty("execInst")]
        public string ExecInst { get; set; }

        [JsonProperty("contingencyType")]
        public string ContingencyType { get; set; }

        [JsonProperty("exDestination")]
        public string ExDestination { get; set; }

        [JsonProperty("ordStatus")]
        public string OrdStatus { get; set; }

        [JsonProperty("triggered")]
        public string Triggered { get; set; }

        [JsonProperty("workingIndicator")]
        public bool? WorkingIndicator { get; set; }

        [JsonProperty("ordRejReason")]
        public string OrdRejReason { get; set; }

        [JsonProperty("simpleLeavesQty")]
        public decimal? SimpleLeavesQty { get; set; }

        [JsonProperty("leavesQty")]
        public decimal? LeavesQty { get; set; }

        [JsonProperty("simpleCumQty")]
        public decimal? SimpleCumQty { get; set; }

        [JsonProperty("cumQty")]
        public decimal? CumQty { get; set; }

        [JsonProperty("avgPx")]
        public decimal? AvgPx { get; set; }

        [JsonProperty("commission")]
        public decimal? Commission { get; set; }

        [JsonProperty("tradePublishIndicator")]
        public string TradePublishIndicator { get; set; }

        [JsonProperty("multiLegReportingType")]
        public string MultiLegReportingType { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("trdMatchID")]
        public string TrdMatchID { get; set; }

        [JsonProperty("execCost")]
        public decimal? ExecCost { get; set; }

        [JsonProperty("execComm")]
        public decimal? ExecComm { get; set; }

        [JsonProperty("homeNotional")]
        public decimal? HomeNotional { get; set; }

        [JsonProperty("foreignNotional")]
        public decimal? ForeignNotional { get; set; }

        [JsonProperty("transactTime")]
        public System.DateTime? TransactTime { get; set; }

        [JsonProperty("timestamp")]
        public System.DateTime? Timestamp { get; set; }


    }

}

