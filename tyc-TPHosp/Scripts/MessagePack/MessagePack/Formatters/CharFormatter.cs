namespace MessagePack.Formatters
{
	public sealed class CharFormatter : IMessagePackFormatter<char>, IMessagePackFormatter
	{
		public static readonly CharFormatter Instance = new CharFormatter();

		private CharFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, char value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteChar(ref bytes, offset, value);
		}

		public char Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadChar(bytes, offset, out readSize);
		}
	}
}
