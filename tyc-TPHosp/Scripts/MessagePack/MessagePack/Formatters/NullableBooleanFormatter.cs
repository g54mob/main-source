namespace MessagePack.Formatters
{
	public sealed class NullableBooleanFormatter : IMessagePackFormatter<bool?>, IMessagePackFormatter
	{
		public static readonly NullableBooleanFormatter Instance = new NullableBooleanFormatter();

		private NullableBooleanFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, bool? value, IFormatterResolver formatterResolver)
		{
			if (!value.HasValue)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			return MessagePackBinary.WriteBoolean(ref bytes, offset, value.Value);
		}

		public bool? Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			return MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
		}
	}
}
