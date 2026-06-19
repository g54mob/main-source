namespace MessagePack.Formatters
{
	public sealed class NullableForceUInt64BlockFormatter : IMessagePackFormatter<ulong?>, IMessagePackFormatter
	{
		public static readonly NullableForceUInt64BlockFormatter Instance = new NullableForceUInt64BlockFormatter();

		private NullableForceUInt64BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, ulong? value, IFormatterResolver formatterResolver)
		{
			if (!value.HasValue)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			return MessagePackBinary.WriteUInt64ForceUInt64Block(ref bytes, offset, value.Value);
		}

		public ulong? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			return MessagePackBinary.ReadUInt64(bytes, offset, out readSize);
		}
	}
}
