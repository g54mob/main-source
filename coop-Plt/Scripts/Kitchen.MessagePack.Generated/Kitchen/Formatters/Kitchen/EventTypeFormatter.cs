using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class EventTypeFormatter : IMessagePackFormatter<EventType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, EventType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public EventType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (EventType)reader.ReadInt32();
		}
	}
}
