using System;
using Kitchen.Layouts;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class LayoutView_InitialViewDataFormatter : IMessagePackFormatter<LayoutView.InitialViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, LayoutView.InitialViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<LayoutBlueprint>().Serialize(ref writer, value.Floorplan, options);
		}

		public LayoutView.InitialViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			LayoutView.InitialViewData result = default(LayoutView.InitialViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Floorplan = resolver.GetFormatterWithVerify<LayoutBlueprint>().Deserialize(ref reader, options);
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
