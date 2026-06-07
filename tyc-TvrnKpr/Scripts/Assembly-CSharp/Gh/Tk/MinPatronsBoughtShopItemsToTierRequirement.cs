namespace Gh.Tk
{
	public class MinPatronsBoughtShopItemsToTierRequirement : MinTavernGameStatWithMinTierRequirementBase
	{
		public MinPatronsBoughtShopItemsToTierRequirement(string titleKey, int targetMinAmount, int minTier, string category = null)
			: base(null, null, 0, 0)
		{
		}

		protected override string GetStatKey(string itemCategory, int tier)
		{
			return null;
		}
	}
}
