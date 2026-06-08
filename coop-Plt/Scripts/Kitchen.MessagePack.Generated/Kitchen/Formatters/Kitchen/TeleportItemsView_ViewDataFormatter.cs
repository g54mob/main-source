using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class TeleportItemsView_ViewDataFormatter : IMessagePackFormatter<TeleportItemsView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, TeleportItemsView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.HasReceivedTeleport);
			writer.Write(value.HasSentTeleport);
			writer.Write(value.GroupID);
		}

		public TeleportItemsView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			TeleportItemsView.ViewData result = default(TeleportItemsView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.HasReceivedTeleport = reader.ReadBoolean();
					break;
				case 1:
					result.HasSentTeleport = reader.ReadBoolean();
					break;
				case 2:
					result.GroupID = reader.ReadInt32();
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
