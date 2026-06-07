namespace Gh.Tk
{
	public class ExplosiveTrait : IngredientTrait, IProgressTrait
	{
		[PersistenceOptIn]
		private bool _errorInfoSet;

		private const float _hoursTillExplode = 4f;

		public const float EXPLOSION_TEMP = 4.5f;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameObjectX PreviousTargetProp;

		[PersistenceOptIn]
		private float _triggeredAt;

		[PersistenceOptIn]
		public float ProgressPercentage { get; protected set; }

		protected ExplosiveTrait()
		{
		}

		public ExplosiveTrait(GameObjectX owner)
		{
		}

		public override void Update()
		{
		}

		private void Trigger()
		{
		}

		private GameObjectX GetTargetProp()
		{
			return null;
		}

		public override void OnRemoving()
		{
		}
	}
}
