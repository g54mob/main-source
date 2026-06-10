using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Model.SecondMap;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.WorldMap;

namespace NSMedieval.Village.Map
{
	public class SecondMapLeaveManager
	{
		private const int LeaveHoursTimeout = 18;

		private const int HoursRemainingWarning = 6;

		private int elapsedHours;

		private int timeoutWarningRemainingMinutes;

		private List<Vec3Int> workerStartPositions = new List<Vec3Int>();

		private SecondMapType secondMapType;

		private VillageMap villageMap;

		private int minutesInHour;

		public bool TimerDisabledDebug { get; set; }

		private WorldMapPlace WorldMapPlace { get; set; }

		public float ResourcePercentageLost { get; private set; }

		public bool IsTimeRunningOutMessageVisible { get; private set; }

		public bool TimedOut { get; private set; }

		public bool DisableExitCaravanScreenButton { get; private set; }

		public bool AllWorkersDied { get; private set; }

		public bool CombatStarted { get; private set; }

		public SecondMapLeaveOutcome SecondMapLeaveOutcome
		{
			get
			{
				return GlobalSaveController.CurrentVillageData.SecondMapLeaveOutcome;
			}
			private set
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\SecondMap\\SecondMapLeaveManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Set leave map outcome ");
					messageBuilder.AppendFormatted(value);
				}
				Log.Info(messageBuilder);
				GlobalSaveController.CurrentVillageData.SecondMapLeaveOutcome = value;
			}
		}

		public SecondMapType SecondMapType => WorldMapPlace.CachedMapInfo.Type;

		public event Action OnRaidWonEvent;

		public SecondMapLeaveManager(VillageMap map)
		{
			villageMap = map;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
		}

		public void Dispose()
		{
			if (GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				elapsedHours = 0;
				villageMap = null;
				TimedOut = false;
				DisableExitCaravanScreenButton = false;
				if (MonoSingleton<WorkerController>.IsInstantiated())
				{
					MonoSingleton<WorkerController>.Instance.WorkerDiedEvent -= OnWorkerDied;
					MonoSingleton<WorkerController>.Instance.WorkerFaintedEvent -= OnWorkerFainted;
				}
				if (MonoSingleton<World>.IsInstantiated())
				{
					MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
				}
				if (MonoSingleton<WorldTimeManager>.IsInstantiated())
				{
					MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
				}
				if (MonoSingleton<RaidController>.IsInstantiated())
				{
					MonoSingleton<RaidController>.Instance.OnWorkersWonRaidEvent -= OnWorkersWonRaid;
					MonoSingleton<RaidController>.Instance.OnWorkersLostRaidEvent -= OnWorkersLostRaid;
					MonoSingleton<RaidController>.Instance.RaidTieEvent -= OnRaidTie;
				}
				if (MonoSingleton<CombatController>.IsInstantiated())
				{
					MonoSingleton<CombatController>.Instance.CombatStartedEvent -= OnCombatStarted;
				}
				if (MonoSingleton<WorldTimeManager>.IsInstantiated())
				{
					MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent -= OnQuarterHourUpdate;
				}
				if (MonoSingleton<AnimalController>.IsInstantiated())
				{
					MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent -= OnRemoveAnimal;
				}
				this.OnRaidWonEvent = null;
			}
		}

		public void OnBeforeOpenLeaveMenu()
		{
			if (SecondMapLeaveOutcome != SecondMapLeaveOutcome.FullDefeat && SecondMapLeaveOutcome != SecondMapLeaveOutcome.BattleDefeat)
			{
				villageMap.SiegeWeaponComponentManager.UninstallAllPlayerSiegeWeapons();
			}
			if (SecondMapLeaveOutcome == SecondMapLeaveOutcome.BattleInProgress)
			{
				if (SecondMapType == SecondMapType.LootStash && !WorldMapPlace.CachedMapInfo.HasHostiles)
				{
					ResourcePercentageLost = 0f;
				}
				else
				{
					ResourcePercentageLost = SingletonModel<LeaveMapOutcomeSettings, LeaveMapOutcomeSettingsData>.I.Get(SecondMapType).EscapeLoseCargoPercent;
				}
			}
		}

		public void OnBeforeCloseLeaveMenuButton()
		{
			if (SecondMapLeaveOutcome == SecondMapLeaveOutcome.BattleInProgress)
			{
				ResourcePercentageLost = 0f;
			}
		}

		private void OnMapLoaded(bool fromSave)
		{
			if (!GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				return;
			}
			elapsedHours = GlobalSaveController.CurrentVillageData.SecondMapTimeoutElapsedHours;
			minutesInHour = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour;
			timeoutWarningRemainingMinutes = GlobalSaveController.CurrentVillageData.TimeoutWarningRemainingMinutes;
			WorldMapPlace = GlobalSaveController.CurrentVillageData.WorldMapPlace;
			if (WorldMapPlace == null)
			{
				Log.Error("WorldMapPlace was null!", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\SecondMap\\SecondMapLeaveManager.cs");
				return;
			}
			SecondMapSaveInfo cachedMapInfo = WorldMapPlace.CachedMapInfo;
			if (fromSave)
			{
				SecondMapLeaveOutcome = GlobalSaveController.CurrentVillageData.SecondMapLeaveOutcome;
				if (cachedMapInfo.Type != SecondMapType.LootStash)
				{
					if (SecondMapLeaveOutcome == SecondMapLeaveOutcome.BattleVictory)
					{
						MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
					}
					if (SecondMapLeaveOutcome == SecondMapLeaveOutcome.BattleTie)
					{
						DisableExitCaravanScreenButton = true;
					}
				}
				if (timeoutWarningRemainingMinutes > 0)
				{
					MonoSingleton<GlobalWarningMessagesManager>.Instance.SetWarningMessageSecondMapTimeout(timeoutWarningRemainingMinutes);
					IsTimeRunningOutMessageVisible = true;
					MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent += OnQuarterHourUpdate;
				}
			}
			else
			{
				SecondMapLeaveOutcome = SecondMapLeaveOutcome.LeftWithoutEngagingEnemy;
			}
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				workerStartPositions.Add(key.GetGridPosition());
			}
			MonoSingleton<WorkerController>.Instance.WorkerDiedEvent += OnWorkerDied;
			MonoSingleton<WorkerController>.Instance.WorkerFaintedEvent += OnWorkerFainted;
			switch (cachedMapInfo.Type)
			{
			case SecondMapType.Ambush:
				AttachRaidCallbacks();
				break;
			case SecondMapType.Attack:
				AttachRaidCallbacks();
				break;
			case SecondMapType.Settlement:
				AttachRaidCallbacks();
				break;
			case SecondMapType.LootStash:
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
				if (cachedMapInfo.HasHostiles)
				{
					MonoSingleton<CombatController>.Instance.CombatStartedEvent += OnCombatStarted;
					MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent += OnRemoveAnimal;
				}
				MonoSingleton<AchievementManager>.Instance.UnlockAchievement("EXPLORE_LOOT_STASH");
				break;
			case SecondMapType.None:
				break;
			}
			void AttachRaidCallbacks()
			{
				MonoSingleton<RaidController>.Instance.OnWorkersWonRaidEvent += OnWorkersWonRaid;
				MonoSingleton<RaidController>.Instance.OnWorkersLostRaidEvent += OnWorkersLostRaid;
				MonoSingleton<RaidController>.Instance.RaidTieEvent += OnRaidTie;
				MonoSingleton<CombatController>.Instance.CombatStartedEvent += OnCombatStarted;
			}
		}

		private void OnRemoveAnimal(AnimalInstance animalInstance)
		{
			if (!MonoSingleton<AnimalManager>.Instance.HasHostileAnimals())
			{
				SecondMapLeaveOutcome = SecondMapLeaveOutcome.BattleVictory;
			}
		}

		private void OnHourUpdate()
		{
			if (!TimerDisabledDebug)
			{
				elapsedHours++;
				GlobalSaveController.CurrentVillageData.SecondMapTimeoutElapsedHours = elapsedHours;
				if (18 - elapsedHours == 6)
				{
					MonoSingleton<GlobalWarningMessagesManager>.Instance.SetWarningMessageSecondMapTimeout(GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour * 6);
					IsTimeRunningOutMessageVisible = true;
					MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent += OnQuarterHourUpdate;
					timeoutWarningRemainingMinutes = 6 * minutesInHour;
					GlobalSaveController.CurrentVillageData.TimeoutWarningRemainingMinutes = timeoutWarningRemainingMinutes;
				}
				if (elapsedHours >= 18)
				{
					MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
					MonoSingleton<WorldTimeManager>.Instance.QuarterHourUpdateEvent -= OnQuarterHourUpdate;
					NoMoreTime();
				}
			}
		}

		private void OnQuarterHourUpdate()
		{
			timeoutWarningRemainingMinutes -= minutesInHour / 4;
			GlobalSaveController.CurrentVillageData.TimeoutWarningRemainingMinutes = timeoutWarningRemainingMinutes;
		}

		private void NoMoreTime()
		{
			TimedOut = true;
			SecondMapSaveInfo cachedMapInfo = WorldMapPlace.CachedMapInfo;
			if (cachedMapInfo.Type == SecondMapType.LootStash && cachedMapInfo.HasHostiles && CombatStarted && SecondMapLeaveOutcome != SecondMapLeaveOutcome.BattleVictory)
			{
				ResourcePercentageLost = SingletonModel<LeaveMapOutcomeSettings, LeaveMapOutcomeSettingsData>.I.Get(SecondMapType.LootStash).DefeatLoseCargoPercent;
			}
			if (MonoSingleton<WorkerManager>.Instance.FaintedWorkers.Count == MonoSingleton<WorkerManager>.Instance.AllWorkers.Count)
			{
				UnFaintWorkers();
			}
			MonoSingleton<CaravanManager>.Instance.OpenLeaveMapCaravanPanel();
		}

		private void OnWorkerDied(int remainingWorkers)
		{
			if (remainingWorkers <= 0)
			{
				bool num = WorldMapPlace.CachedMapInfo.Type == SecondMapType.LootStash;
				ResourcePercentageLost = 1f;
				AllWorkersDied = true;
				if (num)
				{
					SaveUnlootedResources();
				}
				SecondMapLeaveOutcome = SecondMapLeaveOutcome.FullDefeat;
				MonoSingleton<CaravanManager>.Instance.DisposeCurrentWorldMapPlaceCaravan();
			}
		}

		private void SaveUnlootedResources()
		{
			using PooledList<HumanoidInstance> pooledList = GlobalSaveController.CurrentVillageData.Workers.ToPooledListJanitor();
			pooledList.Sort((HumanoidInstance workerA, HumanoidInstance workerB) => string.Compare(workerA.Info.GetFullName(), workerB.Info.GetFullName(), StringComparison.CurrentCulture));
			if (!(GlobalSaveController.CurrentVillageData.WorldMapPlace is WorldMapMarkerPlace worldMapMarkerPlace))
			{
				return;
			}
			worldMapMarkerPlace.LootableStorage.ClearAll(isSilent: true);
			foreach (ResourceInstance resource in TradingManager.GetResources(mustBeStored: false, workerStartPositions))
			{
				worldMapMarkerPlace.LootableStorage.Add(resource);
			}
		}

		private void OnWorkerFainted(int faintedCount, int totalWorkerCount)
		{
			if (faintedCount >= totalWorkerCount)
			{
				DisableExitCaravanScreenButton = true;
				SecondMapLeaveOutcome = SecondMapLeaveOutcome.FullDefeat;
				MonoSingleton<CaravanManager>.Instance.OpenLeaveMapCaravanPanel();
				UnFaintWorkers();
			}
		}

		private void UnFaintWorkers()
		{
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (key.Stats?.GetStat(StatType.Consciousness) != null)
				{
					key.Stats.GetStat(StatType.Consciousness).SetCurrent(100f);
				}
			}
		}

		private void OnWorkersWonRaid()
		{
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
			SecondMapLeaveOutcome = SecondMapLeaveOutcome.BattleVictory;
			this.OnRaidWonEvent?.Invoke();
			if (WorldMapPlace.CachedMapInfo.Type == SecondMapType.Settlement)
			{
				MonoSingleton<AchievementManager>.Instance.UnlockAchievement("DEFEAT_SETTLEMENT");
			}
		}

		private void OnWorkersLostRaid()
		{
			SecondMapLeaveOutcome = SecondMapLeaveOutcome.BattleDefeat;
			ResourcePercentageLost = SingletonModel<LeaveMapOutcomeSettings, LeaveMapOutcomeSettingsData>.I.Get(SecondMapType).DefeatLoseCargoPercent;
			if (!AllWorkersDied)
			{
				DisableExitCaravanScreenButton = true;
				MonoSingleton<CaravanManager>.Instance.OpenLeaveMapCaravanPanel();
			}
		}

		private void OnRaidTie()
		{
			ResourcePercentageLost = SingletonModel<LeaveMapOutcomeSettings, LeaveMapOutcomeSettingsData>.I.Get(SecondMapType).TieLoseCargoPercent;
			DisableExitCaravanScreenButton = true;
			SecondMapLeaveOutcome = SecondMapLeaveOutcome.BattleTie;
			MonoSingleton<CaravanManager>.Instance.OpenLeaveMapCaravanPanel();
		}

		private void OnCombatStarted()
		{
			MonoSingleton<CombatController>.Instance.CombatStartedEvent -= OnCombatStarted;
			SecondMapLeaveOutcome = SecondMapLeaveOutcome.BattleInProgress;
			CombatStarted = true;
		}
	}
}
