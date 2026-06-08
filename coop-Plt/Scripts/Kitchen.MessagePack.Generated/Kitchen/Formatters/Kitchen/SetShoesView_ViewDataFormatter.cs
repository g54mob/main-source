using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SetShoesView_ViewDataFormatter : IMessagePackFormatter<SetShoesView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SetShoesView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Available);
		}

		public SetShoesView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			SetShoesView.ViewData result = default(SetShoesView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Available = reader.ReadInt32();
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
