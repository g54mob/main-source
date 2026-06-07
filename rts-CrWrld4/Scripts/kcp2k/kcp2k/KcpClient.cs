using System;

namespace kcp2k
{
	public class KcpClient
	{
		public Action OnConnected;

		public Action<ArraySegment<byte>> OnData;

		public Action OnDisconnected;

		public KcpClientConnection connection;

		public bool connected;

		public KcpClient(Action OnConnected, Action<ArraySegment<byte>> OnData, Action OnDisconnected)
		{
		}

		public void Connect(string address, ushort port, bool noDelay, uint interval, int fastResend = 0, bool congestionWindow = true, uint sendWindowSize = 32u, uint receiveWindowSize = 128u)
		{
		}

		public void Send(ArraySegment<byte> segment, KcpChannel channel)
		{
		}

		public void Disconnect()
		{
		}

		public void TickIncoming()
		{
		}

		public void TickOutgoing()
		{
		}

		public void Tick()
		{
		}

		public void Pause()
		{
		}

		public void Unpause()
		{
		}
	}
}
