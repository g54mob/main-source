namespace MessagePack.Decoders
{
	internal sealed class Int8Single : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new Int8Single();

		private Int8Single()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			return Int8SByte.Instance.Read(bytes, offset, out readSize);
		}
	}
}
