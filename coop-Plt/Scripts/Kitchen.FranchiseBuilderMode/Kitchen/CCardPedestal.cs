using Unity.Entities;

namespace Kitchen
{
	public struct CCardPedestal : IComponentData
	{
		public int CardID;

		public bool IsSelected;

		public int BlockedBy;

		public bool UntoggleableTooManyCards;

		public bool IsForcedCard;

		public bool IsToggleable
		{
			get
			{
				if (!IsForcedCard && !UntoggleableTooManyCards)
				{
					return BlockedBy == 0;
				}
				return false;
			}
		}
	}
}
