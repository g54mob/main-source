using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class MoneyDisplayView_ViewDataFormatter : IMessagePackFormatter<MoneyDisplayView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, MoneyDisplayView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Money);
		}

		public MoneyDisplayView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			MoneyDisplayView.ViewData result = default(MoneyDisplayView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Money = reader.ReadInt32();
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
