using System;
using MessagePack;
using MessagePack.Formatters;
using Unity.Collections;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class GenericPromptIndicatorView_ViewDataFormatter : IMessagePackFormatter<GenericPromptIndicatorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, GenericPromptIndicatorView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<InputIndicatorMessage>().Serialize(ref writer, value.Message, options);
			writer.Write(value.OpenPromptFor);
			resolver.GetFormatterWithVerify<FixedString64>().Serialize(ref writer, value.AdditionalInfo, options);
		}

		public GenericPromptIndicatorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			GenericPromptIndicatorView.ViewData result = default(GenericPromptIndicatorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Message = resolver.GetFormatterWithVerify<InputIndicatorMessage>().Deserialize(ref reader, options);
					break;
				case 1:
					result.OpenPromptFor = reader.ReadInt32();
					break;
				case 2:
					result.AdditionalInfo = resolver.GetFormatterWithVerify<FixedString64>().Deserialize(ref reader, options);
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
