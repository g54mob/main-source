using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerTooManyStaffOfTypeDefinition : AdvisorTriggerDefinition
	{
		[Header("Too Many Staff")]
		[Tooltip("The staff type we are interested in")]
		public StaffDefinition.Type StaffType;

		[Tooltip("Number of that staff type before we start caring about this")]
		public int NumStaffThreshold = 3;

		[Tooltip("Percentage of staff of this type that will trigger a low priority message")]
		public float PercentIdleLowPri = 0.2f;

		[Tooltip("Percentage of staff of this type that will trigger a medium priority message")]
		public float PercentIdleMedPri = 0.4f;

		[Tooltip("Percentage of staff of this type that will trigger a high priority message")]
		public float PercentIdleHiPri = 0.6f;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerTooManyStaffOfType(this);
		}
	}
}
