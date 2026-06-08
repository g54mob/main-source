using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class LossReasonFormatter : IMessagePackFormatter<LossReason>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, LossReason value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public LossReason Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (LossReason)reader.ReadInt32();
		}
	}
}
