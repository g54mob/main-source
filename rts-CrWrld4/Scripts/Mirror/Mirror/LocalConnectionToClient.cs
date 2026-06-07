using System;

namespace Mirror
{
	internal class LocalConnectionToClient : NetworkConnectionToClient
	{
		internal LocalConnectionToServer connectionToServer;

		public override string address => null;

		public LocalConnectionToClient()
			: base(0, batching: false, 0f)
		{
		}

		internal override void Send(ArraySegment<byte> segment, int channelId = 0)
		{
		}

		internal override bool IsAlive(float timeout)
		{
			return false;
		}

		internal void DisconnectInternal()
		{
		}

		public override void Disconnect()
		{
		}
	}
}
