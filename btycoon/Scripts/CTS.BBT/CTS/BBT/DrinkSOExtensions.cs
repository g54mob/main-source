namespace CTS.BBT
{
	public static class DrinkSOExtensions
	{
		public static bool CanBePrepared(this DrinkSO drinkSO)
		{
			if ((object)drinkSO == null)
			{
				return false;
			}
			foreach (RecipeIngredient ingredient in drinkSO.Recipe.Ingredients)
			{
				if (Stocks.GetStockedCount(ingredient.ScriptableObject) < ingredient.Count)
				{
					return false;
				}
			}
			return true;
		}
	}
}
