using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ItemVariableStorageView_ViewDataFormatter : IMessagePackFormatter<ItemVariableStorageView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ItemVariableStorageView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(5);
			resolver.GetFormatterWithVerify<ItemVariableStorageView.ItemData>().Serialize(ref writer, value.Item1, options);
			resolver.GetFormatterWithVerify<ItemVariableStorageView.ItemData>().Serialize(ref writer, value.Item2, options);
			resolver.GetFormatterWithVerify<ItemVariableStorageView.ItemData>().Serialize(ref writer, value.Item3, options);
			resolver.GetFormatterWithVerify<ItemVariableStorageView.ItemData>().Serialize(ref writer, value.Item4, options);
			resolver.GetFormatterWithVerify<ItemVariableStorageView.ItemData>().Serialize(ref writer, value.Item5, options);
		}

		public ItemVariableStorageView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ItemVariableStorageView.ViewData result = default(ItemVariableStorageView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Item1 = resolver.GetFormatterWithVerify<ItemVariableStorageView.ItemData>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Item2 = resolver.GetFormatterWithVerify<ItemVariableStorageView.ItemData>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Item3 = resolver.GetFormatterWithVerify<ItemVariableStorageView.ItemData>().Deserialize(ref reader, options);
					break;
				case 3:
					result.Item4 = resolver.GetFormatterWithVerify<ItemVariableStorageView.ItemData>().Deserialize(ref reader, options);
					break;
				case 4:
					result.Item5 = resolver.GetFormatterWithVerify<ItemVariableStorageView.ItemData>().Deserialize(ref reader, options);
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
