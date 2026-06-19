namespace MessagePack.Formatters
{
	public sealed class ForceByteBlockFormatter : IMessagePackFormatter<byte>, IMessagePackFormatter
	{
		public static readonly ForceByteBlockFormatter Instance = new ForceByteBlockFormatter();

		private ForceByteBlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, byte value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteByteForceByteBlock(ref bytes, offset, value);
		}

		public byte Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadByte(bytes, offset, out readSize);
		}
	}
}
