using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerMoreRoomsOfTypeDefinition : AdvisorTriggerDefinition
	{
		[Header("More Rooms of Type")]
		[Tooltip("The room type we are interested in")]
		public RoomDefinition.Type RoomType = RoomDefinition.Type.GPOffice;

		[Tooltip("If queue length reaches this size the trigger a low priority message")]
		public float QueueLengthLowPri = 4f;

		[Tooltip("If queue length reaches this size the trigger a medium priority message")]
		public float QueueLengthMedPri = 6f;

		[Tooltip("If queue length reaches this size the trigger a high priority message")]
		public float QueueLengthHiPri = 8f;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerMoreRoomsOfType(this);
		}
	}
}
