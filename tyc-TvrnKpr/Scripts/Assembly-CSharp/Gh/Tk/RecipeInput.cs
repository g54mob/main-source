namespace Gh.Tk
{
	public class RecipeInput : IPersistable
	{
		[PersistenceObjectReference]
		public IngredientTemplate IngredientTemplate;

		public int Amount;
	}
}
