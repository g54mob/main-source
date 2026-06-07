using System;

namespace Mirror.SimpleWeb
{
	public class WebSocketClientStandAlone : SimpleWebClient
	{
		private readonly ClientSslHelper sslHelper;

		private readonly ClientHandshake handshake;

		private readonly TcpConfig tcpConfig;

		private Connection conn;

		internal WebSocketClientStandAlone(int maxMessageSize, int maxMessagesPerTick, TcpConfig tcpConfig)
			: base(0, 0)
		{
		}

		public override void Connect(Uri serverAddress)
		{
		}

		private void ConnectAndReceiveLoop(Uri serverAddress)
		{
		}

		private void AfterConnectionDisposed(Connection conn)
		{
		}

		public override void Disconnect()
		{
		}

		public override void Send(ArraySegment<byte> segment)
		{
		}
	}
}
