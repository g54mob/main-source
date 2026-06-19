using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengeLevelObjectiveProcessPatients : StaffChallengeLevelObjective
	{
		private int _processed;

		private readonly StaffChallengeSubGoalDefinitionProcessPatients _definition;

		public StaffChallengeLevelObjectiveProcessPatients(Objective owner, StaffChallengeSubGoalDefinitionProcessPatients definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			base.OnStart();
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffServedCustomer = (Action<Staff, Character>)Delegate.Combine(characterEvents.OnStaffServedCustomer, new Action<Staff, Character>(OnStaffServedCustomer));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents2.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
			CharacterEvents characterEvents3 = Level.CharacterEvents;
			characterEvents3.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents3.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnStaffServedCustomer = (Action<Staff, Character>)Delegate.Combine(characterEvents.OnStaffServedCustomer, new Action<Staff, Character>(OnStaffServedCustomer));
				CharacterEvents characterEvents2 = Level.CharacterEvents;
				characterEvents2.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents2.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
				CharacterEvents characterEvents3 = Level.CharacterEvents;
				characterEvents3.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents3.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			}
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnStaffServedCustomer = (Action<Staff, Character>)Delegate.Remove(characterEvents.OnStaffServedCustomer, new Action<Staff, Character>(OnStaffServedCustomer));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Remove(characterEvents2.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientReceivedDiagnosis));
			CharacterEvents characterEvents3 = Level.CharacterEvents;
			characterEvents3.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Remove(characterEvents3.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			base.OnEnd();
		}

		private void OnStaffServedCustomer(Staff staff, Character character)
		{
			UpdateProcessed(staff, staff.RoomUsing);
		}

		private void OnPatientReceivedTreatment(Patient patient, Staff staff, Room room)
		{
			UpdateProcessed(staff, room);
		}

		private void OnPatientReceivedDiagnosis(Patient patient, Staff staff, Room room, float certainty)
		{
			UpdateProcessed(staff, room);
		}

		private void UpdateProcessed(Staff staff, Room room)
		{
			if (staff == _challenge.Staff)
			{
				bool num = _definition.Room == null || _definition.Room.Instance == room.Definition;
				bool flag = _definition.Room == null || (_definition.Room.Instance._type == RoomDefinition.Type.Reception && room.Definition.IsHospitalOrBay);
				if (num || flag)
				{
					_processed++;
					UpdateProgress();
				}
			}
		}

		protected override bool HasCompleted()
		{
			return _processed >= _definition.NumToProcess;
		}

		public override float PercentComplete()
		{
			return (float)_processed / (float)_definition.NumToProcess;
		}

		public override int Score()
		{
			return _processed;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_processed} / {_definition.NumToProcess}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
