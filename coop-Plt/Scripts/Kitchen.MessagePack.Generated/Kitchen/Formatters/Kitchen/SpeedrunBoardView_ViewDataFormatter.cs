using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SpeedrunBoardView_ViewDataFormatter : IMessagePackFormatter<SpeedrunBoardView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SpeedrunBoardView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.Valid);
			writer.Write(value.Percentile);
			writer.Write(value.DurationMilliseconds);
		}

		public SpeedrunBoardView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			SpeedrunBoardView.ViewData result = default(SpeedrunBoardView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Valid = reader.ReadBoolean();
					break;
				case 1:
					result.Percentile = reader.ReadSingle();
					break;
				case 2:
					result.DurationMilliseconds = reader.ReadInt32();
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
