using System;
using System.Collections.Generic;

namespace KitchenData
{
	[Serializable]
	public class UnlockSetFixed : IUnlockSet
	{
		public List<Unlock> Unlocks = new List<Unlock>();

		public IEnumerable<Unlock> GetCardSet(UnlockRequest request)
		{
			return Unlocks;
		}
	}
}
