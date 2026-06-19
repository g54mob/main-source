using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalCurePatients : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionCurePatients _definition;

		private int _numCured;

		public SubGoalCurePatients(Objective owner, SubGoalDefinitionCurePatients definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionCurePatients;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionCurePatients)base.Definition;
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
			if (_definition != null && patient.RoomUsing != null)
			{
				bool num = _definition.ValidRoom(patient.RoomUsing.Definition);
				bool flag = _definition.ValidIllness(patient.Illness);
				bool flag2 = _definition.ValidStaff(involvedStaff);
				if (num && flag && flag2)
				{
					_numCured++;
					UpdateProgress();
				}
			}
		}

		protected override bool HasCompleted()
		{
			return _numCured >= _definition.CureCount;
		}

		public override float PercentComplete()
		{
			return (float)_numCured / (float)_definition.CureCount;
		}

		public override int Score()
		{
			return _numCured;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numCured} / {_definition.CureCount}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
