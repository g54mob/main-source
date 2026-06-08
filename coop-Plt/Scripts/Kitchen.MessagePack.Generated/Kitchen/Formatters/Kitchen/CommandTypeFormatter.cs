using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CommandTypeFormatter : IMessagePackFormatter<CommandType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CommandType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public CommandType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (CommandType)reader.ReadInt32();
		}
	}
}
