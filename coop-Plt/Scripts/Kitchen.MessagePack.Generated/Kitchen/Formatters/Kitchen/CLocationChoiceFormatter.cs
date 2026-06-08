using System;
using MessagePack;
using MessagePack.Formatters;
using Unity.Collections;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CLocationChoiceFormatter : IMessagePackFormatter<CLocationChoice>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CLocationChoice value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(10);
			resolver.GetFormatterWithVerify<SaveState>().Serialize(ref writer, value.State, options);
			writer.Write(value.Slot);
			writer.Write(value.Setting);
			resolver.GetFormatterWithVerify<Seed>().Serialize(ref writer, value.Seed, options);
			writer.Write(value.FranchiseTier);
			resolver.GetFormatterWithVerify<FixedString64>().Serialize(ref writer, value.RestaurantName, options);
			resolver.GetFormatterWithVerify<FixedString64>().Serialize(ref writer, value.RestaurantSafeName, options);
			writer.Write(value.Day);
			writer.Write(value.MainDish);
			writer.Write(value.RunID);
		}

		public CLocationChoice Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CLocationChoice result = default(CLocationChoice);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.State = resolver.GetFormatterWithVerify<SaveState>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Slot = reader.ReadInt32();
					break;
				case 2:
					result.Setting = reader.ReadInt32();
					break;
				case 3:
					result.Seed = resolver.GetFormatterWithVerify<Seed>().Deserialize(ref reader, options);
					break;
				case 4:
					result.FranchiseTier = reader.ReadInt32();
					break;
				case 5:
					result.RestaurantName = resolver.GetFormatterWithVerify<FixedString64>().Deserialize(ref reader, options);
					break;
				case 6:
					result.RestaurantSafeName = resolver.GetFormatterWithVerify<FixedString64>().Deserialize(ref reader, options);
					break;
				case 7:
					result.Day = reader.ReadInt32();
					break;
				case 8:
					result.MainDish = reader.ReadInt32();
					break;
				case 9:
					result.RunID = reader.ReadInt32();
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
