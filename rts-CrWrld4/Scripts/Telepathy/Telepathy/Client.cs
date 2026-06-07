using System;

namespace Telepathy
{
	public class Client : Common
	{
		public Action OnConnected;

		public Action<ArraySegment<byte>> OnData;

		public Action OnDisconnected;

		public int SendQueueLimit;

		public int ReceiveQueueLimit;

		private ClientConnectionState state;

		public bool Connected => false;

		public bool Connecting => false;

		public int ReceivePipeCount => 0;

		public Client(int MaxMessageSize)
			: base(0)
		{
		}

		private static void ReceiveThreadFunction(ClientConnectionState state, string ip, int port, int MaxMessageSize, bool NoDelay, int SendTimeout, int ReceiveTimeout, int ReceiveQueueLimit)
		{
		}

		public void Connect(string ip, int port)
		{
		}

		public void Disconnect()
		{
		}

		public bool Send(ArraySegment<byte> message)
		{
			return false;
		}

		public int Tick(int processLimit, Func<bool> checkEnabled = null)
		{
			return 0;
		}
	}
}
