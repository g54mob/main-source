using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerStaffPaySatisfaction : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerStaffPaySatisfactionDefinition _definition;

		public AdvisorTriggerStaffPaySatisfaction(AdvisorTriggerStaffPaySatisfactionDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			int num = 0;
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				if (!staffMember.IsSatisfiedWithSalary)
				{
					num++;
				}
			}
			if (num < _definition.MinStaffThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			return _definition.PriorityLevel;
		}
	}
}
