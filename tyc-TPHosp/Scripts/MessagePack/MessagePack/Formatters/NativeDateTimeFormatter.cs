using System;

namespace MessagePack.Formatters
{
	public sealed class NativeDateTimeFormatter : IMessagePackFormatter<DateTime>, IMessagePackFormatter
	{
		public static readonly NativeDateTimeFormatter Instance = new NativeDateTimeFormatter();

		public int Serialize(ref byte[] bytes, int offset, DateTime value, IFormatterResolver formatterResolver)
		{
			long value2 = value.ToBinary();
			return MessagePackBinary.WriteInt64(ref bytes, offset, value2);
		}

		public DateTime Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.GetMessagePackType(bytes, offset) == MessagePackType.Extension)
			{
				return DateTimeFormatter.Instance.Deserialize(bytes, offset, formatterResolver, out readSize);
			}
			return DateTime.FromBinary(MessagePackBinary.ReadInt64(bytes, offset, out readSize));
		}
	}
}
