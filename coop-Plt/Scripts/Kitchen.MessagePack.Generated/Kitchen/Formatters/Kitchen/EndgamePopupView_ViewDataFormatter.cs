using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class EndgamePopupView_ViewDataFormatter : IMessagePackFormatter<EndgamePopupView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, EndgamePopupView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<List<PlayerInputData>>().Serialize(ref writer, value.Inputs, options);
		}

		public EndgamePopupView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			EndgamePopupView.ViewData result = default(EndgamePopupView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Inputs = resolver.GetFormatterWithVerify<List<PlayerInputData>>().Deserialize(ref reader, options);
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
