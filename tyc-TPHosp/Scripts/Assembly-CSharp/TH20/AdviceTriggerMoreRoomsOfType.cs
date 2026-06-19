using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerMoreRoomsOfType : AdviceTrigger
	{
		[InspectorMargin(8)]
		[InspectorHeader("More Rooms of Type")]
		[InspectorTooltip("The room type we are interested in")]
		[SerializeField]
		private RoomDefinition.Type _roomType = RoomDefinition.Type.GPOffice;

		[InspectorTooltip("If queue length reaches this size the trigger a low priority message")]
		[SerializeField]
		private float _queueLengthLowPri = 4f;

		[InspectorTooltip("If queue length reaches this size the trigger a medium priority message")]
		[SerializeField]
		private float _queueLengthMedPri = 6f;

		[InspectorTooltip("If queue length reaches this size the trigger a high priority message")]
		[SerializeField]
		private float _queueLengthHiPri = 8f;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			int num = 0;
			foreach (Room allRoom in Level.WorldState.AllRooms)
			{
				if (allRoom.Definition._type == _roomType && allRoom.IsStaffed())
				{
					num = Mathf.Max(num, allRoom.QueueLength);
				}
			}
			if ((float)num < _queueLengthLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if ((float)num < _queueLengthMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if ((float)num < _queueLengthHiPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
