using System;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CardPedestalView_ViewDataFormatter : IMessagePackFormatter<CardPedestalView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CardPedestalView.ViewData value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(5);
			writer.Write(value.IsSelected);
			writer.Write(value.BlockedBy);
			writer.Write(value.UnselectableTooManyCards);
			writer.Write(value.CardID);
			writer.Write(value.IsForcedCard);
		}

		public CardPedestalView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			int num = reader.ReadArrayHeader();
			CardPedestalView.ViewData result = default(CardPedestalView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IsSelected = reader.ReadBoolean();
					break;
				case 1:
					result.BlockedBy = reader.ReadInt32();
					break;
				case 2:
					result.UnselectableTooManyCards = reader.ReadBoolean();
					break;
				case 3:
					result.CardID = reader.ReadInt32();
					break;
				case 4:
					result.IsForcedCard = reader.ReadBoolean();
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
