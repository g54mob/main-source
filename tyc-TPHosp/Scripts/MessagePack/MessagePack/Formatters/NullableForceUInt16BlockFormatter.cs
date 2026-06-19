namespace MessagePack.Formatters
{
	public sealed class NullableForceUInt16BlockFormatter : IMessagePackFormatter<ushort?>, IMessagePackFormatter
	{
		public static readonly NullableForceUInt16BlockFormatter Instance = new NullableForceUInt16BlockFormatter();

		private NullableForceUInt16BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, ushort? value, IFormatterResolver formatterResolver)
		{
			if (!value.HasValue)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			return MessagePackBinary.WriteUInt16ForceUInt16Block(ref bytes, offset, value.Value);
		}

		public ushort? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			return MessagePackBinary.ReadUInt16(bytes, offset, out readSize);
		}
	}
}
