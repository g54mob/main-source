using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Model.SecondMap;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using Utils;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.AttackCampEvent", "")]
	public class AttackCampEvent : GameEventInstance, IRaidPhaseDataHolder
	{
		private const string VICTORY_DIALOG_ID = "won";

		private const string DEFEAT_DIALOG_ID = "lost";

		private const string TIE_DIALOG_ID = "tie";

		private ActiveRaidInfo cachedRaidInfo;

		private IWorldMapPlaceReference battleMapPlaceRef;

		private VillagePlaceReference raiderOriginVillageRef;

		private RaiderBlueprintId[] enemyBlueprintIds;

		private SiegeWeaponComponentBlueprint[] siegeWeaponBlueprints;

		private bool isSiege;

		public List<MapNode> OverrideRaidSpawnPositions { get; set; }

		public WorldMapPlace BattleMapPlace => battleMapPlaceRef?.Value;

		public VillagePlace RaiderOriginVillage => raiderOriginVillageRef?.VillageValue;

		public FactionInstance RaiderFactionInstance => BattleMapPlace.FactionInstance;

		public RaiderBlueprintId[] EnemyBlueprintIds => enemyBlueprintIds;

		public SiegeWeaponComponentBlueprint[] SiegeWeaponBlueprints => siegeWeaponBlueprints;

		public bool IsSiege => isSiege;

		private SecondMapSaveInfo MapSaveInfo => GlobalSaveController.CurrentVillageData.WorldMapPlace.CachedMapInfo;

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

		public AttackCampEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			InitMapPlaces();
			InitRaiders();
			return new RaidPhase(0).NextPhaseOnVictory(new ShowDialogPhase("won")).NextPhaseOnDefeat(new ShowDialogPhase("lost")).NextPhaseOnTie(new ShowDialogPhase("tie"));
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
			InitMapPlaces();
			List<IEnemyPurchaseUnit> enemiesToSpawn;
			return MonoSingleton<RaidEnemySelector>.Instance.TryPurchaseEnemies(RaiderFactionInstance.BlueprintId, BattleMapPlace, out enemiesToSpawn);
		}

		public override void OnLoaded(bool fromSave)
		{
			base.OnLoaded(fromSave);
			InitMapPlaces();
		}

		public override void OnEnd()
		{
			foreach (DoorComponentInstance componentInstance in VillageManager.ActiveVillage.Map.DoorComponentManager.ComponentInstances)
			{
				componentInstance.SetAlwaysOpen();
			}
			foreach (HumanoidInstance nPC in GlobalSaveController.CurrentVillageData.NPCs)
			{
				if (nPC.IsEnemy())
				{
					nPC.PathDriver.Agent.SetWalkableModel(Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID("enemy_flee_camp"));
				}
			}
			if (cachedRaidInfo.Won)
			{
				MonoSingleton<AchievementManager>.Instance.UnlockAchievement("DEFEAT_BANDIT_CAMP");
			}
			base.OnEnd();
		}

		public override void SetBlueprint(GameEvent blueprintEvent)
		{
			base.SetBlueprint(blueprintEvent);
			InitMapPlaces();
		}

		private void InitMapPlaces()
		{
			if (battleMapPlaceRef == null)
			{
				battleMapPlaceRef = GlobalSaveController.CurrentVillageData.WorldMapPlace.CreateReference();
			}
			if (raiderOriginVillageRef == null)
			{
				raiderOriginVillageRef = FactionUtil.GetRandomVillagePlace(RaiderFactionInstance);
			}
		}

		private void InitRaiders()
		{
			if (!MonoSingleton<RaidEnemySelector>.Instance.TryPurchaseEnemies(RaiderFactionInstance.BlueprintId, BattleMapPlace, out var enemiesToSpawn))
			{
				throw new Exception("Failed to purchase enemies.");
			}
			enemyBlueprintIds = enemiesToSpawn.Select((IEnemyPurchaseUnit unit) => new RaiderBlueprintId(unit)).ToArray();
			OverrideRaidSpawnPositions = new List<MapNode>();
			VillageMap map = VillageManager.ActiveVillage.Map;
			RaiderBlueprintId[] array = enemyBlueprintIds;
			foreach (RaiderBlueprintId obj in array)
			{
				SpawnPointType type = SpawnPointType.EnemyGeneral;
				if (!(obj.FindBlueprint() is NPC nPC))
				{
					type = SpawnPointType.EnemyGeneral;
				}
				else if (nPC.Type == NPCType.Archer)
				{
					type = SpawnPointType.EnemyArcher;
				}
				Vec3Int spawnPoint = MonoSingleton<TravelManager>.Instance.GetSpawnPoint(type);
				OverrideRaidSpawnPositions.Add(map.GetNode(spawnPoint));
			}
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
			serializer.Write("battleMapPlace", battleMapPlaceRef);
			serializer.Write("enemyBlueprintIds", enemyBlueprintIds);
			serializer.Write("isSiege", isSiege);
			serializer.WriteBlueprintIds("siegeWeaponBlueprints", siegeWeaponBlueprints);
		}

		public AttackCampEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			cachedRaidInfo = deserializer.ReadObject<ActiveRaidInfo>("cachedRaidInfo");
			raiderOriginVillageRef = deserializer.ReadObject<VillagePlaceReference>("raiderVillagePlace");
			battleMapPlaceRef = deserializer.ReadObject<IWorldMapPlaceReference>("battleMapPlace");
			enemyBlueprintIds = deserializer.ReadObjectArray<RaiderBlueprintId>("enemyBlueprintIds");
			isSiege = deserializer.ReadBool("isSiege");
			siegeWeaponBlueprints = deserializer.ReadIdsToBlueprints("siegeWeaponBlueprints", Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetByID, new List<SiegeWeaponComponentBlueprint>()).ToArray();
			enemyBlueprintIds = enemyBlueprintIds.Where((RaiderBlueprintId raider) => raider.Type != RaiderBlueprintId.RaiderType.Trebuchet).ToArray();
		}
	}
}
