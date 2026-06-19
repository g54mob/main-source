using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerRoomMissingRequiredItem : AdviceTrigger
	{
		private Sprite _icon;

		private string _message;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			foreach (Room allRoom in Level.WorldState.AllRooms)
			{
				if (!allRoom.Definition.IsHospitalOrBay && allRoom.GetMissingRequiredItem(out var missing))
				{
					_icon = missing.GetIcon();
					_message = LocalisedString.Replace(MessageLocalised.Translation, new SubPair[2]
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
			return result;
		}
	}
}
