namespace Gh.Tk
{
	public class StaffQuietSleepExpectation : StaffExpectationBase
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private EnergyStat _energy;

		protected StaffQuietSleepExpectation()
		{
		}

		public StaffQuietSleepExpectation(Staff owner)
		{
		}

		public override void Init()
		{
		}

		public override bool IsEnabled()
		{
			return false;
		}

		protected override void UpdateInternal()
		{
		}
	}
}
