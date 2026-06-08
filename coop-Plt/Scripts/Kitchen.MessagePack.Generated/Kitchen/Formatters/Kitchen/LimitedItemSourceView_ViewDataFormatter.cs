using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class LimitedItemSourceView_ViewDataFormatter : IMessagePackFormatter<LimitedItemSourceView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, LimitedItemSourceView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			writer.Write(value.DisplayedType);
			resolver.GetFormatterWithVerify<ItemList>().Serialize(ref writer, value.DisplayedComponents, options);
			writer.Write(value.Amount);
		}

		public LimitedItemSourceView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			LimitedItemSourceView.ViewData result = default(LimitedItemSourceView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.DisplayedType = reader.ReadInt32();
					break;
				case 1:
					result.DisplayedComponents = resolver.GetFormatterWithVerify<ItemList>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Amount = reader.ReadInt32();
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
