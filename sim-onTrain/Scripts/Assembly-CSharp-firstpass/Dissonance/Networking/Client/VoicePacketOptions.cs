namespace Dissonance.Networking.Client
{
	internal struct VoicePacketOptions
	{
		public const int ChannelSessionRange = 4;

		private readonly byte _bitfield;

		public byte ChannelSession => (byte)(_bitfield & 3);

		public byte Bitfield => _bitfield;

		private VoicePacketOptions(byte bitfield)
		{
			_bitfield = bitfield;
		}

		public static VoicePacketOptions Unpack(byte bitfield)
		{
			return new VoicePacketOptions(bitfield);
		}

		public static VoicePacketOptions Pack(byte channelSession)
		{
			return new VoicePacketOptions((byte)(0 | (channelSession % 4)));
		}
	}
}
