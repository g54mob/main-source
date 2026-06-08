using System.Collections.Generic;
using Kitchen.Layouts;
using Kitchen.Layouts.Features;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen.Layouts
{
	public sealed class LayoutBlueprintFormatter : IMessagePackFormatter<LayoutBlueprint>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, LayoutBlueprint value, MessagePackSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNil();
				return;
			}
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			writer.Write(value.ID);
			resolver.GetFormatterWithVerify<Dictionary<LayoutPosition, Room>>().Serialize(ref writer, value.Tiles, options);
			resolver.GetFormatterWithVerify<List<Feature>>().Serialize(ref writer, value.Features, options);
		}

		public LayoutBlueprint Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			LayoutBlueprint layoutBlueprint = new LayoutBlueprint();
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					layoutBlueprint.ID = reader.ReadInt32();
					break;
				case 1:
					layoutBlueprint.Tiles = resolver.GetFormatterWithVerify<Dictionary<LayoutPosition, Room>>().Deserialize(ref reader, options);
					break;
				case 2:
					layoutBlueprint.Features = resolver.GetFormatterWithVerify<List<Feature>>().Deserialize(ref reader, options);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			reader.Depth--;
			return layoutBlueprint;
		}
	}
}
