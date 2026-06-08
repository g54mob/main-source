using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CPopupSpeedrunCompletedFormatter : IMessagePackFormatter<CPopupSpeedrunCompleted>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CPopupSpeedrunCompleted value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.ThisRunMilliseconds);
			writer.Write(value.PreviousBestMilliseconds);
		}

		public CPopupSpeedrunCompleted Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			CPopupSpeedrunCompleted result = default(CPopupSpeedrunCompleted);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ThisRunMilliseconds = reader.ReadInt32();
					break;
				case 1:
					result.PreviousBestMilliseconds = reader.ReadInt32();
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
