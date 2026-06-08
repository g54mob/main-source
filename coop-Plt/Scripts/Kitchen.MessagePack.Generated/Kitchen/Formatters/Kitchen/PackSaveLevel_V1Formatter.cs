using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PackSaveLevel_V1Formatter : IMessagePackFormatter<PackSaveLevel.V1>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PackSaveLevel.V1 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.Level);
			writer.Write(value.ExpProgress);
		}

		public PackSaveLevel.V1 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			PackSaveLevel.V1 result = default(PackSaveLevel.V1);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Level = reader.ReadInt32();
					break;
				case 1:
					result.ExpProgress = reader.ReadInt32();
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
