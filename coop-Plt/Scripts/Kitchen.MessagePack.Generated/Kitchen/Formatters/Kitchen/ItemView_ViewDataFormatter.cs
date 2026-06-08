using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ItemView_ViewDataFormatter : IMessagePackFormatter<ItemView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ItemView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(5);
			writer.Write(value.ItemID);
			resolver.GetFormatterWithVerify<ItemList>().Serialize(ref writer, value.Components, options);
			writer.Write(value.IsDemoLocked);
			writer.Write(value.UndergoingProcess);
			writer.Write(value.IsPartial);
		}

		public ItemView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ItemView.ViewData result = default(ItemView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ItemID = reader.ReadInt32();
					break;
				case 1:
					result.Components = resolver.GetFormatterWithVerify<ItemList>().Deserialize(ref reader, options);
					break;
				case 2:
					result.IsDemoLocked = reader.ReadBoolean();
					break;
				case 3:
					result.UndergoingProcess = reader.ReadBoolean();
					break;
				case 4:
					result.IsPartial = reader.ReadBoolean();
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
