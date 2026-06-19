namespace MessagePack.Decoders
{
	internal sealed class ReadNextExt32 : IReadNextDecoder
	{
		internal static readonly IReadNextDecoder Instance = new ReadNextExt32();

		private ReadNextExt32()
		{
		}

		public int Read(byte[] bytes, int offset)
		{
			return ((bytes[offset + 1] << 24) | (bytes[offset + 2] << 16) | (bytes[offset + 3] << 8) | bytes[offset + 4]) + 6;
		}
	}
}
