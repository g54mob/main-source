namespace MessagePack.Decoders
{
	internal sealed class UInt16Single : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new UInt16Single();

		private UInt16Single()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			return (int)UInt16UInt16.Instance.Read(bytes, offset, out readSize);
		}
	}
}
