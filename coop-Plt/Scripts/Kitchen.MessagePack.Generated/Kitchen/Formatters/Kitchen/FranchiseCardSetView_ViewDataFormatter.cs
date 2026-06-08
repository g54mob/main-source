using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class FranchiseCardSetView_ViewDataFormatter : IMessagePackFormatter<FranchiseCardSetView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, FranchiseCardSetView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
			resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Cards, options);
			writer.Write(value.FranchiseIndex);
			writer.Write(value.FranchiseCount);
		}

		public FranchiseCardSetView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			FranchiseCardSetView.ViewData result = default(FranchiseCardSetView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Name = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Cards = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
					break;
				case 2:
					result.FranchiseIndex = reader.ReadInt32();
					break;
				case 3:
					result.FranchiseCount = reader.ReadInt32();
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
