using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerRoomNeedsQualification : AdviceTrigger
	{
		private string _completedMessage;

		private QualificationDefinition _requiredQualification;

		[InspectorMargin(8)]
		[InspectorHeader("Qualification Required")]
		[InspectorTooltip("The priority level of the message if a room requires a qualification we don't have")]
		[SerializeField]
		private Advisor.PriorityLevel _priorityLevel = Advisor.PriorityLevel.High;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			foreach (Job allJob in Level.StaffWorkScheduler.AllJobs)
			{
				if (allJob is JobRoom jobRoom && jobRoom.Available())
				{
					_requiredQualification = jobRoom.StaffRequired().QualificationInstance;
					if (_requiredQualification != null && !StaffOnPayrollWithQualification(_requiredQualification))
					{
						_completedMessage = LocalisedString.Replace(MessageLocalised.Translation, new SubPair[3]
						{
							new SubPair("{[ROOM]}", jobRoom.Room.Definition.GetLocalisedName()),
							new SubPair("{[STAFF]}", GameStringUtils.GetStaffTypeTextLoc(jobRoom.StaffRequired().Definition._type)),
							new SubPair("{[QUALIFICATION]}", _requiredQualification.NameLocalised.Translation)
						});
						return _priorityLevel;
					}
				}
			}
			return Advisor.PriorityLevel.DontShow;
		}

		private bool StaffOnPayrollWithQualification(QualificationDefinition qualificationRequired)
		{
			for (int i = 0; i < Level.CharacterManager.StaffMembers.Count; i++)
			{
				Staff staff = Level.CharacterManager.StaffMembers[i];
				if (staff.Definition._type == qualificationRequired.StaffType && staff.HasCompletedQualification(qualificationRequired))
				{
					return true;
				}
			}
			return false;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Message = _completedMessage;
			result.Icon = _requiredQualification.Icon;
			return result;
		}
	}
}
