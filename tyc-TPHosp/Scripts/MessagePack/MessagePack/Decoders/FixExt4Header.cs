namespace MessagePack.Decoders
{
	internal sealed class FixExt4Header : IExtHeaderDecoder
	{
		internal static readonly IExtHeaderDecoder Instance = new FixExt4Header();

		private FixExt4Header()
		{
		}

		public ExtensionHeader Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 2;
			return new ExtensionHeader((sbyte)bytes[offset + 1], 4u);
		}
	}
}
