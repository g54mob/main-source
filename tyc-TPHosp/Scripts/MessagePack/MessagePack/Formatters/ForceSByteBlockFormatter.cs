namespace MessagePack.Formatters
{
	public sealed class ForceSByteBlockFormatter : IMessagePackFormatter<sbyte>, IMessagePackFormatter
	{
		public static readonly ForceSByteBlockFormatter Instance = new ForceSByteBlockFormatter();

		private ForceSByteBlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, sbyte value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteSByteForceSByteBlock(ref bytes, offset, value);
		}

		public sbyte Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadSByte(bytes, offset, out readSize);
		}
	}
}
