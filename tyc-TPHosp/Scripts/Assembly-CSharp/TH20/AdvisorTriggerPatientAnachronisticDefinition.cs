using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerPatientAnachronisticDefinition : AdvisorTriggerDefinition
	{
		[Tooltip("The priority level of the message")]
		public Advisor.PriorityLevel PriorityLevel = Advisor.PriorityLevel.High;

		[Tooltip("The total number of messages that will be fired, 0 = always active")]
		public int NumMessages = 1;

		[Tooltip("Message delay, in days, until becomes active")]
		public float MessageDelay;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerPatientAnachronistic(this);
		}
	}
}
