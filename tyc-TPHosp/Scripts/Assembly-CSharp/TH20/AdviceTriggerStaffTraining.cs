using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerStaffTraining : AdviceTrigger
	{
		private string _messageToDisplay;

		[InspectorMargin(8)]
		[InspectorHeader("Staff Training")]
		[InspectorTooltip("The minimum number of staff until we start caring about this...")]
		[SerializeField]
		private int _minStaffThreshold = 8;

		[InspectorTooltip("If this proportion of staff or more have free training slots then trigger a low priority message.")]
		[SerializeField]
		private float _lowPriThreshold = 0.15f;

		[InspectorTooltip("If this proportion of staff or more have free training slots then trigger a medium priority message.")]
		[SerializeField]
		private float _medPriThreshold = 0.225f;

		[InspectorTooltip("If this proportion of staff or more have free training slots then trigger a high priority message.")]
		[SerializeField]
		private float _highPriThreshold = 0.3f;

		[InspectorTooltip("Display this message if the conditions hold but you don't have a training room.")]
		[FullInspector.InspectorName("Message If No Training Room")]
		[SerializeField]
		private LocalisedString _messageIfNoTrainingRoomLocalised;

		public override Advisor.PriorityLevel GetMessagePriority()
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
			if (count < _minStaffThreshold)
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
			if (num2 < _lowPriThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (GameAlgorithms.DoesHospitalHaveRoom(Level.WorldState, RoomDefinition.Type.Training))
			{
				_messageToDisplay = MessageLocalised.Translation;
			}
			else
			{
				_messageToDisplay = _messageIfNoTrainingRoomLocalised.Translation;
			}
			if (num2 < _medPriThreshold)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num2 < _highPriThreshold)
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
