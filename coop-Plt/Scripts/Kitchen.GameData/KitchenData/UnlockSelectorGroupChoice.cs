using System;
using System.Collections.Generic;

namespace KitchenData
{
	[Serializable]
	public class UnlockSelectorGroupChoice : IUnlockSelector
	{
		public UnlockGroup Group1;

		public UnlockGroup Group2;

		public UnlockOptions GetOptions(List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			UnlockOptions result = default(UnlockOptions);
			foreach (Unlock candidate in candidates)
			{
				if (candidate.UnlockGroup == Group1 || candidate.UnlockGroup == Group2)
				{
					if (result.Unlock1 == null || (candidate.UnlockGroup == Group1 && result.Unlock1.UnlockGroup != Group1))
					{
						result.Unlock1 = candidate;
					}
					else if (result.Unlock2 == null || (candidate.UnlockGroup == Group2 && result.Unlock2.UnlockGroup != Group2))
					{
						result.Unlock2 = candidate;
					}
				}
			}
			return result;
		}
	}
}
