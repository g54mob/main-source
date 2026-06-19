using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerLowMoney : AdviceTrigger
	{
		[InspectorMargin(8)]
		[InspectorHeader("Low Money")]
		[InspectorTooltip("If (Balance - Expenses) is less than this threshold then trigger the message")]
		[SerializeField]
		private int _lowMoneyThreshold;

		[InspectorTooltip("The priority level of the message.")]
		[SerializeField]
		private Advisor.PriorityLevel _priorityLevel = Advisor.PriorityLevel.High;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.FinanceManager.Balance < _lowMoneyThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
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
			if (Level.FinanceManager.Balance - num < _lowMoneyThreshold)
			{
				return _priorityLevel;
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
