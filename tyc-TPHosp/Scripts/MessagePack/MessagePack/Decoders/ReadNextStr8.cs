namespace MessagePack.Decoders
{
	internal sealed class ReadNextStr8 : IReadNextDecoder
	{
		internal static readonly IReadNextDecoder Instance = new ReadNextStr8();

		private ReadNextStr8()
		{
		}

		public int Read(byte[] bytes, int offset)
		{
			return bytes[offset + 1] + 2;
		}
	}
}
