using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
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
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;
using Utils;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.TraderEvent", "")]
	public class TraderEvent : GameEventInstance, ITraderPhaseDataHolder, IVisitorEvent
	{
		public static Action EventStart;

		[SerializeField]
		private HumanoidInstance trader;

		[SerializeField]
		private List<HumanoidInstance> guards;

		private const string fvs_trader = "trader";

		private const string fvs_guards = "guards";

		public HumanoidInstance Trader => trader;

		public List<HumanoidInstance> Guards => guards;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			EventStart = null;
		}

		public TraderEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			Subscribe();
			SpawnTraderAndGuards();
			EventStart?.Invoke();
			return PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new TraderVisitPhase());
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
			EventStart = null;
			trader = null;
			guards = null;
		}

		public override void OnEnd()
		{
			base.OnEnd();
			Unsubscribe();
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
			if (Repository<TraderTypeRepository, TraderType>.Instance.GetByID(base.Blueprint.Category) == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\TraderEvent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trader type ");
					messageBuilder.AppendFormatted(base.Blueprint.Category);
					messageBuilder.AppendLiteral(" not found. Trader event will not start.");
				}
				GameEventInstance.Logger.Error(in messageBuilder);
				return false;
			}
			return GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.Any((VillagePlace village) => base.Blueprint.Friendliness.Contains(village.FactionInstance.GetFriendliness()));
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

		private void OnTradeApplied(ITrader playerTrader, ITrader otherTrader, float totalValueTraded, bool wasGiftingOnly)
		{
			if (otherTrader is TraderBehaviour traderBehaviour && trader == traderBehaviour.Humanoid)
			{
				TraderType traderType = traderBehaviour.TraderType;
				if (0f - MonoSingleton<TradingManager>.Instance.Balance > traderType.SpawnStashMarkerGiftBalanceThresh)
				{
					MapPlaceGenerator.MaybeSpawnLootStash(base.Blueprint.TraderGiftStashMarkerSpawnChance);
				}
			}
		}

		private void SpawnTraderAndGuards()
		{
			VillagePlace villagePlace = FactionUtil.GetVillagesByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions).PickRandom();
			FactionInstance factionInstance = villagePlace?.FactionInstance;
			if (factionInstance == null)
			{
				factionInstance = FactionUtil.GetFactionsByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions).PickRandom();
			}
			if (base.Blueprint.ResetFactionFriendliness)
			{
				factionInstance.SetPlayerFriendliness(factionInstance.FriendlinessRange.Random(), showNotification: false, processRelatedFactions: false);
			}
			TraderType byID = Repository<TraderTypeRepository, TraderType>.Instance.GetByID(base.Blueprint.Category);
			FVLogInfoInterpolationHandler messageBuilder;
			bool isEnabled;
			if (byID == null)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(69, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\TraderEvent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trader type ");
					messageBuilder.AppendFormatted(base.Blueprint.Category);
					messageBuilder.AppendLiteral(" not found. Failed to spawn trader, event will not start.");
				}
				GameEventInstance.Logger.Info(in messageBuilder);
				return;
			}
			int pointsToSpend = byID.BodyguardStrength;
			if (!MonoSingleton<RaidEnemySelector>.Instance.PurchaseBodyGuards(in pointsToSpend, out var enemiesToSpawn, factionInstance.BlueprintId))
			{
				messageBuilder = new FVLogInfoInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\TraderEvent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No '");
					messageBuilder.AppendFormatted(factionInstance.BlueprintId);
					messageBuilder.AppendLiteral("' bodyguards added.");
				}
				GameEventInstance.Logger.Info(in messageBuilder);
				if (pointsToSpend > 0 && !MonoSingleton<RaidEnemySelector>.Instance.PurchaseBodyGuards(in pointsToSpend, out enemiesToSpawn, "general"))
				{
					GameEventInstance.Logger.Info("No 'general' bodyguards added.");
				}
			}
			foreach (IEnemyPurchaseUnit item in enemiesToSpawn)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\TraderEvent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Will spawn guard:'");
					messageBuilder.AppendFormatted(item.GetID());
					messageBuilder.AppendLiteral("'.");
				}
				GameEventInstance.Logger.Info(in messageBuilder);
			}
			guards = new List<HumanoidInstance>();
			foreach (IEnemyPurchaseUnit item2 in enemiesToSpawn)
			{
				HumanoidInstance bodyguard = MonoSingleton<NPCManager>.Instance.SpawnTraderBodyguard(item2.GetID(), factionInstance.GetRandomBodyType(), Vector3.zero, villagePlace, factionInstance, this);
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					bodyguard.GetGoapAgent()?.StartTicker();
				});
				guards.Add(bodyguard);
			}
			trader = MonoSingleton<NPCManager>.Instance.SpawnTrader("trader_1", factionInstance.GetRandomBodyType(), Vector3.zero, villagePlace, factionInstance, this);
			TradingManager.InitTrader(trader, byID, out var creatures, this);
			List<CreatureBase> list = new List<CreatureBase> { trader };
			list.AddRange(guards);
			list.AddRange(creatures);
			NPCStartPositionManager.SetStartPositionsForAgents(trader.WalkableModel, list);
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				trader.GetGoapAgent()?.StartTicker();
				foreach (CreatureBase item3 in creatures)
				{
					item3.GetGoapAgent()?.StartTicker();
				}
			});
		}

		private void OnBeforeShowChatDialog(string chatGraphId, string dialogName, DialogContent dialogContent, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			if (!(chatGraphId != "merchant") && chatTarget == Trader)
			{
				dialogContent.Localize();
				WorldMapPlace worldMapPlace = Trader.TraderBehaviour.BanditCampToldSettlerAbout?.Value;
				if (worldMapPlace != null)
				{
					string name = FactionUtil.GetClosestVillage(worldMapPlace.Position, includePermanentlyHostile: true).Name;
					dialogContent.Replace("<village_name>", name);
				}
				if (!(dialogName != "start") && (!Trader.TraderBehaviour.KnowsRumoursBanditCamp || !MapPlaceGenerator.CanSpawnMarker(SecondMapType.Attack)))
				{
					dialogContent.Options.RemoveAt(2);
				}
			}
		}

		private void OnChatOptionChosen(string chatGraphId, string dialogName, int optionIndex, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			if (!(chatGraphId != "merchant") && chatTarget == Trader && dialogName == "start")
			{
				if (optionIndex == 0)
				{
					MonoSingleton<TradingManager>.Instance.OpenTradingMenu(((HumanoidInstance)chatInitiator).WorkerBehaviour, Trader.TraderBehaviour);
				}
				if (optionIndex == 2)
				{
					Trader.TraderBehaviour.KnowsRumoursBanditCamp = false;
					WorldMapMarkerPlace worldMapMarkerPlace = MapPlaceGenerator.MaybeSpawnBanditCamp(1f);
					Trader.TraderBehaviour.BanditCampToldSettlerAbout = worldMapMarkerPlace?.CreateReference();
				}
			}
		}

		public override string GetEventInfo(GameEvent.DialogContent dialogContent)
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(dialogContent.DescriptionTextKey, Trader.Info);
		}

		public bool Contains(HumanoidInstance humanoidInstance)
		{
			if (Trader == humanoidInstance)
			{
				return true;
			}
			return Guards.Contains(humanoidInstance);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("trader", trader);
			serializer.Write("guards", guards);
		}

		public TraderEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			trader = deserializer.ReadObject<HumanoidInstance>("trader");
			guards = deserializer.ReadObjectList<HumanoidInstance>("guards");
		}
	}
}
