using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using Utils;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.MultiRaidEvent", "")]
	public class MultiRaidEvent : GameEventInstance, IRaidPhaseDataHolder
	{
		private const string CountdownText = "warning_message_short_FinalRaidCountdown";

		private const string CountdownTooltip = "warning_message_info_FinalRaidCountdown";

		private const string CountdownIcon = "Raid";

		private const float MaxRaidPhases = 3f;

		private readonly float[] countdownRaidHours = new float[3] { 48f, 4f, 4f };

		private const int RaidPoints = 6000;

		private string raiderFactionId;

		private VillagePlaceReference raiderOriginVillageRef;

		private FactionInstance raiderFactionInstance;

		private RaiderBlueprintId[] enemyBlueprintIds;

		private SiegeWeaponComponentBlueprint[] siegeWeaponBlueprints;

		public WorldMapPlace BattleMapPlace => GlobalSaveController.CurrentVillageData.WorldMapPlace;

		public VillagePlace RaiderOriginVillage => raiderOriginVillageRef?.VillageValue;

		public FactionInstance RaiderFactionInstance => raiderFactionInstance;

		public ActiveRaidInfo CachedRaidInfo { get; set; }

		public RaiderBlueprintId[] EnemyBlueprintIds => enemyBlueprintIds;

		public SiegeWeaponComponentBlueprint[] SiegeWeaponBlueprints => siegeWeaponBlueprints;

		public bool IsSiege => true;

		public List<MapNode> OverrideRaidSpawnPositions { get; set; }

		public MultiRaidEvent()
		{
		}

		public override void OnLoaded(bool fromSave)
		{
			base.OnLoaded(fromSave);
			InitMapPlaces();
		}

		public override void SetBlueprint(GameEvent blueprintEvent)
		{
			base.SetBlueprint(blueprintEvent);
			InitMapPlaces();
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			InitMapPlaces();
			InitRaiders();
			return GetRaidPhase(0);
		}

		private GameEventPhaseBase GetRaidPhase(int index)
		{
			RaidPhase raidPhase = new RaidPhase(15, skipManyUnitsDeadCondition: false, skipNoDamageTimeoutCondition: true);
			DelayCountdownPhase delayCountdownPhase = new DelayCountdownPhase((uint)((float)(int)Repository<DateTimeSettingsData, DateTimeSettings>.Instance.GetData<DateTimeSettings>().MinutesInHour * countdownRaidHours[index]), "warning_message_short_FinalRaidCountdown", "warning_message_info_FinalRaidCountdown", "Raid", raiderFactionId);
			if ((float)index < 2f)
			{
				raidPhase.NextPhaseOnVictory(GetRaidPhase(index + 1));
			}
			return delayCountdownPhase.LinkNextPhase(raidPhase);
		}

		private void InitMapPlaces()
		{
			if (string.IsNullOrEmpty(raiderFactionId))
			{
				FactionInstance factionInstance = FactionUtil.GetFactionsByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions, mustHaveVillages: true).PickRandom();
				raiderFactionId = factionInstance.BlueprintId;
				raiderOriginVillageRef = FactionUtil.GetRandomVillagePlace(factionInstance);
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Raid\\MultiRaidEvent.cs");
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
			if (!GameEventUtil.TryPurchaseEnemiesForceSiege(RaiderFactionInstance.BlueprintId, 6000, out var enemies, out var siegeWeapons))
			{
				throw new Exception("Failed to purchase enemies.");
			}
			enemyBlueprintIds = enemies.Select((IEnemyPurchaseUnit unit) => new RaiderBlueprintId(unit)).ToArray();
			siegeWeaponBlueprints = siegeWeapons.ToArray();
		}

		public override string GetEventInfo(GameEvent.DialogContent dialogContent)
		{
			string key = dialogContent.DescriptionTextKey.Replace("<faction>", RaiderFactionInstance.BlueprintId);
			string text = MonoSingleton<LocalizationController>.Instance.GetText(key).Replace("<faction_name>", RaiderFactionInstance.NameLocalized);
			text = TextFormatting.FormatText(text);
			ActiveRaidInfo cachedRaidInfo = CachedRaidInfo;
			if (cachedRaidInfo == null)
			{
				return text;
			}
			return TextFormatting.FormatRaidText(text, cachedRaidInfo);
		}

		public override string GetEventTitle(GameEvent.DialogContent dialogContent)
		{
			string key = dialogContent.TypeTextKey.Replace("<faction>", RaiderFactionInstance?.BlueprintId);
			return TextFormatting.FormatText(MonoSingleton<LocalizationController>.Instance.GetText(key).Replace("<faction_name>", RaiderFactionInstance?.NameLocalized));
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
			string result = "event_raid_general";
			string text3 = "event_raid_" + RaiderFactionInstance.BlueprintId;
			if (AssetUtils.GetSprite(text3) != null)
			{
				return text3;
			}
			return result;
		}

		public override SortedDictionary<string, int> GetPossibleEnemiesList()
		{
			return new SortedDictionary<string, int>();
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("cachedRaidInfo", CachedRaidInfo);
			serializer.Write("raiderVillagePlace", raiderOriginVillageRef);
			serializer.Write("enemyBlueprintIds", enemyBlueprintIds);
			serializer.Write("raiderFactionId", raiderFactionId);
			serializer.WriteBlueprintIds("siegeWeaponBlueprints", siegeWeaponBlueprints);
		}

		public MultiRaidEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			CachedRaidInfo = deserializer.ReadObject<ActiveRaidInfo>("cachedRaidInfo");
			raiderOriginVillageRef = deserializer.ReadObject<VillagePlaceReference>("raiderVillagePlace");
			raiderFactionId = deserializer.ReadString("raiderFactionId");
			enemyBlueprintIds = deserializer.ReadObjectArray<RaiderBlueprintId>("enemyBlueprintIds");
			siegeWeaponBlueprints = deserializer.ReadIdsToBlueprints("siegeWeaponBlueprints", Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetByID, new List<SiegeWeaponComponentBlueprint>()).ToArray();
		}
	}
}
