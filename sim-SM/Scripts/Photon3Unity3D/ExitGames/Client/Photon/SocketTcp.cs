using System;
using System.Net.Sockets;

namespace ExitGames.Client.Photon
{
	public class SocketTcp : IPhotonSocket, IDisposable
	{
		private Socket sock;

		private readonly object syncer;

		[Preserve]
		public SocketTcp(PeerBase npeer)
			: base(null)
		{
		}

		~SocketTcp()
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

		public void ReceiveLoop()
		{
		}
	}
}
