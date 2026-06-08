using System;
using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CInputDataFormatter : IMessagePackFormatter<CInputData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CInputData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			writer.WriteNil();
			resolver.GetFormatterWithVerify<InputState>().Serialize(ref writer, value.State, options);
			writer.Write(value.IsCaptured);
			writer.Write(value.IsDisconnected);
		}

		public CInputData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CInputData result = default(CInputData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 1:
					result.State = resolver.GetFormatterWithVerify<InputState>().Deserialize(ref reader, options);
					break;
				case 2:
					result.IsCaptured = reader.ReadBoolean();
					break;
				case 3:
					result.IsDisconnected = reader.ReadBoolean();
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
