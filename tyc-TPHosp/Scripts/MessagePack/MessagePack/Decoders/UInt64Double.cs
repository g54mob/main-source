namespace MessagePack.Decoders
{
	internal sealed class UInt64Double : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new UInt64Double();

		private UInt64Double()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			return UInt64UInt64.Instance.Read(bytes, offset, out readSize);
		}
	}
}
