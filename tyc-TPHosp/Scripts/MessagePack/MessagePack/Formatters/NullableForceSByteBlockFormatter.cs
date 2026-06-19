namespace MessagePack.Formatters
{
	public sealed class NullableForceSByteBlockFormatter : IMessagePackFormatter<sbyte?>, IMessagePackFormatter
	{
		public static readonly NullableForceSByteBlockFormatter Instance = new NullableForceSByteBlockFormatter();

		private NullableForceSByteBlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, sbyte? value, IFormatterResolver formatterResolver)
		{
			if (!value.HasValue)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			return MessagePackBinary.WriteSByteForceSByteBlock(ref bytes, offset, value.Value);
		}

		public sbyte? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			return MessagePackBinary.ReadSByte(bytes, offset, out readSize);
		}
	}
}
