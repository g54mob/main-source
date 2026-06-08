using System;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SaveUpgrades_V1Formatter : IMessagePackFormatter<SaveUpgrades.V1>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SaveUpgrades.V1 value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			writer.Write(value.ID);
			writer.Write(value.HasLocation);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.Location, options);
		}

		public SaveUpgrades.V1 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			SaveUpgrades.V1 result = default(SaveUpgrades.V1);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ID = reader.ReadInt32();
					break;
				case 1:
					result.HasLocation = reader.ReadBoolean();
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
