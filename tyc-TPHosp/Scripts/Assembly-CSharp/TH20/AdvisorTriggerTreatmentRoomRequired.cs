using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerTreatmentRoomRequired : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerTreatmentRoomRequiredDefinition _definition;

		[SerializeField]
		private string _constructedMessage;

		[SerializeField]
		private Sprite _icon;

		[DontSave]
		private GameObject _interestPoint;

		public AdvisorTriggerTreatmentRoomRequired(AdvisorTriggerTreatmentRoomRequiredDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			List<Patient> list = Level.CharacterManager.Patients.Where((Patient patient2) => patient2.WaitingForRoom != RoomDefinition.Type.Invalid && patient2.ReasonWaitingForRoom == ReasonUseRoom.Treatment).ToList();
			if (list.Count <= 0)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			Patient patient = list.RandomItem();
			RoomDefinition treatmentRoom = patient.Illness.GetTreatmentRoom(patient, Level.ResearchManager);
			if (Level.WorldState.CountRoomsOfType(treatmentRoom._type, includeClosed: true) != 0)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			_constructedMessage = LocalisedString.Replace(_definition.MessageLocalised.Translation, new SubPair[2]
			{
				new SubPair("{[ILLNESS]}", patient.Illness.Name.Translation),
				new SubPair("{[ROOM]}", treatmentRoom.GetLocalisedName())
			});
			_icon = treatmentRoom._icon;
			_interestPoint = patient.GetCameraTrackObject();
			return _definition.PriorityLevel;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Message = _constructedMessage;
			result.Icon = _icon;
			result.CameraTrackObject = _interestPoint;
			return result;
		}
	}
}
