using System.Net.Sockets;

namespace Photon.Realtime
{
	public class PingMono : PhotonPing
	{
		private Socket sock;

		public override bool StartPing(string ip)
		{
			return false;
		}

		public override bool Done()
		{
			return false;
		}

		public override void Dispose()
		{
		}
	}
}
