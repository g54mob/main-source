using System;
using Kitchen.Layouts;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen.Layouts
{
	public sealed class LayoutPositionFormatter : IMessagePackFormatter<LayoutPosition>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, LayoutPosition value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.x);
			writer.Write(value.y);
		}

		public LayoutPosition Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			int x = 0;
			int y = 0;
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					x = reader.ReadInt32();
					break;
				case 1:
					y = reader.ReadInt32();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			LayoutPosition result = new LayoutPosition(x, y);
			reader.Depth--;
			return result;
		}
	}
}
