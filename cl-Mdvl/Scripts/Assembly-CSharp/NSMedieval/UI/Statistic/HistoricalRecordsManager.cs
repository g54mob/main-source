using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Dialogs.Data;
using NSMedieval.GameEventSystem;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.UI.Statistic
{
	public class HistoricalRecordsManager : MonoSingleton<HistoricalRecordsManager>, IObserver
	{
		[NonSerialized]
		private readonly List<HumanoidInstance> banishedWorkers = new List<HumanoidInstance>();

		private float elapsedTime;

		private TimeSpan inGameTime = TimeSpan.Zero;

		private LocalizationController Localize;

		private bool measureTime;

		private VillageSaveData villageSave;

		public StatisticData SaveStats => villageSave.StatisticData;

		public event Action TimerUpdateEvent;

		private void OnEnable()
		{
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnLeavingMainScene;
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += OnMainSceneLoaded;
		}

		private void OnDisable()
		{
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnLeavingMainScene;
				MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent -= OnMainSceneLoaded;
			}
		}

		private void Start()
		{
			Localize = MonoSingleton<LocalizationController>.Instance;
			villageSave = GlobalSaveController.CurrentVillageData;
			InitStats();
			InitStatGraphData();
			InitHistory();
		}

		private void OnMainSceneLoaded()
		{
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += UpdateStatsOnDateUpdate;
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += HourlySaveStats;
			MonoSingleton<UIController>.Instance.GameStartedEvent += OnGameStarted;
			MonoSingleton<WorkerController>.Instance.WorkerBanished += OnWorkerBanished;
			MonoSingleton<WorkerController>.Instance.CreateWorkerEvent += OnCreateWorker;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnRemoveWorker;
			MonoSingleton<NPCController>.Instance.OnNPCDiedEvent += OnRemoveNpc;
			MonoSingleton<GameEventSystemController>.Instance.RaidEventEnded += OnEndRaid;
			MonoSingleton<GameEventSystemController>.Instance.GameEventEnded += OnGameEventEnded;
			MonoSingleton<GameEventSystemController>.Instance.GameEventOptionChosen += OnGameEventOptionChosen;
			measureTime = true;
			StartCoroutine(UpdateTimer());
		}

		private void OnLeavingMainScene()
		{
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= UpdateStatsOnDateUpdate;
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= HourlySaveStats;
			MonoSingleton<UIController>.Instance.GameStartedEvent -= OnGameStarted;
			MonoSingleton<WorkerController>.Instance.WorkerBanished -= OnWorkerBanished;
			MonoSingleton<WorkerController>.Instance.CreateWorkerEvent -= OnCreateWorker;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnRemoveWorker;
			MonoSingleton<NPCController>.Instance.OnNPCDiedEvent -= OnRemoveNpc;
			if (MonoSingleton<GameEventSystemController>.IsInstantiated())
			{
				MonoSingleton<GameEventSystemController>.Instance.RaidEventEnded -= OnEndRaid;
				MonoSingleton<GameEventSystemController>.Instance.GameEventEnded -= OnGameEventEnded;
				MonoSingleton<GameEventSystemController>.Instance.GameEventOptionChosen -= OnGameEventOptionChosen;
			}
			measureTime = false;
			StopAllCoroutines();
		}

		private void OnGameStarted(bool started)
		{
			if (started && villageSave.DateAndTime.DaysTotal <= 1)
			{
				UpdateStatsOnDateUpdate();
			}
		}

		private void InitStats()
		{
			if (villageSave.StatisticData == null)
			{
				villageSave.StatisticData = new StatisticData();
			}
			inGameTime = SaveStats.InGameTime ?? inGameTime;
			elapsedTime = (float)inGameTime.TotalSeconds;
			HourlySaveStats();
		}

		public string GetTime()
		{
			return inGameTime.ToString("hh\\:mm\\:ss");
		}

		private void OnCreateWorker(HumanoidInstance humanoidInstance)
		{
			SaveStats.MaxVillagers = ((villageSave.Workers.Count > SaveStats.MaxVillagers) ? villageSave.Workers.Count : SaveStats.MaxVillagers);
		}

		private void OnWorkerBanished(HumanoidInstance humanoidInstance)
		{
			banishedWorkers.Add(humanoidInstance);
			AddHistoryEntry(Localize.GetText("worker_banish_event_log_type", humanoidInstance), Localize.GetText("worker_banish_event_log_title", humanoidInstance), Localize.GetText("worker_banish_event_log_info", humanoidInstance));
		}

		private void OnRemoveWorker(HumanoidInstance humanoidInstance)
		{
			if (humanoidInstance != null && !humanoidInstance.IsInIncognitoMode() && !humanoidInstance.SkipHistoryOnDeath)
			{
				SaveStats.LostVillagers++;
				if (!banishedWorkers.Contains(humanoidInstance))
				{
					AddHistoryEntry(Localize.GetText("worker_died_event_log_type", humanoidInstance), Localize.GetText("worker_died_event_log_title", humanoidInstance), Localize.GetText("worker_died_event_log_info", humanoidInstance));
				}
			}
		}

		private void OnRemoveNpc(HumanoidInstance humanoid)
		{
			SaveStats.EnemiesKilled++;
		}

		private void OnEndRaid(ActiveRaidInfo info)
		{
			switch (info.RaidStatus)
			{
			case RaidStatus.PlayerVictory:
				SaveStats.RaidsWon++;
				break;
			case RaidStatus.EnemyVictory:
				SaveStats.RaidsLost++;
				break;
			}
		}

		private IEnumerator UpdateTimer()
		{
			while (measureTime)
			{
				inGameTime = TimeSpan.FromSeconds(elapsedTime);
				elapsedTime += 1f;
				this.TimerUpdateEvent?.Invoke();
				yield return new WaitForSecondsRealtime(1f);
			}
		}

		private void HourlySaveStats()
		{
			SaveStats.InGameTime = inGameTime;
		}

		private void InitHistory()
		{
			if (villageSave.HistoryEntries == null)
			{
				villageSave.HistoryEntries = new List<HistoryEntry>();
				GenerateFirstEntry();
			}
		}

		public List<HistoryEntry> GetAllHistoryEntries()
		{
			return villageSave.HistoryEntries;
		}

		public HistoryEntry GetHistoryEntry(int entryId)
		{
			return villageSave.HistoryEntries[entryId];
		}

		public void OnGameEventOptionChosen(GameEventInstance eventInstance, int dialogShowingIndex)
		{
			DialogContent dialogContent = GameEventUtil.BuildDialogContent(eventInstance, dialogShowingIndex);
			AddHistoryEntry(dialogContent.WindowTitle, dialogContent.ContentTitle, dialogContent.ContentBodyText);
		}

		private void OnGameEventEnded(GameEventInstance eventInstance)
		{
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(12, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Statistics\\HistoricalRecordsManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(eventInstance.Blueprint.LocKeys.GetNameLocalized());
				messageBuilder.AppendLiteral(" Event Ended");
			}
			Log.Trace(messageBuilder);
			if (!(eventInstance is RaidEvent { CachedRaidInfo: var cachedRaidInfo }))
			{
				return;
			}
			if (cachedRaidInfo == null)
			{
				Log.Debug("Raid Info is null", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Statistics\\HistoricalRecordsManager.cs");
				return;
			}
			int num = MonoSingleton<NPCManager>.Instance.GetByRaidId(cachedRaidInfo.RaidId).Count((HumanoidInstance item) => !item.HasFainted);
			int spawnCount = cachedRaidInfo.SpawnCount;
			int num2 = cachedRaidInfo.WorkersDied?.Count ?? 0;
			string key = cachedRaidInfo.RaidStatus switch
			{
				RaidStatus.PlayerVictory => "raid_won", 
				RaidStatus.EnemyVictory => "raid_lost", 
				RaidStatus.Tie => "raid_tie", 
				_ => string.Empty, 
			};
			string text = Localize.GetText(key, formatVariables: true);
			string text2 = "\n" + text + "\n" + string.Format("{0}: {1}\n", Localize.GetText("enemies_total"), spawnCount) + string.Format("{0}: {1}\n", Localize.GetText("enemies_killed"), spawnCount - num) + string.Format("{0}: {1}\n", Localize.GetText("villagers_died"), num2);
			if (GetLastHistoryEntry("Raid") != null)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Statistics\\HistoricalRecordsManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Appending Details to last raid: ");
					messageBuilder.AppendFormatted(text2);
				}
				Log.Trace(messageBuilder);
				GetLastHistoryEntry("Raid").AppendDetails("\n" + text2);
			}
		}

		private HistoryEntry AddHistoryEntry(string type, string title, string details)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Statistics\\HistoricalRecordsManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Adding entry ");
				messageBuilder.AppendFormatted(details);
			}
			Log.Trace(messageBuilder);
			HistoryEntry historyEntry = new HistoryEntry(villageSave.HistoryEntries.Count, Localize.GetText(type, formatVariables: true), Localize.GetText(title, formatVariables: true), Localize.GetText(details, formatVariables: true), GetDateString());
			villageSave.HistoryEntries.Add(historyEntry);
			return historyEntry;
		}

		private HistoryEntry GetLastHistoryEntry(string typeText)
		{
			return villageSave.HistoryEntries.FindLast((HistoryEntry entry) => entry.TypeText == typeText);
		}

		private string GetDateString()
		{
			WorldDate dateAndTime = villageSave.DateAndTime;
			return string.Format("{0} {1}, {2}", Localize.GetText("general_" + GlobalSaveController.CurrentVillageData.DateAndTime.Season.Name), dateAndTime.Day, dateAndTime.Year);
		}

		private void GenerateFirstEntry()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(Localize.GetText(LocKeyUtils.GetDescription(villageSave.Scenario.LocKeys), (HumanoidInstance)null) ?? "");
			if (villageSave.Scenario.VillagerConstraints.NumberOfVillagers > 1)
			{
				stringBuilder.AppendLine("\n" + Localize.GetText(villageSave.MapTypeID + "_narrative", (HumanoidInstance)null) + "\n");
			}
			else
			{
				HumanoidInstance humanoid = villageSave.Workers.FirstOrDefault();
				stringBuilder.AppendLine("\n" + Localize.GetText(villageSave.MapTypeID + "_narrative_single", humanoid) + "\n");
			}
			SaveStats.MaxVillagers = villageSave.Workers.Count;
			AddHistoryEntry(LocKeyUtils.GetName(villageSave.Scenario.LocKeys), LocKeyUtils.GetName(villageSave.Scenario.LocKeys), stringBuilder.ToString());
		}

		private void InitStatGraphData()
		{
			if (villageSave.StatisticsGraphs == null)
			{
				villageSave.StatisticsGraphs = new List<GraphData>();
			}
			StatisticGraphType[] statisticGraphTypes = EnumValues.StatisticGraphTypes;
			for (int i = 0; i < statisticGraphTypes.Length; i++)
			{
				StatisticGraphType type = statisticGraphTypes[i];
				GraphData graphData = villageSave.StatisticsGraphs.FirstOrDefault((GraphData data) => data.GraphType == type);
				if (graphData == null)
				{
					graphData = new GraphData(type.ToString() + "Graph", type, ColorUtils.GetColor(type.ToString()));
					villageSave.StatisticsGraphs.Add(graphData);
				}
			}
		}

		private void UpdateStatsOnDateUpdate()
		{
			List<HumanoidInstance> list = new List<HumanoidInstance>(villageSave.Workers);
			foreach (CaravanInstance caravan in villageSave.WorldMapData.Caravans)
			{
				list.AddRange(caravan.Workers);
			}
			BaseWealth baseWealth = MonoSingleton<BaseWealth>.Instance;
			foreach (GraphData statisticsGraph in villageSave.StatisticsGraphs)
			{
				switch (statisticsGraph.GraphType)
				{
				case StatisticGraphType.PopulationCount:
					statisticsGraph.NodeValues.Add(list.Count);
					break;
				case StatisticGraphType.ResourceWealth:
					statisticsGraph.NodeValues.Add(baseWealth.GetPilesWealth());
					break;
				case StatisticGraphType.BuildingWealth:
					statisticsGraph.NodeValues.Add(baseWealth.GetBuildingsWealth());
					break;
				case StatisticGraphType.TotalWealth:
					statisticsGraph.NodeValues.Add(baseWealth.GetTotalWealth());
					break;
				case StatisticGraphType.FoodAmount:
					statisticsGraph.NodeValues.Add(MonoSingleton<ResourcePileTracker>.Instance.GetTotalStockpilePilesNutrition());
					break;
				case StatisticGraphType.MoodAverage:
				{
					float num = 0f;
					if (list.Count > 0)
					{
						foreach (HumanoidInstance item in list)
						{
							num += item.Stats.GetStat(StatType.Mood).Current;
						}
						int num2 = (int)num / list.Count;
						statisticsGraph.NodeValues.Add(num2);
					}
					else
					{
						statisticsGraph.NodeValues.Add(0f);
					}
					break;
				}
				default:
					throw new ArgumentOutOfRangeException();
				case StatisticGraphType.InfluenceAmount:
					break;
				}
			}
		}
	}
}
