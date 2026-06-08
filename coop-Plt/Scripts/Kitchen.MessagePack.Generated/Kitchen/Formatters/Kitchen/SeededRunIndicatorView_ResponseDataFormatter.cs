using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SeededRunIndicatorView_ResponseDataFormatter : IMessagePackFormatter<SeededRunIndicatorView.ResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SeededRunIndicatorView.ResponseData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.RequestSeed, options);
		}

		public SeededRunIndicatorView.ResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			SeededRunIndicatorView.ResponseData result = default(SeededRunIndicatorView.ResponseData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.RequestSeed = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
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
