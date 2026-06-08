using System;
using System.Collections.Generic;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class NewsUIView_ViewDataFormatter : IMessagePackFormatter<NewsUIView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, NewsUIView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<List<PlayerInputData>>().Serialize(ref writer, value.Inputs, options);
			writer.Write(value.RewardID);
			resolver.GetFormatterWithVerify<NewsItemType>().Serialize(ref writer, value.Type, options);
		}

		public NewsUIView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			NewsUIView.ViewData result = default(NewsUIView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Inputs = resolver.GetFormatterWithVerify<List<PlayerInputData>>().Deserialize(ref reader, options);
					break;
				case 1:
					result.RewardID = reader.ReadInt32();
					break;
				case 2:
					result.Type = resolver.GetFormatterWithVerify<NewsItemType>().Deserialize(ref reader, options);
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
