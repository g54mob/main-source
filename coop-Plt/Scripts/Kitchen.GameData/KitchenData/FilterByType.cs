using System;
using System.Collections.Generic;

namespace KitchenData
{
	[Serializable]
	public class FilterByType : IUnlockFilter
	{
		public bool AllowIfOnList;

		public List<CardType> Types = new List<CardType>();

		public bool ShouldBlockCard(Unlock candidate, HashSet<int> current_cards, UnlockRequest request)
		{
			return AllowIfOnList != Types.Contains(candidate.CardType);
		}
	}
}
