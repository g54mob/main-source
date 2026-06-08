using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class TwitchOptionsView_ViewDataFormatter : IMessagePackFormatter<TwitchOptionsView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, TwitchOptionsView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			writer.Write(value.ItemID);
			resolver.GetFormatterWithVerify<ItemList>().Serialize(ref writer, value.ItemComponents, options);
			writer.Write(value.Index);
		}

		public TwitchOptionsView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			TwitchOptionsView.ViewData result = default(TwitchOptionsView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ItemID = reader.ReadInt32();
					break;
				case 1:
					result.ItemComponents = resolver.GetFormatterWithVerify<ItemList>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Index = reader.ReadInt32();
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
