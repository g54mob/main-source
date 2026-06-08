using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.KitchenData
{
	public sealed class PlayerShoeFormatter : IMessagePackFormatter<PlayerShoe>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerShoe value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public PlayerShoe Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (PlayerShoe)reader.ReadInt32();
		}
	}
}
