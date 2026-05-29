using ScheduleOne.Equipping;
using ScheduleOne.Growing;

namespace ScheduleOne.ObjectScripts.Soil
{
	public class Equippable_Soil : Equippable_Pourable
	{
		protected override bool CanPour(GrowContainer growContainer, out string reason)
		{
			reason = null;
			return false;
		}

		protected override void StartPourTask(GrowContainer growContainer)
		{
		}
	}
}
