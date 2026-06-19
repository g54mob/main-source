using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerNegativeMoney : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerNegativeMoneyDefinition _definition;

		public AdvisorTriggerNegativeMoney(AdvisorTriggerNegativeMoneyDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.FinanceManager.Balance < _definition.MoneyThreshold)
			{
				return _definition.PriorityLevel;
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
