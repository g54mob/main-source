using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class EventIndicatorView_ViewDataFormatter : IMessagePackFormatter<EventIndicatorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, EventIndicatorView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<EventType>().Serialize(ref writer, value.Event, options);
		}

		public EventIndicatorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			EventIndicatorView.ViewData result = default(EventIndicatorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Event = resolver.GetFormatterWithVerify<EventType>().Deserialize(ref reader, options);
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
