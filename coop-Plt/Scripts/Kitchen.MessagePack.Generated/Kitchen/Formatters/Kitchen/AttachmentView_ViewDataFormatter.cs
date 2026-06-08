using System;
using MessagePack;
using MessagePack.Formatters;
using Unity.Collections;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class AttachmentView_ViewDataFormatter : IMessagePackFormatter<AttachmentView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, AttachmentView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<FixedListInt64>().Serialize(ref writer, value.Attachments, options);
			resolver.GetFormatterWithVerify<FixedListInt64>().Serialize(ref writer, value.Active, options);
			resolver.GetFormatterWithVerify<Orientation>().Serialize(ref writer, value.ActiveChairs, options);
		}

		public AttachmentView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			AttachmentView.ViewData result = default(AttachmentView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Attachments = resolver.GetFormatterWithVerify<FixedListInt64>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Active = resolver.GetFormatterWithVerify<FixedListInt64>().Deserialize(ref reader, options);
					break;
				case 2:
					result.ActiveChairs = resolver.GetFormatterWithVerify<Orientation>().Deserialize(ref reader, options);
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
