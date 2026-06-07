namespace Epic.OnlineServices.P2P
{
	public class PacketQueueInfo : ISettable
	{
		public ulong IncomingPacketQueueMaxSizeBytes { get; set; }

		public ulong IncomingPacketQueueCurrentSizeBytes { get; set; }

		public ulong IncomingPacketQueueCurrentPacketCount { get; set; }

		public ulong OutgoingPacketQueueMaxSizeBytes { get; set; }

		public ulong OutgoingPacketQueueCurrentSizeBytes { get; set; }

		public ulong OutgoingPacketQueueCurrentPacketCount { get; set; }

		internal void Set(PacketQueueInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
