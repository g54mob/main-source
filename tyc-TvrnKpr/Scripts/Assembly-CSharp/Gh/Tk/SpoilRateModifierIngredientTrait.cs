namespace Gh.Tk
{
	public abstract class SpoilRateModifierIngredientTrait : IngredientTrait
	{
		[PersistenceOptIn]
		public float SpoilModifier { get; private set; }

		protected SpoilRateModifierIngredientTrait()
		{
		}

		public SpoilRateModifierIngredientTrait(GameObjectX owner, float spoilModifier)
		{
		}
	}
}
