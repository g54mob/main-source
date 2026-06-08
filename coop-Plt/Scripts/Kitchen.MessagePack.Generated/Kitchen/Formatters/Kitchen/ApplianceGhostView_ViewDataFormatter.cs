using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ApplianceGhostView_ViewDataFormatter : IMessagePackFormatter<ApplianceGhostView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ApplianceGhostView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.ApplianceID);
			writer.Write(value.IsHappy);
			writer.Write(value.IsSale);
		}

		public ApplianceGhostView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ApplianceGhostView.ViewData result = default(ApplianceGhostView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ApplianceID = reader.ReadInt32();
					break;
				case 1:
					result.IsHappy = reader.ReadBoolean();
					break;
				case 2:
					result.IsSale = reader.ReadBoolean();
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
