namespace Gh.Tk
{
	public static class GameItemExtensions
	{
		public static bool CanTrash(this GameItem item)
		{
			return false;
		}

		public static bool IsFood(this GameItem item)
		{
			return false;
		}

		public static bool IsSideDish(this GameItem item)
		{
			return false;
		}

		public static int GetStockAmount(this GameItem item)
		{
			return 0;
		}

		public static bool IsDrink(this GameItem item)
		{
			return false;
		}

		public static bool IsIngredientPart(this GameItem item)
		{
			return false;
		}

		public static bool IsOthers(this GameItem item)
		{
			return false;
		}

		public static ShopItemDemand GetItemDemand(this ShopItem item)
		{
			return default(ShopItemDemand);
		}
	}
}
