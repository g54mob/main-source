using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class InfoManagerResponseUpdateFormatter : IMessagePackFormatter<InfoManagerResponseUpdate>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, InfoManagerResponseUpdate value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			writer.Write(value.PlayerID);
			resolver.GetFormatterWithVerify<PlayerProfile>().Serialize(ref writer, value.Profile, options);
		}

		public InfoManagerResponseUpdate Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			InfoManagerResponseUpdate result = default(InfoManagerResponseUpdate);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.PlayerID = reader.ReadInt32();
					break;
				case 1:
					result.Profile = resolver.GetFormatterWithVerify<PlayerProfile>().Deserialize(ref reader, options);
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
