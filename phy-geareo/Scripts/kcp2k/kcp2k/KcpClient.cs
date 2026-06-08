using System;
using System.Net;
using System.Net.Sockets;

namespace kcp2k
{
	public class KcpClient : KcpPeer
	{
		protected Socket socket;

		public EndPoint remoteEndPoint;

		protected readonly KcpConfig config;

		protected readonly byte[] rawReceiveBuffer;

		protected readonly Action OnConnectedCallback;

		protected readonly Action<ArraySegment<byte>, KcpChannel> OnDataCallback;

		protected readonly Action OnDisconnectedCallback;

		protected readonly Action<ErrorCode, string> OnErrorCallback;

		private bool active;

		public bool connected;

		public EndPoint LocalEndPoint => null;

		public KcpClient(Action OnConnected, Action<ArraySegment<byte>, KcpChannel> OnData, Action OnDisconnected, Action<ErrorCode, string> OnError, KcpConfig config)
			: base(null, 0u)
		{
		}

		protected override void OnAuthenticated()
		{
		}

		protected override void OnData(ArraySegment<byte> message, KcpChannel channel)
		{
		}

		protected override void OnError(ErrorCode error, string message)
		{
		}

		protected override void OnDisconnected()
		{
		}

		public void Connect(string address, ushort port)
		{
		}

		protected virtual bool RawReceive(out ArraySegment<byte> segment)
		{
			segment = default(ArraySegment<byte>);
			return false;
		}

		protected override void RawSend(ArraySegment<byte> data)
		{
		}

		public void Send(ArraySegment<byte> segment, KcpChannel channel)
		{
		}

		public void RawInput(ArraySegment<byte> segment)
		{
		}

		public override void TickIncoming()
		{
		}

		public override void TickOutgoing()
		{
		}

		public virtual void Tick()
		{
		}
	}
}
