using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class KickReasonFormatter : IMessagePackFormatter<KickReason>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, KickReason value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public KickReason Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (KickReason)reader.ReadInt32();
		}
	}
}
