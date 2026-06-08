using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class MoneyPopupView_ViewDataFormatter : IMessagePackFormatter<MoneyPopupView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, MoneyPopupView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.Amount);
			writer.Write(value.TwitchBits);
		}

		public MoneyPopupView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			MoneyPopupView.ViewData result = default(MoneyPopupView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Amount = reader.ReadInt32();
					break;
				case 1:
					result.TwitchBits = reader.ReadInt32();
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
