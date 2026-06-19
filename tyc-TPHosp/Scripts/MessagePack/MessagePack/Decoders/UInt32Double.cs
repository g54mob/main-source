namespace MessagePack.Decoders
{
	internal sealed class UInt32Double : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new UInt32Double();

		private UInt32Double()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			return UInt32UInt32.Instance.Read(bytes, offset, out readSize);
		}
	}
}
