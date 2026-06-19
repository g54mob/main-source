namespace MessagePack.Decoders
{
	internal sealed class UInt8Single : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new UInt8Single();

		private UInt8Single()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			return (int)UInt8Byte.Instance.Read(bytes, offset, out readSize);
		}
	}
}
