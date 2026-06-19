namespace MessagePack.Formatters
{
	public sealed class ForceUInt16BlockArrayFormatter : IMessagePackFormatter<ushort[]>, IMessagePackFormatter
	{
		public static readonly ForceUInt16BlockArrayFormatter Instance = new ForceUInt16BlockArrayFormatter();

		private ForceUInt16BlockArrayFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, ushort[] value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteArrayHeader(ref bytes, offset, value.Length);
			for (int i = 0; i < value.Length; i++)
			{
				offset += MessagePackBinary.WriteUInt16ForceUInt16Block(ref bytes, offset, value[i]);
			}
			return offset - num;
		}

		public ushort[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
			offset += readSize;
			ushort[] array = new ushort[num2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = MessagePackBinary.ReadUInt16(bytes, offset, out readSize);
				offset += readSize;
			}
			readSize = offset - num;
			return array;
		}
	}
}
