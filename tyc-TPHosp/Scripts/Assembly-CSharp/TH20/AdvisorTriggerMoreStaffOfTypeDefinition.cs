using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerMoreStaffOfTypeDefinition : AdvisorTriggerDefinition
	{
		[Header("Need More Staff")]
		[Tooltip("The staff type we are interested in")]
		public StaffDefinition.Type StaffType;

		[Tooltip("Number of patients in hospital before we start caring about this")]
		public int NumPatientsThreshold = 20;

		[Tooltip("If total percentage of queuing patients in hospital drifts higher than this threshold then trigger a low priority message")]
		public float PercQueuingLowPri = 0.04f;

		[Tooltip("If total percentage of queuing patients in hospital drifts higher than this threshold then trigger a medium priority message")]
		public float PercQueuingMedPri = 0.06f;

		[Tooltip("If total percentage of queuing patients in hospital drifts higher than this threshold then trigger a high priority message")]
		public float PercQueuingHighPri = 0.08f;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerMoreStaffOfType(this);
		}
	}
}
