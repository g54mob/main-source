using System;
using System.Collections.Generic;
using System.Linq;
using Managers;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Dialogs.Data;
using NSMedieval.Manager;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using UnityEngine;
using Utils;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.RunawayEvent", "")]
	public class RunawayEvent : NewWorkerEvent, IRaidPhaseDataHolder, INegotiationPhaseHolder
	{
		private const string VICTORY_DIALOG_ID = "won";

		private const string DEFEAT_DIALOG_ID = "lost";

		private const string TIE_DIALOG_ID = "tie";

		private const string WORKER_GONE_DIALOG_ID = "attackers_leave_worker_dead";

		private const string WORKER_GIVEN_UP_DIALOG_ID = "worker_given_up";

		private const string ENEMY_HOSTILE_AFTER_TRICK_DIALOG_ID = "villager_cant_leave_attack";

		private const string ENEMY_NEUTRAL_AFTER_TRICK_DIALOG_ID = "neutral_decline";

		private const string DIALOG_NEGOTIATOR_ARRIVED_NEWS = "negotiator_arrived_news";

		private const string ENEMY_NEUTRAL_AFTER_REFUSE_DIALOG_ID = "decline_neutral";

		private const string ENEMY_HOSTILE_AFTER_REFUSE_DIALOG_ID = "decline_hostile";

		private const string ENEMY_AFTER_TRADE_SUCCESS = "after_trade_attackers_satisfied";

		private const string EFFECTOR_MOOD_NEGATIVE = "MoodMinusRunawayEvent";

		private const string EFFECTOR_MOOD_POSITIVE = "MoodPlusRunawayEvent";

		private const float FRIENDLINESS_DENY = -120f;

		private const float FRIENDLINESS_ACCEPT = 50f;

		private const float FRIENDLINESS_TRADE_SUCCESS = 25f;

		private const string GLOBAL_MODIFIER_ON_GIVEN_UP = "infamy";

		private const float GLOBAL_MODIFIER_ON_GIVEN_UP_VALUE = 8f;

		private const string COUNTDOWN_TEXT = "warning_message_short_RaidCountdown";

		private const string COUNTDOWN_TOOLTIP = "warning_message_info_RaidCountdown";

		private const string COUNTDOWN_ICON = "Raid";

		private const string COUNTDOWN_TEXT_NEGOTIATION = "warning_message_short_NegotiationCountdown";

		private const string COUNTDOWN_TOOLTIP_NEGOTIATION = "warning_message_info_NegotiationCountdown";

		private const string COUNTDOWN_ICON_NEGOTIATION = "Idle";

		private const string COUNTDOWN_RAID_TEXT = "warning_message_short_AttackCountdown";

		private const string COUNTDOWN_RAID_TOOLTIP = "warning_message_info_AttackCountdown";

		private const string COUNTDOWN_RAID_ICON = "Raid";

		private const string DEMAND_SETTLER_CHAT_GRAPH = "runaway-demand-settler";

		private const string WONT_NEGOTIATE_WITH_RUNAWAY_BBT = "event_runaway_err_runaway_negotiator";

		private VillagePlaceReference raiderOriginVillageRef;

		private ActiveRaidInfo cachedRaidInfo;

		private RaiderBlueprintId[] enemyBlueprintIds;

		private SiegeWeaponComponentBlueprint[] siegeWeaponBlueprints;

		private bool isSiege;

		private float baseValueDemanded;

		private ITrader currentPlayerTrader;

		private ITrader currentNegotiatorTrader;

		private float lastShouldCancelQueryTime;

		public List<MapNode> OverrideRaidSpawnPositions { get; set; }

		public Action<NegotiationEndResult> NegotiationFinishedEvent { get; set; }

		public HumanoidInstance Negotiator { get; set; }

		public RaiderBlueprintId[] EnemyBlueprintIds => enemyBlueprintIds;

		public SiegeWeaponComponentBlueprint[] SiegeWeaponBlueprints => siegeWeaponBlueprints;

		public bool IsSiege => isSiege;

		public WorldMapPlace BattleMapPlace => GlobalSaveController.CurrentVillageData.WorldMapPlace;

		public VillagePlace RaiderOriginVillage => raiderOriginVillageRef?.VillageValue;

		public FactionInstance RaiderFactionInstance => raiderOriginVillageRef?.FactionInstance;

		public ActiveRaidInfo CachedRaidInfo
		{
			get
			{
				return cachedRaidInfo;
			}
			set
			{
				cachedRaidInfo = value;
			}
		}

		public RunawayEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			baseValueDemanded = CalculateValueDemanded();
			InitRaiderVillagePlace();
			InitRaiders();
			Subscribe();
			base.HumanoidToAdd = GenerateWorkerToAdd();
			ShowDialogPhaseBranching showDialogPhaseBranching = new ShowDialogPhaseBranching(0);
			showDialogPhaseBranching.NextPhaseOnReject(PhaseBuilder.LinkPhases(new DisposeWorkerToAddPhase(), new RunEffectorPhase("MoodMinusRunawayEvent")));
			CheckWorkerPresentPhase checkWorkerPresentPhase = new CheckWorkerPresentPhase(workerToAdd.UniqueId);
			showDialogPhaseBranching.NextPhaseOnAccept(PhaseBuilder.LinkPhases(new AddWorkerPhase(), new RunEffectorPhase("MoodPlusRunawayEvent"), new GlobalStatModifyPhase("infamy", -2f), new GlobalStatModifyPhase("misc_global_stat", 20f), SearchPartyDelayCountdownPhase().LinkNextPhase(checkWorkerPresentPhase)));
			ShowDialogPhase nextPhase = new ShowDialogPhase("attackers_leave_worker_dead");
			checkWorkerPresentPhase.NextPhaseOnFalse(nextPhase);
			RaidPhase raidPhase = new RaidPhase();
			raidPhase.NextPhaseOnVictory(new ShowDialogPhase("won"));
			raidPhase.NextPhaseOnDefeat(new ShowDialogPhase("lost"));
			raidPhase.NextPhaseOnTie(new ShowDialogPhase("tie"));
			NegotiationPhaseConfig config = new NegotiationPhaseConfig
			{
				ChatGraphId = "runaway-demand-settler",
				NewsMessage = NegotiatorArrivedNewsData(),
				WontNegotiateWithWorkerId = workerToAdd.UniqueId,
				WontNegotiateWithWorkerBBTTextKey = "event_runaway_err_runaway_negotiator",
				CountdownDurationMinutes = base.Blueprint.GetRandomDurationMinutes(),
				CountdownText = "warning_message_short_NegotiationCountdown",
				CountdownTooltip = "warning_message_info_NegotiationCountdown",
				CountdownIcon = "Idle",
				SpawnCampfire = true
			};
			checkWorkerPresentPhase.NextPhaseOnTrue(new NegotiationPhase(in config).NextPhaseOn(NegotiationEndResult.Cancelled, nextPhase).NextPhaseOn(NegotiationEndResult.FailNegotiatorAttacked, PhaseBuilder.LinkPhases(new AddFriendlinessPhase(RaiderFactionInstance.BlueprintId, -120f).LinkNextPhase(new CheckFactionHostilePhase(RaiderFactionInstance.BlueprintId).NextPhaseOnTrue(new ShowDialogPhase("decline_hostile").LinkNextPhase(raidPhase)).NextPhaseOnFalse(new ShowDialogPhase("decline_neutral"))))).NextPhaseOn(NegotiationEndResult.FailNegotiatorKilled, PhaseBuilder.LinkPhases(new AddFriendlinessPhase(RaiderFactionInstance.BlueprintId, -200f), new ShowDialogPhase("decline_hostile").LinkNextPhase(raidPhase)))
				.NextPhaseOnFailOther(PhaseBuilder.LinkPhases(new AddFriendlinessPhase(RaiderFactionInstance.BlueprintId, -120f).LinkNextPhase(new CheckFactionHostilePhase(RaiderFactionInstance.BlueprintId).NextPhaseOnTrue(new ShowDialogPhase("decline_hostile").LinkNextPhase(RaidDelayCountdownPhase().LinkNextPhase(raidPhase))).NextPhaseOnFalse(new ShowDialogPhase("decline_neutral")))))
				.NextPhaseOn(NegotiationEndResult.Success, new TryBanishWorkerSilentPhase(workerToAdd.UniqueId).NextPhaseOnSuccess(PhaseBuilder.LinkPhases(new ShowDialogPhase("worker_given_up"), new RunEffectorPhase("MoodMinusRunawayEvent"), new GlobalStatModifyPhase("infamy", 8f), new AddFriendlinessPhase(RaiderFactionInstance.BlueprintId, 50f))).NextPhaseOnFail(new AddFriendlinessPhase(RaiderFactionInstance.BlueprintId, -120f).LinkNextPhase(new CheckFactionHostilePhase(RaiderFactionInstance.BlueprintId).NextPhaseOnTrue(new ShowDialogPhase("villager_cant_leave_attack").LinkNextPhase(raidPhase)).NextPhaseOnFalse(new ShowDialogPhase("neutral_decline")))))
				.NextPhaseOn(NegotiationEndResult.SuccessTraded, PhaseBuilder.LinkPhases(new AddFriendlinessPhase(RaiderFactionInstance.BlueprintId, 25f), new ShowDialogPhase("after_trade_attackers_satisfied"))));
			return showDialogPhaseBranching;
			NewsData NegotiatorArrivedNewsData()
			{
				NewsData newsData = GameEventUtil.BuildNewsData(this, "negotiator_arrived_news");
				newsData.Replace("<faction>", RaiderFactionInstance.BlueprintId);
				newsData.Localize();
				newsData.Replace("<faction_name>", RaiderFactionInstance.NameLocalized);
				newsData.Format((string text) => TextFormatting.FormatText(text, base.HumanoidToAdd));
				return newsData;
			}
			DelayCountdownPhase RaidDelayCountdownPhase()
			{
				return new DelayCountdownPhase(GetRandomRaidDelayMinutes(), "warning_message_short_AttackCountdown", "warning_message_info_AttackCountdown", "Raid", RaiderFactionInstance.BlueprintId, (from pair in GetPossibleEnemiesList()
					select TooltipStyles.ApplyStyle($"~{pair.Value} {pair.Key}", TooltipStyles.TooltipDescriptionLine)).ToList());
			}
			DelayCountdownPhase SearchPartyDelayCountdownPhase()
			{
				return new DelayCountdownPhase(GetRandomSearchPartyDelayMinutes(), "warning_message_short_RaidCountdown", "warning_message_info_RaidCountdown", "Raid", RaiderFactionInstance.BlueprintId, (from pair in GetPossibleEnemiesList()
					select TooltipStyles.ApplyStyle($"~{pair.Value} {pair.Key}", TooltipStyles.TooltipDescriptionLine)).ToList());
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
		}

		public override void OnEnd()
		{
			base.OnEnd();
			Unsubscribe();
		}

		private void Subscribe()
		{
			MonoSingleton<TradingManager>.Instance.TradeAppliedEvent += OnTradeApplied;
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<TradingManager>.IsInstantiated())
			{
				MonoSingleton<TradingManager>.Instance.TradeAppliedEvent -= OnTradeApplied;
			}
		}

		private void InitRaiders()
		{
			if (!GameEventUtil.TryPurchaseEnemies(RaiderFactionInstance.BlueprintId, (int)MonoSingleton<BaseWealth>.Instance.GetRaidPoints(), out var enemies, out var siegeWeapons, out var flag))
			{
				throw new Exception("Failed to purchase enemies.");
			}
			enemyBlueprintIds = enemies.Select((IEnemyPurchaseUnit unit) => new RaiderBlueprintId(unit)).ToArray();
			siegeWeaponBlueprints = siegeWeapons.ToArray();
			isSiege = flag;
		}

		public override void OnLoaded(bool fromSave)
		{
			base.OnLoaded(fromSave);
			Subscribe();
			if (fromSave && base.Blueprint != null)
			{
				GameEvent byID = Repository<GameEventSettingsRepository, GameEvent>.Instance.GetByID(base.Blueprint.GetID());
				if (byID == null)
				{
					byID = Repository<GameEventSettingsRepository, GameEvent>.Instance.GetByID("game_event_runaway_new");
				}
				if (byID != null)
				{
					SetBlueprint(byID);
				}
				else
				{
					InitRaiderVillagePlace();
				}
			}
		}

		private float CalculateValueDemanded()
		{
			int x = (int)MonoSingleton<BaseWealth>.Instance.GetTotalWealth();
			return base.Blueprint.GetInterpolatedValue("valueDemandedBasedOnWealth", x);
		}

		public void FormatChatDialogContent(string dialogName, DialogContent dialogContent, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			dialogContent.Replace("<faction>", RaiderFactionInstance.BlueprintId);
			foreach (TooltipData item in dialogContent.Options.SelectMany((DialogOption option) => option.Tooltips))
			{
				if (item.Key == GameEventOptionEffect.PossibleRaid.ToString() || item.Key == GameEventOptionEffect.RaidImminent.ToString())
				{
					item.Args = (from pair in GetPossibleEnemiesList()
						select $"~{pair.Value} {pair.Key}").ToList();
				}
			}
			if (dialogName == "start")
			{
				bool runawayEventWillTrade = RaiderFactionInstance.Blueprint.RunawayEventWillTrade;
				dialogContent.Options[1].Disabled = !runawayEventWillTrade;
				dialogContent.Options[1].DisabledTooltip = "runaway_faction_wont_trade_tooltip";
			}
			dialogContent.Localize();
			dialogContent.Replace("<faction_name>", RaiderFactionInstance.NameLocalized);
			dialogContent.Format((string text) => TextFormatting.FormatText(text, base.HumanoidToAdd));
		}

		public void OnNegotiationChatOptionChosen(string dialogName, int optionIndex, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			if (dialogName != "start" || !(chatInitiator is HumanoidInstance humanoidInstance) || !(chatTarget is HumanoidInstance { ActiveBehaviour: NegotiatorBehaviour activeBehaviour }))
			{
				return;
			}
			currentPlayerTrader = null;
			currentNegotiatorTrader = null;
			switch (optionIndex)
			{
			case 0:
				NegotiationFinishedEvent?.Invoke(NegotiationEndResult.Success);
				break;
			case 1:
			{
				float num = 1f;
				AttributeInstance attribute = chatInitiator.GetAttribute(AttributeType.NegotiationMultiplier);
				if (attribute != null)
				{
					num = attribute.Value;
				}
				float valueDemanded = baseValueDemanded * num;
				MonoSingleton<TradingManager>.Instance.OpenExtortionMenu(humanoidInstance.WorkerBehaviour, activeBehaviour, valueDemanded);
				currentPlayerTrader = humanoidInstance.WorkerBehaviour;
				currentNegotiatorTrader = activeBehaviour;
				break;
			}
			case 2:
				NegotiationFinishedEvent?.Invoke(NegotiationEndResult.FailPlayerRejected);
				break;
			case 3:
				break;
			}
		}

		public bool TickShouldCancelNegotiations()
		{
			if (Time.unscaledTime - lastShouldCancelQueryTime < 0.5f)
			{
				return false;
			}
			lastShouldCancelQueryTime = Time.unscaledTime;
			return !MonoSingleton<WorkerManager>.Instance.AnyWorker((HumanoidInstance workerInstance) => workerInstance.UniqueId == workerToAdd.UniqueId);
		}

		public void OnNegotiatorLeaveMap()
		{
		}

		private void OnTradeApplied(ITrader playerTrader, ITrader otherTrader, float totalValueTraded, bool wasGiftingOnly)
		{
			if (playerTrader == currentPlayerTrader && otherTrader == currentNegotiatorTrader)
			{
				NegotiationFinishedEvent?.Invoke(NegotiationEndResult.SuccessTraded);
				currentPlayerTrader = null;
				currentNegotiatorTrader = null;
			}
		}

		public override void SetBlueprint(GameEvent blueprintEvent)
		{
			base.SetBlueprint(blueprintEvent);
			InitRaiderVillagePlace();
		}

		private void InitRaiderVillagePlace()
		{
			if (raiderOriginVillageRef == null)
			{
				raiderOriginVillageRef = FactionUtil.FindVillagePlace(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions);
			}
		}

		public bool IsWorkerPresent()
		{
			HumanoidInstance humanoidToAdd = base.HumanoidToAdd;
			if (humanoidToAdd != null && !humanoidToAdd.HasDied && !humanoidToAdd.HasDisposed)
			{
				return !humanoidToAdd.IsInIncognitoMode();
			}
			return false;
		}

		private static uint GetRandomSearchPartyDelayMinutes()
		{
			return (uint)(new FloatRange(0.75f, 2f).Random() * (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInDay);
		}

		private static uint GetRandomRaidDelayMinutes()
		{
			return (uint)(new FloatRange(0.1f, 0.15f).Random() * (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInDay);
		}

		public override string GetEventInfo(GameEvent.DialogContent dialogContent)
		{
			string key = dialogContent.DescriptionTextKey.Replace("<faction>", RaiderFactionInstance.BlueprintId);
			string text = MonoSingleton<LocalizationController>.Instance.GetText(key).Replace("<faction_name>", RaiderFactionInstance.NameLocalized);
			text = TextFormatting.FormatText(text, base.HumanoidToAdd);
			if (CachedRaidInfo == null)
			{
				return text;
			}
			return TextFormatting.FormatRaidText(text, CachedRaidInfo);
		}

		public override string GetEventTitle(GameEvent.DialogContent dialogContent)
		{
			string key = dialogContent.TypeTextKey.Replace("<faction>", RaiderFactionInstance.BlueprintId);
			return TextFormatting.FormatText(MonoSingleton<LocalizationController>.Instance.GetText(key).Replace("<faction_name>", RaiderFactionInstance.NameLocalized));
		}

		public override string GetEventName(GameEvent.DialogContent dialogContent, BodyType bodyType)
		{
			string key = dialogContent.NameTextKey.Replace("<faction>", RaiderFactionInstance.BlueprintId);
			return TextFormatting.FormatText(MonoSingleton<LocalizationController>.Instance.GetText(key, bodyType).Replace("<faction_name>", RaiderFactionInstance.NameLocalized));
		}

		public override string GetEventImagePath(GameEvent.DialogContent dialogContent)
		{
			if (!string.IsNullOrEmpty(dialogContent.ImagePath))
			{
				string imagePath = dialogContent.ImagePath;
				if (imagePath.Contains("<faction>"))
				{
					string text = imagePath.Replace("<faction>", RaiderFactionInstance.BlueprintId);
					if (AssetUtils.GetSprite(text) != null)
					{
						return text;
					}
					string text2 = imagePath.Replace("<faction>", "general");
					if (AssetUtils.GetSprite(text2) != null)
					{
						return text2;
					}
				}
				return base.GetEventImagePath(dialogContent);
			}
			string result = "event_runaway_general";
			string text3 = "event_runaway_" + RaiderFactionInstance.BlueprintId;
			if (AssetUtils.GetSprite(text3) != null)
			{
				return text3;
			}
			return result;
		}

		public override SortedDictionary<string, int> GetPossibleEnemiesList()
		{
			SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();
			foreach (IEnemyPurchaseUnit item in EnemyBlueprintIds.Select((RaiderBlueprintId raiderId) => raiderId.FindBlueprint()))
			{
				if (item != null)
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText(item.GetID(), BodyType.None);
					if (!sortedDictionary.TryAdd(text, 1))
					{
						sortedDictionary[text]++;
					}
				}
			}
			SiegeWeaponComponentBlueprint[] array = siegeWeaponBlueprints;
			foreach (SiegeWeaponComponentBlueprint siegeWeaponComponentBlueprint in array)
			{
				if (!(siegeWeaponComponentBlueprint == null))
				{
					string text2 = MonoSingleton<LocalizationController>.Instance.GetText(siegeWeaponComponentBlueprint.GetID());
					if (!sortedDictionary.TryAdd(text2, 1))
					{
						sortedDictionary[text2]++;
					}
				}
			}
			return sortedDictionary;
		}

		public override string ProcessLocalizedButtonText(string buttonText)
		{
			return TextFormatting.FormatText(buttonText, base.HumanoidToAdd);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("cachedRaidInfo", cachedRaidInfo);
			serializer.Write("raiderVillagePlace", raiderOriginVillageRef);
			serializer.Write("enemyBlueprintIds", enemyBlueprintIds);
			serializer.Write("isSiege", isSiege);
			serializer.Write("baseValueDemanded", baseValueDemanded);
			serializer.WriteBlueprintIds("siegeWeaponBlueprints", siegeWeaponBlueprints);
		}

		public RunawayEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			cachedRaidInfo = deserializer.ReadObject<ActiveRaidInfo>("cachedRaidInfo");
			raiderOriginVillageRef = deserializer.ReadObject<VillagePlaceReference>("raiderVillagePlace");
			enemyBlueprintIds = deserializer.ReadObjectArray<RaiderBlueprintId>("enemyBlueprintIds");
			isSiege = deserializer.ReadBool("isSiege");
			baseValueDemanded = deserializer.ReadFloat("baseValueDemanded");
			siegeWeaponBlueprints = deserializer.ReadIdsToBlueprints("siegeWeaponBlueprints", Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetByID, new List<SiegeWeaponComponentBlueprint>()).ToArray();
			enemyBlueprintIds = enemyBlueprintIds.Where((RaiderBlueprintId raider) => raider.Type != RaiderBlueprintId.RaiderType.Trebuchet).ToArray();
		}
	}
}
