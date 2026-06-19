namespace MessagePack.Formatters
{
	public sealed class SingleFormatter : IMessagePackFormatter<float>, IMessagePackFormatter
	{
		public static readonly SingleFormatter Instance = new SingleFormatter();

		private SingleFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, float value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteSingle(ref bytes, offset, value);
		}

		public float Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadSingle(bytes, offset, out readSize);
		}
	}
}
