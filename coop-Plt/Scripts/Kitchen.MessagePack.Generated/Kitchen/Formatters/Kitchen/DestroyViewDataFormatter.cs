using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class DestroyViewDataFormatter : IMessagePackFormatter<DestroyViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, DestroyViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.PurgeCacheOnly);
		}

		public DestroyViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			DestroyViewData result = default(DestroyViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.PurgeCacheOnly = reader.ReadBoolean();
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
