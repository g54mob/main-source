using System;
using System.Collections.Generic;

namespace TH20
{
	public abstract class SubGoalAnachronisticCure : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionAnachronisticCure _definition;

		protected int _historyLength;

		private int _historyIndex;

		private bool[] _history;

		protected virtual void Record(bool success)
		{
			if (_historyLength < _history.Length)
			{
				_historyLength++;
			}
			_history[_historyIndex++] = success;
			if (_historyIndex == _history.Length)
			{
				_historyIndex = 0;
			}
		}

		protected int NumSuccess()
		{
			int num = 0;
			for (int i = 0; i < _historyLength; i++)
			{
				if (_history.ValidIndex(i) && _history[i])
				{
					num++;
				}
			}
			return num;
		}

		public SubGoalAnachronisticCure(Objective owner, SubGoalDefinitionAnachronisticCure definition)
			: base(owner, definition)
		{
			_definition = definition;
			_history = new bool[GameAlgorithms.Config.CureRateObjectiveNumPatients];
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionAnachronisticCure;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionAnachronisticCure)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				RegisterEvents();
			}
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientSuccess));
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientDied, new Action<Patient>(OnPatientFailure));
			characterEvents.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnPatientTreatmentFailed));
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientFailure));
		}

		protected override void OnStart()
		{
			RegisterEvents();
			base.OnStart();
		}

		protected override void OnEnd()
		{
			CharacterEvents characterEvents = Level.CharacterEvents;
			characterEvents.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientSuccess));
			characterEvents.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientDied, new Action<Patient>(OnPatientFailure));
			characterEvents.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnPatientTreatmentFailed));
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientFailure));
			base.OnEnd();
		}

		private void OnPatientSuccess(Patient patient, List<Staff> involvedStaff)
		{
			if (patient.GetComponent<AnachronisticTreatmentComponent>() != null && _definition.IsValid(patient.Illness, patient.RoomUsing))
			{
				Record(success: true);
				UpdateProgress();
			}
		}

		private void OnPatientTreatmentFailed(Patient patient, List<Staff> involvedStaff)
		{
			OnPatientFailure(patient);
		}

		private void OnPatientFailure(Patient patient)
		{
			if (patient.GetComponent<AnachronisticTreatmentComponent>() != null && _definition.IsValid(patient.Illness, patient.RoomUsing))
			{
				Record(success: false);
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return Score() >= _definition.Target;
		}

		public override float PercentComplete()
		{
			return (float)Score() / (float)_definition.Target;
		}

		public int Target()
		{
			return _definition.Target;
		}
	}
}
