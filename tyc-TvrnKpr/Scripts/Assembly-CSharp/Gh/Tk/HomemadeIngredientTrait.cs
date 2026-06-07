namespace Gh.Tk
{
	public class HomemadeIngredientTrait : IngredientTrait, IIngredientOkPriceBonus
	{
		protected HomemadeIngredientTrait()
		{
		}

		public HomemadeIngredientTrait(GameObjectX owner)
		{
		}

		public int GetBonusPercentage(string race, int tier)
		{
			return 0;
		}
	}
}
