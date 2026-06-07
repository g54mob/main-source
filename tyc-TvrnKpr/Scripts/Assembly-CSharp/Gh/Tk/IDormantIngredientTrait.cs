namespace Gh.Tk
{
	public interface IDormantIngredientTrait
	{
		bool ShouldActivate(CraftProcess process, RecipeInput[] inputs, Ingredient output);
	}
}
