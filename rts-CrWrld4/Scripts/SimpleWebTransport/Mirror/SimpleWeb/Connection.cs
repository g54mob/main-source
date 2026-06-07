using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Mirror.SimpleWeb
{
	internal sealed class Connection : IDisposable
	{
		public const int IdNotSet = -1;

		private readonly object disposedLock;

		public TcpClient client;

		public int connId;

		public Stream stream;

		public Thread receiveThread;

		public Thread sendThread;

		public ManualResetEventSlim sendPending;

		public ConcurrentQueue<ArrayBuffer> sendQueue;

		public Action<Connection> onDispose;

		private bool hasDisposed;

		public Connection(TcpClient client, Action<Connection> onDispose)
		{
		}

		public void Dispose()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
