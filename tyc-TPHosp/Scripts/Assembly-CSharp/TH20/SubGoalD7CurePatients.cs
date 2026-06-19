using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalD7CurePatients : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionD7CurePatients _definition;

		private int _numCured;

		public SubGoalD7CurePatients(Objective owner, SubGoalDefinitionD7CurePatients definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionD7CurePatients;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionD7CurePatients)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			base.OnEnd();
		}

		private void OnPatientCured(Patient patient, List<Staff> involvedStaff)
		{
			if (_definition != null && patient.RoomUsing != null && _definition.IsValidPatient(patient))
			{
				_numCured++;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numCured >= _definition.CureCountTarget;
		}

		public override float PercentComplete()
		{
			return (float)_numCured / (float)_definition.CureCountTarget;
		}

		public override int Score()
		{
			return _numCured;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numCured} / {_definition.CureCountTarget}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
