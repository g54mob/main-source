using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerTooManyStaffOfType : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerTooManyStaffOfTypeDefinition _definition;

		public AdvisorTriggerTooManyStaffOfType(AdvisorTriggerTooManyStaffOfTypeDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.CharacterManager.StaffMembers.Count < 0)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int num = 0;
			int num2 = 0;
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				if (staffMember.Definition._type == _definition.StaffType)
				{
					num2++;
					if (staffMember.CurrentMode == Staff.Mode.Work && staffMember.CurrentJob == null)
					{
						num++;
					}
				}
			}
			if (num2 <= 0 || num2 < _definition.NumStaffThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			float num3 = (float)num / (float)num2;
			if (num3 < _definition.PercentIdleLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num3 < _definition.PercentIdleMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num3 < _definition.PercentIdleHiPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
