using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CExpChangeFormatter : IMessagePackFormatter<CExpChange>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CExpChange value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			resolver.GetFormatterWithVerify<SPlayerLevel>().Serialize(ref writer, value.Old, options);
			resolver.GetFormatterWithVerify<SPlayerLevel>().Serialize(ref writer, value.New, options);
			writer.Write(value.ExpGranted);
			writer.Write(value.ExpIdentifier);
		}

		public CExpChange Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CExpChange result = default(CExpChange);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Old = resolver.GetFormatterWithVerify<SPlayerLevel>().Deserialize(ref reader, options);
					break;
				case 1:
					result.New = resolver.GetFormatterWithVerify<SPlayerLevel>().Deserialize(ref reader, options);
					break;
				case 2:
					result.ExpGranted = reader.ReadInt32();
					break;
				case 3:
					result.ExpIdentifier = reader.ReadInt32();
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
