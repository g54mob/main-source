using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Threading;

namespace Telepathy
{
	public class Server : Common
	{
		public Action<int> OnConnected;

		public Action<int, ArraySegment<byte>> OnData;

		public Action<int> OnDisconnected;

		public TcpListener listener;

		private Thread listenerThread;

		public int SendQueueLimit;

		public int ReceiveQueueLimit;

		protected MagnificentReceivePipe receivePipe;

		private readonly ConcurrentDictionary<int, ConnectionState> clients;

		private int counter;

		public int ReceivePipeTotalCount => 0;

		public bool Active => false;

		public int NextConnectionId()
		{
			return 0;
		}

		public Server(int MaxMessageSize)
			: base(0)
		{
		}

		private void Listen(int port)
		{
		}

		public bool Start(int port)
		{
			return false;
		}

		public void Stop()
		{
		}

		public bool Send(int connectionId, ArraySegment<byte> message)
		{
			return false;
		}

		public string GetClientAddress(int connectionId)
		{
			return null;
		}

		public bool Disconnect(int connectionId)
		{
			return false;
		}

		public int Tick(int processLimit, Func<bool> checkEnabled = null)
		{
			return 0;
		}
	}
}
