using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenData
{
	[Serializable]
	public class UnlockSetHalloween : IUnlockSet
	{
		public IEnumerable<Unlock> GetCardSet(UnlockRequest request)
		{
			return from u in GameData.Main.Get<Unlock>()
				where u.UnlockGroup == UnlockGroup.Special && u.CardType == CardType.HalloweenTrick
				select u;
		}
	}
}
