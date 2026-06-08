using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class SeedInfoView_ViewDataFormatter : IMessagePackFormatter<SeedInfoView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, SeedInfoView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.IsSeedOverride);
			writer.Write(value.IsFunctionMode);
		}

		public SeedInfoView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			SeedInfoView.ViewData result = default(SeedInfoView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IsSeedOverride = reader.ReadBoolean();
					break;
				case 1:
					result.IsFunctionMode = reader.ReadBoolean();
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
