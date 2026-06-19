using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerRoomNeedsQualificationDefinition : AdvisorTriggerDefinition
	{
		[Header("Qualification Required")]
		[Tooltip("The priority level of the message if a room requires a qualification we don't have")]
		public Advisor.PriorityLevel PriorityLevel = Advisor.PriorityLevel.High;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerRoomNeedsQualification(this);
		}
	}
}
