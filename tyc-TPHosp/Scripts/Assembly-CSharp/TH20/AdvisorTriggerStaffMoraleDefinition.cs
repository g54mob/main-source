using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerStaffMoraleDefinition : AdvisorTriggerDefinition
	{
		[Header("Staff Morale")]
		[Tooltip("The minimum number of staff until we start caring about this advice")]
		public int MinStaffThreshold = 6;

		[Tooltip("If your staff morale falls below this value then trigger a low priority message.")]
		public float LowPriThreshold = 0.35f;

		[Tooltip("If your staff morale falls below this value then trigger a medium priority message.")]
		public float MedPriThreshold = 0.25f;

		[Tooltip("If your staff morale falls below this value then trigger a high priority message.")]
		public float HighPriThreshold = 0.2f;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerStaffMorale(this);
		}
	}
}
