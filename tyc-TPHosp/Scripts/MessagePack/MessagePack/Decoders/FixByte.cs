namespace MessagePack.Decoders
{
	internal sealed class FixByte : IByteDecoder
	{
		internal static readonly IByteDecoder Instance = new FixByte();

		private FixByte()
		{
		}

		public byte Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 1;
			return bytes[offset];
		}
	}
}
