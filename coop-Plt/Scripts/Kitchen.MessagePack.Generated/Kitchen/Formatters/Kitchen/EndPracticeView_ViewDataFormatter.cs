using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class EndPracticeView_ViewDataFormatter : IMessagePackFormatter<EndPracticeView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, EndPracticeView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<List<PlayerInputData>>().Serialize(ref writer, value.Inputs, options);
			writer.Write(value.Paused);
		}

		public EndPracticeView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			EndPracticeView.ViewData result = default(EndPracticeView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Inputs = resolver.GetFormatterWithVerify<List<PlayerInputData>>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Paused = reader.ReadBoolean();
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
