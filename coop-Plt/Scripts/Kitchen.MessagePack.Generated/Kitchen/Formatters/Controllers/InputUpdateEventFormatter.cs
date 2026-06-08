using System;
using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Controllers
{
	public sealed class InputUpdateEventFormatter : IMessagePackFormatter<InputUpdateEvent>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, InputUpdateEvent value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			writer.Write(value.User);
			resolver.GetFormatterWithVerify<InputState>().Serialize(ref writer, value.State, options);
		}

		public InputUpdateEvent Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			InputUpdateEvent result = default(InputUpdateEvent);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.User = reader.ReadInt32();
					break;
				case 1:
					result.State = resolver.GetFormatterWithVerify<InputState>().Deserialize(ref reader, options);
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
