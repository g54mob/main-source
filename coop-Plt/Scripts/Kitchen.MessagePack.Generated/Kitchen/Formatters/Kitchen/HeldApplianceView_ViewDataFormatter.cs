using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class HeldApplianceView_ViewDataFormatter : IMessagePackFormatter<HeldApplianceView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, HeldApplianceView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.ID);
			writer.Write(value.DrawUsing);
		}

		public HeldApplianceView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			HeldApplianceView.ViewData result = default(HeldApplianceView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ID = reader.ReadInt32();
					break;
				case 1:
					result.DrawUsing = reader.ReadInt32();
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
