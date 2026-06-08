using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Controllers
{
	public sealed class GameStateRequestFormatter : IMessagePackFormatter<GameStateRequest>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, GameStateRequest value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public GameStateRequest Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (GameStateRequest)reader.ReadInt32();
		}
	}
}
