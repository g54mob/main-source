using System;
using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ControlCommandFormatter : IMessagePackFormatter<ControlCommand>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ControlCommand value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<SourceIdentifier>().Serialize(ref writer, value.SourceIdentifier, options);
			resolver.GetFormatterWithVerify<CommandType>().Serialize(ref writer, value.Type, options);
			resolver.GetFormatterWithVerify<ICommandData>().Serialize(ref writer, value.Data, options);
		}

		public ControlCommand Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ControlCommand result = default(ControlCommand);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.SourceIdentifier = resolver.GetFormatterWithVerify<SourceIdentifier>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Type = resolver.GetFormatterWithVerify<CommandType>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Data = resolver.GetFormatterWithVerify<ICommandData>().Deserialize(ref reader, options);
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
