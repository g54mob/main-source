using KitchenData;

namespace Kitchen.ShopBuilder
{
	public struct ShopBuilderApplianceInfo
	{
		public int ID;

		public ShoppingTags ShoppingTags;

		public bool SellOnlyAsDuplicate;

		public bool SellOnlyAsUnique;

		public DataObjectList RequiresForShop;

		public DataObjectList RequiresPhaseForShop;

		public DataObjectList RequiresProcessForShop;

		public DataObjectList RequiresIngredientForShop;
	}
}
