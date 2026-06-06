namespace Brewery.Quest
{
	public struct RequiredItemInfo
	{
		public string ItemId;

		public int Quantity;

		public CatalyzedItemRequirement CatalyzedRequirement;

		public string DisplayName;

		public string CatalystInfo;

		public bool IsCatalyzed => false;
	}
}
