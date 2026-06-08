using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SoundEventView_ViewDataFormatter : IMessagePackFormatter<SoundEventView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SoundEventView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<SoundEvent>().Serialize(ref writer, value.Event, options);
		}

		public SoundEventView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			SoundEventView.ViewData result = default(SoundEventView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Event = resolver.GetFormatterWithVerify<SoundEvent>().Deserialize(ref reader, options);
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
