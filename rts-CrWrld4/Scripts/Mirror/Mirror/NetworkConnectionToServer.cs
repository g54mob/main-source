using System;

namespace Mirror
{
	public class NetworkConnectionToServer : NetworkConnection
	{
		public override string address => null;

		internal override void Send(ArraySegment<byte> segment, int channelId = 0)
		{
		}

		public override void Disconnect()
		{
		}
	}
}
