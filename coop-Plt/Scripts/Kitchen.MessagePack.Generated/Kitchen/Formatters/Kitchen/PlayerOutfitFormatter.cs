using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PlayerOutfitFormatter : IMessagePackFormatter<PlayerOutfit>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerOutfit value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public PlayerOutfit Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (PlayerOutfit)reader.ReadInt32();
		}
	}
}
