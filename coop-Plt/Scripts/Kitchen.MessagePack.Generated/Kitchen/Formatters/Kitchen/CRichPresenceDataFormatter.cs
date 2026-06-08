using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CRichPresenceDataFormatter : IMessagePackFormatter<CRichPresenceData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CRichPresenceData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(4);
			writer.Write(value.IsInGame);
			writer.Write(value.Day);
			writer.Write(value.IsMultiplayer);
			writer.Write(value.Players);
		}

		public CRichPresenceData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			CRichPresenceData result = default(CRichPresenceData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IsInGame = reader.ReadBoolean();
					break;
				case 1:
					result.Day = reader.ReadInt32();
					break;
				case 2:
					result.IsMultiplayer = reader.ReadBoolean();
					break;
				case 3:
					result.Players = reader.ReadInt32();
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
