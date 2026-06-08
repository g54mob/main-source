using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CommandUpdateFormatter : IMessagePackFormatter<CommandUpdate>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CommandUpdate value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<ICommandUpdate>().Serialize(ref writer, value.Command, options);
		}

		public CommandUpdate Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CommandUpdate result = default(CommandUpdate);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Command = resolver.GetFormatterWithVerify<ICommandUpdate>().Deserialize(ref reader, options);
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
