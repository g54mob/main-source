using System;
using System.Net.Sockets;

namespace ExitGames.Client.Photon
{
	public class SocketTcpAsync : IPhotonSocket, IDisposable
	{
		private class ReceiveContext
		{
			public Socket workSocket;

			public int ReceivedHeaderBytes;

			public byte[] HeaderBuffer;

			public int ExpectedMessageBytes;

			public int ReceivedMessageBytes;

			public byte[] MessageBuffer;

			public bool ReadingHeader => false;

			public bool ReadingMessage => false;

			public byte[] CurrentBuffer => null;

			public int CurrentOffset => 0;

			public int CurrentExpected => 0;

			public ReceiveContext(Socket socket, byte[] headerBuffer, byte[] messageBuffer)
			{
			}

			public void Reset()
			{
			}
		}

		private Socket sock;

		private readonly object syncer;

		[Preserve]
		public SocketTcpAsync(PeerBase npeer)
			: base(null)
		{
		}

		~SocketTcpAsync()
		{
		}

		public void Dispose()
		{
		}

		public override bool Connect()
		{
			return false;
		}

		public override bool Disconnect()
		{
			return false;
		}

		public override PhotonSocketError Send(byte[] data, int length)
		{
			return default(PhotonSocketError);
		}

		public override PhotonSocketError Receive(out byte[] data)
		{
			data = null;
			return default(PhotonSocketError);
		}

		internal void DnsAndConnect()
		{
		}

		private void ReceiveAsync(ReceiveContext context = null)
		{
		}

		private void ReceiveAsync(IAsyncResult ar)
		{
		}
	}
}
