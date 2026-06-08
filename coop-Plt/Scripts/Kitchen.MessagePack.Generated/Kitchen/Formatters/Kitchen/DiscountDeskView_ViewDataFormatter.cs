using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class DiscountDeskView_ViewDataFormatter : IMessagePackFormatter<DiscountDeskView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, DiscountDeskView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.GrantsAmount);
			writer.Write(value.IsLocked);
			writer.Write(value.Show);
		}

		public DiscountDeskView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			DiscountDeskView.ViewData result = default(DiscountDeskView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.GrantsAmount = reader.ReadSingle();
					break;
				case 1:
					result.IsLocked = reader.ReadBoolean();
					break;
				case 2:
					result.Show = reader.ReadBoolean();
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
