﻿using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.Net.Client
{
    public class BitmexSocketClientOptions : SocketClientOptions
    {
        public bool IsTestnet;
        public BitmexSocketClientOptions():base("wss://www.bitmex.com/realtime")
        {
            IsTestnet = false;
        }
        public BitmexSocketClientOptions(bool isTestnet = false, bool useMultiplexing = false) : base(isTestnet ? "wss://testnet.bitmex.com/realtime":"wss://www.bitmex.com/realtime" )
        {
            IsTestnet = isTestnet;
            if (useMultiplexing)
            {
                throw new NotImplementedException("Multiplex client is not implemented yet");
            }
        }
        public BitmexSocketClientOptions(string key, string secret, bool isTestnet = false, bool useMultiplexing = false) : base(isTestnet ? "wss://testnet.bitmex.com/realtime" : "wss://www.bitmex.com/realtime")
        {
            if (useMultiplexing)
            {
                throw new NotImplementedException("Multiplex client is not implemented yet");
            }
            IsTestnet = isTestnet;
            key.ValidateNotNull(nameof(key));
            secret.ValidateNotNull(nameof(secret));
            ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials(key, secret);
        }
        public BitmexSocketClientOptions Copy()
        {
            var copy = Copy<BitmexSocketClientOptions>();

            return copy;
        }
    }
}
