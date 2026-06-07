namespace DV.Shops
{
	public class ShoppingCartEntry
	{
		public Shop shop;

		public InventoryItemSpec specs;

		public int desiredAmount;

		public ShoppingCartEntry(Shop shop, InventoryItemSpec specs, int desiredAmount)
		{
			this.shop = shop;
			this.specs = specs;
			this.desiredAmount = desiredAmount;
		}
	}
}
