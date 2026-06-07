namespace Gh.Tk
{
	public abstract class IngredientTrait : GameItemTrait
	{
		public Ingredient Ingredient => null;

		protected IngredientTrait()
		{
		}

		public IngredientTrait(GameObjectX owner)
		{
		}

		public virtual void OnConsume(Actor target)
		{
		}
	}
}
