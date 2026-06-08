using System.Collections.Generic;
using Sirenix.Utilities;

namespace KitchenData.Workshop
{
	public class MatchTags : IWorkshopGroupCondition, IWorkshopCondition
	{
		public bool RequireMismatch;

		public bool Matches(List<Appliance> apps)
		{
			if (apps.IsNullOrEmpty())
			{
				return false;
			}
			ShoppingTags shoppingTags = apps[0].ShoppingTags;
			foreach (Appliance app in apps)
			{
				shoppingTags &= app.ShoppingTags;
			}
			return RequireMismatch != (shoppingTags != ShoppingTags.None);
		}
	}
}
