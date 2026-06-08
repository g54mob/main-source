using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class PlayerHoldingSubview_ViewDataFormatter : IMessagePackFormatter<PlayerHoldingSubview.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, PlayerHoldingSubview.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(5);
			writer.Write(value.IsReadyToInteract);
			writer.Write(value.IsInteracting);
			writer.Write(value.HeldItemID);
			writer.Write(value.UsingToolID);
			writer.Write(value.IsHolding);
		}

		public PlayerHoldingSubview.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			PlayerHoldingSubview.ViewData result = default(PlayerHoldingSubview.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IsReadyToInteract = reader.ReadBoolean();
					break;
				case 1:
					result.IsInteracting = reader.ReadBoolean();
					break;
				case 2:
					result.HeldItemID = reader.ReadInt32();
					break;
				case 3:
					result.UsingToolID = reader.ReadInt32();
					break;
				case 4:
					result.IsHolding = reader.ReadBoolean();
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
