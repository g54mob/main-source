using Kitchen.Layouts;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen.Layouts
{
	public sealed class FeatureTypeFormatter : IMessagePackFormatter<FeatureType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, FeatureType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public FeatureType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (FeatureType)reader.ReadInt32();
		}
	}
}
