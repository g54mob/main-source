using BestHTTP.PlatformSupport.Memory;
using BestHTTP.WebSocket;

namespace BestHTTP.SignalRCore.Transports
{
	internal sealed class WebSocketTransport : TransportBase
	{
		private BestHTTP.WebSocket.WebSocket webSocket;

		public override TransportTypes TransportType => default(TransportTypes);

		internal WebSocketTransport(HubConnection con)
			: base(null)
		{
		}

		public override void StartConnect()
		{
		}

		public override void Send(BufferSegment msg)
		{
		}

		private void OnOpen(BestHTTP.WebSocket.WebSocket webSocket)
		{
		}

		private void OnMessage(BestHTTP.WebSocket.WebSocket webSocket, string data)
		{
		}

		private void OnBinary(BestHTTP.WebSocket.WebSocket webSocket, byte[] data)
		{
		}

		private void OnError(BestHTTP.WebSocket.WebSocket webSocket, string reason)
		{
		}

		private void OnClosed(BestHTTP.WebSocket.WebSocket webSocket, ushort code, string message)
		{
		}

		public override void StartClose()
		{
		}
	}
}
