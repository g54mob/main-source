using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.KitchenData
{
	public sealed class WeatherModeFormatter : IMessagePackFormatter<WeatherMode>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, WeatherMode value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public WeatherMode Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (WeatherMode)reader.ReadInt32();
		}
	}
}
