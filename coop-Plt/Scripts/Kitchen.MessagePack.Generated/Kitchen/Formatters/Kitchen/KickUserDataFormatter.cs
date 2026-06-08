using System;
using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class KickUserDataFormatter : IMessagePackFormatter<KickUserData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, KickUserData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<KickReason>().Serialize(ref writer, value.Reason, options);
			resolver.GetFormatterWithVerify<SourceIdentifier>().Serialize(ref writer, value.Target, options);
		}

		public KickUserData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			KickUserData result = default(KickUserData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Reason = resolver.GetFormatterWithVerify<KickReason>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Target = resolver.GetFormatterWithVerify<SourceIdentifier>().Deserialize(ref reader, options);
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
