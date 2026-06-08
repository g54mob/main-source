using Kitchen.Layouts;
using Kitchen.Layouts.Features;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen.Layouts.Features
{
	public sealed class FeatureFormatter : IMessagePackFormatter<Feature>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, Feature value, MessagePackSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNil();
				return;
			}
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<LayoutPosition>().Serialize(ref writer, value.Tile1, options);
			resolver.GetFormatterWithVerify<LayoutPosition>().Serialize(ref writer, value.Tile2, options);
			resolver.GetFormatterWithVerify<FeatureType>().Serialize(ref writer, value.Type, options);
		}

		public Feature Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			LayoutPosition tile = default(LayoutPosition);
			LayoutPosition tile2 = default(LayoutPosition);
			FeatureType type = FeatureType.Generic;
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					tile = resolver.GetFormatterWithVerify<LayoutPosition>().Deserialize(ref reader, options);
					break;
				case 1:
					tile2 = resolver.GetFormatterWithVerify<LayoutPosition>().Deserialize(ref reader, options);
					break;
				case 2:
					type = resolver.GetFormatterWithVerify<FeatureType>().Deserialize(ref reader, options);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			Feature result = new Feature(tile, tile2, type);
			reader.Depth--;
			return result;
		}
	}
}
