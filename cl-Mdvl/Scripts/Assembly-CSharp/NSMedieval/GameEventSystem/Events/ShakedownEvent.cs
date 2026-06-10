using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Dialogs.Data;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using Utils;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.ShakedownEvent", "")]
	public class ShakedownEvent : GameEventInstance, IRaidPhaseDataHolder, INegotiationPhaseHolder
	{
		private const float FRIENDLINESS_FAIL = -100f;

		private const float FRIENDLINESS_SUCCESS = 10f;

		private const string DIALOG_RAID_AVOIDED = "raid_avoided";

		private const string DIALOG_RAID_VICTORY = "raid_victory";

		private const string DIALOG_RAID_DEFEAT = "raid_defeat";

		private const string TIE_DIALOG_ID = "tie";

		private const string DIALOG_RAID_INCOMING = "raid_incoming";

		private const string DIALOG_DECLINE_NEUTRAL = "decline_neutral";

		private const string DIALOG_NEGOTIATOR_ARRIVED_NEWS = "start";

		private const string COUNTDOWN_TEXT = "warning_message_short_AttackCountdown";

		private const string COUNTDOWN_TOOLTIP = "warning_message_info_AttackCountdown";

		private const string COUNTDOWN_ICON = "Raid";

		private const string COUNTDOWN_TEXT_NEGOTIATION = "warning_message_short_NegotiationCountdown";

		private const string COUNTDOWN_TOOLTIP_NEGOTIATION = "warning_message_info_NegotiationCountdown";

		private const string COUNTDOWN_ICON_NEGOTIATION = "Idle";

		private const string SHAKEDOWN_CHAT_GRAPH = "shakedown-negotiate";

		private const string EFFECTOR_BLOODLUST_NEGATIVE = "MoodMinusShakedownBloodlust";

		private VillagePlaceReference raiderOriginVillageRef;

		private FactionInstance raiderFactionInstance;

		private string raiderFactionId;

		private ActiveRaidInfo cachedRaidInfo;

		private RaiderBlueprintId[] enemyBlueprintIds;

		private SiegeWeaponComponentBlueprint[] siegeWeaponBlueprints;

		private bool isSiege;

		private float baseValueDemanded;

		private ITrader currentPlayerTrader;

		private ITrader currentNegotiatorTrader;

		public Action<NegotiationEndResult> NegotiationFinishedEvent { get; set; }

		public HumanoidInstance Negotiator { get; set; }

		public List<MapNode> OverrideRaidSpawnPositions { get; set; }

		public VillagePlace RaiderOriginVillage => raiderOriginVillageRef?.VillageValue;

		public WorldMapPlace BattleMapPlace => GlobalSaveController.CurrentVillageData.WorldMapPlace;

		public FactionInstance RaiderFactionInstance => raiderFactionInstance;

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

		public RaiderBlueprintId[] EnemyBlueprintIds => enemyBlueprintIds;

		public SiegeWeaponComponentBlueprint[] SiegeWeaponBlueprints => siegeWeaponBlueprints;

		public bool IsSiege => isSiege;

		public ShakedownEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			baseValueDemanded = CalculateValueDemanded();
			InitMapPlaces();
			InitRaiders();
			Subscribe();
			string factionBlueprintId = RaiderFactionInstance.BlueprintId;
			RaidPhase nextPhase = new RaidPhase().NextPhaseOnVictory(new ShowDialogPhase("raid_victory")).NextPhaseOnDefeat(new ShowDialogPhase("raid_defeat")).NextPhaseOnTie(new ShowDialogPhase("tie"));
			GameEventLinearPhaseBase nextPhase2 = new ShowDialogPhase("raid_incoming").LinkNextPhase(NewDelayCountdownPhase().LinkNextPhase(nextPhase));
			NegotiationPhaseConfig config = new NegotiationPhaseConfig
			{
				ChatGraphId = "shakedown-negotiate",
				NewsMessage = GameEventUtil.BuildNewsData(this, "start"),
				CountdownDurationMinutes = base.Blueprint.GetRandomDurationMinutes(),
				CountdownText = "warning_message_short_NegotiationCountdown",
				CountdownTooltip = "warning_message_info_NegotiationCountdown",
				CountdownIcon = "Idle",
				UseExistingNegotiatorNPC = Negotiator,
				SpawnCampfire = true
			};
			NegotiationPhase negotiationPhase = new NegotiationPhase(in config);
			negotiationPhase.NextPhaseOn(NegotiationEndResult.SuccessTraded, PhaseBuilder.LinkPhases(new AddFriendlinessPhase(factionBlueprintId, 10f), new RunEffectorPhase("MoodMinusShakedownBloodlust"), new ShowDialogPhase("raid_avoided")));
			negotiationPhase.NextPhaseOn(NegotiationEndResult.FailNegotiatorAttacked, PhaseBuilder.LinkPhases(new AddFriendlinessPhase(factionBlueprintId, -100f).LinkNextPhase(new CheckFactionHostilePhase(factionBlueprintId).NextPhaseOnFalse(new ShowDialogPhase("decline_neutral")).NextPhaseOnTrue(nextPhase))));
			negotiationPhase.NextPhaseOn(NegotiationEndResult.FailNegotiatorKilled, PhaseBuilder.LinkPhases(new AddFriendlinessPhase(factionBlueprintId, -200f), new ShowDialogPhase("raid_incoming").LinkNextPhase(nextPhase)));
			negotiationPhase.NextPhaseOnFailOther(new AddFriendlinessPhase(factionBlueprintId, -100f).LinkNextPhase(new CheckFactionHostilePhase(factionBlueprintId).NextPhaseOnFalse(new ShowDialogPhase("decline_neutral")).NextPhaseOnTrue(nextPhase2)));
			return negotiationPhase;
			DelayCountdownPhase NewDelayCountdownPhase()
			{
				return new DelayCountdownPhase(GetRandomRaidDelayMinutes(), "warning_message_short_AttackCountdown", "warning_message_info_AttackCountdown", "Raid", RaiderFactionInstance.BlueprintId);
			}
		}

		public override void OnLoaded(bool fromSave)
		{
			base.OnLoaded(fromSave);
			Subscribe();
			InitMapPlaces();
		}

		public override void OnEnd()
		{
			base.OnEnd();
			Unsubscribe();
		}

		public override void Dispose()
		{
			base.Dispose();
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
			case 1:
				NegotiationFinishedEvent?.Invoke(NegotiationEndResult.FailPlayerRejected);
				break;
			case 2:
				break;
			}
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

		private float CalculateValueDemanded()
		{
			int x = (int)MonoSingleton<BaseWealth>.Instance.GetTotalWealth();
			return base.Blueprint.GetInterpolatedValue("valueDemandedBasedOnWealth", x);
		}

		private static uint GetRandomRaidDelayMinutes()
		{
			return (uint)(new FloatRange(0.1f, 0.2f).Random() * (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInDay);
		}

		private void InitMapPlaces()
		{
			if (string.IsNullOrEmpty(raiderFactionId) && raiderOriginVillageRef?.FactionId != null)
			{
				raiderFactionId = raiderOriginVillageRef.FactionId;
			}
			if (raiderFactionId == null)
			{
				FactionInstance factionInstance = FactionUtil.GetFactionsByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions, mustHaveVillages: true).PickRandom();
				raiderFactionId = factionInstance.BlueprintId;
				raiderOriginVillageRef = FactionUtil.GetRandomVillagePlace(factionInstance);
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Shakedown\\ShakedownEvent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Set village: ");
					messageBuilder.AppendFormatted(raiderOriginVillageRef?.Value?.Name);
					messageBuilder.AppendLiteral(", Faction: ");
					messageBuilder.AppendFormatted(raiderFactionId);
				}
				GameEventInstance.Logger.Info(in messageBuilder);
			}
			raiderFactionInstance = FactionUtil.FindById(raiderFactionId);
		}

		private void InitRaiders()
		{
			if (enemyBlueprintIds == null)
			{
				if (!GameEventUtil.TryPurchaseEnemies(RaiderFactionInstance.BlueprintId, (int)MonoSingleton<BaseWealth>.Instance.GetRaidPoints(), out var enemies, out var siegeWeapons, out var flag))
				{
					throw new Exception("Failed to purchase enemies.");
				}
				enemyBlueprintIds = enemies.Select((IEnemyPurchaseUnit unit) => new RaiderBlueprintId(unit)).ToArray();
				siegeWeaponBlueprints = siegeWeapons.ToArray();
				isSiege = flag;
				Negotiator = NegotiationPhase.GenerateNegotiatorInstance(EnemyBlueprintIds, RaiderOriginVillage, RaiderFactionInstance);
			}
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
			dialogContent.Localize();
			dialogContent.Replace("<faction_name>", RaiderFactionInstance.NameLocalized);
			dialogContent.Format((string text) => TextFormatting.FormatText(text, chatInitiator.GetCharacterInfo()));
		}

		public override SortedDictionary<string, int> GetPossibleEnemiesList()
		{
			SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();
			RaiderBlueprintId[] array = EnemyBlueprintIds;
			for (int i = 0; i < array.Length; i++)
			{
				IEnemyPurchaseUnit enemyPurchaseUnit = array[i].FindBlueprint();
				if (enemyPurchaseUnit != null)
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText(enemyPurchaseUnit.GetID(), BodyType.None);
					if (!sortedDictionary.TryAdd(text, 1))
					{
						sortedDictionary[text]++;
					}
				}
			}
			SiegeWeaponComponentBlueprint[] array2 = siegeWeaponBlueprints;
			foreach (SiegeWeaponComponentBlueprint siegeWeaponComponentBlueprint in array2)
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

		public override string GetEventInfo(GameEvent.DialogContent dialogContent)
		{
			string key = dialogContent.DescriptionTextKey.Replace("<faction>", RaiderFactionInstance.BlueprintId);
			string text = MonoSingleton<LocalizationController>.Instance.GetText(key).Replace("<faction_name>", RaiderFactionInstance.NameLocalized);
			text = TextFormatting.FormatText(text);
			text = TextFormatting.FormatText(text, Negotiator.GetCharacterInfo());
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
			string result = "event_shakedown_general";
			string text3 = "event_shakedown_" + RaiderFactionInstance.BlueprintId;
			if (AssetUtils.GetSprite(text3) != null)
			{
				return text3;
			}
			return result;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("raiderVillagePlace", raiderOriginVillageRef);
			serializer.Write("cachedRaidInfo", cachedRaidInfo);
			serializer.Write("enemyBlueprintIds", enemyBlueprintIds);
			serializer.Write("isSiege", isSiege);
			serializer.Write("baseValueDemanded", baseValueDemanded);
			serializer.Write("negotiator", Negotiator);
			serializer.Write("raiderFactionId", raiderFactionId);
			serializer.WriteBlueprintIds("siegeWeaponBlueprints", siegeWeaponBlueprints);
		}

		public ShakedownEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			raiderOriginVillageRef = deserializer.ReadObject<VillagePlaceReference>("raiderVillagePlace");
			cachedRaidInfo = deserializer.ReadObject<ActiveRaidInfo>("cachedRaidInfo");
			enemyBlueprintIds = deserializer.ReadObjectArray<RaiderBlueprintId>("enemyBlueprintIds");
			isSiege = deserializer.ReadBool("isSiege");
			baseValueDemanded = deserializer.ReadFloat("baseValueDemanded");
			Negotiator = deserializer.ReadObject<HumanoidInstance>("negotiator");
			raiderFactionId = deserializer.ReadString("raiderFactionId");
			siegeWeaponBlueprints = deserializer.ReadIdsToBlueprints("siegeWeaponBlueprints", Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetByID, new List<SiegeWeaponComponentBlueprint>()).ToArray();
			enemyBlueprintIds = enemyBlueprintIds.Where((RaiderBlueprintId raider) => raider.Type != RaiderBlueprintId.RaiderType.Trebuchet).ToArray();
		}
	}
}
