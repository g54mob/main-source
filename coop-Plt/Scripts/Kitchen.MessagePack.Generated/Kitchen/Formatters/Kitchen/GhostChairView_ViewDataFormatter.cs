using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class GhostChairView_ViewDataFormatter : IMessagePackFormatter<GhostChairView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, GhostChairView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.IsDisabled);
			writer.Write(value.IsPathable);
		}

		public GhostChairView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			GhostChairView.ViewData result = default(GhostChairView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IsDisabled = reader.ReadBoolean();
					break;
				case 1:
					result.IsPathable = reader.ReadBoolean();
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
