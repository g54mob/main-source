using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class FixedDishView_ViewDataFormatter : IMessagePackFormatter<FixedDishView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, FixedDishView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<FixedDishReason>().Serialize(ref writer, value.Reason, options);
		}

		public FixedDishView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			FixedDishView.ViewData result = default(FixedDishView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Reason = resolver.GetFormatterWithVerify<FixedDishReason>().Deserialize(ref reader, options);
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
