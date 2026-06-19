using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerCashFlowWarning : AdviceTrigger
	{
		[InspectorMargin(8)]
		[InspectorHeader("Cash Flow Warning")]
		[InspectorTooltip("If cash flow falls below this value then trigger the message with low priority.")]
		[SerializeField]
		private int lowPriThreshold = -1000;

		[InspectorTooltip("If cash flow falls below this value then trigger the message with medium priority.")]
		[SerializeField]
		private int medPriThreshold = -10000;

		[InspectorTooltip("If cash flow falls below this value then trigger the message with high priority.")]
		[SerializeField]
		private int hiPriThreshold = -50000;

		public override Advisor.PriorityLevel GetMessagePriority()
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
				num = staffMember.GetSalary();
			}
			foreach (LoanOffer offer in Level.LoanManager.Offers)
			{
				if (offer.Active)
				{
					num += offer.MonthlyRepayment;
				}
			}
			int num2 = revenue - num;
			if (num2 > lowPriThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num2 > medPriThreshold)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num2 > hiPriThreshold)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
