namespace MessagePack.Decoders
{
	internal sealed class ReadNextBin8 : IReadNextDecoder
	{
		internal static readonly IReadNextDecoder Instance = new ReadNextBin8();

		private ReadNextBin8()
		{
		}

		public int Read(byte[] bytes, int offset)
		{
			return bytes[offset + 1] + 2;
		}
	}
}
