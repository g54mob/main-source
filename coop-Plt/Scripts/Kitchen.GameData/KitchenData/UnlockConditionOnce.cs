using System;
using System.Collections.Generic;

namespace KitchenData
{
	[Serializable]
	public class UnlockConditionOnce : IUnlockCondition
	{
		public int Day = 15;

		public bool ShouldProvide(List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			if (request.Day != Day)
			{
				return false;
			}
			return true;
		}
	}
}
