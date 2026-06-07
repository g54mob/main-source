namespace Gh.Tk
{
	public class HappinessBehaviour : StaffBehaviour
	{
		public float triggerChancePerHour;

		[PersistenceOptIn]
		private float _threateningActiveCountdown;

		protected HappinessBehaviour()
		{
		}

		public HappinessBehaviour(Staff staff)
		{
		}

		public override void Update()
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}
	}
}
