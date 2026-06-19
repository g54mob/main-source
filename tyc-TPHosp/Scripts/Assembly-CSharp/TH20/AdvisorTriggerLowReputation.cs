using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerLowReputation : AdvisorTrigger
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

		[SerializeField]
		private AdvisorTriggerLowReputationDefinition _definition;

		public AdvisorTriggerLowReputation(AdvisorTriggerLowReputationDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			float num = 1f;
			switch (_definition.ReputationType)
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
			if (num > _definition.LowPriThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num > _definition.MedPriThreshold)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num > _definition.HiPriThreshold)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
