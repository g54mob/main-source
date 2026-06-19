using System;
using System.Collections.Generic;
using I2.Loc;

namespace TH20
{
	public class ChallengeSpecialPatient : Challenge, IPatientSpawned
	{
		public enum ActionOnFail
		{
			StayInHospital = 0,
			RageQuit = 1,
			Die = 2
		}

		private readonly ChallengeSpecialPatientConfig _config;

		private readonly List<Patient> _patients = new List<Patient>();

		private int _numRemaining;

		private int _numCured;

		private int _numFailed;

		private int _selectionIndex;

		[DontSave]
		private bool _restoredFromSave;

		public int PatientsCured => _numCured;

		public int PatientsFailed => _numFailed;

		public int PatientsInProgress => _numRemaining;

		public float InitialDiagnosisCertainty => _config.DiagnosisComplete;

		public ChallengeSpecialPatient(ChallengeConfig config, Level level)
			: base(config, level)
		{
			_config = GetConfig<ChallengeSpecialPatientConfig>();
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPatientDestroyed = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientDestroyed, new Action<Patient>(OnPatientDestroyed));
			_numRemaining = _config.PatientCount;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPatientDestroyed = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientDestroyed, new Action<Patient>(OnPatientDestroyed));
			_restoredFromSave = true;
		}

		public override void Destroy()
		{
			base.Destroy();
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Remove(characterEvents.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPatientDestroyed = (Action<Patient>)Delegate.Remove(characterEvents2.OnPatientDestroyed, new Action<Patient>(OnPatientDestroyed));
		}

		protected override void OnChallengeStarted()
		{
			base.OnChallengeStarted();
			ArrivalMethodDefinition arrivalMethod = ((_config.ArrivalMethod != null) ? _config.ArrivalMethod.Instance : null);
			float num = 0f;
			for (int i = 0; i < _config.PatientCount; i++)
			{
				IllnessDefinition instance = _config.IllnessDefinition.RandomItem().Instance;
				int count = ArrivalTimePortalComponent.Components.Count;
				if (_config.PatientSpawnRate > 0f && count > 0)
				{
					ArrivalTimePortalComponent.Components.RandomItem().QueueSpawn(num, instance, arrivalMethod, this);
					num += _config.PatientSpawnRate;
				}
				else
				{
					base.Level.CharacterManager.SpawnPatient(instance, arrivalMethod, this);
				}
			}
		}

		protected override void OnChallengeFinished()
		{
			CancelArrivals();
			switch (_config.ActionOnFail)
			{
			case ActionOnFail.RageQuit:
				foreach (Patient patient in _patients)
				{
					patient.LeaveHospital(Character.ReasonForLeavingHospital.RageQuit);
				}
				break;
			case ActionOnFail.Die:
				foreach (Patient patient2 in _patients)
				{
					patient2.GetCharacterAttributes().GetAttribute(CharacterAttributes.Type.Health)?.Modify(-100f, 1f);
				}
				break;
			}
			_patients.Clear();
			if (base.CompletionResult != CompletionType.Invalid)
			{
				bool flag = CalculateChallengeScore() >= _config.RewardSuccessScore;
				base.CompletionResult = (flag ? CompletionType.Successful : CompletionType.Failed);
			}
			base.OnChallengeFinished();
		}

		public override void Abandon()
		{
			CancelArrivals();
			Finish(CompletionType.Abandoned);
		}

		private void CancelArrivals()
		{
			base.Level.CharacterManager.ArrivalsManager.CancelPatientArrivals(this);
		}

		protected override int CalculateChallengeScore()
		{
			return (int)((float)_numCured / (float)_config.PatientCount * 100f);
		}

		private void OnPatientReceivedTreatment(Patient patient, Staff staff, Room room)
		{
			ProcessPatientResult(patient);
		}

		private void OnPatientDestroyed(Patient patient)
		{
			ProcessPatientResult(patient);
		}

		private void ProcessPatientResult(Patient patient)
		{
			if (base.State == ObjectiveState.Active && _patients.Contains(patient))
			{
				_numRemaining--;
				if (patient.TreatmentOutcome == Treatment.Outcome.Cured)
				{
					_numCured++;
				}
				else
				{
					_numFailed++;
				}
				_patients.Remove(patient);
				if (_numRemaining <= 0)
				{
					FinishChallenge();
				}
			}
		}

		public void OnPatientSpawned(Patient patient)
		{
			if (base.Definition.IsTimed)
			{
				patient.AddComponent<SirenCharacterComponent>().Setup(_config.SirenCharacterComponentConfig);
			}
			else
			{
				patient.AddComponent<SpecialVIPCharacterComponent>();
			}
			patient.ModifyDiagnosisCertainty(_config.DiagnosisComplete);
			if (patient.FullyDiagnosed())
			{
				patient.SendToTreatmentRoom(patient.Illness.GetTreatmentRoom(patient, base.Level.ResearchManager), immediately: true);
			}
			_patients.Add(patient);
		}

		public void OnFailedToSpawn()
		{
			if (!_restoredFromSave)
			{
				_patients.ClearAndCallDestroy();
				Destroy();
			}
			else if (base.State != ObjectiveState.Finished)
			{
				Abandon();
			}
		}

		public bool IsValid()
		{
			if (!HasBeenDestroyed())
			{
				return base.Level.LevelScriptManager.ActiveObjectives.Contains(this);
			}
			return false;
		}

		public int GetArrivalPriority()
		{
			return GameAlgorithms.Config.ArrivalPriorityPatientEmergency;
		}

		public override string GetScoreText()
		{
			string text = ScriptLocalization.Challenges.SpecialPatient_Score_CS;
			LocalisationParams.Set("COUNT", PatientsCured);
			LocalisationParams.Set("TARGET", _config.PatientCount);
			return LocalisationParams.Localise(ref text);
		}

		public override bool ShowGUIOnDiscover()
		{
			return true;
		}

		public override void OnMouseSelect()
		{
			if (_patients.Count > 0)
			{
				if (_selectionIndex >= _patients.Count || _selectionIndex < 0)
				{
					_selectionIndex = 0;
				}
				base.Level.CameraLogic.TrackObject(_patients[_selectionIndex].GetCameraTrackObject().transform);
				_selectionIndex++;
			}
		}
	}
}
