using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerStaffPromotions : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerStaffPromotionsDefinition _definition;

		public AdvisorTriggerStaffPromotions(AdvisorTriggerStaffPromotionsDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			int count = Level.CharacterManager.StaffMembers.Count;
			if (count < _definition.MinStaffThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int num = 0;
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				if (staffMember.IsReadyForPromotion)
				{
					num++;
				}
			}
			float num2 = (float)num / (float)count;
			if (num2 < _definition.LowPriThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num2 < _definition.MedPriThreshold)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num2 < _definition.HighPriThreshold)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
