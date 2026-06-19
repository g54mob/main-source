using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerNoSeatsDefinition : AdvisorTriggerDefinition
	{
		[Header("No Seats")]
		[Tooltip("Number of patients before we care about this")]
		public int NumPatientsThreshold = 20;

		[Tooltip("Number of patients in queues before we care about this")]
		public int NumPatientsInQueuesThreshold = 20;

		[Tooltip("Percentage of patients in queue forced to stand to trigger a low priority message")]
		public float PercentageForceToStandLowPri = 0.4f;

		[Tooltip("Percentage of patients in queue forced to stand to trigger a medium priority message")]
		public float PercentageForceToStandMedPri = 0.5f;

		[Tooltip("Percentage of patients in queue forced to stand to trigger a high priority message")]
		public float PercentageForceToStandHiPri = 0.6f;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerNoSeats(this);
		}
	}
}
