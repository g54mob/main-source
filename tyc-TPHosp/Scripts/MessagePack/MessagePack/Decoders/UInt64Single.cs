namespace MessagePack.Decoders
{
	internal sealed class UInt64Single : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new UInt64Single();

		private UInt64Single()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			return UInt64UInt64.Instance.Read(bytes, offset, out readSize);
		}
	}
}
