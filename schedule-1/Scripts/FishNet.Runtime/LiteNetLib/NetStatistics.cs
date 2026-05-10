namespace LiteNetLib
{
	public sealed class NetStatistics
	{
		private long _packetsSent;

		private long _packetsReceived;

		private long _bytesSent;

		private long _bytesReceived;

		private long _packetLoss;

		public long PacketsSent => 0L;

		public long PacketsReceived => 0L;

		public long BytesSent => 0L;

		public long BytesReceived => 0L;

		public long PacketLoss => 0L;

		public long PacketLossPercent => 0L;

		public void Reset()
		{
		}

		public void IncrementPacketsSent()
		{
		}

		public void IncrementPacketsReceived()
		{
		}

		public void AddBytesSent(long bytesSent)
		{
		}

		public void AddBytesReceived(long bytesReceived)
		{
		}

		public void IncrementPacketLoss()
		{
		}

		public void AddPacketLoss(long packetLoss)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
