using MessagePack;
using MessagePack.Formatters;
using Platforms;

namespace Kitchen.Formatters.Platforms
{
	public sealed class PlatformTypeFormatter : IMessagePackFormatter<PlatformType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlatformType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public PlatformType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (PlatformType)reader.ReadInt32();
		}
	}
}
