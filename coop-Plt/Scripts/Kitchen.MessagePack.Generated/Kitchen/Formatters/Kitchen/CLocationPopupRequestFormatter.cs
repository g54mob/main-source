using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CLocationPopupRequestFormatter : IMessagePackFormatter<CLocationPopupRequest>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CLocationPopupRequest value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<CLocationChoice>().Serialize(ref writer, value.Location, options);
		}

		public CLocationPopupRequest Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CLocationPopupRequest result = default(CLocationPopupRequest);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Location = resolver.GetFormatterWithVerify<CLocationChoice>().Deserialize(ref reader, options);
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
