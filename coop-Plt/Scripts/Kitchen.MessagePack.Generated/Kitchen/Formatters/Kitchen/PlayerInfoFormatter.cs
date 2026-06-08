using System;
using Controllers;
using Kitchen.NetworkSupport;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PlayerInfoFormatter : IMessagePackFormatter<PlayerInfo>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerInfo value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(10);
			writer.WriteNil();
			writer.Write(value.ID);
			resolver.GetFormatterWithVerify<ConnectionType>().Serialize(ref writer, value.Connection, options);
			resolver.GetFormatterWithVerify<SourceIdentifier>().Serialize(ref writer, value.Identifier, options);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Username, options);
			resolver.GetFormatterWithVerify<PlayerProfile>().Serialize(ref writer, value.Profile, options);
			writer.Write(value.JoinProgress);
			writer.Write(value.Index);
			writer.WriteNil();
			writer.Write(value.IsReportedDisconnectedByServer);
		}

		public PlayerInfo Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PlayerInfo result = default(PlayerInfo);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 1:
					result.ID = reader.ReadInt32();
					break;
				case 2:
					result.Connection = resolver.GetFormatterWithVerify<ConnectionType>().Deserialize(ref reader, options);
					break;
				case 3:
					result.Identifier = resolver.GetFormatterWithVerify<SourceIdentifier>().Deserialize(ref reader, options);
					break;
				case 4:
					result.Username = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 5:
					result.Profile = resolver.GetFormatterWithVerify<PlayerProfile>().Deserialize(ref reader, options);
					break;
				case 6:
					result.JoinProgress = reader.ReadSingle();
					break;
				case 7:
					result.Index = reader.ReadInt32();
					break;
				case 9:
					result.IsReportedDisconnectedByServer = reader.ReadBoolean();
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
