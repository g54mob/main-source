namespace Gh.Tk
{
	[TraitRarityConfig(0.03f, null)]
	public class NarcolepticTrait : ActorTrait
	{
		[PersistenceOptIn]
		private float _secondsUntilNextCheck;

		[PersistenceOptIn]
		public float SleepTimeRemaining { get; set; }

		protected NarcolepticTrait()
		{
		}

		public NarcolepticTrait(Actor owner)
		{
		}

		public override void Update()
		{
		}
	}
}
