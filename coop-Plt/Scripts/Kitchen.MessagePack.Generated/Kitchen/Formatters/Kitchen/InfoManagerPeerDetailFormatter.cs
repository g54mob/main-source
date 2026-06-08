using System;
using Controllers;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class InfoManagerPeerDetailFormatter : IMessagePackFormatter<InfoManagerPeerDetail>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, InfoManagerPeerDetail value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(3);
			resolver.GetFormatterWithVerify<SourceIdentifier>().Serialize(ref writer, value.Identifier, options);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.MainName, options);
			writer.Write(value.HasPlayers);
		}

		public InfoManagerPeerDetail Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			InfoManagerPeerDetail result = default(InfoManagerPeerDetail);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Identifier = resolver.GetFormatterWithVerify<SourceIdentifier>().Deserialize(ref reader, options);
					break;
				case 1:
					result.MainName = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 2:
					result.HasPlayers = reader.ReadBoolean();
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
