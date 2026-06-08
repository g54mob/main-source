using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PackSaveCardSets_V4Formatter : IMessagePackFormatter<PackSaveCardSets.V4>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PackSaveCardSets.V4 value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			writer.Write(value.Tier);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
			resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Cards, options);
			resolver.GetFormatterWithVerify<Seed>().Serialize(ref writer, value.MapSeed, options);
		}

		public PackSaveCardSets.V4 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PackSaveCardSets.V4 result = default(PackSaveCardSets.V4);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Tier = reader.ReadInt32();
					break;
				case 1:
					result.Name = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Cards = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
					break;
				case 3:
					result.MapSeed = resolver.GetFormatterWithVerify<Seed>().Deserialize(ref reader, options);
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
