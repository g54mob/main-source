using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerNegativeMoneyDefinition : AdvisorTriggerDefinition
	{
		[Header("Negative Money")]
		[Tooltip("If your money falls below this value then trigger the message.")]
		public int MoneyThreshold = -2000;

		[Tooltip("The priority level of the message.")]
		public Advisor.PriorityLevel PriorityLevel = Advisor.PriorityLevel.High;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerNegativeMoney(this);
		}
	}
}
