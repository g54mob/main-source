namespace MessagePack.Formatters
{
	public sealed class ByteFormatter : IMessagePackFormatter<byte>, IMessagePackFormatter
	{
		public static readonly ByteFormatter Instance = new ByteFormatter();

		private ByteFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, byte value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteByte(ref bytes, offset, value);
		}

		public byte Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadByte(bytes, offset, out readSize);
		}
	}
}
