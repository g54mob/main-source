namespace Epic.OnlineServices.P2P
{
	public class OnIncomingPacketQueueFullInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public ulong PacketQueueMaxSizeBytes { get; private set; }

		public ulong PacketQueueCurrentSizeBytes { get; private set; }

		public ProductUserId OverflowPacketLocalUserId { get; private set; }

		public byte OverflowPacketChannel { get; private set; }

		public uint OverflowPacketSizeBytes { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(OnIncomingPacketQueueFullInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
