using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ItemCollectionView_ViewDataFormatter : IMessagePackFormatter<ItemCollectionView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ItemCollectionView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<List<ItemCollectionView.ItemData>>().Serialize(ref writer, value.Items, options);
			writer.Write(value.IsHidden);
		}

		public ItemCollectionView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ItemCollectionView.ViewData result = default(ItemCollectionView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Items = resolver.GetFormatterWithVerify<List<ItemCollectionView.ItemData>>().Deserialize(ref reader, options);
					break;
				case 1:
					result.IsHidden = reader.ReadBoolean();
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
