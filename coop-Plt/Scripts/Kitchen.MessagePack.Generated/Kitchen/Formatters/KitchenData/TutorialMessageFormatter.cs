using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.KitchenData
{
	public sealed class TutorialMessageFormatter : IMessagePackFormatter<TutorialMessage>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, TutorialMessage value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public TutorialMessage Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (TutorialMessage)reader.ReadInt32();
		}
	}
}
