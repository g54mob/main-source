using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class BlueprintStoreView_ViewDataFormatter : IMessagePackFormatter<BlueprintStoreView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, BlueprintStoreView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(8);
			writer.Write(value.InUse);
			writer.Write(value.Appliance);
			writer.Write(value.HasUpgradeEvent);
			writer.Write(value.HasCopyEvent);
			writer.Write(value.IsUpgrading);
			writer.Write(value.IsCopying);
			writer.Write(value.HasMakeFreeEvent);
			writer.Write(value.IsMakingFree);
		}

		public BlueprintStoreView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			BlueprintStoreView.ViewData result = default(BlueprintStoreView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.InUse = reader.ReadBoolean();
					break;
				case 1:
					result.Appliance = reader.ReadInt32();
					break;
				case 2:
					result.HasUpgradeEvent = reader.ReadBoolean();
					break;
				case 3:
					result.HasCopyEvent = reader.ReadBoolean();
					break;
				case 4:
					result.IsUpgrading = reader.ReadBoolean();
					break;
				case 5:
					result.IsCopying = reader.ReadBoolean();
					break;
				case 6:
					result.HasMakeFreeEvent = reader.ReadBoolean();
					break;
				case 7:
					result.IsMakingFree = reader.ReadBoolean();
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
