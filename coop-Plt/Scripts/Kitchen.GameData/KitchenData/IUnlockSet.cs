using System.Collections.Generic;

namespace KitchenData
{
	public interface IUnlockSet
	{
		IEnumerable<Unlock> GetCardSet(UnlockRequest request);
	}
}
