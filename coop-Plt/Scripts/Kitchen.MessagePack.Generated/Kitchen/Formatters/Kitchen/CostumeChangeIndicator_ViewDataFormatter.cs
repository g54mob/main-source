using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CostumeChangeIndicator_ViewDataFormatter : IMessagePackFormatter<CostumeChangeIndicator.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CostumeChangeIndicator.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.WriteNil();
			writer.Write(value.Player);
		}

		public CostumeChangeIndicator.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			CostumeChangeIndicator.ViewData result = default(CostumeChangeIndicator.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 1)
				{
					result.Player = reader.ReadInt32();
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
