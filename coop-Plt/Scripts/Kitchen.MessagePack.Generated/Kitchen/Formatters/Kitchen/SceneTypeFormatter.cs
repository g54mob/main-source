using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SceneTypeFormatter : IMessagePackFormatter<SceneType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SceneType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public SceneType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (SceneType)reader.ReadInt32();
		}
	}
}
