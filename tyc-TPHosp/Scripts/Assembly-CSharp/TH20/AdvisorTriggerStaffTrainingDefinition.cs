using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerStaffTrainingDefinition : AdvisorTriggerDefinition
	{
		[Header("Staff Training")]
		[Tooltip("The minimum number of staff until we start caring about this...")]
		public int MinStaffThreshold = 8;

		[Tooltip("If this proportion of staff or more have free training slots then trigger a low priority message.")]
		public float LowPriThreshold = 0.15f;

		[Tooltip("If this proportion of staff or more have free training slots then trigger a medium priority message.")]
		public float MedPriThreshold = 0.225f;

		[Tooltip("If this proportion of staff or more have free training slots then trigger a high priority message.")]
		public float HighPriThreshold = 0.3f;

		[Tooltip("Display this message if the conditions hold but you don't have a training room.")]
		public LocalisedString MessageIfNoTrainingRoomLocalised;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerStaffTraining(this);
		}
	}
}
