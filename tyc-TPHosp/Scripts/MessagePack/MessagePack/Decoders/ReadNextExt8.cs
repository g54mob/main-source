namespace MessagePack.Decoders
{
	internal sealed class ReadNextExt8 : IReadNextDecoder
	{
		internal static readonly IReadNextDecoder Instance = new ReadNextExt8();

		private ReadNextExt8()
		{
		}

		public int Read(byte[] bytes, int offset)
		{
			return bytes[offset + 1] + 3;
		}
	}
}
