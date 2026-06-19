using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerStaffPromotionsDefinition : AdvisorTriggerDefinition
	{
		[Header("Staff Promotions")]
		[Tooltip("The minimum number of staff until we start caring about this... Must be greater than 0!")]
		public int MinStaffThreshold = 8;

		[Tooltip("If this proportion of staff or more are waiting for promotion then trigger a low priority message.")]
		public float LowPriThreshold = 0.18f;

		[Tooltip("If this proportion of staff or more are waiting for promotion then trigger a medium priority message.")]
		public float MedPriThreshold = 0.24f;

		[Tooltip("If this proportion of staff or more are waiting for promotion then trigger a high priority message.")]
		public float HighPriThreshold = 0.3f;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerStaffPromotions(this);
		}
	}
}
