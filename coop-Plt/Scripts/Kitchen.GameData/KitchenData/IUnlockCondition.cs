using System.Collections.Generic;

namespace KitchenData
{
	public interface IUnlockCondition
	{
		bool ShouldProvide(List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request);
	}
}
