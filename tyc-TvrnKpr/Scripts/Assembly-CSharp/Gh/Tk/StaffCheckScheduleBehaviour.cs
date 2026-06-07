namespace Gh.Tk
{
	public class StaffCheckScheduleBehaviour : StaffBehaviour
	{
		public const string BEHAVIOUR_NAME = "checkScheduleBehaviour";

		[PersistenceOptIn]
		private float _earliestNextCheckDayF;

		private EnergyStat _energyStat;

		private GlobalTimeController _timeController;

		protected StaffCheckScheduleBehaviour()
		{
		}

		public StaffCheckScheduleBehaviour(Staff owner)
		{
		}

		public override void Init()
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}
	}
}
