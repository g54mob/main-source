using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PlayerInputDataFormatter : IMessagePackFormatter<PlayerInputData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerInputData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			writer.Write(value.PlayerID);
			resolver.GetFormatterWithVerify<CInputData>().Serialize(ref writer, value.Input, options);
		}

		public PlayerInputData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PlayerInputData result = default(PlayerInputData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.PlayerID = reader.ReadInt32();
					break;
				case 1:
					result.Input = resolver.GetFormatterWithVerify<CInputData>().Deserialize(ref reader, options);
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
