namespace MessagePack.Formatters
{
	public sealed class NullableForceInt64BlockFormatter : IMessagePackFormatter<long?>, IMessagePackFormatter
	{
		public static readonly NullableForceInt64BlockFormatter Instance = new NullableForceInt64BlockFormatter();

		private NullableForceInt64BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, long? value, IFormatterResolver formatterResolver)
		{
			if (!value.HasValue)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			return MessagePackBinary.WriteInt64ForceInt64Block(ref bytes, offset, value.Value);
		}

		public long? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			return MessagePackBinary.ReadInt64(bytes, offset, out readSize);
		}
	}
}
