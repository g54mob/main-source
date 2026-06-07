using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Threading;

namespace Mirror.SimpleWeb
{
	public class WebSocketServer
	{
		public readonly ConcurrentQueue<Message> receiveQueue;

		private readonly TcpConfig tcpConfig;

		private readonly int maxMessageSize;

		private TcpListener listener;

		private Thread acceptThread;

		private bool serverStopped;

		private readonly ServerHandshake handShake;

		private readonly ServerSslHelper sslHelper;

		private readonly BufferPool bufferPool;

		private readonly ConcurrentDictionary<int, Connection> connections;

		private int _idCounter;

		public WebSocketServer(TcpConfig tcpConfig, int maxMessageSize, int handshakeMaxSize, SslConfig sslConfig, BufferPool bufferPool)
		{
		}

		public void Listen(int port)
		{
		}

		public void Stop()
		{
		}

		private void acceptLoop()
		{
		}

		private void HandshakeAndReceiveLoop(Connection conn)
		{
		}

		private void AfterConnectionDisposed(Connection conn)
		{
		}

		public void Send(int id, ArrayBuffer buffer)
		{
		}

		public bool CloseConnection(int id)
		{
			return false;
		}

		public string GetClientAddress(int id)
		{
			return null;
		}
	}
}
