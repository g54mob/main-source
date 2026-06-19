using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerTooManyAliensDefinition : AdvisorTriggerDefinition
	{
		[Header("Too Many Aliens")]
		[Tooltip("If the number of aliens in the level is greater than this threshold then trigger the message")]
		public int AlienCountThreshold;

		[Tooltip("The priority level of the message.")]
		public Advisor.PriorityLevel PriorityLevel = Advisor.PriorityLevel.High;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerTooManyAliens(this);
		}
	}
}
