using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ItemVariableStorageView_ItemDataFormatter : IMessagePackFormatter<ItemVariableStorageView.ItemData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ItemVariableStorageView.ItemData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			writer.Write(value.Item);
			resolver.GetFormatterWithVerify<ItemList>().Serialize(ref writer, value.ItemList, options);
			writer.Write(value.SplitCount);
			writer.Write(value.SplitMax);
		}

		public ItemVariableStorageView.ItemData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ItemVariableStorageView.ItemData result = default(ItemVariableStorageView.ItemData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Item = reader.ReadInt32();
					break;
				case 1:
					result.ItemList = resolver.GetFormatterWithVerify<ItemList>().Deserialize(ref reader, options);
					break;
				case 2:
					result.SplitCount = reader.ReadInt32();
					break;
				case 3:
					result.SplitMax = reader.ReadInt32();
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
