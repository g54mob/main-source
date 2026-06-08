using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ViewModeFormatter : IMessagePackFormatter<ViewMode>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ViewMode value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public ViewMode Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (ViewMode)reader.ReadInt32();
		}
	}
}
