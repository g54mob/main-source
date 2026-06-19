namespace MessagePack.Decoders
{
	internal sealed class FixNegativeFloat : ISingleDecoder
	{
		internal static readonly ISingleDecoder Instance = new FixNegativeFloat();

		private FixNegativeFloat()
		{
		}

		public float Read(byte[] bytes, int offset, out int readSize)
		{
			return FixSByte.Instance.Read(bytes, offset, out readSize);
		}
	}
}
