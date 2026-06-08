using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ProfileIdentifierFormatter : IMessagePackFormatter<ProfileIdentifier>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ProfileIdentifier value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value._Value, options);
		}

		public ProfileIdentifier Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ProfileIdentifier result = default(ProfileIdentifier);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result._Value = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
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
