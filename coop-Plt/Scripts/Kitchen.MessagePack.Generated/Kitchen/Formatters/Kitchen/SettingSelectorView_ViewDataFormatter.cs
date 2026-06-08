using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SettingSelectorView_ViewDataFormatter : IMessagePackFormatter<SettingSelectorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SettingSelectorView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.SettingID);
			writer.Write(value.BeingLookedAt);
		}

		public SettingSelectorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			SettingSelectorView.ViewData result = default(SettingSelectorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.SettingID = reader.ReadInt32();
					break;
				case 1:
					result.BeingLookedAt = reader.ReadBoolean();
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
