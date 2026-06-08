using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class INetworkDataListFormatter : IMessagePackFormatter<INetworkDataList>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, INetworkDataList value, MessagePackSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNil();
				return;
			}
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(1);
			resolver.GetFormatterWithVerify<List<INetworkData>>().Serialize(ref writer, value.data, options);
		}

		public INetworkDataList Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			INetworkDataList networkDataList = new INetworkDataList();
			for (int i = 0; i < num; i++)
			{
				if (i == 0)
				{
					networkDataList.data = resolver.GetFormatterWithVerify<List<INetworkData>>().Deserialize(ref reader, options);
				}
				else
				{
					reader.Skip();
				}
			}
			reader.Depth--;
			return networkDataList;
		}
	}
}
