namespace MessagePack.Formatters
{
	public sealed class ForceInt64BlockFormatter : IMessagePackFormatter<long>, IMessagePackFormatter
	{
		public static readonly ForceInt64BlockFormatter Instance = new ForceInt64BlockFormatter();

		private ForceInt64BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, long value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteInt64ForceInt64Block(ref bytes, offset, value);
		}

		public long Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadInt64(bytes, offset, out readSize);
		}
	}
}
