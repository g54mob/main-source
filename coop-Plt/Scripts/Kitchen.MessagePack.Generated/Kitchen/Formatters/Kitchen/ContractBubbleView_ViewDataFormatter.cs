using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ContractBubbleView_ViewDataFormatter : IMessagePackFormatter<ContractBubbleView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ContractBubbleView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Contract);
		}

		public ContractBubbleView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ContractBubbleView.ViewData result = default(ContractBubbleView.ViewData);
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					result.Contract = reader.ReadInt32();
				}
				else
				{
					reader.Skip();
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
