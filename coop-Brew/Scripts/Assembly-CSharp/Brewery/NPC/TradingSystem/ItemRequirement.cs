using System;
using InventorySystem;

namespace Brewery.NPC.TradingSystem
{
	[Serializable]
	public struct ItemRequirement
	{
		public Item item;

		public int quantity;

		public ItemRequirement(Item item, int quantity)
		{
			this.item = null;
			this.quantity = 0;
		}
	}
}
