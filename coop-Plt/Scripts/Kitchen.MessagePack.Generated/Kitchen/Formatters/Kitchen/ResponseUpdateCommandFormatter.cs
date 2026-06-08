using System;
using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ResponseUpdateCommandFormatter : IMessagePackFormatter<ResponseUpdateCommand>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ResponseUpdateCommand value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			resolver.GetFormatterWithVerify<SourceIdentifier>().Serialize(ref writer, value.SourceIdentifier, options);
			resolver.GetFormatterWithVerify<IResponseData>().Serialize(ref writer, value.Data, options);
			resolver.GetFormatterWithVerify<Type>().Serialize(ref writer, value.HandleType, options);
			resolver.GetFormatterWithVerify<ViewIdentifier>().Serialize(ref writer, value.ViewSourceIdentifier, options);
		}

		public ResponseUpdateCommand Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			SourceIdentifier source_id = default(SourceIdentifier);
			IResponseData data = null;
			Type handle_type = null;
			ViewIdentifier view_source_identifier = default(ViewIdentifier);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					source_id = resolver.GetFormatterWithVerify<SourceIdentifier>().Deserialize(ref reader, options);
					break;
				case 1:
					data = resolver.GetFormatterWithVerify<IResponseData>().Deserialize(ref reader, options);
					break;
				case 2:
					handle_type = resolver.GetFormatterWithVerify<Type>().Deserialize(ref reader, options);
					break;
				case 3:
					view_source_identifier = resolver.GetFormatterWithVerify<ViewIdentifier>().Deserialize(ref reader, options);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			ResponseUpdateCommand result = new ResponseUpdateCommand(source_id, data, handle_type, view_source_identifier);
			reader.Depth--;
			return result;
		}
	}
}
