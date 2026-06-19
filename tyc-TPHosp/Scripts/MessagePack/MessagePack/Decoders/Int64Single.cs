namespace MessagePack.Decoders
{
	internal sealed class Int64Single : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new Int64Single();

		private Int64Single()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			return Int64Int64.Instance.Read(bytes, offset, out readSize);
		}
	}
}
