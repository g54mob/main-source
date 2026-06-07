using System.Collections.Generic;

namespace Gh.Tk.Story.Config
{
	public class PatronBuyShopItemsNeedConfigNode : PatronNeedConfigNode
	{
		internal override PatronNeedData CreatePatronNeedData(PatronPopulationData pawn)
		{
			return null;
		}

		public override void AddSecondaryNeeds(PatronPopulationData pawn, PatronNeedData data, bool tryForceSecondaryNeed)
		{
		}

		public static void InvalidateShopItemNeedsBasedOnNewDemand(PatronPopulationData pawn)
		{
		}

		private static IEnumerable<GameItemTemplate> GetShopItemsForShoppingNeed(int hoursFromNow, int tier, int itemCount)
		{
			return null;
		}
	}
}
