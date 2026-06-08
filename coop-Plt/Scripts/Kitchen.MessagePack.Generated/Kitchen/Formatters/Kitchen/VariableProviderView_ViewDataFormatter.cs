using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class VariableProviderView_ViewDataFormatter : IMessagePackFormatter<VariableProviderView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, VariableProviderView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.ProviderID);
			writer.Write(value.ProviderIndex);
		}

		public VariableProviderView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			VariableProviderView.ViewData result = default(VariableProviderView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.ProviderID = reader.ReadInt32();
					break;
				case 1:
					result.ProviderIndex = reader.ReadInt32();
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
