using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class StartDayWarningView_ResponseDataFormatter : IMessagePackFormatter<StartDayWarningView.ResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, StartDayWarningView.ResponseData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.IsComplete);
		}

		public StartDayWarningView.ResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			StartDayWarningView.ResponseData result = default(StartDayWarningView.ResponseData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.IsComplete = reader.ReadBoolean();
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
