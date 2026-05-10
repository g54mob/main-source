using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Map;

namespace ScheduleOne.Cartel
{
	public class StealDeadDrop : CartelActivity
	{
		public const int MIN_TIME_SINCE_CONTENTS_CHANGED = 360;

		public ItemDefinition[] ItemsToLeave;

		public override bool IsRegionValidForActivity(EMapRegion region)
		{
			return false;
		}

		public override void Activate(EMapRegion region)
		{
		}

		private static DeadDrop GetRandomDropToStealFrom(EMapRegion region)
		{
			return null;
		}
	}
}
