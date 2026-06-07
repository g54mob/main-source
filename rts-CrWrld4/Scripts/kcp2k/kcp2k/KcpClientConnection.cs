namespace kcp2k
{
	public class KcpClientConnection : KcpConnection
	{
		private readonly byte[] rawReceiveBuffer;

		public void Connect(string host, ushort port, bool noDelay, uint interval = 100u, int fastResend = 0, bool congestionWindow = true, uint sendWindowSize = 32u, uint receiveWindowSize = 128u)
		{
		}

		public void RawReceive()
		{
		}

		protected override void Dispose()
		{
		}

		protected override void RawSend(byte[] data, int length)
		{
		}
	}
}
