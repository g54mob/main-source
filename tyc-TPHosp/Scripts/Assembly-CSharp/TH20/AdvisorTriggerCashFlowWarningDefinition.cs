using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerCashFlowWarningDefinition : AdvisorTriggerDefinition
	{
		[Header("Cash Flow Warning")]
		[Tooltip("If cash flow falls below this value then trigger the message with low priority.")]
		public int LowPriThreshold = -1000;

		[Tooltip("If cash flow falls below this value then trigger the message with medium priority.")]
		public int MedPriThreshold = -10000;

		[Tooltip("If cash flow falls below this value then trigger the message with high priority.")]
		public int HiPriThreshold = -50000;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerCashFlowWarning(this);
		}
	}
}
