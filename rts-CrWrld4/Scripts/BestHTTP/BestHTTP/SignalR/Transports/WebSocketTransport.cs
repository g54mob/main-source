using BestHTTP.WebSocket;

namespace BestHTTP.SignalR.Transports
{
	public sealed class WebSocketTransport : TransportBase
	{
		private BestHTTP.WebSocket.WebSocket wSocket;

		public override bool SupportsKeepAlive => false;

		public override TransportTypes Type => default(TransportTypes);

		public WebSocketTransport(Connection connection)
			: base(null, null)
		{
		}

		public override void Connect()
		{
		}

		protected override void SendImpl(string json)
		{
		}

		public override void Stop()
		{
		}

		protected override void Started()
		{
		}

		protected override void Aborted()
		{
		}

		private void WSocket_OnOpen(BestHTTP.WebSocket.WebSocket webSocket)
		{
		}

		private void WSocket_OnMessage(BestHTTP.WebSocket.WebSocket webSocket, string message)
		{
		}

		private void WSocket_OnClosed(BestHTTP.WebSocket.WebSocket webSocket, ushort code, string message)
		{
		}

		private void WSocket_OnError(BestHTTP.WebSocket.WebSocket webSocket, string reason)
		{
		}
	}
}
