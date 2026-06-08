using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ConveyItemsView_ViewDataFormatter : IMessagePackFormatter<ConveyItemsView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ConveyItemsView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(6);
			writer.Write(value.PushAmount);
			resolver.GetFormatterWithVerify<CConveyPushItems.ConveyState>().Serialize(ref writer, value.State, options);
			writer.Write(value.SmartActive);
			writer.Write(value.SmartFilter);
			resolver.GetFormatterWithVerify<ItemList>().Serialize(ref writer, value.SmartFilterComponents, options);
			resolver.GetFormatterWithVerify<Orientation>().Serialize(ref writer, value.PushDirection, options);
		}

		public ConveyItemsView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ConveyItemsView.ViewData result = default(ConveyItemsView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.PushAmount = reader.ReadSingle();
					break;
				case 1:
					result.State = resolver.GetFormatterWithVerify<CConveyPushItems.ConveyState>().Deserialize(ref reader, options);
					break;
				case 2:
					result.SmartActive = reader.ReadBoolean();
					break;
				case 3:
					result.SmartFilter = reader.ReadInt32();
					break;
				case 4:
					result.SmartFilterComponents = resolver.GetFormatterWithVerify<ItemList>().Deserialize(ref reader, options);
					break;
				case 5:
					result.PushDirection = resolver.GetFormatterWithVerify<Orientation>().Deserialize(ref reader, options);
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
