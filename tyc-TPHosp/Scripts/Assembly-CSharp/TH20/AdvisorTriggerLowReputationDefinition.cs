using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerLowReputationDefinition : AdvisorTriggerDefinition
	{
		[Header("Low Reputation")]
		[Tooltip("The reputation type that we are interested in...")]
		public AdvisorTriggerLowReputation.ReputationType ReputationType;

		[Tooltip("If Reputation falls below this value then trigger the message with low priority.")]
		public float LowPriThreshold = 0.32f;

		[Tooltip("If Reputation falls below this value then trigger the message with medium priority.")]
		public float MedPriThreshold = 0.25f;

		[Tooltip("If Reputation falls below this value then trigger the message with high priority.")]
		public float HiPriThreshold = 0.21f;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerLowReputation(this);
		}
	}
}
