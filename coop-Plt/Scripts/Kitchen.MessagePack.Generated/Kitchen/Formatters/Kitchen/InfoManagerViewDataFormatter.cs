using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class InfoManagerViewDataFormatter : IMessagePackFormatter<InfoManagerViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, InfoManagerViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<List<InfoManagerPlayerDetail>>().Serialize(ref writer, value.Players, options);
			resolver.GetFormatterWithVerify<List<InfoManagerPeerDetail>>().Serialize(ref writer, value.Peers, options);
		}

		public InfoManagerViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			InfoManagerViewData result = default(InfoManagerViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Players = resolver.GetFormatterWithVerify<List<InfoManagerPlayerDetail>>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Peers = resolver.GetFormatterWithVerify<List<InfoManagerPeerDetail>>().Deserialize(ref reader, options);
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
