using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Controllers
{
	public sealed class ButtonFormatter : IMessagePackFormatter<Button>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, Button value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public Button Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (Button)reader.ReadInt32();
		}
	}
}
