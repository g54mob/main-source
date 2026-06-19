namespace MessagePack.Decoders
{
	internal sealed class ReadNextBin16 : IReadNextDecoder
	{
		internal static readonly IReadNextDecoder Instance = new ReadNextBin16();

		private ReadNextBin16()
		{
		}

		public int Read(byte[] bytes, int offset)
		{
			return ((bytes[offset + 1] << 8) | bytes[offset + 2]) + 3;
		}
	}
}
