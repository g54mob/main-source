namespace Gh.Tk
{
	public class VoluminousVomitisTrait : SicknessTrait
	{
		[PersistenceOptIn]
		private float _nextVomitIn;

		protected VoluminousVomitisTrait()
		{
		}

		public VoluminousVomitisTrait(Actor owner)
		{
		}

		public override void Init()
		{
		}

		private void ScheduleNextVomit()
		{
		}

		public override void Update()
		{
		}

		private bool CanVomit()
		{
			return false;
		}
	}
}
