using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class EndOfDayPopupView_ResponseDataFormatter : IMessagePackFormatter<EndOfDayPopupView.ResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, EndOfDayPopupView.ResponseData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Dismiss);
		}

		public EndOfDayPopupView.ResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			EndOfDayPopupView.ResponseData result = default(EndOfDayPopupView.ResponseData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Dismiss = reader.ReadBoolean();
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
