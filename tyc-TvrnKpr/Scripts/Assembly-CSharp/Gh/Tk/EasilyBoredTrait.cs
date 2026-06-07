namespace Gh.Tk
{
	[TraitRarityConfig(0.01f, null)]
	public class EasilyBoredTrait : StaffTrait
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private HappinessStat _stat;

		protected EasilyBoredTrait()
		{
		}

		public EasilyBoredTrait(Staff owner)
		{
		}

		public override void Init()
		{
		}

		public override void Update()
		{
		}
	}
}
