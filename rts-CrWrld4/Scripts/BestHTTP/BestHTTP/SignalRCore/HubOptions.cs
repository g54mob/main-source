using System;

namespace BestHTTP.SignalRCore
{
	public sealed class HubOptions
	{
		public bool SkipNegotiation { get; set; }

		public TransportTypes PreferedTransport { get; set; }

		public TimeSpan PingInterval { get; set; }

		public TimeSpan PingTimeoutInterval { get; set; }

		public int MaxRedirects { get; set; }

		public TimeSpan ConnectTimeout { get; set; }
	}
}
