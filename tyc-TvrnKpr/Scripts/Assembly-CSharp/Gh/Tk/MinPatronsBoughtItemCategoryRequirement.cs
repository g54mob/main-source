namespace Gh.Tk
{
	public class MinPatronsBoughtItemCategoryRequirement : MinTavernGameStatWithMinTierRequirementBase
	{
		public MinPatronsBoughtItemCategoryRequirement(string titleKey, string itemCategory, int targetMinAmount, int minTier, string category = null)
			: base(null, null, 0, 0)
		{
		}

		protected override string GetStatKey(string itemCategory, int tier)
		{
			return null;
		}
	}
}
