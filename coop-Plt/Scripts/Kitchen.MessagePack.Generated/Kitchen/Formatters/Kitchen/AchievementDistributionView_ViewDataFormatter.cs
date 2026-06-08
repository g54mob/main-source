using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class AchievementDistributionView_ViewDataFormatter : IMessagePackFormatter<AchievementDistributionView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, AchievementDistributionView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Achievement, options);
		}

		public AchievementDistributionView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			AchievementDistributionView.ViewData result = default(AchievementDistributionView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Achievement = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
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
