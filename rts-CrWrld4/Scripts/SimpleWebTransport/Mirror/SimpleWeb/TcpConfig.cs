using System.Net.Sockets;

namespace Mirror.SimpleWeb
{
	public struct TcpConfig
	{
		public readonly bool noDelay;

		public readonly int sendTimeout;

		public readonly int receiveTimeout;

		public TcpConfig(bool noDelay, int sendTimeout, int receiveTimeout)
		{
			this.noDelay = false;
			this.sendTimeout = 0;
			this.receiveTimeout = 0;
		}

		public void ApplyTo(TcpClient client)
		{
		}
	}
}
