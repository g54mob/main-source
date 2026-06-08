using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class UnlockSelectPopupView_ResponseDataFormatter : IMessagePackFormatter<UnlockSelectPopupView.ResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, UnlockSelectPopupView.ResponseData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Consensus);
		}

		public UnlockSelectPopupView.ResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			UnlockSelectPopupView.ResponseData result = default(UnlockSelectPopupView.ResponseData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Consensus = reader.ReadInt32();
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
