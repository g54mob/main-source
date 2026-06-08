using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class MessageTypeFormatter : IMessagePackFormatter<MessageType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, MessageType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public MessageType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (MessageType)reader.ReadInt32();
		}
	}
}
