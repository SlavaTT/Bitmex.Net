﻿using Bitmex.Net.Client.Interfaces;
using Bitmex.Net.Client.Objects;
using Bitmex.Net.Client.Objects.Requests;
using CryptoExchange.Net;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces.CommonClients;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bitmex.Net.Client
{
    public class BitmexMarginClient : BitmexBaseTradeClient, IBitmexMarginClient
    {
        private static readonly BitmexRestOptions defaultOptions = new();
        private static BitmexRestOptions DefaultOptions => defaultOptions.Copy();
        #region Endpoints

        private const string LiquidationEndpoint = "liquidation";
        private const string FundingEndpoint = "funding";
        private const string PositionEndpoint = "position";
        private const string PositionIsolateEndpoint = "position/isolate";
        private const string PositionRiskLimitEndpoint = "position/riskLimit";
        private const string PositionTransferMarginEndpoint = "position/transferMargin";
        private const string PositionLeverageEndpoint = "position/leverage";
        private const string OrderClosePositionEndpoint = "order/closePosition";
        #endregion

        internal BitmexMarginClient(ILogger logger, HttpClient httpClient, BitmexRestOptions opt)
        : base(logger, httpClient, opt)
        {
        }

        internal static IEnumerable<string> GetEndPointsWithAdditionalRateLimiter(string baseAddress)
        {
            return new[] 
            {
                $"{baseAddress}/{PositionIsolateEndpoint}",
                $"{baseAddress}/{PositionLeverageEndpoint}",
                $"{baseAddress}/{PositionTransferMarginEndpoint}",
                $"{baseAddress}/{OrderEndpoint}",
                $"{baseAddress}/{OrderCancelAllEndpoint}",
            };
        }

        #region IBitmexMarginClient
        public async Task<WebCallResult<List<Funding>>> GetFundingAsync(BitmexRequestWithFilter requestWithFilter = null, CancellationToken ct = default)
        {
            var parameters = GetParameters(requestWithFilter);
            return await SendRequestAsync<List<Funding>>(FundingEndpoint, HttpMethod.Get, ct, parameters);
        }

        public async Task<WebCallResult<List<Liquidation>>> GetLiquidationsAsync(BitmexRequestWithFilter requestWithFilter = null, CancellationToken ct = default)
        {
            var parameters = GetParameters(requestWithFilter);
            return await SendRequestAsync<List<Liquidation>>(LiquidationEndpoint, HttpMethod.Get, ct, parameters);
        }

        public async Task<WebCallResult<List<BitmexPosition>>> GetPositionsAsync(BitmexRequestWithFilter requestWithFilter = null, CancellationToken ct = default)
        {
            var parameters = GetParameters(requestWithFilter);

            return await SendRequestAsync<List<BitmexPosition>>(PositionEndpoint, HttpMethod.Get, ct, parameters);
        }

        public async Task<WebCallResult<BitmexPosition>> SetPositionIsolationAsync(string symbol, bool isolate, CancellationToken ct = default)
        {
            symbol.ValidateNotNull(nameof(symbol));
            var parameters = GetParameters();
            parameters.Add("symbol", symbol);
            parameters.Add("isolate", isolate);
            return await SendRequestAsync<BitmexPosition>(PositionIsolateEndpoint, HttpMethod.Post, ct, parameters);
        }

        public async Task<WebCallResult<BitmexPosition>> SetPositionLeverageAsync(string symbol, decimal leverage, CancellationToken ct = default)
        {
            symbol.ValidateNotNull(nameof(symbol));
            var parameters = GetParameters();
            parameters.Add("symbol", symbol);
            parameters.Add("leverage", leverage);
            return await SendRequestAsync<BitmexPosition>(PositionLeverageEndpoint, HttpMethod.Post, ct, parameters);
        }

        public async Task<WebCallResult<BitmexPosition>> SetPositionRiskLimitAsync(string symbol, decimal riskLimit, CancellationToken ct = default)
        {
            symbol.ValidateNotNull(nameof(symbol));

            var parameters = GetParameters();
            parameters.Add("symbol", symbol);
            parameters.Add("riskLimit", riskLimit);
            return await SendRequestAsync<BitmexPosition>(PositionRiskLimitEndpoint, HttpMethod.Post, ct, parameters);
        }

        public async Task<WebCallResult<BitmexPosition>> SetPositionTransferMarginAsync(string symbol, decimal amount, CancellationToken ct = default)
        {
            symbol.ValidateNotNull(nameof(symbol));
            var parameters = GetParameters();
            parameters.Add("symbol", symbol);
            parameters.Add("amount", amount);
            return await SendRequestAsync<BitmexPosition>(PositionTransferMarginEndpoint, HttpMethod.Post, ct, parameters);
        }

        #endregion
        #region IFuturesClient, IBaseRestClient implementation
        public override string GetSymbolName(string baseAsset, string quoteAsset)
        {
            return $"{baseAsset}{quoteAsset}";
        }

        async Task<WebCallResult<OrderId>> IFuturesClient.PlaceOrderAsync(string symbol, CommonOrderSide side, CommonOrderType type, decimal quantity, decimal? price, int? leverage, string accountId, string clientOrderId, CancellationToken ct)
            => await base.PlaceOrderAsync(symbol, side, type, quantity, price, accountId, clientOrderId, ct);

        async Task<WebCallResult<IEnumerable<Position>>> IFuturesClient.GetPositionsAsync(CancellationToken ct)
        {
            var result = await GetPositionsAsync(ct: ct);
            return result.As(result.Data?.Select(pos => pos.ToCryptoExchangePosition()));
        }

		public async Task<WebCallResult<IEnumerable<Margin>>> GetUserMarginStatusAllAssetsAsync(CancellationToken ct = default)
		{
            var result = await GetMarginStatusAllAssets(ct);
            return result.As(result.Data?.Select(x => x));
		}

		#endregion

	}
}
