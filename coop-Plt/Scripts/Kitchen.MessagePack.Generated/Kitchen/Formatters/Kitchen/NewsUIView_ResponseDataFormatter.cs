using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class NewsUIView_ResponseDataFormatter : IMessagePackFormatter<NewsUIView.ResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, NewsUIView.ResponseData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.RequestNextItem);
			writer.Write(value.RequestPrevItem);
		}

		public NewsUIView.ResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			NewsUIView.ResponseData result = default(NewsUIView.ResponseData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.RequestNextItem = reader.ReadBoolean();
					break;
				case 1:
					result.RequestPrevItem = reader.ReadBoolean();
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
