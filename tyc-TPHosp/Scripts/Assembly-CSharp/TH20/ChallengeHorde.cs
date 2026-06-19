using System;
using System.Collections.Generic;
using UnityConsole;

namespace TH20
{
	public class ChallengeHorde : Challenge, IPatientSpawned
	{
		private readonly ChallengeHordeConfig _config;

		private int _numToSpawn;

		private List<Patient> _patients;

		[DontSave]
		private bool _restoredFromSave;

		public static Action<int> OnWaveChanged;

		[DontSave]
		private RoomItemConstructionSequenceComponent _constructionSequence;

		private int _constructionProgress;

		public int WaveIndex { get; private set; }

		public int Countdown { get; private set; }

		public int Cured { get; private set; }

		public int CureStreak { get; private set; }

		public int TotalPatients => _config.GetWave(WaveIndex).NumPatients;

		public float CureRatePercent => (float)Cured / (float)TotalPatients;

		public float TargetCureRatePercent => (float)_config.GetWave(WaveIndex).TargetCureRate / 100f;

		public int NumRemaining => _patients.Count + _numToSpawn;

		public ChallengeHorde(ChallengeConfig config, Level level)
			: base(config, level)
		{
			_config = GetConfig<ChallengeHordeConfig>();
			_patients = new List<Patient>();
			CacheConstructionSequence(restoring: false);
		}

		public override void Destroy()
		{
			EndWave();
			UnregisterEvents();
			base.Destroy();
		}

		private void RegisterEvents()
		{
			base.Level.CharacterManager.StopPatientSpawning = true;
			base.Level.AddTimelineUpdateListener(OnTimelineUpdate);
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientRageQuit, new Action<Patient>(OnCureFail));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPatientDestroyed = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientDestroyed, new Action<Patient>(OnCureFail));
			CharacterEvents characterEvents3 = base.Level.CharacterEvents;
			characterEvents3.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents3.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			ConsoleCommandsDatabase.RegisterCommand("CompleteHordeWave", "Complete current horde wave", "CompleteHordeWave", Debug_CompleteHordeWave);
			ConsoleCommandsDatabase.RegisterCommand("FailHordeWave", "Fail current horde wave", "FailHordeWave", Debug_FailHordeWave);
		}

		private void UnregisterEvents()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("CompleteHordeWave");
			ConsoleCommandsDatabase.UnRegisterCommand("FailHordeWave");
			base.Level.CharacterManager.StopPatientSpawning = false;
			base.Level.RemoveTimelineUpdateListener(OnTimelineUpdate);
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientRageQuit, new Action<Patient>(OnCureFail));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPatientDestroyed = (Action<Patient>)Delegate.Remove(characterEvents2.OnPatientDestroyed, new Action<Patient>(OnCureFail));
			CharacterEvents characterEvents3 = base.Level.CharacterEvents;
			characterEvents3.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Remove(characterEvents3.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (base.ChallengeStatus == ChallengeState.InProgress)
			{
				RegisterEvents();
			}
			CacheConstructionSequence(restoring: true);
			_restoredFromSave = true;
		}

		private void CacheConstructionSequence(bool restoring)
		{
			_constructionSequence = RoomItemConstructionSequenceComponent.Get(_config.ConstructionSequenceName);
			if (_constructionSequence != null)
			{
				_constructionSequence.Refresh(_constructionProgress, restoring);
			}
		}

		protected override void OnChallengeStarted()
		{
			base.OnChallengeStarted();
			RegisterEvents();
			if (_config.UseSeparateStartCountdown)
			{
				Countdown = _config.FirstWaveCountdownInDays;
			}
			else
			{
				Countdown = _config.WaveCountdownInDays;
			}
		}

		protected override void OnChallengeFinished()
		{
			UnregisterEvents();
			base.OnChallengeFinished();
		}

		private void StartWave()
		{
			_config.StartWave(base.Level, WaveIndex);
			Cured = 0;
			_numToSpawn = TotalPatients;
		}

		private void EndWave()
		{
			int waveIndex = WaveIndex;
			WaveIndex = _config.EndWave(base.Level, WaveIndex, Cured);
			CureStreak = 0;
			Countdown = _config.WaveCountdownInDays;
			_config.EndStreak(base.Level, WaveIndex);
			OnWaveChanged.InvokeSafe(WaveIndex);
			if (_constructionSequence != null && waveIndex != WaveIndex)
			{
				_constructionProgress++;
				_constructionSequence.Refresh(_constructionProgress, restoring: false);
			}
		}

		private void OnTimelineUpdate(int day, int month, int year)
		{
			if (Countdown > 0)
			{
				Countdown--;
				if (Countdown == 0)
				{
					StartWave();
				}
			}
			if (_numToSpawn != 0)
			{
				ChallengeHordeConfig.Wave wave = _config.GetWave(WaveIndex);
				int num = wave.NumPatients / wave.SpawnDurationInDays;
				CharacterManager characterManager = base.Level.CharacterManager;
				while (_numToSpawn != 0 && num != 0)
				{
					characterManager.SpawnPatient(characterManager.RandomIllness(), null, this, bAllowPatientTypeOverrides: true);
					num--;
					_numToSpawn--;
				}
			}
		}

		private void RemovePatient(Patient patient)
		{
			_patients.Remove(patient);
			if (_patients.Count == 0)
			{
				EndWave();
			}
		}

		private void OnCureSuccess(Patient patient)
		{
			if (_patients.Contains(patient))
			{
				Cured++;
				CureStreak++;
				if (CureStreak == _config.CureStreak)
				{
					_config.BeginStreak(base.Level, WaveIndex);
				}
				RemovePatient(patient);
			}
		}

		private void OnCureFail(Patient patient)
		{
			if (_patients.Contains(patient))
			{
				CureStreak = 0;
				_config.EndStreak(base.Level, WaveIndex);
				RemovePatient(patient);
			}
		}

		private void OnPatientReceivedTreatment(Patient patient, Staff staff, Room room)
		{
			switch (patient.TreatmentOutcome)
			{
			case Treatment.Outcome.Cured:
				OnCureSuccess(patient);
				break;
			case Treatment.Outcome.Ineffective:
			case Treatment.Outcome.Death:
				OnCureFail(patient);
				break;
			}
		}

		protected override int CalculateChallengeScore()
		{
			return 0;
		}

		public void OnPatientSpawned(Patient patient)
		{
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

		private ConsoleCommandResult Debug_CompleteHordeWave(string[] args)
		{
			Cured = _config.GetWave(WaveIndex).NumPatients;
			EndWave();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_FailHordeWave(string[] args)
		{
			Cured = 0;
			EndWave();
			return ConsoleCommandResult.Succeeded();
		}

		public override string GetObjectiveMenuItemTooltip()
		{
			string text = base.Definition.DescriptionLocalised.Translation;
			if (text != string.Empty)
			{
				text = LocalisedString.Replace(text, new SubPair[2]
				{
					new SubPair("{[CURE_STREAK]}", _config.CureStreak),
					new SubPair("{[INCOME_MULTIPLIER]}", _config.CureStreakMoneyMultiplier.ToString("x 0.00"))
				});
				string rewardsHUDString = GetRewardsHUDString(CompletionType.Successful);
				if (rewardsHUDString != string.Empty)
				{
					text += "\n\n";
					text += rewardsHUDString;
				}
			}
			return text;
		}
	}
}
