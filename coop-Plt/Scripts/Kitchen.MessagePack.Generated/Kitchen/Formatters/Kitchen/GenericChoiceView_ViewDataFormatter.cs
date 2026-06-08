using System;
using System.Collections.Generic;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class GenericChoiceView_ViewDataFormatter : IMessagePackFormatter<GenericChoiceView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, GenericChoiceView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(5);
			resolver.GetFormatterWithVerify<List<PlayerInputData>>().Serialize(ref writer, value.Inputs, options);
			resolver.GetFormatterWithVerify<GenericChoiceType>().Serialize(ref writer, value.Type, options);
			resolver.GetFormatterWithVerify<PopupType>().Serialize(ref writer, value.TextSet, options);
			writer.Write(value.IsPaused);
			resolver.GetFormatterWithVerify<IManagedPopupData>().Serialize(ref writer, value.PopupData, options);
		}

		public GenericChoiceView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			GenericChoiceView.ViewData result = default(GenericChoiceView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Inputs = resolver.GetFormatterWithVerify<List<PlayerInputData>>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Type = resolver.GetFormatterWithVerify<GenericChoiceType>().Deserialize(ref reader, options);
					break;
				case 2:
					result.TextSet = resolver.GetFormatterWithVerify<PopupType>().Deserialize(ref reader, options);
					break;
				case 3:
					result.IsPaused = reader.ReadBoolean();
					break;
				case 4:
					result.PopupData = resolver.GetFormatterWithVerify<IManagedPopupData>().Deserialize(ref reader, options);
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
