using System;
using System.Collections.Generic;

namespace KitchenData
{
	[Serializable]
	public class UnlockSelectorAnyFromGroup : IUnlockSelector
	{
		public List<UnlockGroup> Groups = new List<UnlockGroup>();

		public UnlockOptions GetOptions(List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			UnlockOptions result = default(UnlockOptions);
			foreach (Unlock candidate in candidates)
			{
				if (Groups.Contains(candidate.UnlockGroup))
				{
					if (!(result.Unlock1 == null))
					{
						result.Unlock2 = candidate;
						return result;
					}
					result.Unlock1 = candidate;
				}
			}
			return result;
		}
	}
}
