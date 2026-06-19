namespace MessagePack.Formatters
{
	public sealed class NullableForceInt32BlockFormatter : IMessagePackFormatter<int?>, IMessagePackFormatter
	{
		public static readonly NullableForceInt32BlockFormatter Instance = new NullableForceInt32BlockFormatter();

		private NullableForceInt32BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, int? value, IFormatterResolver formatterResolver)
		{
			if (!value.HasValue)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			return MessagePackBinary.WriteInt32ForceInt32Block(ref bytes, offset, value.Value);
		}

		public int? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			return MessagePackBinary.ReadInt32(bytes, offset, out readSize);
		}
	}
}
