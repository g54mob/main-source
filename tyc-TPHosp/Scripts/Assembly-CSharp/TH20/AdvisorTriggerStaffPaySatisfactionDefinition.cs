using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerStaffPaySatisfactionDefinition : AdvisorTriggerDefinition
	{
		[Tooltip("The minimum number of staff with below satisfied pay...")]
		public int MinStaffThreshold = 8;

		[Tooltip("The priority level of the message.")]
		public Advisor.PriorityLevel PriorityLevel = Advisor.PriorityLevel.High;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerStaffPaySatisfaction(this);
		}
	}
}
