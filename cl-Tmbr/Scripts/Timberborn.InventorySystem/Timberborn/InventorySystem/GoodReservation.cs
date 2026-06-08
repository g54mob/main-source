using Timberborn.Goods;

namespace Timberborn.InventorySystem
{
	public readonly struct GoodReservation
	{
		public Inventory Inventory { get; }

		public GoodAmount GoodAmount { get; }

		public bool FixedAmount { get; }

		public GoodReservation(Inventory inventory, GoodAmount goodAmount, bool fixedAmount)
		{
			Inventory = inventory;
			GoodAmount = goodAmount;
			FixedAmount = fixedAmount;
		}
	}
}
