namespace MessagePack.Decoders
{
	internal sealed class FixFloat : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new FixFloat();

		private FixFloat()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			return (int)FixByte.Instance.Read(bytes, offset, out readSize);
		}
	}
}
