using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace kcp2k
{
	public class KcpServer
	{
		protected readonly Action<int, IPEndPoint> OnConnected;

		protected readonly Action<int, ArraySegment<byte>, KcpChannel> OnData;

		protected readonly Action<int> OnDisconnected;

		protected readonly Action<int, ErrorCode, string> OnError;

		protected readonly KcpConfig config;

		protected Socket socket;

		private EndPoint newClientEP;

		protected readonly byte[] rawReceiveBuffer;

		public Dictionary<int, KcpServerConnection> connections;

		private readonly HashSet<int> connectionsToRemove;

		public EndPoint LocalEndPoint => null;

		public KcpServer(Action<int, IPEndPoint> OnConnected, Action<int, ArraySegment<byte>, KcpChannel> OnData, Action<int> OnDisconnected, Action<int, ErrorCode, string> OnError, KcpConfig config)
		{
		}

		public virtual bool IsActive()
		{
			return false;
		}

		private static Socket CreateServerSocket(bool DualMode, ushort port)
		{
			return null;
		}

		public virtual void Start(ushort port)
		{
		}

		public void Send(int connectionId, ArraySegment<byte> segment, KcpChannel channel)
		{
		}

		public void Disconnect(int connectionId)
		{
		}

		public IPEndPoint GetClientEndPoint(int connectionId)
		{
			return null;
		}

		protected virtual bool RawReceiveFrom(out ArraySegment<byte> segment, out int connectionId)
		{
			segment = default(ArraySegment<byte>);
			connectionId = default(int);
			return false;
		}

		protected virtual void RawSend(int connectionId, ArraySegment<byte> data)
		{
		}

		protected virtual KcpServerConnection CreateConnection(int connectionId)
		{
			return null;
		}

		private void ProcessMessage(ArraySegment<byte> segment, int connectionId)
		{
		}

		public virtual void TickIncoming()
		{
		}

		public virtual void TickOutgoing()
		{
		}

		public virtual void Tick()
		{
		}

		public virtual void Stop()
		{
		}
	}
}
