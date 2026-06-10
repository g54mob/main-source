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
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using Utils;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.RaidEvent", "")]
	public class RaidEvent : GameEventInstance, IRaidPhaseDataHolder
	{
		private const string VICTORY_DIALOG_ID = "won";

		private const string DEFEAT_DIALOG_ID = "lost";

		private const string TIE_DIALOG_ID = "tie";

		private ActiveRaidInfo cachedRaidInfo;

		private VillagePlaceReference raiderOriginVillageRef;

		private FactionInstance raiderFactionInstance;

		private string raiderFactionId;

		private RaiderBlueprintId[] enemyBlueprintIds;

		private SiegeWeaponComponentBlueprint[] siegeWeaponBlueprints;

		private bool isSiege;

		public List<MapNode> OverrideRaidSpawnPositions { get; set; }

		public RaiderBlueprintId[] EnemyBlueprintIds => enemyBlueprintIds;

		public SiegeWeaponComponentBlueprint[] SiegeWeaponBlueprints => siegeWeaponBlueprints;

		public bool IsSiege => isSiege;

		public WorldMapPlace BattleMapPlace => GlobalSaveController.CurrentVillageData.WorldMapPlace;

		public VillagePlace RaiderOriginVillage => raiderOriginVillageRef?.VillageValue;

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

		public RaidEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			InitMapPlaces();
			InitRaiders();
			return new ShowDialogPhase(0).LinkNextPhase(new RaidPhase().NextPhaseOnVictory(new ShowDialogPhase("won")).NextPhaseOnDefeat(new ShowDialogPhase("lost")).NextPhaseOnTie(new ShowDialogPhase("tie")));
		}

		public override bool CanStart()
		{
			if (!MonoSingleton<RaidEnemySelector>.IsInstantiated() || !MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				return false;
			}
			if (GlobalSaveController.CurrentVillageData.Workers.Count <= 0)
			{
				GameEventInstance.Logger.Info("No workers in current village");
				return false;
			}
			if (!base.CanStart())
			{
				return false;
			}
			IEnumerable<FactionInstance> factionsByFriendliness = FactionUtil.GetFactionsByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions);
			if (factionsByFriendliness == null || !factionsByFriendliness.Any())
			{
				GameEventInstance.Logger.Info("No factions to pick from");
				return false;
			}
			InitMapPlaces();
			List<IEnemyPurchaseUnit> enemies;
			List<SiegeWeaponComponentBlueprint> siegeWeapons;
			bool flag;
			return GameEventUtil.TryPurchaseEnemies(RaiderFactionInstance.BlueprintId, (int)MonoSingleton<BaseWealth>.Instance.GetRaidPoints(), out enemies, out siegeWeapons, out flag);
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
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Raid\\RaidEvent.cs");
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
			if (!GameEventUtil.TryPurchaseEnemies(RaiderFactionInstance.BlueprintId, (int)MonoSingleton<BaseWealth>.Instance.GetRaidPoints(), out var enemies, out var siegeWeapons, out var flag))
			{
				throw new Exception("Failed to purchase enemies.");
			}
			enemyBlueprintIds = enemies.Select((IEnemyPurchaseUnit unit) => new RaiderBlueprintId(unit)).ToArray();
			siegeWeaponBlueprints = siegeWeapons.ToArray();
			isSiege = flag;
		}

		public override string GetEventInfo(GameEvent.DialogContent dialogContent)
		{
			string key = dialogContent.DescriptionTextKey.Replace("<faction>", RaiderFactionInstance.BlueprintId);
			string text = MonoSingleton<LocalizationController>.Instance.GetText(key).Replace("<faction_name>", RaiderFactionInstance.NameLocalized);
			text = TextFormatting.FormatText(text);
			ActiveRaidInfo activeRaidInfo = cachedRaidInfo;
			if (activeRaidInfo == null)
			{
				return text;
			}
			return TextFormatting.FormatRaidText(text, activeRaidInfo);
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

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("cachedRaidInfo", cachedRaidInfo);
			serializer.Write("raiderVillagePlace", raiderOriginVillageRef);
			serializer.Write("enemyBlueprintIds", enemyBlueprintIds);
			serializer.Write("isSiege", isSiege);
			serializer.Write("raiderFactionId", raiderFactionId);
			serializer.WriteBlueprintIds("siegeWeaponBlueprints", siegeWeaponBlueprints);
		}

		public RaidEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			cachedRaidInfo = deserializer.ReadObject<ActiveRaidInfo>("cachedRaidInfo");
			raiderOriginVillageRef = deserializer.ReadObject<VillagePlaceReference>("raiderVillagePlace");
			raiderFactionId = deserializer.ReadString("raiderFactionId");
			enemyBlueprintIds = deserializer.ReadObjectArray<RaiderBlueprintId>("enemyBlueprintIds");
			isSiege = deserializer.ReadBool("isSiege");
			siegeWeaponBlueprints = deserializer.ReadIdsToBlueprints("siegeWeaponBlueprints", Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetByID, new List<SiegeWeaponComponentBlueprint>()).ToArray();
			enemyBlueprintIds = enemyBlueprintIds.Where((RaiderBlueprintId raider) => raider.Type != RaiderBlueprintId.RaiderType.Trebuchet).ToArray();
		}
	}
}
