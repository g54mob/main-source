using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ExpTrackView_ViewDataFormatter : IMessagePackFormatter<ExpTrackView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ExpTrackView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.Level);
			writer.WriteNil();
			writer.Write(value.Experience);
		}

		public ExpTrackView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ExpTrackView.ViewData result = default(ExpTrackView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Level = reader.ReadInt32();
					break;
				case 2:
					result.Experience = reader.ReadInt32();
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
