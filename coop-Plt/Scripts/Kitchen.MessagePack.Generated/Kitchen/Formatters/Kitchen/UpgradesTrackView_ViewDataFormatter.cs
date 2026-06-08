using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class UpgradesTrackView_ViewDataFormatter : IMessagePackFormatter<UpgradesTrackView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, UpgradesTrackView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Level);
		}

		public UpgradesTrackView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			UpgradesTrackView.ViewData result = default(UpgradesTrackView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Level = reader.ReadInt32();
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
