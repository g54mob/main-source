using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerRoomMissingRequiredItem : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerRoomMissingRequiredItemDefinition _definition;

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private string _message;

		private Vector3 _interestPoint;

		public AdvisorTriggerRoomMissingRequiredItem(AdvisorTriggerRoomMissingRequiredItemDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			foreach (Room allRoom in Level.WorldState.AllRooms)
			{
				if (!allRoom.Definition.IsHospitalOrBay && allRoom.GetMissingRequiredItem(out var missing))
				{
					_icon = missing.GetIcon();
					_interestPoint = allRoom.Center;
					_message = LocalisedString.Replace(_definition.MessageLocalised.Translation, new SubPair[2]
					{
						new SubPair("{[ROOM]}", allRoom.Definition.GetLocalisedName()),
						new SubPair("{[ITEM]}", missing.GetLocalisedName())
					});
					return Advisor.PriorityLevel.High;
				}
			}
			return Advisor.PriorityLevel.DontShow;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Icon = _icon;
			result.Message = _message;
			result.CameraFocus = _interestPoint;
			return result;
		}
	}
}
