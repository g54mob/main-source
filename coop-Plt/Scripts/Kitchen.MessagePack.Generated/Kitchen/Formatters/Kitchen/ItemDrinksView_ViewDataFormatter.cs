using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ItemDrinksView_ViewDataFormatter : IMessagePackFormatter<ItemDrinksView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ItemDrinksView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<DrinkData>().Serialize(ref writer, value.Drink, options);
		}

		public ItemDrinksView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ItemDrinksView.ViewData result = default(ItemDrinksView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Drink = resolver.GetFormatterWithVerify<DrinkData>().Deserialize(ref reader, options);
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
