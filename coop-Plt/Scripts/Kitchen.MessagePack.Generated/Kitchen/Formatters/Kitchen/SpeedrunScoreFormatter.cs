using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SpeedrunScoreFormatter : IMessagePackFormatter<SpeedrunScore>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SpeedrunScore value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<TimeSpan>().Serialize(ref writer, value.Duration, options);
		}

		public SpeedrunScore Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			TimeSpan ts = default(TimeSpan);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					ts = resolver.GetFormatterWithVerify<TimeSpan>().Deserialize(ref reader, options);
				}
				else
				{
					reader.Skip();
				}
			}
			SpeedrunScore result = new SpeedrunScore(ts);
			reader.Depth--;
			return result;
		}
	}
}
