namespace MessagePack.Decoders
{
	internal sealed class UInt16Double : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new UInt16Double();

		private UInt16Double()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			return (int)UInt16UInt16.Instance.Read(bytes, offset, out readSize);
		}
	}
}
