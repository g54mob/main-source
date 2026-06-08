using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ItemSourceView_ViewDataFormatter : IMessagePackFormatter<ItemSourceView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ItemSourceView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.IsGrabbed);
			writer.Write(value.IconPrefab);
		}

		public ItemSourceView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ItemSourceView.ViewData result = default(ItemSourceView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IsGrabbed = reader.ReadBoolean();
					break;
				case 1:
					result.IconPrefab = reader.ReadInt32();
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
