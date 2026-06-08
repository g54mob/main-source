using System;
using System.Collections.Generic;

namespace KitchenData
{
	[Serializable]
	public class UnlockConditionGuarantee : IUnlockCondition
	{
		public int MinDay = 5;

		public int MinTier = -1;

		public UnlockGroup GuaranteedGroup;

		public bool ShouldProvide(List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			if (request.Day < MinDay)
			{
				return false;
			}
			if (request.Tier < MinTier)
			{
				return false;
			}
			foreach (int current_card in current_cards)
			{
				if (GameData.Main.TryGet<Unlock>(current_card, out var output) && output.UnlockGroup == GuaranteedGroup)
				{
					return false;
				}
			}
			return true;
		}
	}
}
