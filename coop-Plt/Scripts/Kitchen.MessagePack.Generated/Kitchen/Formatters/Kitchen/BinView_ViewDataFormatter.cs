using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class BinView_ViewDataFormatter : IMessagePackFormatter<BinView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, BinView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.Current);
			writer.Write(value.Capacity);
		}

		public BinView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			BinView.ViewData result = default(BinView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Current = reader.ReadInt32();
					break;
				case 1:
					result.Capacity = reader.ReadInt32();
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
