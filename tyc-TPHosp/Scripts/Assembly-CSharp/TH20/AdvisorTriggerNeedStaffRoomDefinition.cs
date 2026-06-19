using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerNeedStaffRoomDefinition : AdvisorTriggerDefinition
	{
		[Header("Need Staff Room")]
		[Tooltip("What is the priority of this message when it is triggered")]
		public Advisor.PriorityLevel Priority = Advisor.PriorityLevel.High;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerNeedStaffRoom(this);
		}
	}
}
