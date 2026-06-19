using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerRoomRequired : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerRoomRequiredDefinition _definition;

		public AdvisorTriggerRoomRequired(AdvisorTriggerRoomRequiredDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			int num = 0;
			foreach (Patient patient in Level.CharacterManager.Patients)
			{
				if (patient.WaitingForRoom == _definition.RoomType)
				{
					num++;
					if (num == _definition.NumWaitingForRoom)
					{
						return _definition.Priority;
					}
				}
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
