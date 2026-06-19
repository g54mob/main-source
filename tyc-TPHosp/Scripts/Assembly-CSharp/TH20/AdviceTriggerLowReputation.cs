using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerLowReputation : AdviceTrigger
	{
		public enum ReputationType
		{
			OverallReputation = 0,
			MedicalReputation = 1,
			PatientReputation = 2,
			PricesReputation = 3,
			StaffReputation = 4,
			SpecialReputation = 5
		}

		[InspectorMargin(8)]
		[InspectorHeader("Low Reputation")]
		[InspectorTooltip("The reputation type that we are interested in...")]
		[SerializeField]
		private ReputationType _reputationType;

		[InspectorTooltip("If Reputation falls below this value then trigger the message with low priority.")]
		[SerializeField]
		private float _LowPriThreshold = 0.32f;

		[InspectorTooltip("If Reputation falls below this value then trigger the message with medium priority.")]
		[SerializeField]
		private float _MedPriThreshold = 0.25f;

		[InspectorTooltip("If Reputation falls below this value then trigger the message with high priority.")]
		[SerializeField]
		private float _HiPriThreshold = 0.21f;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			float num = 1f;
			switch (_reputationType)
			{
			case ReputationType.OverallReputation:
				num = Level.ReputationTracker.OverallReputation;
				break;
			case ReputationType.MedicalReputation:
				num = Level.ReputationTracker.MedicalReputation;
				break;
			case ReputationType.PatientReputation:
				num = Level.ReputationTracker.PatientReputation;
				break;
			case ReputationType.PricesReputation:
				num = Level.ReputationTracker.PriceReputation;
				break;
			case ReputationType.StaffReputation:
				num = Level.ReputationTracker.StaffReputation;
				break;
			case ReputationType.SpecialReputation:
				num = Level.ReputationTracker.SpecialReputation;
				break;
			}
			if (num > _LowPriThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num > _MedPriThreshold)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num > _HiPriThreshold)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
