using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class OpenFrontDoorView_ViewDataFormatter : IMessagePackFormatter<OpenFrontDoorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, OpenFrontDoorView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.IsOpenTime);
		}

		public OpenFrontDoorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			OpenFrontDoorView.ViewData result = default(OpenFrontDoorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.IsOpenTime = reader.ReadBoolean();
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
