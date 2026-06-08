using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenData
{
	[Serializable]
	public class UnlockSetGroup : IUnlockSet
	{
		public UnlockGroup Group;

		public IEnumerable<Unlock> GetCardSet(UnlockRequest request)
		{
			return from u in GameData.Main.Get<Unlock>()
				where u.UnlockGroup == Group
				select u;
		}
	}
}
