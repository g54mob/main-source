using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace kcp2k
{
	public abstract class KcpConnection
	{
		protected Socket socket;

		protected EndPoint remoteEndpoint;

		internal Kcp kcp;

		private KcpState state;

		public Action OnAuthenticated;

		public Action<ArraySegment<byte>> OnData;

		public Action OnDisconnected;

		private bool paused;

		public const int TIMEOUT = 20000;

		private uint lastReceiveTime;

		private readonly Stopwatch refTime;

		private const int CHANNEL_HEADER_SIZE = 1;

		public const int ReliableMaxMessageSize = 149224;

		public const int UnreliableMaxMessageSize = 1199;

		private byte[] kcpMessageBuffer;

		private byte[] kcpSendBuffer;

		private byte[] rawSendBuffer;

		public const int PING_INTERVAL = 1000;

		private uint lastPingTime;

		internal const int QueueDisconnectThreshold = 10000;

		public int SendQueueCount => 0;

		public int ReceiveQueueCount => 0;

		public int SendBufferCount => 0;

		public int ReceiveBufferCount => 0;

		public uint MaxSendRate => 0u;

		public uint MaxReceiveRate => 0u;

		protected void SetupKcp(bool noDelay, uint interval = 100u, int fastResend = 0, bool congestionWindow = true, uint sendWindowSize = 32u, uint receiveWindowSize = 128u)
		{
		}

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

		private bool ReceiveNextReliable(out KcpHeader header, out ArraySegment<byte> message)
		{
			header = default(KcpHeader);
			message = default(ArraySegment<byte>);
			return false;
		}

		private void TickIncoming_Connected(uint time)
		{
		}

		private void TickIncoming_Authenticated(uint time)
		{
		}

		public void TickIncoming()
		{
		}

		public void TickOutgoing()
		{
		}

		public void RawInput(byte[] buffer, int msgLength)
		{
		}

		protected abstract void RawSend(byte[] data, int length);

		private void RawSendReliable(byte[] data, int length)
		{
		}

		private void SendReliable(KcpHeader header, ArraySegment<byte> content)
		{
		}

		private void SendUnreliable(ArraySegment<byte> message)
		{
		}

		public void SendHandshake()
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

		protected virtual void Dispose()
		{
		}

		public void Disconnect()
		{
		}

		public EndPoint GetRemoteEndPoint()
		{
			return null;
		}

		public void Pause()
		{
		}

		public void Unpause()
		{
		}
	}
}
