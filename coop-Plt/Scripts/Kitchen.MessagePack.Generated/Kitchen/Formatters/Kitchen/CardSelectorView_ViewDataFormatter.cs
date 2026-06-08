using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CardSelectorView_ViewDataFormatter : IMessagePackFormatter<CardSelectorView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CardSelectorView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(4);
			writer.Write(value.CardID);
			writer.Write(value.CardIndex);
			writer.Write(value.CardCount);
			writer.Write(value.HasFranchise);
		}

		public CardSelectorView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			CardSelectorView.ViewData result = default(CardSelectorView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.CardID = reader.ReadInt32();
					break;
				case 1:
					result.CardIndex = reader.ReadInt32();
					break;
				case 2:
					result.CardCount = reader.ReadInt32();
					break;
				case 3:
					result.HasFranchise = reader.ReadBoolean();
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
