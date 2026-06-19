using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengeLevelObjectiveCurePatients : StaffChallengeLevelObjective
	{
		private int _numberCured;

		private readonly StaffChallengeSubGoalDefinitionCurePatients _definition;

		public StaffChallengeLevelObjectiveCurePatients(Objective owner, StaffChallengeSubGoalDefinitionCurePatients definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			base.OnStart();
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			}
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			base.OnEnd();
		}

		private void OnPatientCured(Patient patient, List<Staff> staffs)
		{
			if (staffs.Contains(_challenge.Staff) && (_definition.Illness == null || _definition.Illness.Instance == patient.Illness) && (_definition.Room == null || _definition.Room.Instance == patient.RoomUsing.Definition))
			{
				_numberCured++;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numberCured >= _definition.NumToCure;
		}

		public override float PercentComplete()
		{
			return (float)_numberCured / (float)_definition.NumToCure;
		}

		public override int Score()
		{
			return _numberCured;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numberCured} / {_definition.NumToCure}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
