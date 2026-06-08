using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class DishSelectionIndicator_ResponseDataFormatter : IMessagePackFormatter<DishSelectionIndicator.ResponseData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, DishSelectionIndicator.ResponseData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.IsComplete);
			writer.Write(value.Dish);
		}

		public DishSelectionIndicator.ResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			DishSelectionIndicator.ResponseData result = default(DishSelectionIndicator.ResponseData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IsComplete = reader.ReadBoolean();
					break;
				case 1:
					result.Dish = reader.ReadInt32();
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
