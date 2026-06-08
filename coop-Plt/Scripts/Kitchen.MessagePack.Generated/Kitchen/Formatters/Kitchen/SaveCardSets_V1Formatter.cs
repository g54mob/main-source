using System;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SaveCardSets_V1Formatter : IMessagePackFormatter<SaveCardSets.V1>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SaveCardSets.V1 value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			writer.Write(value.HasLocation);
			writer.Write(value.Tier);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.Location, options);
		}

		public SaveCardSets.V1 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			SaveCardSets.V1 result = default(SaveCardSets.V1);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.HasLocation = reader.ReadBoolean();
					break;
				case 1:
					result.Tier = reader.ReadInt32();
					break;
				case 2:
					result.Location = resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
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
