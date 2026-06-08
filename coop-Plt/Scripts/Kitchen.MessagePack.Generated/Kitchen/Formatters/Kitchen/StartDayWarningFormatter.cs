using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class StartDayWarningFormatter : IMessagePackFormatter<StartDayWarning>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, StartDayWarning value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public StartDayWarning Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (StartDayWarning)reader.ReadInt32();
		}
	}
}
