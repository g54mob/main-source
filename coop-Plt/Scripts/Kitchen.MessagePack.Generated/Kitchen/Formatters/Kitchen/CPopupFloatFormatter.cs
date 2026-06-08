using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CPopupFloatFormatter : IMessagePackFormatter<CPopupFloat>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CPopupFloat value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Value);
		}

		public CPopupFloat Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			CPopupFloat result = default(CPopupFloat);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Value = reader.ReadInt32();
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
