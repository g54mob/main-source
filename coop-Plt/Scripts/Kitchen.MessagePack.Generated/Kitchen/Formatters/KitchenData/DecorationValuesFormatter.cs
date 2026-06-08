using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.KitchenData
{
	public sealed class DecorationValuesFormatter : IMessagePackFormatter<DecorationValues>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, DecorationValues value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(5);
			writer.Write(value.Exclusive);
			writer.Write(value.Affordable);
			writer.Write(value.Charming);
			writer.Write(value.Formal);
			writer.Write(value.Kitchen);
		}

		public DecorationValues Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			DecorationValues result = default(DecorationValues);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Exclusive = reader.ReadInt32();
					break;
				case 1:
					result.Affordable = reader.ReadInt32();
					break;
				case 2:
					result.Charming = reader.ReadInt32();
					break;
				case 3:
					result.Formal = reader.ReadInt32();
					break;
				case 4:
					result.Kitchen = reader.ReadInt32();
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
