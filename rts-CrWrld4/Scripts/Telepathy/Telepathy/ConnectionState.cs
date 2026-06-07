using System.Net.Sockets;
using System.Threading;

namespace Telepathy
{
	public class ConnectionState
	{
		public TcpClient client;

		public readonly MagnificentSendPipe sendPipe;

		public ManualResetEvent sendPending;

		public ConnectionState(TcpClient client, int MaxMessageSize)
		{
		}
	}
}
