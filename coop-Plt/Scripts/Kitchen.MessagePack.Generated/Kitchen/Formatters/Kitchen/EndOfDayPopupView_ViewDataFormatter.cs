using System;
using System.Collections.Generic;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class EndOfDayPopupView_ViewDataFormatter : IMessagePackFormatter<EndOfDayPopupView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, EndOfDayPopupView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			resolver.GetFormatterWithVerify<List<PlayerInputData>>().Serialize(ref writer, value.Inputs, options);
			resolver.GetFormatterWithVerify<CPopupEndDayData>().Serialize(ref writer, value.PopupData, options);
			resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Identifiers, options);
			resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Amounts, options);
		}

		public EndOfDayPopupView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			EndOfDayPopupView.ViewData result = default(EndOfDayPopupView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Inputs = resolver.GetFormatterWithVerify<List<PlayerInputData>>().Deserialize(ref reader, options);
					break;
				case 1:
					result.PopupData = resolver.GetFormatterWithVerify<CPopupEndDayData>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Identifiers = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
					break;
				case 3:
					result.Amounts = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
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
