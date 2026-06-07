using System;
using System.Collections.Generic;

namespace Mirror
{
	internal class LocalConnectionToServer : NetworkConnectionToServer
	{
		internal LocalConnectionToClient connectionToClient;

		internal readonly Queue<PooledNetworkWriter> queue;

		private bool connectedEventPending;

		private bool disconnectedEventPending;

		public override string address => null;

		internal void QueueConnectedEvent()
		{
		}

		internal void QueueDisconnectedEvent()
		{
		}

		internal override void Send(ArraySegment<byte> segment, int channelId = 0)
		{
		}

		internal void Update()
		{
		}

		internal void DisconnectInternal()
		{
		}

		public override void Disconnect()
		{
		}

		internal override bool IsAlive(float timeout)
		{
			return false;
		}
	}
}
