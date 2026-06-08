using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class EndgamePopupView_ResponseDataFormatter : IMessagePackFormatter<EndgamePopupView.ResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, EndgamePopupView.ResponseData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.IsComplete);
		}

		public EndgamePopupView.ResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			EndgamePopupView.ResponseData result = default(EndgamePopupView.ResponseData);
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
