namespace Gh.Tk
{
	public static class ItemCategories
	{
		public const string SideDish = "side";

		public const string Main = "main";

		public const string Dessert = "dessert";

		public const string Drink = "drink";

		public const string Ingredient = "ingredient";

		public const string ShopItem = "shop";

		public const string Ingot = "ingot";

		public const string Story = "story";

		public static string[] AllItemCategories;

		public static string[] FoodCategories;

		public static string[] DrinkCategories;

		public static string[] GetAllItemCategories()
		{
			return null;
		}

		public static string GetFinanceCategoryFromItemCategory(string category)
		{
			return null;
		}

		public static bool IsFood(string category)
		{
			return false;
		}

		public static bool IsDrink(string category)
		{
			return false;
		}

		public static bool IsShopItem(string category)
		{
			return false;
		}

		public static string GetDisplayNameKey(string category, bool plural = false)
		{
			return null;
		}
	}
}
