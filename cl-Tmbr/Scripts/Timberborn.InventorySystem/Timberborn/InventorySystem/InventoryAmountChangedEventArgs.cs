using Timberborn.Goods;

namespace Timberborn.InventorySystem
{
	public readonly struct InventoryAmountChangedEventArgs
	{
		public GoodAmount GoodAmount { get; }

		public InventoryAmountChangedEventArgs(GoodAmount goodAmount)
		{
			GoodAmount = goodAmount;
		}
	}
}
