using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SeededRunIndicatorView_ViewDataFormatter : IMessagePackFormatter<SeededRunIndicatorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SeededRunIndicatorView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<Seed>().Serialize(ref writer, value.FixedSeed, options);
			writer.Write(value.IsForcedSeed);
			writer.Write(value.OpenPromptFor);
		}

		public SeededRunIndicatorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			SeededRunIndicatorView.ViewData result = default(SeededRunIndicatorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.FixedSeed = resolver.GetFormatterWithVerify<Seed>().Deserialize(ref reader, options);
					break;
				case 1:
					result.IsForcedSeed = reader.ReadBoolean();
					break;
				case 2:
					result.OpenPromptFor = reader.ReadInt32();
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
