using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ViewTypeFormatter : IMessagePackFormatter<ViewType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ViewType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public ViewType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (ViewType)reader.ReadInt32();
		}
	}
}
