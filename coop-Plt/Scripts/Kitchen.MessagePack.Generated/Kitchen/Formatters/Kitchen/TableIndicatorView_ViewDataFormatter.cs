using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class TableIndicatorView_ViewDataFormatter : IMessagePackFormatter<TableIndicatorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, TableIndicatorView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			writer.Write(value.Count);
			resolver.GetFormatterWithVerify<DecorationValues>().Serialize(ref writer, value.Decorations, options);
			writer.Write(value.IsBeingLookedAt);
			resolver.GetFormatterWithVerify<ItemList>().Serialize(ref writer, value.Effectors, options);
		}

		public TableIndicatorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			TableIndicatorView.ViewData result = default(TableIndicatorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Count = reader.ReadInt32();
					break;
				case 1:
					result.Decorations = resolver.GetFormatterWithVerify<DecorationValues>().Deserialize(ref reader, options);
					break;
				case 2:
					result.IsBeingLookedAt = reader.ReadBoolean();
					break;
				case 3:
					result.Effectors = resolver.GetFormatterWithVerify<ItemList>().Deserialize(ref reader, options);
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
