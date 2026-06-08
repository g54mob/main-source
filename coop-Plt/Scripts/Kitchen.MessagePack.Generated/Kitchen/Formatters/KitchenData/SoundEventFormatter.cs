using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.KitchenData
{
	public sealed class SoundEventFormatter : IMessagePackFormatter<SoundEvent>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SoundEvent value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public SoundEvent Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (SoundEvent)reader.ReadInt32();
		}
	}
}
