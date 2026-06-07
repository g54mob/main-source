namespace Gh.Tk
{
	public class MinPatronsStayedOvernightRequirement : MinTavernGameStatWithMinTierRequirementBase
	{
		public MinPatronsStayedOvernightRequirement(string titleKey, string itemCategory, int targetMinAmount, int minTier, string category = null)
			: base(null, null, 0, 0)
		{
		}

		protected override string GetStatKey(string itemCategory, int tier)
		{
			return null;
		}
	}
}
