namespace MessagePack.Decoders
{
	internal sealed class ReadNextFixStr : IReadNextDecoder
	{
		internal static readonly IReadNextDecoder Instance = new ReadNextFixStr();

		private ReadNextFixStr()
		{
		}

		public int Read(byte[] bytes, int offset)
		{
			return (bytes[offset] & 0x1F) + 1;
		}
	}
}
