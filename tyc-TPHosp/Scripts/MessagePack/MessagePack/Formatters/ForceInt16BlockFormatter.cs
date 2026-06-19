namespace MessagePack.Formatters
{
	public sealed class ForceInt16BlockFormatter : IMessagePackFormatter<short>, IMessagePackFormatter
	{
		public static readonly ForceInt16BlockFormatter Instance = new ForceInt16BlockFormatter();

		private ForceInt16BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, short value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteInt16ForceInt16Block(ref bytes, offset, value);
		}

		public short Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadInt16(bytes, offset, out readSize);
		}
	}
}
