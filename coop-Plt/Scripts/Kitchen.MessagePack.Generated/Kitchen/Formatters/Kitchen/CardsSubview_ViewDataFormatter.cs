using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CardsSubview_ViewDataFormatter : IMessagePackFormatter<CardsSubview.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CardsSubview.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<List<int>>().Serialize(ref writer, value.Unlocks, options);
		}

		public CardsSubview.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CardsSubview.ViewData result = default(CardsSubview.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Unlocks = resolver.GetFormatterWithVerify<List<int>>().Deserialize(ref reader, options);
				}
				else
				{
					reader.Skip();
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
