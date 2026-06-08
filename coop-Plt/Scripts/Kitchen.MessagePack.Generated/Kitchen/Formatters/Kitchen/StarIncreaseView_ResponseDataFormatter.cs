using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class StarIncreaseView_ResponseDataFormatter : IMessagePackFormatter<StarIncreaseView.ResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, StarIncreaseView.ResponseData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.IsComplete);
		}

		public StarIncreaseView.ResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			StarIncreaseView.ResponseData result = default(StarIncreaseView.ResponseData);
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
