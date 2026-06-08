using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PackSaveSpeedrun_V1Formatter : IMessagePackFormatter<PackSaveSpeedrun.V1>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PackSaveSpeedrun.V1 value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(4);
			writer.Write(value.Year);
			writer.Write(value.Week);
			writer.Write(value.DurationMilliseconds);
			writer.Write(value.Percentile);
		}

		public PackSaveSpeedrun.V1 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			PackSaveSpeedrun.V1 result = default(PackSaveSpeedrun.V1);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Year = reader.ReadInt32();
					break;
				case 1:
					result.Week = reader.ReadInt32();
					break;
				case 2:
					result.DurationMilliseconds = reader.ReadInt32();
					break;
				case 3:
					result.Percentile = reader.ReadSingle();
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
