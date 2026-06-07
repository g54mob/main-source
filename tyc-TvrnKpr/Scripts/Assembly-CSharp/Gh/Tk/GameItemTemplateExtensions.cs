namespace Gh.Tk
{
	public static class GameItemTemplateExtensions
	{
		public static bool IsFood(this GameItemTemplate template)
		{
			return false;
		}

		public static bool IsSideDish(this GameItemTemplate template)
		{
			return false;
		}

		public static int GetStockAmount(this GameItemTemplate template)
		{
			return 0;
		}

		public static bool IsDrink(this GameItemTemplate template)
		{
			return false;
		}

		public static bool IsShopItem(this GameItemTemplate template)
		{
			return false;
		}

		public static bool IsIngredientPart(this GameItemTemplate template)
		{
			return false;
		}

		public static bool IsLaundryItem(this GameItemTemplate template)
		{
			return false;
		}

		public static bool IsBlacksmithItem(this GameItemTemplate template)
		{
			return false;
		}

		public static bool IsOthers(this GameItemTemplate template)
		{
			return false;
		}

		public static bool IsOthers(this IPatronRatable ratable)
		{
			return false;
		}

		public static bool IsWhitelisted(this GameItemTemplate template)
		{
			return false;
		}

		public static ShopItemDemand GetItemDemand(this ShopItemTemplate template)
		{
			return default(ShopItemDemand);
		}
	}
}
