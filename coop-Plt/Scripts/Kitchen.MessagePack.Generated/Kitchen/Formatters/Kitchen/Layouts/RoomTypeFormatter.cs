using Kitchen.Layouts;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen.Layouts
{
	public sealed class RoomTypeFormatter : IMessagePackFormatter<RoomType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, RoomType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public RoomType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (RoomType)reader.ReadInt32();
		}
	}
}
