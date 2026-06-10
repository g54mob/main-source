using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components;
using NSMedieval.Components.Base;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Model.SecondMap;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Village.Map;
using Repository.Map;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	[FVSerializableKey("VillagePlace", "")]
	public class VillagePlace : WorldMapPlace, ITrader
	{
		private const long RegenerateStorageHours = 720L;

		private Storage storage;

		private long lastRefreshStorage;

		private string traderName;

		private List<CreatureBase> creatures;

		private TraderType traderType;

		private string enterMapLoadingScreenTitle;

		private string enterMapLoadingScreenDescription;

		private string preciseEnemyCountInfoLocalized;

		private string ballparkEnemyCountInfoLocalized;

		public override string PreciseEnemyCountInfoLocalized
		{
			get
			{
				if (preciseEnemyCountInfoLocalized == null)
				{
					List<IEnemyPurchaseUnit> enemiesToSpawn;
					bool flag = MonoSingleton<RaidEnemySelector>.Instance.TryPurchaseEnemies(factionBlueprintId, this, out enemiesToSpawn);
					preciseEnemyCountInfoLocalized = (flag ? UiUtils.BuildPreciseEnemiesListing(enemiesToSpawn) : string.Empty);
				}
				return preciseEnemyCountInfoLocalized;
			}
		}

		public override string BallparkEnemyCountInfoLocalized
		{
			get
			{
				if (ballparkEnemyCountInfoLocalized == null)
				{
					if (factionBlueprintId == null)
					{
						ballparkEnemyCountInfoLocalized = null;
					}
					else
					{
						List<IEnemyPurchaseUnit> enemiesToSpawn;
						bool flag = MonoSingleton<RaidEnemySelector>.Instance.TryPurchaseEnemies(factionBlueprintId, this, out enemiesToSpawn);
						ballparkEnemyCountInfoLocalized = (flag ? UiUtils.BuildBallparkEnemiesListing(enemiesToSpawn, base.Name.GetHashCode()) : string.Empty);
					}
				}
				return ballparkEnemyCountInfoLocalized;
			}
		}

		public Storage Storage => storage ?? (storage = new Storage(new StorageBase(1000, ignoreWeigth: true, infinite: true)));

		public override string EnterMapLoadingScreenTitle => base.Name;

		public override string EnterMapLoadingScreenDescription => FactionInstance.Blueprint.Description;

		private List<CreatureBase> Creatures => creatures ?? (creatures = new List<CreatureBase>());

		private TraderType TraderType
		{
			get
			{
				CheckInitTraderType();
				return traderType;
			}
		}

		public override FactionInstance FactionInstance
		{
			get
			{
				FactionInstance factionInstance = base.FactionInstance;
				if (factionInstance != null)
				{
					return factionInstance;
				}
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\VillagePlace.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("This should not happen. Setting a random faction for village ");
					messageBuilder.AppendFormatted(base.Name);
				}
				Log.Error(messageBuilder);
				factionInstance = MonoSingleton<WorldMap>.Instance.Data.FactionInstances.PickRandom();
				if (factionInstance != null)
				{
					factionBlueprintId = FactionInstance.BlueprintId;
				}
				return factionInstance;
			}
			set
			{
				base.FactionInstance = value;
			}
		}

		public FactionInstance Faction => FactionInstance;

		public VillagePlace(string name, FactionInstance FactionInstance)
			: base((string)null)
		{
			base.Name = name;
			factionBlueprintId = FactionInstance.BlueprintId;
		}

		public override IWorldMapPlaceReference CreateReference()
		{
			return new VillagePlaceReference(this);
		}

		public override string ToString()
		{
			return $"VillagePlace '{base.Name}', MapId '{base.MapId}' at region map grid position {base.Position}";
		}

		public override void GenerateSelectionPanelText(List<string> outLines)
		{
			Vector2Int villagePosition = MonoSingleton<WorldMap>.Instance.Data.VillagePosition;
			Vector2Int vector2Int = base.Position;
			int num = (int)(villagePosition - vector2Int).magnitude;
			outLines.Add(MonoSingleton<LocalizationController>.Instance.GetText("village_name") + ": " + base.Name);
			outLines.Add(string.Format("{0}: {1}", MonoSingleton<LocalizationController>.Instance.GetText("distance_from_village"), num));
			FactionInstance factionInstance = FactionInstance;
			if (factionInstance != null)
			{
				outLines.Add(UiUtils.GetFactionLink(factionInstance, factionInstance.NameLocalized));
				outLines.Add(WorldMapUtils.GetFriendlinessText(factionInstance));
			}
			switch (base.MarkerState)
			{
			case MapMarkerState.Enterable:
				if (factionInstance == null || !factionInstance.IsHostile())
				{
					break;
				}
				if (base.CaravanId != int.MaxValue)
				{
					if (!string.IsNullOrEmpty(PreciseEnemyCountInfoLocalized))
					{
						outLines.Add(PreciseEnemyCountInfoLocalized);
					}
				}
				else if (!string.IsNullOrEmpty(BallparkEnemyCountInfoLocalized))
				{
					outLines.Add(BallparkEnemyCountInfoLocalized);
				}
				break;
			case MapMarkerState.Lootable:
			{
				long nextStateTransitionTimeMinutesLeft2 = base.NextStateTransitionTimeMinutesLeft;
				if (nextStateTransitionTimeMinutesLeft2 > 0)
				{
					string timeFormatByMinutes2 = UiUtils.GetTimeFormatByMinutes(nextStateTransitionTimeMinutesLeft2, isDuration: true);
					outLines.Add("map_marker_expires_in".ToLocalized() + " " + timeFormatByMinutes2);
				}
				outLines.Add("point_of_interest_explored_info".ToLocalized());
				outLines.Add("point_of_interest_content".ToLocalized());
				WriteLootListing(outLines);
				outLines.Add(string.Empty);
				break;
			}
			case MapMarkerState.Disabled:
			{
				long nextStateTransitionTimeMinutesLeft = base.NextStateTransitionTimeMinutesLeft;
				if (base.ShouldShowDisabledTimer && nextStateTransitionTimeMinutesLeft > 0)
				{
					string timeFormatByMinutes = UiUtils.GetTimeFormatByMinutes(nextStateTransitionTimeMinutesLeft, isDuration: true);
					string text = "point_of_interest_disabled_settlement_info".ToLocalized();
					text = text.Replace("<time>", timeFormatByMinutes);
					outLines.Add(text);
				}
				else
				{
					outLines.Add("point_of_interest_disabled_settlement_info_02".ToLocalized());
				}
				break;
			}
			}
			if (factionInstance == null)
			{
				return;
			}
			if (MonoSingleton<WorldMap>.Instance.Data.TradeDeals.Contains(factionInstance.BlueprintId))
			{
				outLines.Add("have_trade_deal_with_faction".ToLocalized());
				return;
			}
			WorldMapMarkerPlace tradeDealMarker = MonoSingleton<WorldMap>.Instance.Data.GetTradeDealMarker(FactionInstance.Blueprint);
			if (tradeDealMarker != null)
			{
				WorldMapPlace.ListTradeDealResources(outLines, tradeDealMarker);
			}
		}

		public override List<ResourceInstance> GenerateLoot()
		{
			List<ResourceInstance> list = new List<ResourceInstance>();
			foreach (TradeResource resource in GetResources(null))
			{
				if (!resource.IsCreature)
				{
					ResourceInstance item = new ResourceInstance(resource.Resource, resource.Count);
					list.Add(item);
				}
			}
			return list;
		}

		public float GetSellMultiplier()
		{
			return 1.2f;
		}

		public float GetBuyMultiplier()
		{
			return 0.8f;
		}

		public List<TradeResource> GetResources(ITrader otherTrader)
		{
			if (Storage.IsEmpty())
			{
				InitTradingStorage();
			}
			ResourceInstance[] array = storage.Resources.ToArray();
			foreach (ResourceInstance resourceInstance in array)
			{
				if (resourceInstance.Blueprint == null)
				{
					storage.DeleteResource(resourceInstance);
				}
			}
			if (storage.Resources.Any((ResourceInstance res) => res.Stats.Owner == null))
			{
				foreach (ResourceInstance resource in storage.Resources)
				{
					resource.InitAfterLoadPile();
				}
			}
			WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			if (lastRefreshStorage == 0L || dateAndTime.MinutesTotal - lastRefreshStorage >= 720L * (long)dateAndTime.MinutesInHour)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(69, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\VillagePlace.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Refreshing storage for village ");
					messageBuilder.AppendFormatted(base.Name);
					messageBuilder.AppendLiteral(". It wasn't refreshed for more than ");
					messageBuilder.AppendFormatted(720L);
					messageBuilder.AppendLiteral("h.");
				}
				Log.Info(messageBuilder);
				InitTradingStorage();
				traderName = string.Empty;
			}
			List<TradeResource> resources = TraderUtils.GetResources(Storage);
			foreach (CreatureBase creature in Creatures)
			{
				if (creature != null)
				{
					resources.Add(new TradeResource(creature));
				}
			}
			return resources;
		}

		public string GetTraderName()
		{
			if (string.IsNullOrEmpty(traderName))
			{
				BodyType randomBodyType = GetRandomBodyType();
				traderName = Repository<NameRepository, Names>.Instance.GetFirstName(randomBodyType) + " " + Repository<NameRepository, Names>.Instance.GetLastName();
			}
			return traderName;
		}

		public BodyType GetRandomBodyType()
		{
			if (FactionInstance == null)
			{
				if (!(Random.value >= 0.5f))
				{
					return BodyType.Female;
				}
				return BodyType.Male;
			}
			return FactionInstance.GetRandomBodyType();
		}

		public string GetSettlementName()
		{
			return base.Name;
		}

		public Sprite GetHeraldryCrest()
		{
			return FactionInstance.Blueprint.HeraldryCrestSprite;
		}

		public Sprite GetHeraldryBackground()
		{
			return FactionInstance.Blueprint.HeraldryBackgroundSprite;
		}

		public float GetBargainMultiplier()
		{
			return 1f;
		}

		public void AddItemToStorage(TradeResource tradeResource, int count)
		{
			if (tradeResource.IsCreature)
			{
				Creatures.Add(tradeResource.Creature);
				return;
			}
			ResourceInstance resourceToAdd = new ResourceInstance(tradeResource.Resource, count);
			Storage.Add(resourceToAdd, count);
		}

		public void RemoveItemFromStorage(TradeResource tradeResource, int count)
		{
			if (tradeResource.IsCreature)
			{
				Creatures.Remove(tradeResource.Creature);
			}
			else
			{
				Storage.Consume(tradeResource.Resource, count);
			}
		}

		public float GetPerResourcePriceMultiplier(TradeResource resource)
		{
			return TraderUtils.GetPerResourcePriceMultiplier(TraderType, resource, this, FactionInstance, useMapTypeModifiers: true);
		}

		public VillagePlace GetTraderVillagePlace()
		{
			return this;
		}

		public bool CanTradeResource(TradeResource resource)
		{
			return TraderUtils.CanTradeResource(TraderType, resource, this, FactionInstance, useMapTypeModifiers: true);
		}

		public bool IsTraderFriendly()
		{
			FactionFriendliness friendliness = FactionInstance.GetFriendliness();
			if (friendliness != FactionFriendliness.Hostile)
			{
				return friendliness != FactionFriendliness.PermanentlyHostile;
			}
			return false;
		}

		public int GetStorageCapacity()
		{
			return traderType.StorageCapacity;
		}

		public float GetMinimumNutrition()
		{
			return 0f;
		}

		public TradeForbiddenReason GetPrisonerTradeStatus(CreatureBase creatureBase)
		{
			return FactionInstance.GetPrisonerTradeStatus(creatureBase);
		}

		private void WriteLootListing(List<string> outLines)
		{
			foreach (CreatureBase lootableCreature in LootableCreatures)
			{
				if (lootableCreature is AnimalInstance animalInstance)
				{
					outLines.Add(AnimalUtils.GetTradeName(animalInstance));
				}
				else if (lootableCreature is HumanoidInstance human)
				{
					outLines.Add(HumanoidUtils.GetTradeName(human));
				}
			}
			outLines.Add(string.Empty);
			LootableStorage.WriteContentsListing(outLines);
		}

		private void CheckInitTraderType()
		{
			if (!(traderType != null))
			{
				traderType = Repository<TraderTypeRepository, TraderType>.Instance.GetByID("settlemnt");
				if (Storage.IsEmpty())
				{
					InitTradingStorage();
				}
			}
		}

		private void InitTradingStorage()
		{
			Storage.ClearAll();
			TraderType.GenerateResourceInstances(this, FactionInstance, useMapTypeModifiers: true, out var resources, out var animals, out var addPrisonersByFaction);
			foreach (ResourceInstance item2 in resources)
			{
				Storage.Add(item2, item2.Amount);
			}
			foreach (CreatureBase creature in Creatures)
			{
				creature?.Dispose();
			}
			Creatures.Clear();
			foreach (KeyValuePair<Animal, TraderStockItem> item3 in animals)
			{
				Animal key = item3.Key;
				BodyType bodyType = ((!((double)Random.value < 0.5)) ? BodyType.Male : BodyType.Female);
				int lifePhaseIndex = Mathf.FloorToInt(Random.value * (float)key.LifePhases.Count);
				float lifePhasePercent = Mathf.Pow(0.5f * Random.value, 2f);
				AnimalInstance item = MonoSingleton<AnimalManager>.Instance.CreateNewAnimalInstance(key.GetID(), Vector3.zero, bodyType, lifePhaseIndex, lifePhasePercent, isInIncognitoMode: true, AnimalType.Domestic);
				Creatures.Add(item);
			}
			foreach (string factionId in addPrisonersByFaction)
			{
				VillagePlace villagePlace;
				if (factionId == null)
				{
					villagePlace = GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.PickRandom();
				}
				else
				{
					bool isEnabled;
					if (!GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaceExistsForFaction(factionId))
					{
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\VillagePlace.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("*** No village with faction '");
							messageBuilder.AppendFormatted(factionId);
							messageBuilder.AppendLiteral("'.");
						}
						Log.Info(messageBuilder);
						continue;
					}
					villagePlace = GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.PickRandom((VillagePlace village) => factionId.Equals(village.FactionInstance.BlueprintId));
					if (!GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaceExistsForFaction(factionId))
					{
						FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\VillagePlace.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("No village of faction '");
							messageBuilder2.AppendFormatted(factionId);
							messageBuilder2.AppendLiteral("'.");
						}
						Log.Trace(messageBuilder2);
						continue;
					}
				}
				if (villagePlace != null)
				{
					Log.Info("Prisoners in village's storage not implemented.", "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\VillagePlace.cs");
				}
			}
			lastRefreshStorage = GlobalSaveController.CurrentVillageData.DateAndTime.MinutesTotal;
		}

		public void InitAfterLoad()
		{
			foreach (CreatureBase creature in Creatures)
			{
				if (creature == null)
				{
					continue;
				}
				if (creature.Stats != null && creature.Stats.Owner == null)
				{
					creature.Stats.SetOwner(creature);
					creature.Stats.SetOwnerOnStats();
					creature.Stats.Initialize();
				}
				MonoSingleton<StatsUpdateManager>.Instance.UnregisterStat(creature.Stats);
				List<EquipmentInstance> equipment = creature.GetEquipment();
				if (equipment == null)
				{
					continue;
				}
				foreach (EquipmentInstance item in equipment)
				{
					if (!item.HasDisposed)
					{
						item.CheckInitStats();
						if (item.Stats != null)
						{
							item.Reinstantiate();
						}
					}
				}
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("storage", storage);
			serializer.Write("lastRefreshStorage", lastRefreshStorage);
			serializer.Write("traderName", traderName);
			serializer.Write("creatures", creatures);
		}

		public VillagePlace(FVDeserializer deserializer)
			: base(deserializer)
		{
			storage = deserializer.ReadObject<Storage>("storage");
			lastRefreshStorage = deserializer.ReadLong("lastRefreshStorage", 0L);
			traderName = deserializer.ReadString("traderName");
			List<AnimalInstance> list = deserializer.ReadObjectList<AnimalInstance>("animals");
			if (list != null && list.Count > 0)
			{
				creatures = new List<CreatureBase>();
				foreach (AnimalInstance item in list)
				{
					creatures.Add(item);
				}
			}
			else
			{
				creatures = deserializer.ReadObjectList<CreatureBase>("creatures");
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder;
			if (base.MapId == null || base.CachedMapInfo.BiomeType != base.MapType)
			{
				messageBuilder = new FVLogDebugInterpolationHandler(168, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\VillagePlace.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[Autofix] picking a new map for village place '");
					messageBuilder.AppendFormatted(base.Name);
					messageBuilder.AppendLiteral("' because it doesn't have one or the biomes don't match (probably an older save), biome: '");
					messageBuilder.AppendFormatted(base.MapType);
					messageBuilder.AppendLiteral("', current map '");
					messageBuilder.AppendFormatted(base.CachedMapInfo?.Id);
					messageBuilder.AppendLiteral("' with biome '");
					messageBuilder.AppendFormatted(base.CachedMapInfo?.BiomeType);
					messageBuilder.AppendLiteral("'");
				}
				Log.Debug(messageBuilder);
				SecondMapSaveInfo randomSave = Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetRandomSave(SecondMapType.Settlement, base.MapType);
				base.MapId = randomSave.Id;
			}
			messageBuilder = new FVLogDebugInterpolationHandler(50, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\VillagePlace.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Village place '");
				messageBuilder.AppendFormatted(base.Name);
				messageBuilder.AppendLiteral("' biome '");
				messageBuilder.AppendFormatted(base.MapType);
				messageBuilder.AppendLiteral("' has map '");
				messageBuilder.AppendFormatted(base.CachedMapInfo.Id);
				messageBuilder.AppendLiteral("' with biome '");
				messageBuilder.AppendFormatted(base.CachedMapInfo.BiomeType);
				messageBuilder.AppendLiteral("'");
			}
			Log.Debug(messageBuilder);
		}
	}
}
