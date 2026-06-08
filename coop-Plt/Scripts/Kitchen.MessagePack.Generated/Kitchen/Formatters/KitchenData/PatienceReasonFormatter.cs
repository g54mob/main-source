using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.KitchenData
{
	public sealed class PatienceReasonFormatter : IMessagePackFormatter<PatienceReason>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PatienceReason value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public PatienceReason Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (PatienceReason)reader.ReadInt32();
		}
	}
}
