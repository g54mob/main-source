namespace MessagePack.Decoders
{
	internal sealed class Array16Header : IArrayHeaderDecoder
	{
		internal static readonly IArrayHeaderDecoder Instance = new Array16Header();

		private Array16Header()
		{
		}

		public uint Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 3;
			return (uint)((bytes[offset + 1] << 8) | bytes[offset + 2]);
		}
	}
}
