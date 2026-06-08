using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CrateView_ViewDataFormatter : IMessagePackFormatter<CrateView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CrateView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Prefab);
		}

		public CrateView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			CrateView.ViewData result = default(CrateView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Prefab = reader.ReadInt32();
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
