using System;
using InventorySystem;

namespace Brewery.NPC.TradingSystem
{
	[Serializable]
	public struct ItemReward
	{
		public Item item;

		public int baseQuantity;

		public ItemReward(Item item, int baseQuantity)
		{
			this.item = null;
			this.baseQuantity = 0;
		}
	}
}
