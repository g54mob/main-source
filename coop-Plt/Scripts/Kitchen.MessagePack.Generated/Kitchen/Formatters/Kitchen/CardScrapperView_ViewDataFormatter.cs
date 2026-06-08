using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CardScrapperView_ViewDataFormatter : IMessagePackFormatter<CardScrapperView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CardScrapperView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(2);
			writer.Write(value.HasFranchise);
			writer.Write(value.FranchiseExpValue);
		}

		public CardScrapperView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			CardScrapperView.ViewData result = default(CardScrapperView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.HasFranchise = reader.ReadBoolean();
					break;
				case 1:
					result.FranchiseExpValue = reader.ReadInt32();
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
