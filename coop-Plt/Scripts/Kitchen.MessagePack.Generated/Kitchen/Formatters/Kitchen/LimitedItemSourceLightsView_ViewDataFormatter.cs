using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class LimitedItemSourceLightsView_ViewDataFormatter : IMessagePackFormatter<LimitedItemSourceLightsView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, LimitedItemSourceLightsView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.DisplayedType);
			writer.Write(value.Amount);
		}

		public LimitedItemSourceLightsView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			LimitedItemSourceLightsView.ViewData result = default(LimitedItemSourceLightsView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.DisplayedType = reader.ReadInt32();
					break;
				case 1:
					result.Amount = reader.ReadInt32();
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
