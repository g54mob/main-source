using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ProgressView_ViewDataFormatter : IMessagePackFormatter<ProgressView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ProgressView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(5);
			writer.Write(value.IsBad);
			writer.Write(value.Progress);
			writer.Write(value.Process);
			writer.Write(value.UnknownLength);
			writer.Write(value.CurrentChange);
		}

		public ProgressView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ProgressView.ViewData result = default(ProgressView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IsBad = reader.ReadBoolean();
					break;
				case 1:
					result.Progress = reader.ReadSingle();
					break;
				case 2:
					result.Process = reader.ReadInt32();
					break;
				case 3:
					result.UnknownLength = reader.ReadBoolean();
					break;
				case 4:
					result.CurrentChange = reader.ReadSingle();
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
