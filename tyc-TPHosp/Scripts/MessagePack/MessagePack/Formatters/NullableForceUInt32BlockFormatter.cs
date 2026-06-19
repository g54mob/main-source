namespace MessagePack.Formatters
{
	public sealed class NullableForceUInt32BlockFormatter : IMessagePackFormatter<uint?>, IMessagePackFormatter
	{
		public static readonly NullableForceUInt32BlockFormatter Instance = new NullableForceUInt32BlockFormatter();

		private NullableForceUInt32BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, uint? value, IFormatterResolver formatterResolver)
		{
			if (!value.HasValue)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			return MessagePackBinary.WriteUInt32ForceUInt32Block(ref bytes, offset, value.Value);
		}

		public uint? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			return MessagePackBinary.ReadUInt32(bytes, offset, out readSize);
		}
	}
}
