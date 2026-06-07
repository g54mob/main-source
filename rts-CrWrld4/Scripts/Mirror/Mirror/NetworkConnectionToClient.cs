using System;
using System.Collections.Generic;

namespace Mirror
{
	public class NetworkConnectionToClient : NetworkConnection
	{
		internal class Batch
		{
			internal Queue<PooledNetworkWriter> messages;

			internal double lastSendTime;
		}

		private Dictionary<int, Batch> batches;

		private bool batching;

		private float batchInterval;

		public override string address => null;

		public NetworkConnectionToClient(int networkConnectionId, bool batching, float batchInterval)
		{
		}

		private Batch GetBatchForChannelId(int channelId)
		{
			return null;
		}

		internal void SendBatch(int channelId, Batch batch)
		{
		}

		internal override void Send(ArraySegment<byte> segment, int channelId = 0)
		{
		}

		internal void Update()
		{
		}

		public override void Disconnect()
		{
		}
	}
}
