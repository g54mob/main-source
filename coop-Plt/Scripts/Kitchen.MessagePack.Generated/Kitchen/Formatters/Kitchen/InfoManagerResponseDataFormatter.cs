using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class InfoManagerResponseDataFormatter : IMessagePackFormatter<InfoManagerResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, InfoManagerResponseData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<List<InfoManagerResponseUpdate>>().Serialize(ref writer, value.Updates, options);
		}

		public InfoManagerResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			InfoManagerResponseData result = default(InfoManagerResponseData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Updates = resolver.GetFormatterWithVerify<List<InfoManagerResponseUpdate>>().Deserialize(ref reader, options);
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
