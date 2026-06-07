using System;
using System.Collections.Generic;

namespace BestHTTP.SignalRCore.Messages
{
	public sealed class NegotiationResult
	{
		public int NegotiateVersion { get; private set; }

		public string ConnectionToken { get; private set; }

		public string ConnectionId { get; private set; }

		public List<SupportedTransport> SupportedTransports { get; private set; }

		public Uri Url { get; private set; }

		public string AccessToken { get; private set; }

		public HTTPResponse NegotiationResponse { get; internal set; }

		internal static NegotiationResult Parse(HTTPResponse resp, out string error, HubConnection hub)
		{
			error = null;
			return null;
		}

		private static bool IsAbsolute(string url)
		{
			return false;
		}
	}
}
