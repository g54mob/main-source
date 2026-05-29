namespace LiteNetLib
{
	public readonly ref struct PooledPacket
	{
		internal readonly NetPacket _packet;

		internal readonly byte _channelNumber;

		public readonly int MaxUserDataSize;

		public readonly int UserDataOffset;

		public byte[] Data => null;

		internal PooledPacket(NetPacket packet, int maxDataSize, byte channelNumber)
		{
			_packet = null;
			_channelNumber = 0;
			MaxUserDataSize = 0;
			UserDataOffset = 0;
		}
	}
}
