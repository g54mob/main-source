using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SteamRichPresenceView_ViewDataFormatter : IMessagePackFormatter<SteamRichPresenceView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SteamRichPresenceView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<CRichPresenceData>().Serialize(ref writer, value.Data, options);
		}

		public SteamRichPresenceView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			SteamRichPresenceView.ViewData result = default(SteamRichPresenceView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Data = resolver.GetFormatterWithVerify<CRichPresenceData>().Deserialize(ref reader, options);
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
