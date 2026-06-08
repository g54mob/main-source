using System;
using MessagePack;
using MessagePack.Formatters;
using Unity.Collections;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class LayoutDecorMapFormatter : IMessagePackFormatter<LayoutDecorMap>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, LayoutDecorMap value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<FixedListInt64>().Serialize(ref writer, value.Rooms, options);
			resolver.GetFormatterWithVerify<FixedListInt64>().Serialize(ref writer, value.Wallpapers, options);
			resolver.GetFormatterWithVerify<FixedListInt64>().Serialize(ref writer, value.Floors, options);
		}

		public LayoutDecorMap Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			LayoutDecorMap result = default(LayoutDecorMap);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Rooms = resolver.GetFormatterWithVerify<FixedListInt64>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Wallpapers = resolver.GetFormatterWithVerify<FixedListInt64>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Floors = resolver.GetFormatterWithVerify<FixedListInt64>().Deserialize(ref reader, options);
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
