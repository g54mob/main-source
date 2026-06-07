namespace Gh.Tk
{
	public class HeartyIngredientTrait : IngredientTrait, IDormantIngredientTrait, IIngredientTraitFlavorBonus
	{
		protected HeartyIngredientTrait()
		{
		}

		public HeartyIngredientTrait(GameObjectX owner)
		{
		}

		public bool ShouldActivate(CraftProcess process, RecipeInput[] inputs, Ingredient output)
		{
			return false;
		}

		public override void OnCraftProcess(CraftProcess process, RecipeInput[] inputs, Ingredient output)
		{
		}

		public int GetBonusPercentage(string race, int tier)
		{
			return 0;
		}
	}
}
