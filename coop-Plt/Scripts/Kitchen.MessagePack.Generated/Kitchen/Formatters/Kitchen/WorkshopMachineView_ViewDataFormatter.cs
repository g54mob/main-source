using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class WorkshopMachineView_ViewDataFormatter : IMessagePackFormatter<WorkshopMachineView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, WorkshopMachineView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(4);
			writer.Write(value.Item1);
			writer.Write(value.Item2);
			writer.Write(value.Item3);
			writer.Write(value.Nonce);
		}

		public WorkshopMachineView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			WorkshopMachineView.ViewData result = default(WorkshopMachineView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Item1 = reader.ReadInt32();
					break;
				case 1:
					result.Item2 = reader.ReadInt32();
					break;
				case 2:
					result.Item3 = reader.ReadInt32();
					break;
				case 3:
					result.Nonce = reader.ReadInt32();
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
