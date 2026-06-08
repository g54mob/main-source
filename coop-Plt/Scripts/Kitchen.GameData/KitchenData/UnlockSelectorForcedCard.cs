using System;
using System.Collections.Generic;

namespace KitchenData
{
	[Serializable]
	public class UnlockSelectorForcedCard : IUnlockSelector
	{
		public UnlockOptions GetOptions(List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			return new UnlockOptions
			{
				Unlock1 = ((candidates.Count > 0) ? candidates[0] : null)
			};
		}
	}
}
