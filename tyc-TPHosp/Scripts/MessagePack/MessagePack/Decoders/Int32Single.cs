namespace MessagePack.Decoders
{
	internal sealed class Int32Single : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new Int32Single();

		private Int32Single()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			return Int32Int32.Instance.Read(bytes, offset, out readSize);
		}
	}
}
