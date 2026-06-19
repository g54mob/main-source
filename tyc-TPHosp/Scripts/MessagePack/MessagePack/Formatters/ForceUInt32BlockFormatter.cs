namespace MessagePack.Formatters
{
	public sealed class ForceUInt32BlockFormatter : IMessagePackFormatter<uint>, IMessagePackFormatter
	{
		public static readonly ForceUInt32BlockFormatter Instance = new ForceUInt32BlockFormatter();

		private ForceUInt32BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, uint value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteUInt32ForceUInt32Block(ref bytes, offset, value);
		}

		public uint Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadUInt32(bytes, offset, out readSize);
		}
	}
}
