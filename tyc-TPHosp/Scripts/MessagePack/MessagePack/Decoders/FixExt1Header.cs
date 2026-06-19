namespace MessagePack.Decoders
{
	internal sealed class FixExt1Header : IExtHeaderDecoder
	{
		internal static readonly IExtHeaderDecoder Instance = new FixExt1Header();

		private FixExt1Header()
		{
		}

		public ExtensionHeader Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 2;
			return new ExtensionHeader((sbyte)bytes[offset + 1], 1u);
		}
	}
}
