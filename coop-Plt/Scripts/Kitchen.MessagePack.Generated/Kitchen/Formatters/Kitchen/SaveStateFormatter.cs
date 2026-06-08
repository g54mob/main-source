using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SaveStateFormatter : IMessagePackFormatter<SaveState>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SaveState value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public SaveState Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (SaveState)reader.ReadInt32();
		}
	}
}
