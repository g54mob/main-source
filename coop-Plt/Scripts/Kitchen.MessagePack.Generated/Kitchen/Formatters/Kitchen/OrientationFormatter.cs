using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class OrientationFormatter : IMessagePackFormatter<Orientation>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, Orientation value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public Orientation Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (Orientation)reader.ReadInt32();
		}
	}
}
