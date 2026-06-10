using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using GlobalStats;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.GlobalStats;
using NSMedieval.Model;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class GlobalStatManager : MonoSingleton<GlobalStatManager>
	{
		public const string InfamyGlobalStatId = "infamy";

		private const string TradeInfluenceGlobalStatId = "trade_influence";

		[NonSerialized]
		private List<GlobalStatInstance> globalStatInstancesReference;

		[NonSerialized]
		private Dictionary<string, GlobalStatInstance> globalStatInstancesById;

		public IReadOnlyList<GlobalStatInstance> GlobalStatInstances => globalStatInstancesReference;

		public GlobalStatInstance GetGlobalStatInstance(string globalStatId)
		{
			if (string.IsNullOrEmpty(globalStatId))
			{
				return null;
			}
			globalStatInstancesById.TryGetValue(globalStatId, out var value);
			return value;
		}

		public void AddToGlobalStatValue(string globalStatId, float valueToAdd)
		{
			GetGlobalStatInstance(globalStatId)?.AddToValue(valueToAdd);
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventEndedEvent -= OnPlayerTriggeredEventEnded;
			}
			if (MonoSingleton<GlobalStatController>.IsInstantiated())
			{
				MonoSingleton<GlobalStatController>.Instance.GlobalStatValueSetEvent -= OnGlobalStatValueSet;
			}
			if (MonoSingleton<TradingManager>.IsInstantiated())
			{
				MonoSingleton<TradingManager>.Instance.TradeAppliedEvent -= OnTradeApplied;
			}
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.RaidEndedEvent -= OnRaidEnded;
			}
			if (MonoSingleton<NPCController>.IsInstantiated())
			{
				MonoSingleton<NPCController>.Instance.OnNPCDiedEvent -= OnNPCDied;
				MonoSingleton<NPCController>.Instance.PrisonerReleasedEvent -= OnPrisonerReleased;
				MonoSingleton<NPCController>.Instance.CapturedPrisonersEvent -= OnPrisonersCaptured;
			}
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateUpdate;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent -= OnLoadingComplete;
			}
			base.OnDestroy();
		}

		private void Start()
		{
			MonoSingleton<PlayerTriggeredEventManager>.Instance.EventEndedEvent += OnPlayerTriggeredEventEnded;
			MonoSingleton<GlobalStatController>.Instance.GlobalStatValueSetEvent += OnGlobalStatValueSet;
			MonoSingleton<TradingManager>.Instance.TradeAppliedEvent += OnTradeApplied;
			MonoSingleton<RaidController>.Instance.RaidEndedEvent += OnRaidEnded;
			MonoSingleton<NPCController>.Instance.OnNPCDiedEvent += OnNPCDied;
			MonoSingleton<NPCController>.Instance.PrisonerReleasedEvent += OnPrisonerReleased;
			MonoSingleton<NPCController>.Instance.CapturedPrisonersEvent += OnPrisonersCaptured;
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
			MonoSingleton<LoadingController>.Instance.LoadingCompleteEvent += OnLoadingComplete;
			globalStatInstancesReference = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.GlobalStatInstances;
			if (globalStatInstancesReference == null || globalStatInstancesReference.Count == 0)
			{
				CreateGlobalStatInstances();
			}
			CacheGlobalStatInstancesById();
		}

		private void OnLoadingComplete()
		{
			InitialCheckGlobalStatTriggers();
		}

		private void InitialCheckGlobalStatTriggers()
		{
			foreach (GlobalStatInstance globalStatInstance in GlobalStatInstances)
			{
				globalStatInstance.CheckActivateTrigger();
			}
		}

		private void CreateGlobalStatInstances()
		{
			Log.Info("CreateGlobalStatInstances - this.globalStatInstances was empty or null.", "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatManager.cs");
			foreach (GlobalStat allItem in Repository<GlobalStatRepository, GlobalStat>.Instance.GetAllItems())
			{
				globalStatInstancesReference.Add(new GlobalStatInstance(allItem));
			}
		}

		private void CacheGlobalStatInstancesById()
		{
			if (globalStatInstancesById == null)
			{
				globalStatInstancesById = new Dictionary<string, GlobalStatInstance>();
			}
			else
			{
				globalStatInstancesById.Clear();
			}
			foreach (GlobalStatInstance item in globalStatInstancesReference)
			{
				globalStatInstancesById.Add(item.BlueprintId, item);
			}
		}

		private void OnPrisonersCaptured(IReadOnlyCollection<HumanoidInstance> capturedPrisoners)
		{
			if (capturedPrisoners.Count((HumanoidInstance prisoner) => prisoner != null && !prisoner.HasDisposed && !prisoner.HasDied) == 0)
			{
				AddToGlobalStatValue("infamy", -2f);
			}
		}

		private void OnPrisonerReleased(CaptiveNpcBehaviour captiveNpc)
		{
			AddToGlobalStatValue("infamy", -5f);
		}

		private void OnNPCDied(HumanoidInstance humanDied)
		{
			if (humanDied == null || humanDied.IsWorker() || humanDied.Faction == null || !humanDied.IsKilled(out var killer) || !(killer is HumanoidInstance humanoidInstance) || !humanoidInstance.IsWorker())
			{
				return;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("NPC ");
				messageBuilder.AppendFormatted(humanDied);
				messageBuilder.AppendLiteral(" was killed by ");
				messageBuilder.AppendFormatted(killer);
			}
			Log.Info(messageBuilder);
			if (!(humanDied.ActiveBehaviour.Blueprint is NPC { AddToGlobalStatOnKilledByPlayer: not null, AddToGlobalStatOnKilledByPlayer: var addToGlobalStatOnKilledByPlayer }))
			{
				return;
			}
			foreach (GlobalStatModifier globalStatModifier in addToGlobalStatOnKilledByPlayer)
			{
				GlobalStatInstance globalStatInstance = GetGlobalStatInstance(globalStatModifier.GlobalStat);
				if (globalStatInstance == null)
				{
					FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatManager.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Global Stat ");
						messageBuilder2.AppendFormatted(globalStatModifier.GlobalStat);
						messageBuilder2.AppendLiteral(" does not exist.");
					}
					Log.Warning(messageBuilder2);
				}
				else if (globalStatModifier.Friendliness.Contains(humanDied.Faction.GetFriendliness()))
				{
					globalStatInstance.AddToValue(globalStatModifier.AddValue);
				}
			}
		}

		private void OnRaidEnded(ActiveRaidInfo raidInfo)
		{
			if (string.IsNullOrEmpty(raidInfo.ParentEventId))
			{
				return;
			}
			GameEvent byID = Repository<GameEventSettingsRepository, GameEvent>.Instance.GetByID(raidInfo.ParentEventId);
			if (byID?.RaidOutcomeGlobalStatModifiers == null)
			{
				return;
			}
			GameEvent.RaidOutcomeGlobalStatModifier[] raidOutcomeGlobalStatModifiers = byID.RaidOutcomeGlobalStatModifiers;
			foreach (GameEvent.RaidOutcomeGlobalStatModifier raidOutcomeGlobalStatModifier in raidOutcomeGlobalStatModifiers)
			{
				if (raidOutcomeGlobalStatModifier.RaidStatus != raidInfo.RaidStatus)
				{
					continue;
				}
				GlobalStatInstance globalStatInstance = GetGlobalStatInstance(raidOutcomeGlobalStatModifier.GlobalStat);
				if (globalStatInstance != null)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(53, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Raid ended - event: ");
						messageBuilder.AppendFormatted(raidInfo.ParentEventId);
						messageBuilder.AppendLiteral(". Applying global stat modifier ");
						messageBuilder.AppendFormatted(raidOutcomeGlobalStatModifier.GlobalStat);
						messageBuilder.AppendLiteral(" ");
						messageBuilder.AppendFormatted(raidOutcomeGlobalStatModifier.AddValue);
					}
					Log.Info(messageBuilder);
					globalStatInstance.AddToValue(raidOutcomeGlobalStatModifier.AddValue);
				}
			}
		}

		private void OnTradeApplied(ITrader playerTrader, ITrader otherTrader, float totalValueTraded, bool wasGiftingOnly)
		{
			if (wasGiftingOnly)
			{
				float num = totalValueTraded * 0.02f;
				Log.Info("Gifting-only trade: reducing infamy by " + num, "C:\\GIT\\dev\\Assets\\Scripts\\GlobalStats\\GlobalStatManager.cs");
				AddToGlobalStatValue("infamy", 0f - num);
			}
			else if (otherTrader is TraderBehaviour || otherTrader is VillagePlace)
			{
				if (playerTrader is CaravanInstance)
				{
					float toAdd = 0.01f * totalValueTraded;
					GetGlobalStatInstance("trade_influence")?.AddToValue(toAdd);
				}
				if (playerTrader is WorkerBehaviour)
				{
					float toAdd2 = 0.015f * totalValueTraded;
					GetGlobalStatInstance("trade_influence")?.AddToValue(toAdd2);
				}
			}
		}

		private void OnGlobalStatValueSet(GlobalStatInstance statInstance, float oldValue, bool allowShowBbt)
		{
			if (statInstance.ShouldShowMessages && (!statInstance.IsHidden() || statInstance.Blueprint.AlwaysShowMessages) && Mathf.Abs(oldValue - statInstance.Value) >= 0.5f)
			{
				string key = ((statInstance.Value > oldValue) ? "global_stat_increased" : "global_stat_decreased");
				string text = MonoSingleton<LocalizationController>.Instance.GetText(key);
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(statInstance.GetNameLocalized() + " " + text);
			}
		}

		private void OnPlayerTriggeredEventEnded(PlayerTriggeredEventInstance eventInstance)
		{
			if (!eventInstance.Ended())
			{
				return;
			}
			EventOutcomeSetting outcome = eventInstance.GetOutcome();
			if (outcome.AddToGlobalStats == null)
			{
				return;
			}
			EventOutcomeSetting.GlobalStatWithNpcCount[] addToGlobalStats = outcome.AddToGlobalStats;
			foreach (EventOutcomeSetting.GlobalStatWithNpcCount globalStatWithNpcCount in addToGlobalStats)
			{
				if (globalStatWithNpcCount.MinNpcCount <= 0 || eventInstance.NpcParticipantsCount >= globalStatWithNpcCount.MinNpcCount)
				{
					float value = globalStatWithNpcCount.Value;
					GetGlobalStatInstance(globalStatWithNpcCount.GlobalStat)?.AddToValue(value);
				}
			}
		}

		private void OnDateUpdate()
		{
			TickGlobalStatsFalloff();
		}

		private void TickGlobalStatsFalloff()
		{
			foreach (GlobalStatInstance globalStatInstance in GlobalStatInstances)
			{
				globalStatInstance.TickDailyFalloff();
			}
		}
	}
}
