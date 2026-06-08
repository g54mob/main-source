using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class WarningLevelFormatter : IMessagePackFormatter<WarningLevel>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, WarningLevel value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public WarningLevel Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (WarningLevel)reader.ReadInt32();
		}
	}
}
