namespace Gh.Tk
{
	public class BetterWithAgeIngredientTrait : IngredientTrait
	{
		private const float maxFactor = 1.5f;

		private const float starGain = 0.5f;

		private const float agingLength = 10f;

		[PersistenceOptIn]
		private float _factor;

		protected BetterWithAgeIngredientTrait()
		{
		}

		public BetterWithAgeIngredientTrait(GameObjectX owner)
		{
		}

		public override void Update()
		{
		}
	}
}
