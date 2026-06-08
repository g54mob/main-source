using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ItemHolderView_ItemHolderDataFormatter : IMessagePackFormatter<ItemHolderView.ItemHolderData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ItemHolderView.ItemHolderData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			resolver.GetFormatterWithVerify<ViewIdentifier>().Serialize(ref writer, value.Item, options);
			writer.Write(value.StorageIndex);
			writer.Write(value.IsStorage);
			writer.Write(value.IsTool);
		}

		public ItemHolderView.ItemHolderData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ItemHolderView.ItemHolderData result = default(ItemHolderView.ItemHolderData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Item = resolver.GetFormatterWithVerify<ViewIdentifier>().Deserialize(ref reader, options);
					break;
				case 1:
					result.StorageIndex = reader.ReadInt32();
					break;
				case 2:
					result.IsStorage = reader.ReadBoolean();
					break;
				case 3:
					result.IsTool = reader.ReadBoolean();
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
