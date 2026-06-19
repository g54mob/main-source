using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerStaffTraining : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerStaffTrainingDefinition _definition;

		[SerializeField]
		private string _messageToDisplay;

		public AdvisorTriggerStaffTraining(AdvisorTriggerStaffTrainingDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			bool flag = false;
			foreach (RoomDefinition availableRoom in Level.WorldState.AvailableRooms)
			{
				if (availableRoom._type == RoomDefinition.Type.Training)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int count = Level.CharacterManager.StaffMembers.Count;
			if (count < _definition.MinStaffThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int num = 0;
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				if (staffMember.MaxQualifications > staffMember.Qualifications.Count)
				{
					num++;
				}
			}
			float num2 = (float)num / (float)count;
			if (num2 < _definition.LowPriThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (GameAlgorithms.DoesHospitalHaveRoom(Level.WorldState, RoomDefinition.Type.Training))
			{
				_messageToDisplay = _definition.MessageLocalised.Translation;
			}
			else
			{
				_messageToDisplay = _definition.MessageIfNoTrainingRoomLocalised.Translation;
			}
			if (num2 < _definition.MedPriThreshold)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num2 < _definition.HighPriThreshold)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Message = _messageToDisplay;
			return result;
		}
	}
}
