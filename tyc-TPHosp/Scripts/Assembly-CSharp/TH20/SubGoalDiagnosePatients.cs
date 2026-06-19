using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalDiagnosePatients : LevelObjectiveSubGoal
	{
		private SubGoalDiagnosePatientsDefinition _definition;

		private int _numDiagnosed;

		public SubGoalDiagnosePatients(Objective owner, SubGoalDiagnosePatientsDefinition definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDiagnosePatientsDefinition;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDiagnosePatientsDefinition)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientDiagnosed));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Combine(characterEvents.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientDiagnosed));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientReceivedDiagnosis = (Action<Patient, Staff, Room, float>)Delegate.Remove(characterEvents.OnPatientReceivedDiagnosis, new Action<Patient, Staff, Room, float>(OnPatientDiagnosed));
			base.OnEnd();
		}

		private void OnPatientDiagnosed(Patient patient, Staff staff, Room room, float increment)
		{
			if (patient.FullyDiagnosed())
			{
				bool num = _definition.ValidRoom(patient.RoomUsing.Definition);
				bool flag = _definition.ValidIllness(patient.Illness);
				bool flag2 = _definition.ValidStaff(staff);
				if (num && flag && flag2)
				{
					_numDiagnosed++;
					UpdateProgress();
				}
			}
		}

		protected override bool HasCompleted()
		{
			return _numDiagnosed >= _definition.DiagnoseCount;
		}

		public override float PercentComplete()
		{
			return (float)_numDiagnosed / (float)_definition.DiagnoseCount;
		}

		public override int Score()
		{
			return _numDiagnosed;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numDiagnosed} / {_definition.DiagnoseCount}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
