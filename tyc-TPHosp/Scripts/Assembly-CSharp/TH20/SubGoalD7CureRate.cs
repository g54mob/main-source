using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalD7CureRate : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionD7CureRate _definition;

		private int _numCured;

		private int _collectedByPlayer;

		private float _cureRate;

		public SubGoalD7CureRate(Objective owner, SubGoalDefinitionD7CureRate definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionD7CureRate;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionD7CureRate)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				CharacterEvents characterEvents = Level.CharacterEvents;
				characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Combine(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientsCollectedByPlayer));
				CharacterEvents characterEvents2 = Level.CharacterEvents;
				characterEvents2.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents2.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			}
		}

		protected override void OnStart()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Combine(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientsCollectedByPlayer));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents2.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientsCollectedByPlayer = (Action<List<Patient>, string>)Delegate.Remove(characterEvents.OnPatientsCollectedByPlayer, new Action<List<Patient>, string>(OnPatientsCollectedByPlayer));
			CharacterEvents characterEvents2 = Level.CharacterEvents;
			characterEvents2.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents2.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			base.OnEnd();
		}

		private void OnPatientsCollectedByPlayer(List<Patient> patients, string ID)
		{
			if (_definition != null && patients.Count != 0)
			{
				_collectedByPlayer += patients.Count;
				_cureRate = (float)_numCured / (float)_collectedByPlayer * 100f;
				UpdateProgress();
			}
		}

		private void OnPatientCured(Patient patient, List<Staff> staves)
		{
			if (_definition != null && _collectedByPlayer != 0 && _definition.IsValidPatient(patient))
			{
				_numCured++;
				_cureRate = (float)_numCured / (float)_collectedByPlayer * 100f;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return (int)_cureRate >= _definition.CureRateTarget;
		}

		public override float PercentComplete()
		{
			return _cureRate / (float)_definition.CureRateTarget;
		}

		public override int Score()
		{
			return (int)_cureRate;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{Mathf.Floor(_cureRate)}% / {_definition.CureRateTarget}%";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
