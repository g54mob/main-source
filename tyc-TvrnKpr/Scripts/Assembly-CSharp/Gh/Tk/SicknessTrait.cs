namespace Gh.Tk
{
	public abstract class SicknessTrait : ActorTrait, IProgressTrait
	{
		[PersistenceOptIn]
		protected IRng _rng;

		[PersistenceOptIn]
		protected float _strength;

		[PersistenceOptIn]
		protected float _healEffectiveness;

		protected HappinessStat _happiness;

		protected EnergyStat _energy;

		protected float _healsInNDays;

		public int CuredPercentage => 0;

		public float ProgressPercentage => 0f;

		protected SicknessTrait()
		{
		}

		public SicknessTrait(Actor owner)
		{
		}

		public override void Init()
		{
		}

		public virtual float GetInfectionChance()
		{
			return 0f;
		}

		public virtual float GetInfectionDistance()
		{
			return 0f;
		}

		public override void Update()
		{
		}

		protected void CalculateStrength()
		{
		}

		protected virtual void RemoveSickness()
		{
		}

		public override void OnRemoving()
		{
		}

		protected override string GetTooltipTextKey()
		{
			return null;
		}
	}
}
