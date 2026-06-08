using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CreateViewDataFormatter : IMessagePackFormatter<CreateViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CreateViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<ViewType>().Serialize(ref writer, value.ViewType, options);
			resolver.GetFormatterWithVerify<ViewMode>().Serialize(ref writer, value.ViewMode, options);
			writer.Write(value.IsRedraw);
		}

		public CreateViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CreateViewData result = default(CreateViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ViewType = resolver.GetFormatterWithVerify<ViewType>().Deserialize(ref reader, options);
					break;
				case 1:
					result.ViewMode = resolver.GetFormatterWithVerify<ViewMode>().Deserialize(ref reader, options);
					break;
				case 2:
					result.IsRedraw = reader.ReadBoolean();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
