#define LOG_LEVEL_VERBOSE
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SetupStaffPatientInteraction : PatientOrStaffAction
	{
		[Tooltip("Room to look in")]
		public SharedRoomRef _room;

		[Tooltip("Staff interaction")]
		public SharedObjectInteractionRef _staffInteraction;

		[Tooltip("Patient interaction")]
		public SharedObjectInteractionRef _patientInteraction;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid())
			{
				StaffPatientInteraction staffPatientInteraction = _room.Get.ChooseStaffPatientInteraction();
				if (staffPatientInteraction != null)
				{
					ObjectInteraction staffInteraction = InteractionAlgorithms.GetClosestInteractionByName(staffPatientInteraction.StaffInteraction, _room.Get.FloorPlan, base.Staff.Position, evalAttractiveness: false, (ObjectInteraction interaction) => interaction.Valid && interaction.IsAvailable(base.Staff));
					if (staffInteraction != null)
					{
						_staffInteraction.Value = new ObjectInteractionRef(staffInteraction);
					}
					else
					{
						Logging.Warning(LogChannels.Behaviour, "Failed to find staff interaction {0} for {1} in room {2}", staffPatientInteraction.StaffInteraction, base.Staff, _room.Get);
					}
					string patientInteractionName = GetPatientInteractionName(staffPatientInteraction, base.Patient);
					ObjectInteraction closestInteractionByName = InteractionAlgorithms.GetClosestInteractionByName(patientInteractionName, _room.Get.FloorPlan, base.Patient.Position, evalAttractiveness: false, (ObjectInteraction interaction) => interaction != staffInteraction && interaction.Valid && interaction.IsAvailable(base.Patient));
					if (closestInteractionByName != null)
					{
						_patientInteraction.Value = new ObjectInteractionRef(closestInteractionByName);
					}
					else
					{
						Logging.Warning(LogChannels.Behaviour, "Failed to find patient interaction {0} for {1} in room {2}", patientInteractionName, base.Patient, _room.Get);
					}
					if (staffInteraction != null && closestInteractionByName != null)
					{
						if (base.Patient.ReasonUsingRoom == ReasonUseRoom.Treatment)
						{
							Treatment.Outcome outcome = GameAlgorithms.CalculateTreatmentOutcome(base.Patient, base.Staff, _room.Get);
							base.Patient.PendingTreatmentOutcome = outcome;
							staffInteraction.AddPendingVariable("TreatmentOutcome", (int)outcome);
							closestInteractionByName.AddPendingVariable("TreatmentOutcome", (int)outcome);
						}
						return TaskStatus.Success;
					}
					return TaskStatus.Failure;
				}
			}
			Logging.Warning(LogChannels.Behaviour, "Failed to find staff/patient interactions invalid room");
			return TaskStatus.Failure;
		}

		private string GetPatientInteractionName(StaffPatientInteraction result, Patient patient)
		{
			if (patient.ReasonUsingRoom == ReasonUseRoom.Treatment && !result.PatientTreatmentInteraction.IsNullOrEmpty())
			{
				return result.PatientTreatmentInteraction;
			}
			return result.PatientInteraction;
		}
	}
}
