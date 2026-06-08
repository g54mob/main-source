using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KitchenData
{
	[Serializable]
	public class UnlockSorterEncourageCard : IUnlockSorter
	{
		public float PriorityProbability = 0.5f;

		public List<Unlock> Cards = new List<Unlock>();

		public void SortCards(ref List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			bool is_priority = UnityEngine.Random.value < PriorityProbability;
			candidates = candidates.OrderBy((Unlock c) => (is_priority && IsPriority(c)) ? 1 : 0).ToList();
		}

		private bool IsPriority(Unlock u)
		{
			return Cards.Contains(u);
		}
	}
}
