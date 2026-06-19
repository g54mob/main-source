namespace MessagePack.Formatters
{
	public sealed class BooleanFormatter : IMessagePackFormatter<bool>, IMessagePackFormatter
	{
		public static readonly BooleanFormatter Instance = new BooleanFormatter();

		private BooleanFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, bool value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteBoolean(ref bytes, offset, value);
		}

		public bool Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
		}
	}
}
