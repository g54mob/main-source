namespace MessagePack.Formatters
{
	public sealed class ForceInt32BlockFormatter : IMessagePackFormatter<int>, IMessagePackFormatter
	{
		public static readonly ForceInt32BlockFormatter Instance = new ForceInt32BlockFormatter();

		private ForceInt32BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, int value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteInt32ForceInt32Block(ref bytes, offset, value);
		}

		public int Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadInt32(bytes, offset, out readSize);
		}
	}
}
