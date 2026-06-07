namespace Gh.Tk
{
	[TraitRarityConfig(0.005f, null)]
	public class InfluencerTrait : StaffTrait
	{
		private const float _interval = 2f;

		[PersistenceOptIn]
		private float _secondsUntilNextCheck;

		protected InfluencerTrait()
		{
		}

		public InfluencerTrait(Staff owner)
		{
		}

		public override void Update()
		{
		}
	}
}
