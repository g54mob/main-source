using System;
using System.Diagnostics;

namespace kcp2k
{
	public abstract class KcpPeer
	{
		internal Kcp kcp;

		internal uint cookie;

		protected KcpState state;

		public const int DEFAULT_TIMEOUT = 10000;

		public int timeout;

		private uint lastReceiveTime;

		private readonly Stopwatch watch;

		private readonly byte[] kcpMessageBuffer;

		private readonly byte[] kcpSendBuffer;

		private readonly byte[] rawSendBuffer;

		public const int PING_INTERVAL = 1000;

		private uint lastPingTime;

		internal const int QueueDisconnectThreshold = 10000;

		public const int CHANNEL_HEADER_SIZE = 1;

		public const int COOKIE_HEADER_SIZE = 4;

		public const int METADATA_SIZE = 5;

		public readonly int unreliableMax;

		public readonly int reliableMax;

		public int SendQueueCount => 0;

		public int ReceiveQueueCount => 0;

		public int SendBufferCount => 0;

		public int ReceiveBufferCount => 0;

		public uint MaxSendRate => 0u;

		public uint MaxReceiveRate => 0u;

		private static int ReliableMaxMessageSize_Unconstrained(int mtu, uint rcv_wnd)
		{
			return 0;
		}

		public static int ReliableMaxMessageSize(int mtu, uint rcv_wnd)
		{
			return 0;
		}

		public static int UnreliableMaxMessageSize(int mtu)
		{
			return 0;
		}

		protected KcpPeer(KcpConfig config, uint cookie)
		{
		}

		protected void Reset(KcpConfig config)
		{
		}

		protected abstract void OnAuthenticated();

		protected abstract void OnData(ArraySegment<byte> message, KcpChannel channel);

		protected abstract void OnDisconnected();

		protected abstract void OnError(ErrorCode error, string message);

		protected abstract void RawSend(ArraySegment<byte> data);

		private void HandleTimeout(uint time)
		{
		}

		private void HandleDeadLink()
		{
		}

		private void HandlePing(uint time)
		{
		}

		private void HandleChoked()
		{
		}

		private bool ReceiveNextReliable(out KcpHeaderReliable header, out ArraySegment<byte> message)
		{
			header = default(KcpHeaderReliable);
			message = default(ArraySegment<byte>);
			return false;
		}

		private void TickIncoming_Connected(uint time)
		{
		}

		private void TickIncoming_Authenticated(uint time)
		{
		}

		public virtual void TickIncoming()
		{
		}

		public virtual void TickOutgoing()
		{
		}

		protected void OnRawInputReliable(ArraySegment<byte> message)
		{
		}

		protected void OnRawInputUnreliable(ArraySegment<byte> message)
		{
		}

		private void RawSendReliable(byte[] data, int length)
		{
		}

		private void SendReliable(KcpHeaderReliable header, ArraySegment<byte> content)
		{
		}

		private void SendUnreliable(KcpHeaderUnreliable header, ArraySegment<byte> content)
		{
		}

		public void SendHello()
		{
		}

		public void SendData(ArraySegment<byte> data, KcpChannel channel)
		{
		}

		private void SendPing()
		{
		}

		private void SendDisconnect()
		{
		}

		public virtual void Disconnect()
		{
		}
	}
}
