using System.Net;
using System.Net.Sockets;

namespace kcp2k
{
	public class KcpServerConnection : KcpConnection
	{
		public KcpServerConnection(Socket socket, EndPoint remoteEndpoint, bool noDelay, uint interval = 100u, int fastResend = 0, bool congestionWindow = true, uint sendWindowSize = 32u, uint receiveWindowSize = 128u)
		{
		}

		protected override void RawSend(byte[] data, int length)
		{
		}
	}
}
