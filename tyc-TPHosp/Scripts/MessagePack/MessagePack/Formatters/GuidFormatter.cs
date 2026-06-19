using System;
using MessagePack.Internal;

namespace MessagePack.Formatters
{
	public sealed class GuidFormatter : IMessagePackFormatter<Guid>, IMessagePackFormatter
	{
		public static readonly IMessagePackFormatter<Guid> Instance = new GuidFormatter();

		private GuidFormatter()
		{
		}

		public int Serialize(ref byte[] bytes, int offset, Guid value, IFormatterResolver formatterResolver)
		{
			MessagePackBinary.EnsureCapacity(ref bytes, offset, 38);
			bytes[offset] = 217;
			bytes[offset + 1] = 36;
			new GuidBits(ref value).Write(bytes, offset + 2);
			return 38;
		}

		public Guid Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			return new GuidBits(MessagePackBinary.ReadStringSegment(bytes, offset, out readSize)).Value;
		}
	}
}
