using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.KitchenData
{
	public sealed class DisplayedPatienceFactorFormatter : IMessagePackFormatter<DisplayedPatienceFactor>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, DisplayedPatienceFactor value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public DisplayedPatienceFactor Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (DisplayedPatienceFactor)reader.ReadInt32();
		}
	}
}
