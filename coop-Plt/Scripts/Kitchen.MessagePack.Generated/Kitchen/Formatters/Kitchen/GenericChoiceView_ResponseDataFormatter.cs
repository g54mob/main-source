using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class GenericChoiceView_ResponseDataFormatter : IMessagePackFormatter<GenericChoiceView.ResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, GenericChoiceView.ResponseData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<GenericChoiceDecision>().Serialize(ref writer, value.Choice, options);
		}

		public GenericChoiceView.ResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			GenericChoiceView.ResponseData result = default(GenericChoiceView.ResponseData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Choice = resolver.GetFormatterWithVerify<GenericChoiceDecision>().Deserialize(ref reader, options);
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
