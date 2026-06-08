using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PackSaveCardSets_V1Formatter : IMessagePackFormatter<PackSaveCardSets.V1>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PackSaveCardSets.V1 value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			writer.Write(value.Tier);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
			resolver.GetFormatterWithVerify<List<int>>().Serialize(ref writer, value.Cards, options);
		}

		public PackSaveCardSets.V1 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PackSaveCardSets.V1 result = default(PackSaveCardSets.V1);
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
					result.Cards = resolver.GetFormatterWithVerify<List<int>>().Deserialize(ref reader, options);
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
