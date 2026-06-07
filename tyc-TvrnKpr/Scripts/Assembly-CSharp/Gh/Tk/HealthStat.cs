namespace Gh.Tk
{
	public class HealthStat : ActorStat
	{
		[PersistenceOptIn]
		private bool _isDead;

		protected HealthStat()
		{
		}

		public HealthStat(Actor owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		public override void Update()
		{
		}
	}
}
