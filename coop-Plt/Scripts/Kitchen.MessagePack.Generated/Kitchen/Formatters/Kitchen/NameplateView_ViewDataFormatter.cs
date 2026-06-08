using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class NameplateView_ViewDataFormatter : IMessagePackFormatter<NameplateView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, NameplateView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			writer.Write(value.RequestingInputSource);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.RestaurantName, options);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.StartingRestaurantName, options);
		}

		public NameplateView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			NameplateView.ViewData result = default(NameplateView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.RequestingInputSource = reader.ReadInt32();
					break;
				case 1:
					result.RestaurantName = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 2:
					result.StartingRestaurantName = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
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
