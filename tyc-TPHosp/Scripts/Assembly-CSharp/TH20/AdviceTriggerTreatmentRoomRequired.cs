using System.Collections.Generic;
using System.Linq;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerTreatmentRoomRequired : AdviceTrigger
	{
		private string _constructedMessage;

		private Sprite _icon;

		[InspectorMargin(8)]
		[InspectorHeader("Treatment Room Required")]
		[InspectorTooltip("The priority level of the message")]
		[SerializeField]
		private Advisor.PriorityLevel _priorityLevel = Advisor.PriorityLevel.High;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			List<Patient> list = Level.CharacterManager.Patients.Where((Patient patient2) => patient2.WaitingForRoom != RoomDefinition.Type.Invalid && patient2.ReasonWaitingForRoom == ReasonUseRoom.Treatment).ToList();
			if (list.Count <= 0)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			Patient patient = list.RandomItem();
			RoomDefinition treatmentRoom = patient.Illness.GetTreatmentRoom(patient, Level.ResearchManager);
			_constructedMessage = LocalisedString.Replace(MessageLocalised.Translation, new SubPair[2]
			{
				new SubPair("{[ILLNESS]}", patient.Illness.Name.Translation),
				new SubPair("{[ROOM]}", treatmentRoom.GetLocalisedName())
			});
			_icon = treatmentRoom._icon;
			return _priorityLevel;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Message = _constructedMessage;
			result.Icon = _icon;
			return result;
		}
	}
}
