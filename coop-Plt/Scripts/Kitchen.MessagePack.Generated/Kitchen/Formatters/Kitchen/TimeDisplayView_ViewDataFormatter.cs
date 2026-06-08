using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class TimeDisplayView_ViewDataFormatter : IMessagePackFormatter<TimeDisplayView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, TimeDisplayView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(9);
			writer.Write(value.TimeOfDay);
			writer.Write(value.IsNight);
			writer.Write(value.Day);
			writer.Write(value.IsPractice);
			writer.Write(value.MorningRush);
			writer.Write(value.LunchRush);
			writer.Write(value.DinnerRush);
			writer.Write(value.HasPrepTime);
			writer.Write(value.Setting);
		}

		public TimeDisplayView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			TimeDisplayView.ViewData result = default(TimeDisplayView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.TimeOfDay = reader.ReadSingle();
					break;
				case 1:
					result.IsNight = reader.ReadBoolean();
					break;
				case 2:
					result.Day = reader.ReadInt32();
					break;
				case 3:
					result.IsPractice = reader.ReadBoolean();
					break;
				case 4:
					result.MorningRush = reader.ReadBoolean();
					break;
				case 5:
					result.LunchRush = reader.ReadBoolean();
					break;
				case 6:
					result.DinnerRush = reader.ReadBoolean();
					break;
				case 7:
					result.HasPrepTime = reader.ReadBoolean();
					break;
				case 8:
					result.Setting = reader.ReadInt32();
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
