using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class InputIndicatorMessageFormatter : IMessagePackFormatter<InputIndicatorMessage>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, InputIndicatorMessage value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public InputIndicatorMessage Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (InputIndicatorMessage)reader.ReadInt32();
		}
	}
}
