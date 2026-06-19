namespace MessagePack.Decoders
{
	internal sealed class Int64Double : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new Int64Double();

		private Int64Double()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			return Int64Int64.Instance.Read(bytes, offset, out readSize);
		}
	}
}
