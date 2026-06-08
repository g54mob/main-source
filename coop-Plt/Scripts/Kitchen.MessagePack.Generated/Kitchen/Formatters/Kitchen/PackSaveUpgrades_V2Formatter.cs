using System;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PackSaveUpgrades_V2Formatter : IMessagePackFormatter<PackSaveUpgrades.V2>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PackSaveUpgrades.V2 value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			writer.Write(value.ID);
			writer.Write(value.IsFromLevel);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.Location, options);
			writer.Write(value.HasLocation);
		}

		public PackSaveUpgrades.V2 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PackSaveUpgrades.V2 result = default(PackSaveUpgrades.V2);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ID = reader.ReadInt32();
					break;
				case 1:
					result.IsFromLevel = reader.ReadBoolean();
					break;
				case 2:
					result.Location = resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
					break;
				case 3:
					result.HasLocation = reader.ReadBoolean();
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
