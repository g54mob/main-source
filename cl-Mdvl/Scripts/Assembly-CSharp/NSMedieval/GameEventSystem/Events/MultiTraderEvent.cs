using System;
using System.Collections.Generic;
using System.Linq;
using GameEventSystem.Core.Events;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Dialogs.Data;
using NSMedieval.Manager;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;
using Utils;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.MultiTraderEvent", "")]
	public class MultiTraderEvent : GameEventInstance, ITraderPhaseDataHolder, IVisitorEvent
	{
		public static Action EventStart;

		[SerializeField]
		private List<HumanoidInstance> traders;

		[SerializeField]
		private List<HumanoidInstance> crowd;

		private static readonly string[] PossibleTraderNpcTypes = new string[2] { "general_goods_trader_normal", "general_goods_trader_large" };

		private static readonly string[] PossibleCrowdNpcTypes = new string[1] { "general_market_crowd" };

		private int TradersSpawnCount => 5;

		private int CrowdSpawnCount => 5;

		public List<HumanoidInstance> Traders => traders;

		public HumanoidInstance Trader => traders[0];

		public List<HumanoidInstance> Guards => crowd;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			EventStart = null;
		}

		public MultiTraderEvent()
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
			EventStart = null;
			traders?.Clear();
			traders = null;
			crowd?.Clear();
			crowd = null;
		}

		public override void OnEnd()
		{
			base.OnEnd();
			RetreatAll();
			Unsubscribe();
		}

		private void RetreatAll()
		{
			GameEventInstance.Logger.Info("Retreating");
			if (traders != null)
			{
				using PooledHashSet<string> pooledHashSet = HashSetPool<string>.GetJanitor();
				foreach (HumanoidInstance trader in traders)
				{
					if (!trader.HasDied && !trader.HasDisposed && !trader.IsLeaving)
					{
						string text = MonoSingleton<LocalizationController>.Instance.GetText("trader_leaving").Replace("<faction_name>", trader.Faction?.NameLocalized ?? string.Empty);
						if (!string.IsNullOrEmpty(text))
						{
							pooledHashSet.Add(text);
						}
						trader.RetreatFromMap();
					}
				}
				foreach (string item in pooledHashSet)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(item);
				}
			}
			if (crowd != null)
			{
				foreach (HumanoidInstance item2 in crowd)
				{
					if (!item2.HasDied && !item2.HasDisposed && !item2.IsLeaving)
					{
						item2.RetreatFromMap();
					}
				}
			}
			foreach (HumanoidInstance item3 in MonoSingleton<NPCManager>.Instance.IterateNPCs((HumanoidInstance npc) => npc.PrisonerBehaviour != null && npc.PrisonerBehaviour.Owner == Trader))
			{
				if (!item3.HasDied && !item3.HasDisposed && !item3.IsLeaving)
				{
					item3.RetreatFromMap();
				}
			}
		}

		public override void OnLoaded(bool fromSave)
		{
			base.OnLoaded(fromSave);
			Subscribe();
		}

		public override bool CanStart()
		{
			if (!base.CanStart())
			{
				return false;
			}
			return GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.Any((VillagePlace village) => base.Blueprint.Friendliness.Contains(village.FactionInstance.GetFriendliness()));
		}

		public override string GetEventInfo(GameEvent.DialogContent dialogContent)
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(dialogContent.DescriptionTextKey);
		}

		public bool Contains(HumanoidInstance humanoidInstance)
		{
			if (!crowd.Contains(humanoidInstance))
			{
				return traders.Contains(humanoidInstance);
			}
			return true;
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			Subscribe();
			GameEventLinearPhaseBase nextPhase = ((!string.IsNullOrEmpty(base.Blueprint.EndGameObjective) && !string.IsNullOrEmpty(base.Blueprint.EndGameObjectiveTaskToComplete)) ? PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new TraderVisitPhase(skipRetreat: true), new CompleteObjectiveTaskPhase(base.Blueprint.EndGameObjective, base.Blueprint.EndGameObjectiveTaskToComplete)) : PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new TraderVisitPhase(skipRetreat: true)));
			SpawnInitAllNpcs();
			return new ShowDialogPhaseBranching(0).NextPhaseOnChoice(1, nextPhase);
		}

		private void Subscribe()
		{
			MonoSingleton<TradingManager>.Instance.TradeAppliedEvent += OnTradeApplied;
			MonoSingleton<ChatGraphManager>.Instance.BeforeShowDialogEvent += OnBeforeShowChatDialog;
			MonoSingleton<ChatGraphManager>.Instance.ChatOptionChosenEvent += OnChatOptionChosen;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<TradingManager>.IsInstantiated())
			{
				MonoSingleton<TradingManager>.Instance.TradeAppliedEvent -= OnTradeApplied;
			}
			if (MonoSingleton<ChatGraphManager>.IsInstantiated())
			{
				MonoSingleton<ChatGraphManager>.Instance.BeforeShowDialogEvent -= OnBeforeShowChatDialog;
				MonoSingleton<ChatGraphManager>.Instance.ChatOptionChosenEvent -= OnChatOptionChosen;
			}
		}

		private void SpawnInitAllNpcs()
		{
			SpawnTraders();
			SpawnCrowd();
			InitNpcsAfterSpawn();
			TraderEvent.EventStart?.Invoke();
		}

		private void OnTradeApplied(ITrader playerTrader, ITrader otherTrader, float totalValueTraded, bool wasGiftingOnly)
		{
			if (otherTrader is TraderBehaviour traderBehaviour && traders.Contains(traderBehaviour.Humanoid))
			{
				TraderType traderType = traderBehaviour.TraderType;
				if (0f - MonoSingleton<TradingManager>.Instance.Balance > traderType.SpawnStashMarkerGiftBalanceThresh)
				{
					MapPlaceGenerator.MaybeSpawnLootStash(base.Blueprint.TraderGiftStashMarkerSpawnChance);
				}
			}
		}

		private void SpawnTraders()
		{
			if (traders == null)
			{
				traders = new List<HumanoidInstance>();
			}
			else
			{
				traders.Clear();
			}
			using PooledList<VillagePlace> pooledList = FactionUtil.GetVillagesByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions).ToPooledListJanitor();
			for (int i = 0; i < TradersSpawnCount; i++)
			{
				VillagePlace villagePlace = pooledList.PickRandom();
				FactionInstance faction = GetFaction(villagePlace);
				string id = PossibleTraderNpcTypes.PickRandom();
				HumanoidInstance humanoidInstance = MonoSingleton<NPCManager>.Instance.SpawnTrader("trader_1", faction.GetRandomBodyType(), Vector3.zero, villagePlace, faction, this);
				TraderType byID = Repository<TraderTypeRepository, TraderType>.Instance.GetByID(id);
				TradingManager.InitTrader(humanoidInstance, byID, out var _, this);
				humanoidInstance.TraderBehaviour.DontShowDialogOnTalkTo = true;
				traders.Add(humanoidInstance);
			}
		}

		private void SpawnCrowd()
		{
			if (crowd == null)
			{
				crowd = new List<HumanoidInstance>();
			}
			else
			{
				crowd.Clear();
			}
			using PooledList<VillagePlace> pooledList = FactionUtil.GetVillagesByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions).ToPooledListJanitor();
			for (int i = 0; i < CrowdSpawnCount; i++)
			{
				VillagePlace villagePlace = pooledList.PickRandom();
				FactionInstance faction = GetFaction(villagePlace);
				string text = PossibleCrowdNpcTypes.PickRandom();
				HumanoidInstance item = MonoSingleton<NPCManager>.Instance.SpawnTraderBodyguard(text, faction.GetRandomBodyType(), Vector3.zero, villagePlace, faction, this);
				crowd.Add(item);
			}
		}

		private void InitNpcsAfterSpawn()
		{
			List<CreatureBase> allNpcs = new List<CreatureBase>();
			allNpcs.AddRange(crowd);
			allNpcs.AddRange(traders);
			foreach (HumanoidInstance trader in traders)
			{
				if (trader.Pets == null)
				{
					continue;
				}
				foreach (AnimalInstance pet in trader.Pets)
				{
					if (pet != null && !pet.HasDisposed && !pet.HasDied)
					{
						allNpcs.Add(pet);
					}
				}
			}
			MapNode idlePointForTrader = allNpcs[0].Map.IdlePoints.GetIdlePointForTrader(allNpcs[0]);
			using PooledHashSet<Region> pooledHashSet = HashSetPool<Region>.GetJanitor();
			if (idlePointForTrader?.Region != null)
			{
				pooledHashSet.Add(idlePointForTrader.Region);
			}
			else
			{
				foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
				{
					if (key != null && key.GetNode() != null)
					{
						pooledHashSet.Add(key.GetNode().Region);
					}
				}
			}
			pooledHashSet.Remove(null);
			NPCStartPositionManager.SetStartPositionsForAgentsRandom(traders[0].WalkableModel, allNpcs, pooledHashSet);
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				foreach (CreatureBase item in allNpcs)
				{
					item.GetGoapAgent()?.StartTicker();
				}
			});
		}

		private FactionInstance GetFaction(VillagePlace village)
		{
			if (village?.FactionInstance != null)
			{
				return village.FactionInstance;
			}
			return FactionUtil.GetFactionsByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions).PickRandom();
		}

		private void OnBeforeShowChatDialog(string chatGraphId, string dialogName, DialogContent dialogContent, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			if (!(chatGraphId != "merchant") && traders.Contains(chatTarget))
			{
				dialogContent.Localize();
			}
		}

		private void OnChatOptionChosen(string chatGraphId, string dialogName, int optionIndex, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			if (!(chatGraphId != "merchant") && traders.Contains(chatTarget) && dialogName == "start" && optionIndex == 0)
			{
				MonoSingleton<TradingManager>.Instance.OpenTradingMenu(((HumanoidInstance)chatInitiator).WorkerBehaviour, ((HumanoidInstance)chatTarget).TraderBehaviour);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("traders", traders);
			serializer.Write("crowd", crowd);
		}

		public MultiTraderEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			traders = deserializer.ReadObjectList<HumanoidInstance>("traders");
			crowd = deserializer.ReadObjectList<HumanoidInstance>("crowd");
		}
	}
}
