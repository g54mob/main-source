using System;
using MessagePack;
using MessagePack.Formatters;
using Platforms;

namespace Kitchen.Formatters.Platforms
{
	public sealed class PlatformUserFormatter : IMessagePackFormatter<PlatformUser>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlatformUser value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<PlatformType>().Serialize(ref writer, value.Platform, options);
			writer.Write(value.Identifier);
		}

		public PlatformUser Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PlatformUser result = default(PlatformUser);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Platform = resolver.GetFormatterWithVerify<PlatformType>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Identifier = reader.ReadInt32();
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
