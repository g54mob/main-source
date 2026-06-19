namespace MessagePack.Decoders
{
	internal sealed class Int32Double : IDoubleDecoder
	{
		internal static readonly IDoubleDecoder Instance = new Int32Double();

		private Int32Double()
		{
		}

		public double Read(byte[] bytes, int offset, out int readSize)
		{
			return Int32Int32.Instance.Read(bytes, offset, out readSize);
		}
	}
}
