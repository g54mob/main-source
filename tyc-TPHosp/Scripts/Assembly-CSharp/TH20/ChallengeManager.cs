#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using JetBrains.Annotations;
using UnityConsole;

namespace TH20
{
	public class ChallengeManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public bool UseAmbulanceDepartments;

			public SharedInstance<PlayerAmbulanceDepartmentDefinition> PlayerAmbulanceDepartmentDefinition;

			public List<SharedInstance<RivalAmbulanceDepartmentDefinition>> RivalAmbulanceDepartmentDefinitions;

			public float RescueDeathPenaltyMultiplier;

			public float IgnoredSceneDeathPenaltyMultiplier;

			[InspectorHeader("Random Schedules")]
			[CanBeNull]
			public List<ChallengeScheduleDefinition> Schedules;

			public Dictionary<string, string> MaintenanceChallengeGroups;
		}

		private readonly Level _level;

		private readonly Config _config;

		private readonly Dictionary<string, ChallengeSchedule> _schedules = new Dictionary<string, ChallengeSchedule>();

		private readonly List<Challenge> _activeChallengeList = new List<Challenge>();

		private PlayerAmbulanceDepartment _playerAmbulanceDepartment;

		private List<RivalAmbulanceDepartment> _rivalAmbulanceDepartments;

		private float _rescueDeathPenaltyMultiplier;

		private float _ignoredSceneDeathPenaltyMultiplier;

		private List<AmbulanceDepartment> _competingDepartments;

		private MaintenanceChallengeManager _maintenanceChallengeManager;

		private bool _bDisableChallenges;

		private int _monthsPlayerIsKingOfHill;

		private int _uniqueSuffix;

		private const int MaxSuffix = 50;

		public Action<bool> OnOpenSatNav;

		public Action<bool> OnAlertSatNav;

		public Action<bool> OnOpenSatNavSubMenu;

		public Action<bool> OnSetPathSatNav;

		public Action<bool> OnCloseSatNavSubMenu;

		public Action<int> OnAmbulanceLeagueUpdated;

		public PlayerAmbulanceDepartment PlayerAmbulanceDepartment => _playerAmbulanceDepartment;

		public List<RivalAmbulanceDepartment> RivalAmbulanceDepartments => _rivalAmbulanceDepartments;

		public float RescueDeathPenaltyMultiplier => _rescueDeathPenaltyMultiplier;

		public float IgnoredSceneDeathPenaltyMultiplier => _ignoredSceneDeathPenaltyMultiplier;

		public ChallengeManager(Level level, Config config)
		{
			_level = level;
			_config = config;
			_uniqueSuffix = 0;
			Config config2 = null;
			if ((_level.UniqueID == "934" || _level.UniqueID == "935" || _level.UniqueID == "936") && _level.IsSandbox())
			{
				config2 = level.GetLevelOnlyChallengeConfig();
			}
			ChallengeEvents challengeEvents = _level.ChallengeEvents;
			challengeEvents.OnChallengeCompleted = (Action<Challenge>)Delegate.Combine(challengeEvents.OnChallengeCompleted, new Action<Challenge>(OnChallengeCompleted));
			if (config.Schedules != null)
			{
				foreach (ChallengeScheduleDefinition schedule in config.Schedules)
				{
					_schedules.Add(schedule.Name, new ChallengeSchedule(level, schedule));
				}
			}
			if (config2?.Schedules != null)
			{
				foreach (ChallengeScheduleDefinition schedule2 in config2.Schedules)
				{
					if (schedule2.Name.StartsWith("Emergency") || schedule2.Name.StartsWith("Ambulance"))
					{
						_schedules.Add(schedule2.Name, new ChallengeSchedule(level, schedule2));
						_schedules[schedule2.Name].IsEnabled = true;
					}
				}
			}
			Config config3 = ((config2 == null) ? config : config2);
			if (config3.PlayerAmbulanceDepartmentDefinition?.Instance != null)
			{
				_playerAmbulanceDepartment = new PlayerAmbulanceDepartment(config3.PlayerAmbulanceDepartmentDefinition.Instance, _level);
				_competingDepartments = new List<AmbulanceDepartment>();
				_competingDepartments.Add(_playerAmbulanceDepartment);
			}
			_rivalAmbulanceDepartments = new List<RivalAmbulanceDepartment>();
			if (config3?.RivalAmbulanceDepartmentDefinitions != null && (config3 == null || config3.RivalAmbulanceDepartmentDefinitions.Count != 0))
			{
				foreach (SharedInstance<RivalAmbulanceDepartmentDefinition> rivalAmbulanceDepartmentDefinition in config3.RivalAmbulanceDepartmentDefinitions)
				{
					_rivalAmbulanceDepartments.Add(new RivalAmbulanceDepartment(rivalAmbulanceDepartmentDefinition.Instance, _level));
				}
				_competingDepartments.AddRange(_rivalAmbulanceDepartments);
			}
			_rescueDeathPenaltyMultiplier = config3.RescueDeathPenaltyMultiplier;
			_ignoredSceneDeathPenaltyMultiplier = config3.IgnoredSceneDeathPenaltyMultiplier;
			level.AddTimelineUpdateListener(OnTimelineUpdated);
			_maintenanceChallengeManager = new MaintenanceChallengeManager(_level, this, _config);
			RegisterConsoleCommands();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			ChallengeEvents challengeEvents = _level.ChallengeEvents;
			challengeEvents.OnChallengeCompleted = (Action<Challenge>)Delegate.Combine(challengeEvents.OnChallengeCompleted, new Action<Challenge>(OnChallengeCompleted));
			_level.AddTimelineUpdateListener(OnTimelineUpdated);
			foreach (KeyValuePair<string, ChallengeSchedule> schedule in _schedules)
			{
				schedule.Value.RestoreFromSave();
			}
			if (_maintenanceChallengeManager == null)
			{
				_maintenanceChallengeManager = new MaintenanceChallengeManager(_level, this, _config);
			}
			else
			{
				_maintenanceChallengeManager.RestoreFromSave();
			}
			Config config = null;
			if ((_level.UniqueID == "934" || _level.UniqueID == "935" || _level.UniqueID == "936") && _level.IsSandbox())
			{
				config = _level.GetLevelOnlyChallengeConfig();
			}
			Config config2 = ((config == null) ? _config : config);
			if (_playerAmbulanceDepartment != null)
			{
				_playerAmbulanceDepartment.RestoreFromSave(config2.PlayerAmbulanceDepartmentDefinition.Instance, _level);
				_competingDepartments = new List<AmbulanceDepartment>();
				_competingDepartments.Add(_playerAmbulanceDepartment);
			}
			if (_rivalAmbulanceDepartments != null && _rivalAmbulanceDepartments.Count != 0)
			{
				for (int i = 0; i < _rivalAmbulanceDepartments.Count; i++)
				{
					_rivalAmbulanceDepartments[i].RestoreFromSave(config2.RivalAmbulanceDepartmentDefinitions[i].Instance, _level);
				}
				_competingDepartments.AddRange(_rivalAmbulanceDepartments);
			}
			RegisterConsoleCommands();
		}

		private void RegisterConsoleCommands()
		{
			ConsoleCommandsDatabase.RegisterCommand("CreateChallenge", "Instantly creates a new challenge with the index into the ChallengeManager playlist", "CreateChallenge <name>, e.g. CreateChallenge Earthquake", Debug_CreateChallenge);
			ConsoleCommandsDatabase.RegisterCommand("LogCurrentChallengeScore", "Logs the current challenge score breakdown", "LogCurrentChallengeScore", Debug_LogCurrentChallengeScore);
			ConsoleCommandsDatabase.RegisterCommand("StopAllChallenges", "Stop any further challenges from starting", "StopAllChallenges", Debug_StopAllChallenges);
			ConsoleCommandsDatabase.RegisterCommand("UseDebugLeagueTableData", "Creates fake data for the Ambulance Emergency League Tables to use for debugging purposes.", "UseDebugLeagueTableData", Debug_UseDebugLeagueTableData);
			if (_config.Schedules == null)
			{
				return;
			}
			List<ChallengeConfig> list = new List<ChallengeConfig>();
			foreach (ChallengeScheduleDefinition schedule in _config.Schedules)
			{
				if (schedule.Challenges == null)
				{
					continue;
				}
				foreach (ChallengeScheduleDefinition.Item challenge in schedule.Challenges)
				{
					list.AddUnique(challenge.Config.Instance);
				}
			}
			foreach (ChallengeConfig item in list)
			{
				string text = $"CreateChallenge {item.NameLocalised}";
				ConsoleCommandsDatabase.RegisterCommand(text, "Instantly creates a new challenge with the index into the ChallengeManager playlist", text, Debug_CreateChallenge);
			}
		}

		private void UnregisterConsoleCommands()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("CreateChallenge");
			ConsoleCommandsDatabase.UnRegisterCommand("LogCurrentChallengeScore");
			ConsoleCommandsDatabase.UnRegisterCommand("StopAllChallenges");
			ConsoleCommandsDatabase.UnRegisterCommand("UseDebugLeagueTableData");
			if (_config.Schedules == null)
			{
				return;
			}
			List<ChallengeConfig> list = new List<ChallengeConfig>();
			foreach (ChallengeScheduleDefinition schedule in _config.Schedules)
			{
				if (schedule.Challenges == null)
				{
					continue;
				}
				foreach (ChallengeScheduleDefinition.Item challenge in schedule.Challenges)
				{
					list.AddUnique(challenge.Config.Instance);
				}
			}
			foreach (ChallengeConfig item in list)
			{
				ConsoleCommandsDatabase.UnRegisterCommand($"CreateChallenge {item.NameLocalised}");
			}
		}

		public override void Destroy()
		{
			_maintenanceChallengeManager.Destroy();
			foreach (Challenge activeChallenge in _activeChallengeList)
			{
				activeChallenge.Destroy();
			}
			foreach (KeyValuePair<string, ChallengeSchedule> schedule in _schedules)
			{
				schedule.Value.Destroy();
			}
			if (_playerAmbulanceDepartment != null)
			{
				_playerAmbulanceDepartment.Destroy();
			}
			if (_rivalAmbulanceDepartments != null)
			{
				foreach (RivalAmbulanceDepartment rivalAmbulanceDepartment in _rivalAmbulanceDepartments)
				{
					rivalAmbulanceDepartment?.Destroy();
				}
			}
			_level.RemoveTimelineUpdateListener(OnTimelineUpdated);
			ChallengeEvents challengeEvents = _level.ChallengeEvents;
			challengeEvents.OnChallengeCompleted = (Action<Challenge>)Delegate.Remove(challengeEvents.OnChallengeCompleted, new Action<Challenge>(OnChallengeCompleted));
			UnregisterConsoleCommands();
			base.Destroy();
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (!_bDisableChallenges)
			{
				foreach (KeyValuePair<string, ChallengeSchedule> schedule in _schedules)
				{
					schedule.Value.OnTimelineUpdated();
				}
			}
			if (!_config.UseAmbulanceDepartments || day != 1)
			{
				return;
			}
			foreach (AmbulanceDepartmentStats.AmbulanceDepartmentStat stat in Enum.GetValues(typeof(AmbulanceDepartmentStats.AmbulanceDepartmentStat)))
			{
				List<AmbulanceDepartment> list = ((!AmbulanceDepartmentStats.ShouldInvertScore(stat)) ? (from x in _competingDepartments
					orderby x.Stats.LastMonthStats.GetStat(stat) descending, x is PlayerAmbulanceDepartment descending
					select x).ToList() : (from x in _competingDepartments
					orderby x.Stats.LastMonthStats.GetStat(stat), x is PlayerAmbulanceDepartment descending
					select x).ToList());
				for (int num = 0; num < list.Count; num++)
				{
					list[num].Stats.UpdateMonthlyLeaguePosition(stat, num);
					if (list[num] is PlayerAmbulanceDepartment && num > 0)
					{
						_monthsPlayerIsKingOfHill = 0;
					}
				}
				if (month == 0)
				{
					list = ((!AmbulanceDepartmentStats.ShouldInvertScore(stat)) ? (from x in _competingDepartments
						orderby x.Stats.LastYearStats.GetStat(stat) descending, x is PlayerAmbulanceDepartment descending
						select x).ToList() : (from x in _competingDepartments
						orderby x.Stats.LastYearStats.GetStat(stat), x is PlayerAmbulanceDepartment descending
						select x).ToList());
					for (int num2 = 0; num2 < list.Count; num2++)
					{
						list[num2].Stats.UpdateYearlyLeaguePosition(stat, num2);
					}
				}
			}
			OnAmbulanceLeagueUpdated.InvokeSafe(month);
			if (!(_level.UniqueID != "936"))
			{
				_monthsPlayerIsKingOfHill++;
				if (_monthsPlayerIsKingOfHill == 3)
				{
					PlatformStatsAndAchievements.TriggerAchievement(AchievementId.TopAllLeagues);
				}
			}
		}

		public void Update(float deltaTime)
		{
			if (!_bDisableChallenges)
			{
				foreach (KeyValuePair<string, ChallengeSchedule> schedule in _schedules)
				{
					schedule.Value.Update(deltaTime);
				}
			}
			for (int i = 0; i < _activeChallengeList.Count; i++)
			{
				_activeChallengeList[i].Update(deltaTime);
			}
			_playerAmbulanceDepartment?.Update(deltaTime);
			if (_rivalAmbulanceDepartments != null)
			{
				for (int j = 0; j < _rivalAmbulanceDepartments.Count; j++)
				{
					_rivalAmbulanceDepartments[j].Update(deltaTime);
				}
			}
		}

		private void OnChallengeCompleted(Objective objective)
		{
			for (int i = 0; i < _activeChallengeList.Count; i++)
			{
				Challenge challenge = _activeChallengeList[i];
				if (objective == challenge)
				{
					challenge.Destroy();
					_activeChallengeList.Remove(challenge);
					break;
				}
			}
		}

		public void CreateNewChallenge(ChallengeConfig config)
		{
			Challenge challenge = config.CreateChallenge(_level);
			_activeChallengeList.Add(challenge);
			_level.LevelScriptManager.AddObjective(challenge);
		}

		public void EnableChallengeSchedule(string name)
		{
			if (_schedules.TryGetValue(name, out var value))
			{
				value.IsEnabled = true;
			}
		}

		public void DisableChallengeSchedule(string name)
		{
			if (_schedules.TryGetValue(name, out var value))
			{
				value.IsEnabled = false;
			}
		}

		public void ResetChallengeSchedule(string name)
		{
			if (_schedules.TryGetValue(name, out var value))
			{
				value.ResetSchedule();
			}
		}

		public ChallengeSchedule FindChallengeSchedule(string name)
		{
			_schedules.TryGetValue(name, out var value);
			return value;
		}

		public void NotifyDepartments(ChallengeAmbulanceEmergency ambulanceEmergency)
		{
			_playerAmbulanceDepartment.AddChallenge(ambulanceEmergency);
			for (int i = 0; i < _rivalAmbulanceDepartments.Count; i++)
			{
				_rivalAmbulanceDepartments[i].AddChallenge(ambulanceEmergency);
			}
		}

		public int AddUniqueSuffix()
		{
			if (++_uniqueSuffix > 50)
			{
				_uniqueSuffix = 0;
			}
			return _uniqueSuffix;
		}

		private ConsoleCommandResult Debug_CreateChallenge(params string[] args)
		{
			ChallengeConfig challengeConfig = null;
			if (args.Length >= 1)
			{
				string text = args[0];
				for (int i = 1; i < args.Length; i++)
				{
					text = text + " " + args[i];
				}
				if (_config.Schedules != null)
				{
					foreach (ChallengeScheduleDefinition schedule in _config.Schedules)
					{
						if (schedule.Challenges == null)
						{
							continue;
						}
						foreach (ChallengeScheduleDefinition.Item challenge in schedule.Challenges)
						{
							if (!text.IsNullOrEmpty() && string.Equals(challenge.Config.Instance.NameLocalised.ToString(), text, StringComparison.OrdinalIgnoreCase))
							{
								challengeConfig = challenge.Config.Instance;
								break;
							}
						}
					}
				}
				if (challengeConfig == null)
				{
					return ConsoleCommandResult.Failed("Couldn't find challenge with name " + text + ". You can use tab autocomplete after typing 'CreateChallenge' to list all available challenges.");
				}
			}
			CreateNewChallenge(challengeConfig);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_LogCurrentChallengeScore(params string[] args)
		{
			foreach (Challenge activeChallenge in _activeChallengeList)
			{
				Logging.Info(LogChannels.Gameplay, activeChallenge.Name);
				Logging.Info(LogChannels.Gameplay, activeChallenge.PrintChallengeScoreBreakdown());
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_StopAllChallenges(string[] args)
		{
			_bDisableChallenges = !_bDisableChallenges;
			return ConsoleCommandResult.Succeeded(string.Format("Challenges are now {0}.", _bDisableChallenges ? "disabled" : "enabled"));
		}

		private ConsoleCommandResult Debug_UseDebugLeagueTableData(string[] args)
		{
			if (_playerAmbulanceDepartment == null)
			{
				return ConsoleCommandResult.Failed("There is no Player Ambulance Department in this level.");
			}
			if (args == null || args.Length < 2)
			{
				return ConsoleCommandResult.Failed("Missing Arguments");
			}
			int monthsAmount = int.Parse(args[0]);
			int yearsAmount = int.Parse(args[1]);
			_playerAmbulanceDepartment.Stats.SetDebugStats(monthsAmount, yearsAmount);
			foreach (RivalAmbulanceDepartment rivalAmbulanceDepartment in _rivalAmbulanceDepartments)
			{
				rivalAmbulanceDepartment.Stats.SetDebugStats(monthsAmount, yearsAmount);
			}
			return ConsoleCommandResult.Succeeded();
		}

		public List<T> GetActiveChallengesOfType<T>() where T : Challenge
		{
			List<T> list = new List<T>();
			foreach (Challenge activeChallenge in _activeChallengeList)
			{
				if (activeChallenge is T item)
				{
					list.Add(item);
				}
			}
			foreach (KeyValuePair<string, ChallengeSchedule> schedule in _schedules)
			{
				if (schedule.Value.ActiveChallenge != null && schedule.Value.ActiveChallenge is T)
				{
					T item2 = (T)schedule.Value.ActiveChallenge;
					list.Add(item2);
				}
			}
			return list;
		}
	}
}
