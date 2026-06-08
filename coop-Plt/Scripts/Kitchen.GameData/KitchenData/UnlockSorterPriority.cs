using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine;

namespace KitchenData
{
	[Serializable]
	public class UnlockSorterPriority : IUnlockSorter
	{
		public float PriorityProbability = 0.5f;

		public bool PrioritiseRequirements = true;

		public List<UnlockGroup> Groups = new List<UnlockGroup>();

		public List<DishType> DishTypes = new List<DishType>();

		public void SortCards(ref List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			bool is_priority = UnityEngine.Random.value < PriorityProbability;
			candidates = candidates.OrderByDescending((Unlock c) => (is_priority && IsPriority(c)) ? 1 : 0).ToList();
		}

		private bool IsPriority(Unlock u)
		{
			if (PrioritiseRequirements && !u.Requires.IsNullOrEmpty())
			{
				return true;
			}
			if (Groups.Contains(u.UnlockGroup))
			{
				return true;
			}
			if (u is Dish dish)
			{
				return DishTypes.Contains(dish.Type);
			}
			return false;
		}
	}
}
