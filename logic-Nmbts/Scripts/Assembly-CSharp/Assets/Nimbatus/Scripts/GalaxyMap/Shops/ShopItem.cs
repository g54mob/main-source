using System;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Shops
{
	[Serializable]
	public abstract class ShopItem
	{
		public ItemPrice Price;

		public abstract void Buy();

		public abstract bool IsInStock();

		public abstract bool HasCapacityToBuy();

		public abstract bool HasResourcesToBuy();
	}
}
