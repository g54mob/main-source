using System.Collections.Generic;

namespace KitchenData
{
	public interface IUnlockFilter
	{
		bool ShouldBlockCard(Unlock candidate, HashSet<int> current_cards, UnlockRequest request);
	}
}
