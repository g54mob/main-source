using System;
using System.Collections.Generic;

namespace KitchenData
{
	[Serializable]
	public class UnlockSetAutomatic : IUnlockSet
	{
		public IEnumerable<Unlock> GetCardSet(UnlockRequest request)
		{
			return GameData.Main.Get<Unlock>();
		}
	}
}
