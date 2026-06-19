namespace MessagePack.Formatters
{
	public sealed class NullableForceInt16BlockFormatter : IMessagePackFormatter<short?>, IMessagePackFormatter
	{
		public static readonly NullableForceInt16BlockFormatter Instance = new NullableForceInt16BlockFormatter();

		private NullableForceInt16BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, short? value, IFormatterResolver formatterResolver)
		{
			if (!value.HasValue)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			return MessagePackBinary.WriteInt16ForceInt16Block(ref bytes, offset, value.Value);
		}

		public short? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			return MessagePackBinary.ReadInt16(bytes, offset, out readSize);
		}
	}
}
