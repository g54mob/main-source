using ScheduleOne.Map;

namespace ScheduleOne.Cartel
{
	public class CartelCustomerDeal : CartelActivity
	{
		public const int TIMEOUT_MINUTES = 720;

		private CartelDealer dealer;

		public override bool IsRegionValidForActivity(EMapRegion region)
		{
			return false;
		}

		public override void Activate(EMapRegion region)
		{
		}

		protected override void MinPassed()
		{
		}

		protected override void Deactivate()
		{
		}

		private void DealerUnconscious()
		{
		}
	}
}
