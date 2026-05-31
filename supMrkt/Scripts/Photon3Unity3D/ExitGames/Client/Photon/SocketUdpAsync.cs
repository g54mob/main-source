using System;
using System.Net.Sockets;

namespace ExitGames.Client.Photon
{
	public class SocketUdpAsync : IPhotonSocket, IDisposable
	{
		private Socket sock;

		private readonly object syncer;

		[Preserve]
		public SocketUdpAsync(PeerBase npeer)
			: base(null)
		{
		}

		~SocketUdpAsync()
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

		public void StartReceive()
		{
		}

		private void OnReceive(IAsyncResult ar)
		{
		}
	}
}
