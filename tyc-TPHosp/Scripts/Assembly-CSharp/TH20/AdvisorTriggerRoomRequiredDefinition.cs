using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerRoomRequiredDefinition : AdvisorTriggerDefinition
	{
		[Header("Room Required")]
		[Tooltip("The room type we are interested in.")]
		public RoomDefinition.Type RoomType = RoomDefinition.Type.GPOffice;

		[Tooltip("Total patients waiting for room to trigger advisor.")]
		public int NumWaitingForRoom = 1;

		[Tooltip("Advisor priority level.")]
		public Advisor.PriorityLevel Priority;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerRoomRequired(this);
		}
	}
}
