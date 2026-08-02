using System;
using System.Net;

namespace kcp2k
{
	public class KcpServerConnection : KcpPeer
	{
		public readonly EndPoint remoteEndPoint;

		protected readonly Action<KcpServerConnection> OnConnectedCallback;

		protected readonly Action<ArraySegment<byte>, KcpChannel> OnDataCallback;

		protected readonly Action OnDisconnectedCallback;

		protected readonly Action<ErrorCode, string> OnErrorCallback;

		protected readonly Action<ArraySegment<byte>> RawSendCallback;

		public KcpServerConnection(Action<KcpServerConnection> OnConnected, Action<ArraySegment<byte>, KcpChannel> OnData, Action OnDisconnected, Action<ErrorCode, string> OnError, Action<ArraySegment<byte>> OnRawSend, KcpConfig config, uint cookie, EndPoint remoteEndPoint)
			: base(null, 0u)
		{
		}

		protected override void OnAuthenticated()
		{
		}

		protected override void OnData(ArraySegment<byte> message, KcpChannel channel)
		{
		}

		protected override void OnDisconnected()
		{
		}

		protected override void OnError(ErrorCode error, string message)
		{
		}

		protected override void RawSend(ArraySegment<byte> data)
		{
		}

		public void RawInput(ArraySegment<byte> segment)
		{
		}
	}
}
