namespace MessagePack.Decoders
{
	internal sealed class FixDouble : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new FixDouble();

		private FixDouble()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			return (int)FixByte.Instance.Read(bytes, offset, out readSize);
		}
	}
}
