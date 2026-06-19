using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerDiagnosisRoomRequiredDefinition : AdvisorTriggerDefinition
	{
		[Header("Diagnosis Room Required")]
		[Tooltip("The priority level of the message")]
		public Advisor.PriorityLevel PriorityLevel = Advisor.PriorityLevel.High;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerDiagnosisRoomRequired(this);
		}
	}
}
