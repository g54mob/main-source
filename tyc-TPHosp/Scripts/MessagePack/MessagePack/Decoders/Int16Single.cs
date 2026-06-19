namespace MessagePack.Decoders
{
	internal sealed class Int16Single : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new Int16Single();

		private Int16Single()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			return Int16Int16.Instance.Read(bytes, offset, out readSize);
		}
	}
}
