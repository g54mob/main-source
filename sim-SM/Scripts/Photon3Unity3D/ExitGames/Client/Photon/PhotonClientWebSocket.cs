using System.Net.WebSockets;
using System.Threading.Tasks;

namespace ExitGames.Client.Photon
{
	public class PhotonClientWebSocket : IPhotonSocket
	{
		private ClientWebSocket clientWebSocket;

		private Task sendTask;

		[Preserve]
		public PhotonClientWebSocket(PeerBase peerBase)
			: base(null)
		{
		}

		public override bool Connect()
		{
			return false;
		}

		private void AsyncConnectAndReceive()
		{
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
	}
}
