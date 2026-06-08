using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KitchenData
{
	[Serializable]
	public class UnlockSorterShuffle : IUnlockSorter
	{
		public void SortCards(ref List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			candidates = candidates.OrderBy((Unlock c) => UnityEngine.Random.value).ToList();
		}
	}
}
