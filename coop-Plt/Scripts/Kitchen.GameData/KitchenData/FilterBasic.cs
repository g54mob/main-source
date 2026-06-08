using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenData
{
	[Serializable]
	public class FilterBasic : IUnlockFilter
	{
		public bool IgnoreUnlockability;

		public bool IgnoreFranchiseTier;

		public bool IgnoreDuplicateFilter;

		public bool IgnoreRequirements;

		public bool AllowBaseDishes;

		public bool IgnoreBlocksOtherFood;

		public bool IgnoreFilterByHasMain;

		public bool ShouldBlockCard(Unlock candidate, HashSet<int> current_cards, UnlockRequest request)
		{
			if (!IgnoreUnlockability && !candidate.IsUnlockable)
			{
				return true;
			}
			if ((!IgnoreFranchiseTier && candidate.IsSpecificFranchiseTier) ? (candidate.MinimumFranchiseTier != request.Tier) : (candidate.MinimumFranchiseTier > request.Tier))
			{
				return true;
			}
			if (!IgnoreDuplicateFilter && current_cards.Contains(candidate.ID))
			{
				return true;
			}
			if (!IgnoreRequirements && candidate.Requires.Any((Unlock r) => !current_cards.Contains(r.ID)))
			{
				return true;
			}
			if (!IgnoreRequirements && candidate.BlockedBy.Any((Unlock r) => current_cards.Contains(r.ID)))
			{
				return true;
			}
			if (!AllowBaseDishes && candidate is Dish { Type: DishType.Base })
			{
				return true;
			}
			if (!IgnoreBlocksOtherFood)
			{
				foreach (int current_card in current_cards)
				{
					if (GameData.Main.TryGet<Unlock>(current_card, out var output) && output.BlocksAllOtherFood && candidate is Dish && !output.AllowedFoods.Contains(candidate))
					{
						return true;
					}
				}
			}
			if (!IgnoreFilterByHasMain && candidate is Dish dish2 && (dish2.ProvidesPhase(MenuPhase.Starter) || dish2.ProvidesPhase(MenuPhase.Side)))
			{
				bool flag = false;
				foreach (int current_card2 in current_cards)
				{
					if (GameData.Main.TryGet<Dish>(current_card2, out var output2) && output2.ProvidesPhase(MenuPhase.Main))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return true;
				}
			}
			return false;
		}
	}
}
