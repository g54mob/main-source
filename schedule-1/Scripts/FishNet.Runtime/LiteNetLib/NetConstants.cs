namespace LiteNetLib
{
	public static class NetConstants
	{
		public const int DefaultWindowSize = 64;

		public const int SocketBufferSize = 1048576;

		public const int SocketTTL = 255;

		public const int HeaderSize = 1;

		public const int ChanneledHeaderSize = 4;

		public const int FragmentHeaderSize = 6;

		public const int FragmentedHeaderTotalSize = 10;

		public const ushort MaxSequence = 32768;

		public const ushort HalfMaxSequence = 16384;

		internal const int ProtocolId = 13;

		internal const int MaxUdpHeaderSize = 68;

		internal const int ChannelTypeCount = 4;

		internal static readonly int[] PossibleMtu;

		public static readonly int MaxPacketSize;

		public static readonly int MaxUnreliableDataSize;

		public const byte MaxConnectionNumber = 4;
	}
}
