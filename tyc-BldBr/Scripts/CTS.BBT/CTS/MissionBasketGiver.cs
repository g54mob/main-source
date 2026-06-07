using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class MissionBasketGiver : ShopBasketGiver
	{
		[SerializeField]
		private StringKey _key;

		protected override ShopBasket GetBasket()
		{
			if (!CTSSingleton<StoreBaskets>.InstanceExists())
			{
				return null;
			}
			return CTSSingleton<StoreBaskets>.Instance.GetMissionBasket(_key);
		}
	}
}
