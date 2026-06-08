using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class DayDisplayView_ViewDataFormatter : IMessagePackFormatter<DayDisplayView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, DayDisplayView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(17);
			writer.Write(value.Day);
			writer.Write(value.IsPractice);
			writer.Write(value.IsNight);
			writer.Write(value.Tier);
			resolver.GetFormatterWithVerify<Seed>().Serialize(ref writer, value.Seed, options);
			writer.Write(value.CurrentSetting);
			writer.Write(value.HasRunTimer);
			writer.Write(value.IsSpeedrun);
			resolver.GetFormatterWithVerify<SpeedrunScore>().Serialize(ref writer, value.SpeedrunScore, options);
			writer.Write(value.ShowSeed);
			writer.Write(value.SeedAffectsEverything);
			writer.Write(value.IsSpeedrunMode);
			writer.Write(value.LivesplitScore);
			writer.Write(value.LivesplitIsRunning);
			writer.Write(value.Heat);
			writer.Write(value.AlwaysShowRunTimerEnabled);
			writer.Write(value.LiveSplitOptionEnabled);
		}

		public DayDisplayView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			DayDisplayView.ViewData result = default(DayDisplayView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Day = reader.ReadInt32();
					break;
				case 1:
					result.IsPractice = reader.ReadBoolean();
					break;
				case 2:
					result.IsNight = reader.ReadBoolean();
					break;
				case 3:
					result.Tier = reader.ReadInt32();
					break;
				case 4:
					result.Seed = resolver.GetFormatterWithVerify<Seed>().Deserialize(ref reader, options);
					break;
				case 5:
					result.CurrentSetting = reader.ReadInt32();
					break;
				case 6:
					result.HasRunTimer = reader.ReadBoolean();
					break;
				case 7:
					result.IsSpeedrun = reader.ReadBoolean();
					break;
				case 8:
					result.SpeedrunScore = resolver.GetFormatterWithVerify<SpeedrunScore>().Deserialize(ref reader, options);
					break;
				case 9:
					result.ShowSeed = reader.ReadBoolean();
					break;
				case 10:
					result.SeedAffectsEverything = reader.ReadBoolean();
					break;
				case 11:
					result.IsSpeedrunMode = reader.ReadBoolean();
					break;
				case 12:
					result.LivesplitScore = reader.ReadInt64();
					break;
				case 13:
					result.LivesplitIsRunning = reader.ReadBoolean();
					break;
				case 14:
					result.Heat = reader.ReadInt32();
					break;
				case 15:
					result.AlwaysShowRunTimerEnabled = reader.ReadBoolean();
					break;
				case 16:
					result.LiveSplitOptionEnabled = reader.ReadBoolean();
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
