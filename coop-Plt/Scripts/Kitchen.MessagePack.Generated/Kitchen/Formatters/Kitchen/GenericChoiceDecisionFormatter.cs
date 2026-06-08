using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class GenericChoiceDecisionFormatter : IMessagePackFormatter<GenericChoiceDecision>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, GenericChoiceDecision value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public GenericChoiceDecision Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (GenericChoiceDecision)reader.ReadInt32();
		}
	}
}
