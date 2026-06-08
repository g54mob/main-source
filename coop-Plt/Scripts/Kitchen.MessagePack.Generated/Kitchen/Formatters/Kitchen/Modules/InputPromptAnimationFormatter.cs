using Kitchen.Modules;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen.Modules
{
	public sealed class InputPromptAnimationFormatter : IMessagePackFormatter<InputPromptAnimation>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, InputPromptAnimation value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public InputPromptAnimation Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (InputPromptAnimation)reader.ReadInt32();
		}
	}
}
