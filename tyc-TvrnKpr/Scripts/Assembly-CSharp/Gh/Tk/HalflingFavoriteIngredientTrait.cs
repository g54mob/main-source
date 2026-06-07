namespace Gh.Tk
{
	public class HalflingFavoriteIngredientTrait : IngredientTrait, IIngredientTraitFlavorBonus
	{
		protected HalflingFavoriteIngredientTrait()
		{
		}

		public HalflingFavoriteIngredientTrait(GameObjectX owner)
		{
		}

		public int GetBonusPercentage(string race, int tier)
		{
			return 0;
		}
	}
}
