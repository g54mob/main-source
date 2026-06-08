using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class BlueprintDeskView_ViewDataFormatter : IMessagePackFormatter<BlueprintDeskView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, BlueprintDeskView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(3);
			writer.Write(value.GrantsBlueprint);
			writer.Write(value.IsLocked);
			writer.Write(value.Show);
		}

		public BlueprintDeskView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			BlueprintDeskView.ViewData result = default(BlueprintDeskView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.GrantsBlueprint = reader.ReadInt32();
					break;
				case 1:
					result.IsLocked = reader.ReadBoolean();
					break;
				case 2:
					result.Show = reader.ReadBoolean();
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
