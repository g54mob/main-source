using ScheduleOne.Economy;
using ScheduleOne.Map;

namespace ScheduleOne.Cartel
{
	public class RobDealer : CartelActivity
	{
		public override bool IsRegionValidForActivity(EMapRegion region)
		{
			return false;
		}

		private Dealer GetDealerToRob(EMapRegion region)
		{
			return null;
		}

		public override void Activate(EMapRegion region)
		{
		}
	}
}
