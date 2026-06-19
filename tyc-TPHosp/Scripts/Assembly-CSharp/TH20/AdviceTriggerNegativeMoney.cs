using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerNegativeMoney : AdviceTrigger
	{
		[InspectorMargin(8)]
		[InspectorHeader("Negative Money")]
		[InspectorTooltip("If your money falls below this value then trigger the message.")]
		[SerializeField]
		private int _moneyThreshold = -2000;

		[InspectorTooltip("The priority level of the message.")]
		[SerializeField]
		private Advisor.PriorityLevel _priorityLevel = Advisor.PriorityLevel.High;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.FinanceManager.Balance < _moneyThreshold)
			{
				return _priorityLevel;
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
