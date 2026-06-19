using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerTreatmentRoomRequiredDefinition : AdvisorTriggerDefinition
	{
		[Header("Treatment Room Required")]
		[Tooltip("The priority level of the message")]
		public Advisor.PriorityLevel PriorityLevel = Advisor.PriorityLevel.High;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerTreatmentRoomRequired(this);
		}
	}
}
