using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class LayoutDecorView_DecorationUpdatesFormatter : IMessagePackFormatter<LayoutDecorView.DecorationUpdates>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, LayoutDecorView.DecorationUpdates value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<LayoutDecorMap>().Serialize(ref writer, value.Map, options);
		}

		public LayoutDecorView.DecorationUpdates Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			LayoutDecorView.DecorationUpdates result = default(LayoutDecorView.DecorationUpdates);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Map = resolver.GetFormatterWithVerify<LayoutDecorMap>().Deserialize(ref reader, options);
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
