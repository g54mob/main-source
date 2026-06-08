using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class RerollBlueprintView_ViewDataFormatter : IMessagePackFormatter<RerollBlueprintView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, RerollBlueprintView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.Price);
			writer.Write(value.PlayerMoney);
		}

		public RerollBlueprintView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			RerollBlueprintView.ViewData result = default(RerollBlueprintView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Price = reader.ReadInt32();
					break;
				case 1:
					result.PlayerMoney = reader.ReadInt32();
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
