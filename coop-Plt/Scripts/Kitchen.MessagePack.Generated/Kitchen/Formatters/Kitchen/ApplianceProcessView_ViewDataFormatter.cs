using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ApplianceProcessView_ViewDataFormatter : IMessagePackFormatter<ApplianceProcessView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ApplianceProcessView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(5);
			writer.Write(value.CurrentProcess);
			writer.Write(value.IsBad);
			writer.Write(value.Progress);
			writer.Write(value.IsActive);
			writer.Write(value.IsGhost);
		}

		public ApplianceProcessView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ApplianceProcessView.ViewData result = default(ApplianceProcessView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.CurrentProcess = reader.ReadInt32();
					break;
				case 1:
					result.IsBad = reader.ReadBoolean();
					break;
				case 2:
					result.Progress = reader.ReadSingle();
					break;
				case 3:
					result.IsActive = reader.ReadBoolean();
					break;
				case 4:
					result.IsGhost = reader.ReadBoolean();
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
