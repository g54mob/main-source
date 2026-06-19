namespace MessagePack.Decoders
{
	internal sealed class UInt8Double : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new UInt8Double();

		private UInt8Double()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			return (int)UInt8Byte.Instance.Read(bytes, offset, out readSize);
		}
	}
}
