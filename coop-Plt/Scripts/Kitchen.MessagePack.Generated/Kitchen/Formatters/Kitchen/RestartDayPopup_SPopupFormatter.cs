using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class RestartDayPopup_SPopupFormatter : IMessagePackFormatter<RestartDayPopup.SPopup>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, RestartDayPopup.SPopup value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<LossReason>().Serialize(ref writer, value.Reason, options);
		}

		public RestartDayPopup.SPopup Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			RestartDayPopup.SPopup result = default(RestartDayPopup.SPopup);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Reason = resolver.GetFormatterWithVerify<LossReason>().Deserialize(ref reader, options);
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
