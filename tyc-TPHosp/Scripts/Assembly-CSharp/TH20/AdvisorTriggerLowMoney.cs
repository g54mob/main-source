using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerLowMoney : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerLowMoneyDefinition _definition;

		public AdvisorTriggerLowMoney(AdvisorTriggerLowMoneyDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.FinanceManager.Balance >= _definition.LowMoneyThreshold)
			{
				int num = 0;
				num += Level.FinanceManager.TotalStaffWages / 12;
				foreach (LoanOffer offer in Level.LoanManager.Offers)
				{
					if (offer.Active)
					{
						num += offer.MonthlyRepayment;
					}
				}
				if (Level.FinanceManager.Balance - num < _definition.LowMoneyThreshold)
				{
					return _definition.PriorityLevel;
				}
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
