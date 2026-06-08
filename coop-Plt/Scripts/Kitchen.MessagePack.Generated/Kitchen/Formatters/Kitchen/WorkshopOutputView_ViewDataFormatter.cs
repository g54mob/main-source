using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class WorkshopOutputView_ViewDataFormatter : IMessagePackFormatter<WorkshopOutputView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, WorkshopOutputView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Nonce);
		}

		public WorkshopOutputView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			WorkshopOutputView.ViewData result = default(WorkshopOutputView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Nonce = reader.ReadInt32();
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
