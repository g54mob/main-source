namespace MessagePack.Decoders
{
	internal sealed class FixExt2Header : IExtHeaderDecoder
	{
		internal static readonly IExtHeaderDecoder Instance = new FixExt2Header();

		private FixExt2Header()
		{
		}

		public ExtensionHeader Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 2;
			return new ExtensionHeader((sbyte)bytes[offset + 1], 2u);
		}
	}
}
