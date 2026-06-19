namespace MessagePack.Formatters
{
	public sealed class NullableForceByteBlockFormatter : IMessagePackFormatter<byte?>, IMessagePackFormatter
	{
		public static readonly NullableForceByteBlockFormatter Instance = new NullableForceByteBlockFormatter();

		private NullableForceByteBlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, byte? value, IFormatterResolver formatterResolver)
		{
			if (!value.HasValue)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			return MessagePackBinary.WriteByteForceByteBlock(ref bytes, offset, value.Value);
		}

		public byte? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			return MessagePackBinary.ReadByte(bytes, offset, out readSize);
		}
	}
}
