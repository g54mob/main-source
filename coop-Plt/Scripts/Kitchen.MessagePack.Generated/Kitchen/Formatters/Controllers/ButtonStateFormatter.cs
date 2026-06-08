using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Controllers
{
	public sealed class ButtonStateFormatter : IMessagePackFormatter<ButtonState>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ButtonState value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public ButtonState Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (ButtonState)reader.ReadInt32();
		}
	}
}
