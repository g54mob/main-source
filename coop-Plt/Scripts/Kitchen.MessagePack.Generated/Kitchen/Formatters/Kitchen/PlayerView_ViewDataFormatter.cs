using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PlayerView_ViewDataFormatter : IMessagePackFormatter<PlayerView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(8);
			resolver.GetFormatterWithVerify<CInputData>().Serialize(ref writer, value.Inputs, options);
			writer.Write(value.Speed);
			writer.Write(value.IsPaused);
			writer.Write(value.IsHolding);
			writer.Write(value.IsInteracting);
			writer.Write(value.Process);
			writer.Write(value.InputSource);
			writer.Write(value.PlayerID);
		}

		public PlayerView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			PlayerView.ViewData result = default(PlayerView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Inputs = resolver.GetFormatterWithVerify<CInputData>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Speed = reader.ReadSingle();
					break;
				case 2:
					result.IsPaused = reader.ReadBoolean();
					break;
				case 3:
					result.IsHolding = reader.ReadBoolean();
					break;
				case 4:
					result.IsInteracting = reader.ReadBoolean();
					break;
				case 5:
					result.Process = reader.ReadInt32();
					break;
				case 6:
					result.InputSource = reader.ReadInt32();
					break;
				case 7:
					result.PlayerID = reader.ReadInt32();
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
