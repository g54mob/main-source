using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalCureRate : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionCureRate _definition;

		private int _historyLength;

		private int _historyIndex;

		private bool[] _history;

		private void Record(bool success)
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

		private int NumSuccess()
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

		public SubGoalCureRate(Objective owner, SubGoalDefinitionCureRate definition)
			: base(owner, definition)
		{
			_definition = definition;
			_history = new bool[GameAlgorithms.Config.CureRateObjectiveNumPatients];
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionCureRate;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionCureRate)base.Definition;
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
			characterEvents.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
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
			characterEvents.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientFailure));
			base.OnEnd();
		}

		private void OnPatientSuccess(Patient patient, List<Staff> involvedStaff)
		{
			if (_definition.IsValid(patient.Illness, patient.RoomUsing))
			{
				Record(success: true);
				UpdateProgress();
			}
			UpdateProgress();
		}

		private void OnPatientTreatmentFailed(Patient patient, List<Staff> involvedStaff)
		{
			OnPatientFailure(patient);
		}

		private void OnPatientFailure(Patient patient)
		{
			if (_definition.IsValid(patient.Illness, patient.RoomUsing))
			{
				Record(success: false);
				UpdateProgress();
			}
		}

		private void OnPatientSentHome(Patient patient)
		{
			if (_definition.IsValid(patient.Illness, patient.RoomUsing) && patient.GetComponent<AlienComponent>() == null)
			{
				Record(success: false);
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return (float)Score() >= _definition.TargetCureRate;
		}

		public override float PercentComplete()
		{
			return (float)Score() / _definition.TargetCureRate;
		}

		public override int Score()
		{
			if (_historyLength <= 0)
			{
				return 0;
			}
			return 100 * NumSuccess() / _historyLength;
		}

		public override string ProgressText()
		{
			int value = NumSuccess();
			string text = ScriptLocalization.Challenges_SubGoals.CureRate_Progress_CS;
			LocalisationParams.Set("CURED", value);
			LocalisationParams.Set("TOTAL", _historyLength);
			LocalisationParams.Set("SCORE", StringUtils.FormatPercentageValue((float)Score() / 100f));
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
