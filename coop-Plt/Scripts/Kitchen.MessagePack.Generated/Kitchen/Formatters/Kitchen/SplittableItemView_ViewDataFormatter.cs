using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SplittableItemView_ViewDataFormatter : IMessagePackFormatter<SplittableItemView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SplittableItemView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.Remaining);
			writer.Write(value.Total);
		}

		public SplittableItemView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			SplittableItemView.ViewData result = default(SplittableItemView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Remaining = reader.ReadInt32();
					break;
				case 1:
					result.Total = reader.ReadInt32();
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
