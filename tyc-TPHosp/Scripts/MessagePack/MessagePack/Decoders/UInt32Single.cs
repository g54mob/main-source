namespace MessagePack.Decoders
{
	internal sealed class UInt32Single : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new UInt32Single();

		private UInt32Single()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			return UInt32UInt32.Instance.Read(bytes, offset, out readSize);
		}
	}
}
