namespace MessagePack.Formatters
{
	public sealed class ForceInt16BlockArrayFormatter : IMessagePackFormatter<short[]>, IMessagePackFormatter
	{
		public static readonly ForceInt16BlockArrayFormatter Instance = new ForceInt16BlockArrayFormatter();

		private ForceInt16BlockArrayFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, short[] value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteArrayHeader(ref bytes, offset, value.Length);
			for (int i = 0; i < value.Length; i++)
			{
				offset += MessagePackBinary.WriteInt16ForceInt16Block(ref bytes, offset, value[i]);
			}
			return offset - num;
		}

		public short[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
			offset += readSize;
			short[] array = new short[num2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = MessagePackBinary.ReadInt16(bytes, offset, out readSize);
				offset += readSize;
			}
			readSize = offset - num;
			return array;
		}
	}
}
