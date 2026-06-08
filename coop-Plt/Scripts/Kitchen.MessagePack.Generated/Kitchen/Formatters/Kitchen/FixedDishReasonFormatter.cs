using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class FixedDishReasonFormatter : IMessagePackFormatter<FixedDishReason>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, FixedDishReason value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public FixedDishReason Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (FixedDishReason)reader.ReadInt32();
		}
	}
}
