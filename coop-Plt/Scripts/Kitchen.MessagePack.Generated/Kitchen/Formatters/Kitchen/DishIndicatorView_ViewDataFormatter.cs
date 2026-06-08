using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class DishIndicatorView_ViewDataFormatter : IMessagePackFormatter<DishIndicatorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, DishIndicatorView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Dish);
		}

		public DishIndicatorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			DishIndicatorView.ViewData result = default(DishIndicatorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Dish = reader.ReadInt32();
				}
				else
				{
					reader.Skip();
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
