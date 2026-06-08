using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class NewsItemView_ViewDataFormatter : IMessagePackFormatter<NewsItemView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, NewsItemView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(5);
			writer.Write(value.RewardID);
			resolver.GetFormatterWithVerify<NewsItemType>().Serialize(ref writer, value.Type, options);
			writer.Write(value.Active);
			resolver.GetFormatterWithVerify<CExpChange>().Serialize(ref writer, value.ExpChange, options);
			resolver.GetFormatterWithVerify<LossReason>().Serialize(ref writer, value.Reason, options);
		}

		public NewsItemView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			NewsItemView.ViewData result = default(NewsItemView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.RewardID = reader.ReadInt32();
					break;
				case 1:
					result.Type = resolver.GetFormatterWithVerify<NewsItemType>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Active = reader.ReadBoolean();
					break;
				case 3:
					result.ExpChange = resolver.GetFormatterWithVerify<CExpChange>().Deserialize(ref reader, options);
					break;
				case 4:
					result.Reason = resolver.GetFormatterWithVerify<LossReason>().Deserialize(ref reader, options);
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
