using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CGenericChoicePopupFormatter : IMessagePackFormatter<CGenericChoicePopup>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CGenericChoicePopup value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<GenericChoiceType>().Serialize(ref writer, value.Type, options);
			resolver.GetFormatterWithVerify<GenericChoiceDecision>().Serialize(ref writer, value.Decision, options);
			resolver.GetFormatterWithVerify<PopupType>().Serialize(ref writer, value.TextSet, options);
		}

		public CGenericChoicePopup Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CGenericChoicePopup result = default(CGenericChoicePopup);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Type = resolver.GetFormatterWithVerify<GenericChoiceType>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Decision = resolver.GetFormatterWithVerify<GenericChoiceDecision>().Deserialize(ref reader, options);
					break;
				case 2:
					result.TextSet = resolver.GetFormatterWithVerify<PopupType>().Deserialize(ref reader, options);
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
