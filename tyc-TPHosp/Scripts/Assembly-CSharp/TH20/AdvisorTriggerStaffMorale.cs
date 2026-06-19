using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerStaffMorale : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerStaffMoraleDefinition _definition;

		public AdvisorTriggerStaffMorale(AdvisorTriggerStaffMoraleDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.CharacterManager.StaffMembers.Count < _definition.MinStaffThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			float staffMorale = Level.CharacterManager.StaffMorale;
			if (staffMorale > _definition.LowPriThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (staffMorale > _definition.MedPriThreshold)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (staffMorale > _definition.HighPriThreshold)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
