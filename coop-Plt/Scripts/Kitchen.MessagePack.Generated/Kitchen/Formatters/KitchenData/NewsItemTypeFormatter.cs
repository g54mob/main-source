using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.KitchenData
{
	public sealed class NewsItemTypeFormatter : IMessagePackFormatter<NewsItemType>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, NewsItemType value, MessagePackSerializerOptions options)
		{
			writer.Write((int)value);
		}

		public NewsItemType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			return (NewsItemType)reader.ReadInt32();
		}
	}
}
