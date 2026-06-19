namespace MessagePack.Decoders
{
	internal sealed class Int16Double : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new Int16Double();

		private Int16Double()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			return Int16Int16.Instance.Read(bytes, offset, out readSize);
		}
	}
}
