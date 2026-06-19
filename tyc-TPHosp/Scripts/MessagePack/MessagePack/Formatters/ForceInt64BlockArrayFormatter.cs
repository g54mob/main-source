namespace MessagePack.Formatters
{
	public sealed class ForceInt64BlockArrayFormatter : IMessagePackFormatter<long[]>, IMessagePackFormatter
	{
		public static readonly ForceInt64BlockArrayFormatter Instance = new ForceInt64BlockArrayFormatter();

		private ForceInt64BlockArrayFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, long[] value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteArrayHeader(ref bytes, offset, value.Length);
			for (int i = 0; i < value.Length; i++)
			{
				offset += MessagePackBinary.WriteInt64ForceInt64Block(ref bytes, offset, value[i]);
			}
			return offset - num;
		}

		public long[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
			offset += readSize;
			long[] array = new long[num2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = MessagePackBinary.ReadInt64(bytes, offset, out readSize);
				offset += readSize;
			}
			readSize = offset - num;
			return array;
		}
	}
}
