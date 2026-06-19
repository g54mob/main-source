namespace MessagePack.Decoders
{
	internal sealed class FixExt8Header : IExtHeaderDecoder
	{
		internal static readonly IExtHeaderDecoder Instance = new FixExt8Header();

		private FixExt8Header()
		{
		}

		public ExtensionHeader Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 2;
			return new ExtensionHeader((sbyte)bytes[offset + 1], 8u);
		}
	}
}
