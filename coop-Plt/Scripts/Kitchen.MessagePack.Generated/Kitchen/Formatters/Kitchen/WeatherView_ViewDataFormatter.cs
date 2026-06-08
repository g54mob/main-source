using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class WeatherView_ViewDataFormatter : IMessagePackFormatter<WeatherView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, WeatherView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<WeatherMode>().Serialize(ref writer, value.Weather, options);
			writer.Write(value.IsWeatherActive);
		}

		public WeatherView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			WeatherView.ViewData result = default(WeatherView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Weather = resolver.GetFormatterWithVerify<WeatherMode>().Deserialize(ref reader, options);
					break;
				case 1:
					result.IsWeatherActive = reader.ReadBoolean();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
