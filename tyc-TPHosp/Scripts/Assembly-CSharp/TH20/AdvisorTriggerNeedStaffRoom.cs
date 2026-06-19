using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerNeedStaffRoom : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerNeedStaffRoomDefinition _definition;

		public AdvisorTriggerNeedStaffRoom(AdvisorTriggerNeedStaffRoomDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			if (GameAlgorithms.DoesHospitalHaveRoom(Level.WorldState, RoomDefinition.Type.StaffRoom))
			{
				return Advisor.PriorityLevel.DontShow;
			}
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				if (staffMember.CurrentMode == Staff.Mode.Break)
				{
					return _definition.Priority;
				}
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
