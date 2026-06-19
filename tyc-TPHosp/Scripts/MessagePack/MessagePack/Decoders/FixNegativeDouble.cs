namespace MessagePack.Decoders
{
	internal sealed class FixNegativeDouble : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new FixNegativeDouble();

		private FixNegativeDouble()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			return FixSByte.Instance.Read(bytes, offset, out readSize);
		}
	}
}
