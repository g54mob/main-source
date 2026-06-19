namespace MessagePack.Formatters
{
	public sealed class ForceUInt64BlockFormatter : IMessagePackFormatter<ulong>, IMessagePackFormatter
	{
		public static readonly ForceUInt64BlockFormatter Instance = new ForceUInt64BlockFormatter();

		private ForceUInt64BlockFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, ulong value, IFormatterResolver formatterResolver)
		{
			return MessagePackBinary.WriteUInt64ForceUInt64Block(ref bytes, offset, value);
		}

		public ulong Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return MessagePackBinary.ReadUInt64(bytes, offset, out readSize);
		}
	}
}
