using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class OutfitSelectorView_ViewDataFormatter : IMessagePackFormatter<OutfitSelectorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, OutfitSelectorView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Outfit, options);
			resolver.GetFormatterWithVerify<Color>().Serialize(ref writer, value.PlayerColour, options);
		}

		public OutfitSelectorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			OutfitSelectorView.ViewData result = default(OutfitSelectorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Outfit = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
					break;
				case 1:
					result.PlayerColour = resolver.GetFormatterWithVerify<Color>().Deserialize(ref reader, options);
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
