using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerMoreRoomsOfType : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerMoreRoomsOfTypeDefinition _definition;

		public AdvisorTriggerMoreRoomsOfType(AdvisorTriggerMoreRoomsOfTypeDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			int num = 0;
			foreach (Room allRoom in Level.WorldState.AllRooms)
			{
				if (allRoom.Definition._type == _definition.RoomType && allRoom.IsStaffed())
				{
					num = Mathf.Max(num, allRoom.QueueLength);
				}
			}
			if ((float)num < _definition.QueueLengthLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if ((float)num < _definition.QueueLengthMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if ((float)num < _definition.QueueLengthHiPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
