using System.Collections.Generic;

namespace KitchenData
{
	public interface IUnlockSelector
	{
		UnlockOptions GetOptions(List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request);
	}
}
