using System.Collections.Generic;

namespace KitchenData
{
	public interface IUnlockSorter
	{
		void SortCards(ref List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request);
	}
}
