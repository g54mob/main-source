using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerLowMoneyDefinition : AdvisorTriggerDefinition
	{
		[Header("Low Money")]
		[Tooltip("If (Balance - Expenses) is less than this threshold then trigger the message")]
		public int LowMoneyThreshold;

		[Tooltip("The priority level of the message.")]
		public Advisor.PriorityLevel PriorityLevel = Advisor.PriorityLevel.High;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerLowMoney(this);
		}
	}
}
