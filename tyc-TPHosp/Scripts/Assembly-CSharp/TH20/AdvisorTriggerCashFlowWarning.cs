using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerCashFlowWarning : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerCashFlowWarningDefinition _definition;

		public AdvisorTriggerCashFlowWarning(AdvisorTriggerCashFlowWarningDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			LevelStatsDatabase.MonthStats latestCompletedMonthStats = Level.LevelStatsDatabase.GetLatestCompletedMonthStats();
			if (latestCompletedMonthStats.StartGameDate.Year < 0)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int revenue = latestCompletedMonthStats.Revenue;
			int num = 0;
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				num += staffMember.GetSalary() / 12;
			}
			foreach (LoanOffer offer in Level.LoanManager.Offers)
			{
				if (offer.Active)
				{
					num += offer.MonthlyRepayment;
				}
			}
			int num2 = revenue - num;
			if (num2 > _definition.LowPriThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num2 > _definition.MedPriThreshold)
			{
				return Advisor.PriorityLevel.Medium;
			}
			if (num2 > _definition.HiPriThreshold)
			{
				return Advisor.PriorityLevel.High;
			}
			return Advisor.PriorityLevel.VeryHigh;
		}
	}
}
