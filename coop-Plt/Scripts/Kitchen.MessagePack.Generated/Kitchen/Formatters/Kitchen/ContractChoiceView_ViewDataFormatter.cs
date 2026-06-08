using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ContractChoiceView_ViewDataFormatter : IMessagePackFormatter<ContractChoiceView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ContractChoiceView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(1);
			writer.Write(value.Contract);
		}

		public ContractChoiceView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			ContractChoiceView.ViewData result = default(ContractChoiceView.ViewData);
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
