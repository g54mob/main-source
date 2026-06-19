namespace MessagePack.Decoders
{
	internal sealed class FixExt16Header : IExtHeaderDecoder
	{
		internal static readonly IExtHeaderDecoder Instance = new FixExt16Header();

		private FixExt16Header()
		{
		}

		public ExtensionHeader Read(byte[] bytes, int offset, out int readSize)
		{
			readSize = 2;
			return new ExtensionHeader((sbyte)bytes[offset + 1], 16u);
		}
	}
}
