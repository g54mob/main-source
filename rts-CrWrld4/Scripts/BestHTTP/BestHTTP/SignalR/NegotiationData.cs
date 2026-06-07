using System;
using System.Collections.Generic;

namespace BestHTTP.SignalR
{
	public sealed class NegotiationData
	{
		public Action<NegotiationData> OnReceived;

		public Action<NegotiationData, string> OnError;

		private HTTPRequest NegotiationRequest;

		private IConnection Connection;

		public string Url { get; private set; }

		public string WebSocketServerUrl { get; private set; }

		public string ConnectionToken { get; private set; }

		public string ConnectionId { get; private set; }

		public TimeSpan? KeepAliveTimeout { get; private set; }

		public TimeSpan DisconnectTimeout { get; private set; }

		public TimeSpan ConnectionTimeout { get; private set; }

		public bool TryWebSockets { get; private set; }

		public string ProtocolVersion { get; private set; }

		public TimeSpan TransportConnectTimeout { get; private set; }

		public TimeSpan LongPollDelay { get; private set; }

		public NegotiationData(Connection connection)
		{
		}

		public void Start()
		{
		}

		public void Abort()
		{
		}

		private void OnNegotiationRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}

		private void RaiseOnError(string err)
		{
		}

		private NegotiationData Parse(string str)
		{
			return null;
		}

		private static object Get(Dictionary<string, object> from, string key)
		{
			return null;
		}

		private static string GetString(Dictionary<string, object> from, string key)
		{
			return null;
		}

		private static List<string> GetStringList(Dictionary<string, object> from, string key)
		{
			return null;
		}

		private static int GetInt(Dictionary<string, object> from, string key)
		{
			return 0;
		}

		private static double GetDouble(Dictionary<string, object> from, string key)
		{
			return 0.0;
		}
	}
}
