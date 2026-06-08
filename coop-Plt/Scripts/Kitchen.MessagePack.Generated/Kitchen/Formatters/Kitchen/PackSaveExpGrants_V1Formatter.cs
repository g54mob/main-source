using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PackSaveExpGrants_V1Formatter : IMessagePackFormatter<PackSaveExpGrants.V1>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PackSaveExpGrants.V1 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.Amount);
			writer.Write(value.ExpIdentifier);
			writer.Write(value.IsGranted);
		}

		public PackSaveExpGrants.V1 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			PackSaveExpGrants.V1 result = default(PackSaveExpGrants.V1);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Amount = reader.ReadInt32();
					break;
				case 1:
					result.ExpIdentifier = reader.ReadInt32();
					break;
				case 2:
					result.IsGranted = reader.ReadBoolean();
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
