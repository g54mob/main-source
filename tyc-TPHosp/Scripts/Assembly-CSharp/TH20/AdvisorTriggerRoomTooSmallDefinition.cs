using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerRoomTooSmallDefinition : AdvisorTriggerDefinition
	{
		[Header("Room Too Small")]
		[Tooltip("The number of times this message will be shown")]
		public int MaxSmallRooms = 4;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerRoomTooSmall(this);
		}
	}
}
