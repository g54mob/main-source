using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class GenericChoiceTypeFormatter : IMessagePackFormatter<GenericChoiceType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, GenericChoiceType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public GenericChoiceType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (GenericChoiceType)reader.ReadInt32();
		}
	}
}
