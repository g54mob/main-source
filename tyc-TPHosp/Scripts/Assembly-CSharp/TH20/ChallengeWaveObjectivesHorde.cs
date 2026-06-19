using System;
using System.Collections.Generic;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class ChallengeWaveObjectivesHorde : Challenge, IPatientSpawned
	{
		private readonly ChallengeWaveObjectivesHordeConfig _config;

		private int _numToSpawn;

		private int _numSpawnedPending;

		private List<Patient> _patients;

		private int[] _wavePatientIllnessedRequired;

		private int[] _wavePatientIllnessedRemaining;

		[DontSave]
		private bool _restoredFromSave;

		public static Action<int, int> OnWaveStarted;

		public static Action<int, int> OnWaveChanged;

		[DontSave]
		private RoomItemConstructionSequenceComponent _constructionSequence;

		private int _constructionProgress;

		public int WaveNum { get; private set; }

		public int WaveIndex { get; private set; }

		public int Countdown { get; private set; }

		public int TotalPatients => _config.GetWave(WaveIndex).NumPatients;

		public int NumRemaining => _patients.Count + _numToSpawn + _numSpawnedPending;

		public int NumProcessed => TotalPatients - NumRemaining;

		public bool RestoredFromSave => _restoredFromSave;

		public ChallengeWaveObjectivesHorde(ChallengeConfig config, Level level)
			: base(config, level)
		{
			_config = GetConfig<ChallengeWaveObjectivesHordeConfig>();
			_patients = new List<Patient>();
			_wavePatientIllnessedRequired = new int[1];
			_wavePatientIllnessedRemaining = new int[1];
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
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientProcessed));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPatientDestroyed = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientDestroyed, new Action<Patient>(OnPatientProcessed));
			CharacterEvents characterEvents3 = base.Level.CharacterEvents;
			characterEvents3.OnPatientReceivedTreatment = (Action<Patient, Staff, Room>)Delegate.Combine(characterEvents3.OnPatientReceivedTreatment, new Action<Patient, Staff, Room>(OnPatientReceivedTreatment));
			ConsoleCommandsDatabase.RegisterCommand("WOHordeCompleteWave", "Complete current wave objectives horde wave", "WOHordeCompleteWave", Debug_WOHordeCompleteWave);
			ConsoleCommandsDatabase.RegisterCommand("WOHordeFailWave", "Fail current wave objectives horde wave", "WOHordeFailWave", Debug_WOHordeFailWave);
			ConsoleCommandsDatabase.RegisterCommand("WOHordeCompleteWaveObjective", "Complete current wave objective", "WOHordeCompleteWaveObjective", Debug_WOHordeCompleteWaveObjective);
			ConsoleCommandsDatabase.RegisterCommand("WOHordeListWaveIllnessInfo", "List illness info for  current wave", "WOHordeListWaveIllnessInfo", Debug_WOHordeListWaveIllnessInfo);
			ConsoleCommandsDatabase.RegisterCommand("WOHordeReduceWOCountDown", "Set next wave count down to 1", "WOHordeReduceWOCountDown", Debug_WOHordeReduceWOCountDown);
		}

		private void UnregisterEvents()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("WOHordeCompleteWave");
			ConsoleCommandsDatabase.UnRegisterCommand("WOHordeFailWave");
			ConsoleCommandsDatabase.UnRegisterCommand("WOHordeCompleteWaveObjective");
			ConsoleCommandsDatabase.UnRegisterCommand("WOHordeListWaveIllnessInfo");
			base.Level.CharacterManager.StopPatientSpawning = false;
			base.Level.RemoveTimelineUpdateListener(OnTimelineUpdate);
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientRageQuit, new Action<Patient>(OnPatientProcessed));
			CharacterEvents characterEvents2 = base.Level.CharacterEvents;
			characterEvents2.OnPatientDestroyed = (Action<Patient>)Delegate.Remove(characterEvents2.OnPatientDestroyed, new Action<Patient>(OnPatientProcessed));
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

		public Objective GetActiveWaveObjective()
		{
			return base.Level.LevelScriptManager.GetActiveObjectiveByUniqueReference(_config.GetUniqueObjectiveName(WaveNum));
		}

		protected override void OnChallengeStarted()
		{
			base.OnChallengeStarted();
			RegisterEvents();
			Countdown = _config.WaveCountdownInDays;
		}

		protected override void OnChallengeFinished()
		{
			UnregisterEvents();
			base.OnChallengeFinished();
		}

		private void StartWave()
		{
			_patients.Clear();
			_config.StartWave(base.Level, WaveNum, WaveIndex);
			InitWavePatientIllnessesRequired();
			_numToSpawn = TotalPatients;
			_numSpawnedPending = 0;
			OnWaveStarted.InvokeSafe(WaveNum, WaveIndex);
		}

		private void EndWave()
		{
			int waveIndex = WaveIndex;
			int waveNum = WaveNum;
			int waveIndex2 = WaveIndex;
			_config.EndWave(base.Level, ref waveNum, ref waveIndex2);
			WaveNum = waveNum;
			WaveIndex = waveIndex2;
			Countdown = _config.WaveCountdownInDays;
			OnWaveChanged.InvokeSafe(WaveNum, WaveIndex);
			if (_constructionSequence != null && waveIndex != WaveIndex)
			{
				_constructionProgress++;
				_constructionSequence.Refresh(_constructionProgress, restoring: false);
			}
		}

		private void OnTimelineUpdate(int day, int month, int year)
		{
			ChallengeWaveObjectivesHordeConfig.Wave wave = _config.GetWave(WaveIndex);
			if (Countdown > 0)
			{
				Countdown--;
				if (Countdown == 0)
				{
					StartWave();
				}
			}
			if (_numToSpawn == 0)
			{
				return;
			}
			int num = wave.NumPatients / wave.SpawnDurationInDays;
			CharacterManager characterManager = base.Level.CharacterManager;
			while (_numToSpawn != 0 && num != 0)
			{
				IllnessDefinition illnessDefinition = DetermineIllnessForNextPatient();
				if (illnessDefinition != null)
				{
					characterManager.SpawnPatient(illnessDefinition, null, this, bAllowPatientTypeOverrides: true);
					num--;
					_numToSpawn--;
					_numSpawnedPending++;
					continue;
				}
				break;
			}
		}

		private void InitWavePatientIllnessesRequired()
		{
			_wavePatientIllnessedRequired = null;
			_wavePatientIllnessedRemaining = null;
			ChallengeWaveObjectivesHordeConfig.Wave wave = _config.GetWave(WaveIndex);
			if (wave.PatientIllnesses != null && wave.PatientIllnesses.Length != 0)
			{
				_wavePatientIllnessedRequired = new int[wave.PatientIllnesses.Length + 1];
				_wavePatientIllnessedRemaining = new int[wave.PatientIllnesses.Length + 1];
				int num = 0;
				for (int i = 0; i < wave.PatientIllnesses.Length; i++)
				{
					_wavePatientIllnessedRequired[i] = wave.PatientIllnesses[i].NumPatients;
					num += _wavePatientIllnessedRequired[i];
				}
				_wavePatientIllnessedRequired[_wavePatientIllnessedRequired.Length - 1] = wave.NumPatients - num;
				for (int j = 0; j < _wavePatientIllnessedRequired.Length; j++)
				{
					_wavePatientIllnessedRequired[j] = Mathf.Max(_wavePatientIllnessedRequired[j], 0);
					_wavePatientIllnessedRemaining[j] = _wavePatientIllnessedRequired[j];
				}
			}
		}

		private IllnessDefinition DetermineIllnessForNextPatient()
		{
			IllnessDefinition illnessDefinition = null;
			CharacterManager characterManager = base.Level.CharacterManager;
			ChallengeWaveObjectivesHordeConfig.Wave wave = _config.GetWave(WaveIndex);
			if (_wavePatientIllnessedRemaining != null)
			{
				int num = _wavePatientIllnessedRemaining.Length;
				int num2 = -1;
				int num3 = 0;
				int num4 = UnityEngine.Random.Range(0, num);
				while (num3 < num)
				{
					if (num4 >= num)
					{
						num4 = 0;
					}
					if (_wavePatientIllnessedRemaining[num4] > 0)
					{
						num2 = num4;
						break;
					}
					num3++;
					num4++;
				}
				if (num2 >= 0)
				{
					_wavePatientIllnessedRemaining[num2]--;
					illnessDefinition = ((num2 >= wave.PatientIllnesses.Length) ? characterManager.RandomIllness() : wave.PatientIllnesses[num2].Illness.Instance);
				}
			}
			if (illnessDefinition == null)
			{
				illnessDefinition = characterManager.RandomIllness();
			}
			return illnessDefinition;
		}

		private void ListWaveIllnessInfo()
		{
		}

		private void RemovePatient(Patient patient)
		{
			_patients.Remove(patient);
			if (_patients.Count == 0)
			{
				EndWave();
			}
		}

		private void OnPatientProcessed(Patient patient)
		{
			if (_patients.Contains(patient))
			{
				RemovePatient(patient);
			}
		}

		private void OnPatientReceivedTreatment(Patient patient, Staff staff, Room room)
		{
			GetActiveWaveObjective()?.CheckForObjectiveCompletion();
			OnPatientProcessed(patient);
		}

		protected override int CalculateChallengeScore()
		{
			return 0;
		}

		public void OnPatientSpawned(Patient patient)
		{
			_patients.Add(patient);
			if (_numSpawnedPending > 0)
			{
				_numSpawnedPending--;
			}
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

		private ConsoleCommandResult Debug_WOHordeCompleteWave(string[] args)
		{
			ForceCompleteCurrentWaveObjective();
			_patients.Clear();
			EndWave();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_WOHordeFailWave(string[] args)
		{
			_patients.Clear();
			_numToSpawn = 0;
			_numSpawnedPending = 0;
			EndWave();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_WOHordeCompleteWaveObjective(string[] args)
		{
			ForceCompleteCurrentWaveObjective();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_WOHordeListWaveIllnessInfo(string[] args)
		{
			ListWaveIllnessInfo();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_WOHordeReduceWOCountDown(string[] args)
		{
			Countdown = 1;
			return ConsoleCommandResult.Succeeded();
		}

		private void ForceCompleteCurrentWaveObjective()
		{
			base.Level.LevelScriptManager.GetActiveObjectiveByUniqueReference(_config.GetUniqueObjectiveName(WaveNum))?.ForceSuccess();
		}

		public override string GetObjectiveMenuItemTooltip()
		{
			string text = base.Definition.DescriptionLocalised.Translation;
			if (text != string.Empty)
			{
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
