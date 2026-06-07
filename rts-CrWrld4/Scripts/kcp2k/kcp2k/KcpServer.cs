using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace kcp2k
{
	public class KcpServer
	{
		public Action<int> OnConnected;

		public Action<int, ArraySegment<byte>> OnData;

		public Action<int> OnDisconnected;

		public bool NoDelay;

		public uint Interval;

		public int FastResend;

		public bool CongestionWindow;

		public uint SendWindowSize;

		public uint ReceiveWindowSize;

		private Socket socket;

		private EndPoint newClientEP;

		private readonly byte[] rawReceiveBuffer;

		public Dictionary<int, KcpServerConnection> connections;

		private HashSet<int> connectionsToRemove;

		public KcpServer(Action<int> OnConnected, Action<int, ArraySegment<byte>> OnData, Action<int> OnDisconnected, bool NoDelay, uint Interval, int FastResend = 0, bool CongestionWindow = true, uint SendWindowSize = 32u, uint ReceiveWindowSize = 128u)
		{
		}

		public bool IsActive()
		{
			return false;
		}

		public void Start(ushort port)
		{
		}

		public void Send(int connectionId, ArraySegment<byte> segment, KcpChannel channel)
		{
		}

		public void Disconnect(int connectionId)
		{
		}

		public string GetClientAddress(int connectionId)
		{
			return null;
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

		public void Stop()
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
