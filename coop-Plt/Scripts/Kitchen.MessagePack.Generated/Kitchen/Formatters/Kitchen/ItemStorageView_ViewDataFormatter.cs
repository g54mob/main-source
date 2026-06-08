using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ItemStorageView_ViewDataFormatter : IMessagePackFormatter<ItemStorageView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ItemStorageView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Count);
		}

		public ItemStorageView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ItemStorageView.ViewData result = default(ItemStorageView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Count = reader.ReadInt32();
				}
				else
				{
					reader.Skip();
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
