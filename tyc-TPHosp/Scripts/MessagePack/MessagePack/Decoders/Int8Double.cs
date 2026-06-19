namespace MessagePack.Decoders
{
	internal sealed class Int8Double : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new Int8Double();

		private Int8Double()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			return Int8SByte.Instance.Read(bytes, offset, out readSize);
		}
	}
}
