using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class StartDayWarningView_ViewDataFormatter : IMessagePackFormatter<StartDayWarningView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, StartDayWarningView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(6);
			resolver.GetFormatterWithVerify<StartDayWarning>().Serialize(ref writer, value.Warning, options);
			resolver.GetFormatterWithVerify<WarningLevel>().Serialize(ref writer, value.WarningLevel, options);
			resolver.GetFormatterWithVerify<List<PlayerInputData>>().Serialize(ref writer, value.Inputs, options);
			resolver.GetFormatterWithVerify<HashSet<int>>().Serialize(ref writer, value.ClearReadyState, options);
			writer.Write(value.Paused);
			writer.Write(value.IsNight);
		}

		public StartDayWarningView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			StartDayWarningView.ViewData result = default(StartDayWarningView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Warning = resolver.GetFormatterWithVerify<StartDayWarning>().Deserialize(ref reader, options);
					break;
				case 1:
					result.WarningLevel = resolver.GetFormatterWithVerify<WarningLevel>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Inputs = resolver.GetFormatterWithVerify<List<PlayerInputData>>().Deserialize(ref reader, options);
					break;
				case 3:
					result.ClearReadyState = resolver.GetFormatterWithVerify<HashSet<int>>().Deserialize(ref reader, options);
					break;
				case 4:
					result.Paused = reader.ReadBoolean();
					break;
				case 5:
					result.IsNight = reader.ReadBoolean();
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
