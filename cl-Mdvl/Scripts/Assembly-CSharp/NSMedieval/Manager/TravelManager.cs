using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Dictionary;
using NSMedieval.Enums;
using NSMedieval.Extensions;
using NSMedieval.GameDifficulty;
using NSMedieval.GameEventSystem;
using NSMedieval.Model.MapNew;
using NSMedieval.Model.SecondMap;
using NSMedieval.Research;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.StorageUniversal;
using NSMedieval.Terrain;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Statistic;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using NSMedieval.Weather;
using NSMedieval.WorldMap;
using Repository.Map;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class TravelManager : MonoSingleton<TravelManager>
	{
		private List<AnimalInstance> enemyOwnedAnimals;

		private Dictionary<SpawnPointType, int> spawnPointsIndex;

		private HashSet<Vec3Int> usedSpawnPointsCache;

		private string startEvent;

		private bool randomizeSpawnPointSet;

		private bool spawnLoot;

		private bool disableOutcomeTimeout;

		public bool JustLeftSecondMap { get; set; }

		public List<HumanoidInstance> Workers { get; private set; }

		public List<HumanoidInstance> Prisoners { get; private set; }

		public List<AnimalInstance> Animals { get; private set; }

		public List<ResourceInstance> Resources { get; private set; }

		public WorldMapData WorldMapData { get; private set; }

		public SecondMapSaveInfo SaveInfo { get; private set; }

		public WorldDate DateAndTime { get; private set; }

		public List<WeatherEventInstance> ScheduledWeatherEvents { get; private set; }

		public SerializableStringIntListDictionary WeatherEventsHourly { get; private set; }

		public float[] TemperatureHourly { get; private set; }

		public List<ResearchNodeInstance> ResearchedNodes { get; private set; }

		public List<string> UnlockedItems { get; private set; }

		public List<HistoryEntry> HistoryEntries { get; private set; }

		public int CaravanId { get; private set; }

		public WorldMapPlace DestinationPlace { get; private set; }

		public SecondMapLeaveOutcome SecondMapLeaveOutcome { get; private set; }

		public bool TookItemsFromMap { get; set; }

		public bool IsGeneratingNewSecondMap { get; private set; }

		public GameParametersInstance GameParametersCurrent { get; private set; }

		public event Action BeforeLoadSecondMap;

		protected override void Awake()
		{
			base.Awake();
			ResetData();
		}

		public void GenerateVillage(List<HumanoidInstance> workers, List<AnimalInstance> animals, MapSize mapSize, string mapType, string mapSeed)
		{
			if (mapSize == null || mapSize.Width == 0 || mapSize.Height == 0 || mapSize.Length == 0)
			{
				return;
			}
			Log.Info("Generating new second map village", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\TravelManager.cs");
			IsGeneratingNewSecondMap = true;
			disableOutcomeTimeout = true;
			VillageSaveData villageSaveData = MonoSingleton<GlobalSaveController>.Instance.CreateTempVillage();
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			villageSaveData.SetMapSourceIDs(mapSize, mapType, mapSeed);
			villageSaveData.GameParametersCurrent = currentVillageData.GameParametersCurrent;
			villageSaveData.Scenario = currentVillageData.Scenario;
			FVSerializer fVSerializer = new FVSerializer("travelData");
			fVSerializer.Write("workers", workers);
			fVSerializer.Write("animals", animals);
			FVDeserializer fVDeserializer = new FVDeserializer("travelData", fVSerializer.GetBytes());
			Workers = fVDeserializer.ReadObjectList<HumanoidInstance>("workers");
			Animals = fVDeserializer.ReadObjectList<AnimalInstance>("animals");
			foreach (HumanoidInstance worker in Workers)
			{
				villageSaveData.AddWorker(worker);
				worker.SetPosition(worker.WorkerBehaviour.WorkerBlueprint.SpawnPosition);
			}
			foreach (AnimalInstance animal in Animals)
			{
				villageSaveData.AddAnimal(animal);
			}
			Workers.Clear();
			Animals.Clear();
			InitSpawnPointIndices();
			TryLoading();
		}

		public void DebugLoadVillage(SecondMapSaveInfo info, List<HumanoidInstance> workers, List<HumanoidInstance> prisoners, List<AnimalInstance> animals, List<ResourceInstance> resources, string startEvent = null, bool randomizeSpawn = false, bool spawnLoot = false)
		{
			TookItemsFromMap = false;
			IsGeneratingNewSecondMap = false;
			JustLeftSecondMap = false;
			disableOutcomeTimeout = true;
			SecondMapLeaveOutcome = SecondMapLeaveOutcome.LeftWithoutEngagingEnemy;
			SaveInfo = info;
			randomizeSpawnPointSet = randomizeSpawn;
			this.spawnLoot = spawnLoot;
			if (info.Type == SecondMapType.Settlement)
			{
				System.Random rndOverride = new System.Random(info.GetID().GetHashCode());
				DestinationPlace = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.VillagePlaces.PickRandom(rndOverride);
			}
			else
			{
				DestinationPlace = MapPlaceGenerator.DebugSpawnMarker(info);
			}
			MonoSingleton<GlobalSaveController>.Instance.SetSaveInfoToLoad(info);
			PrepareDataForLoad(workers, prisoners, animals, resources, startEvent);
			InitSpawnPointIndices();
			TryLoading();
		}

		public void LoadVillage(SecondMapSaveInfo info, CaravanInstance caravan, WorldMapPlace worldMapPlace, string startEvent = null, bool randomizeSpawn = false)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(63, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\TravelManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Entering second map '");
				messageBuilder.AppendFormatted(info?.Id);
				messageBuilder.AppendLiteral("' with caravan ");
				messageBuilder.AppendFormatted(caravan.UniqueId);
				messageBuilder.AppendLiteral(", map place ");
				messageBuilder.AppendFormatted(worldMapPlace);
				messageBuilder.AppendLiteral(", startEvent '");
				messageBuilder.AppendFormatted(startEvent);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			if (GlobalSaveController.CurrentVillageData.WorldMapData.Caravans.All((CaravanInstance worldMapCaravan) => worldMapCaravan.UniqueId != caravan.UniqueId))
			{
				throw new Exception($"Didn't find the caravan with ID {CaravanId} on the region map, but tried to enter a second map with it - this should not happen");
			}
			TookItemsFromMap = false;
			IsGeneratingNewSecondMap = false;
			JustLeftSecondMap = false;
			SecondMapLeaveOutcome = SecondMapLeaveOutcome.LeftWithoutEngagingEnemy;
			SaveInfo = info;
			randomizeSpawnPointSet = randomizeSpawn;
			spawnLoot = true;
			DestinationPlace = worldMapPlace;
			this.BeforeLoadSecondMap?.Invoke();
			while (!VillageManager.ActiveVillage.Map.WaterManager.IsThreadFinished)
			{
				Thread.Sleep(25);
			}
			MonoSingleton<GlobalSaveController>.Instance.SetSaveInfoToLoad(info);
			List<HumanoidInstance> list = new List<HumanoidInstance>();
			List<AnimalInstance> list2 = new List<AnimalInstance>();
			foreach (CreatureBase creature in caravan.Creatures)
			{
				if (creature is HumanoidInstance humanoidInstance && humanoidInstance.IsCaptive())
				{
					list.Add(humanoidInstance);
				}
				else
				{
					list2.Add((AnimalInstance)creature);
				}
			}
			CaravanId = caravan.UniqueId;
			caravan.SaveResourcesCaravanCameWith();
			List<ResourceInstance> resources = (from resource in caravan.Storage.GetResourcesWithoutLock()
				select resource.Clone()).ToList();
			PrepareDataForLoad(caravan.Workers.ToList(), list, list2, resources, startEvent);
			foreach (CaravanInstance caravan2 in WorldMapData.Caravans)
			{
				if (caravan2.UniqueId == CaravanId)
				{
					caravan2.Creatures.Clear();
					caravan2.Workers.Clear();
					caravan2.Storage.ClearAll(isSilent: true);
					break;
				}
			}
			foreach (HumanoidInstance worker in Workers)
			{
				worker.ResetIncognito();
			}
			foreach (HumanoidInstance prisoner in Prisoners)
			{
				prisoner.ResetIncognito();
			}
			foreach (AnimalInstance animal in Animals)
			{
				animal.ResetIncognito();
			}
			InitSpawnPointIndices();
			TryLoading();
		}

		public void LoadOriginalVillage()
		{
			if (MonoSingleton<GlobalSaveController>.Instance.SetOriginalSaveInfoToLoad())
			{
				IsGeneratingNewSecondMap = false;
				JustLeftSecondMap = true;
				SecondMapLeaveOutcome = GlobalSaveController.CurrentVillageData.SecondMapLeaveOutcome;
				CaravanId = GlobalSaveController.CurrentVillageData.WorldMapPlace.CaravanId;
				FVSerializer fVSerializer = new FVSerializer("travelData");
				fVSerializer.Write("worldMapData", GlobalSaveController.CurrentVillageData.WorldMapData);
				fVSerializer.Write("worldMapTerrainData", GlobalSaveController.CurrentVillageData.WorldMapData.GetBinaryDataToSerialize());
				fVSerializer.Write("historyEntries", GlobalSaveController.CurrentVillageData.HistoryEntries);
				fVSerializer.Write("gameParametersCurrent", GlobalSaveController.CurrentVillageData.GameParametersCurrent);
				FVDeserializer fVDeserializer = new FVDeserializer("travelData", fVSerializer.GetBytes());
				WorldMapData = fVDeserializer.ReadObject<WorldMapData>("worldMapData");
				byte[] inputData = fVDeserializer.ReadByteArray("worldMapTerrainData");
				WorldMapData.ReadFromBinaryData(inputData);
				HistoryEntries = fVDeserializer.ReadObjectList<HistoryEntry>("historyEntries");
				GameParametersCurrent = fVDeserializer.ReadObject<GameParametersInstance>("gameParametersCurrent");
				SaveInfo = null;
				TryLoading();
			}
		}

		public void LoadVillage(CaravanInstance caravan, WorldMapPlace mapPlace = null, string startEvent = null, bool randomizeSpawn = false)
		{
			DebugEventLog.FinalizeToFile(GlobalSaveController.CurrentVillageData, "[primary_map]_");
			if (mapPlace == null)
			{
				mapPlace = caravan.DestinationPlace;
			}
			SecondMapSaveInfo secondMapSaveInfo = mapPlace.CachedMapInfo;
			if ((object)secondMapSaveInfo == null)
			{
				secondMapSaveInfo = Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetRandomSave(mapPlace.SecondMapType, mapPlace.MapType);
			}
			if (secondMapSaveInfo == null)
			{
				throw new Exception("Tried to load non-existent map with id '" + mapPlace.MapId + "'");
			}
			LoadVillage(secondMapSaveInfo, caravan, mapPlace, startEvent, randomizeSpawn);
		}

		public void SetStartEvent(string startEvent)
		{
			this.startEvent = startEvent;
		}

		public void OnGameplayStarted()
		{
			if (JustLeftSecondMap)
			{
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.SetWorldMapVisible(isWorldMapVisible: true);
			}
			if (GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				VillageManager.ActiveVillage.Map.SecondMapLeaveManager.OnRaidWonEvent += OnRaidWon;
			}
			if (!GlobalSaveController.CurrentVillageData.IsSecondMapFirstTime)
			{
				return;
			}
			PlayerVoxelInfo.ShowInfo = true;
			if (disableOutcomeTimeout)
			{
				VillageManager.ActiveVillage.Map.SecondMapLeaveManager.TimerDisabledDebug = true;
				disableOutcomeTimeout = false;
			}
			if (!string.IsNullOrEmpty(startEvent))
			{
				NSMedieval.GameEventSystem.GameEventSystem gameEventSystem = MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance;
				gameEventSystem.EventStart = (Action<GameEventInstance>)Delegate.Combine(gameEventSystem.EventStart, new Action<GameEventInstance>(OnEventStart));
				MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.StartEvent(startEvent);
				startEvent = null;
			}
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				worker.GetAgentView<WorkerView>()?.StartDraft();
			}
			ResetData();
		}

		private void OnEventStart(GameEventInstance eventInstance)
		{
			NSMedieval.GameEventSystem.GameEventSystem gameEventSystem = MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance;
			gameEventSystem.EventStart = (Action<GameEventInstance>)Delegate.Remove(gameEventSystem.EventStart, new Action<GameEventInstance>(OnEventStart));
			SetupEnemyOwnedAnimals();
		}

		private void SetupEnemyOwnedAnimals()
		{
			using PooledList<HumanoidInstance> pooledList = ListPool<HumanoidInstance>.GetJanitor();
			foreach (HumanoidInstance nPC in GlobalSaveController.CurrentVillageData.NPCs)
			{
				if (nPC.IsEnemy())
				{
					pooledList.Add(nPC);
				}
			}
			if (enemyOwnedAnimals == null || enemyOwnedAnimals.Count == 0 || pooledList.Count == 0)
			{
				return;
			}
			foreach (AnimalInstance enemyOwnedAnimal in enemyOwnedAnimals)
			{
				HumanoidInstance owner = pooledList.PickRandom();
				enemyOwnedAnimal.AssignPetOwner(owner);
			}
			pooledList.Clear();
			enemyOwnedAnimals.Clear();
		}

		private void OnRaidWon()
		{
			foreach (AnimalInstance animal in GlobalSaveController.CurrentVillageData.Animals)
			{
				if (animal.AnimalType == AnimalType.DomesticNpc)
				{
					animal.ResetPetOwner();
					animal.SetAnimalType(AnimalType.Domestic);
				}
			}
			VillageManager.ActiveVillage.Map.SecondMapLeaveManager.OnRaidWonEvent += OnRaidWon;
		}

		public void ClearWorldMapData()
		{
			WorldMapData = null;
		}

		public bool SetSecondMapStartingPositions()
		{
			if (!GlobalSaveController.CurrentVillageData.IsSecondMapFirstTime)
			{
				return false;
			}
			int num = 0;
			if (randomizeSpawnPointSet && SaveInfo != null)
			{
				int maxExclusive = SaveInfo.GetSetsCount() - 1;
				num = UnityEngine.Random.Range(0, maxExclusive);
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\TravelManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Randomized spawn point set index ");
					messageBuilder.AppendFormatted(num);
				}
				Log.Debug(messageBuilder);
			}
			VillageSaveData currentVillageData = GlobalSaveController.CurrentVillageData;
			foreach (HumanoidInstance worker in currentVillageData.Workers)
			{
				if (CombatUtils.GetAttackType(worker) != AttackType.Melee)
				{
					Vec3Int spawnPoint = GetSpawnPoint(SpawnPointType.FriendlyArcher, num);
					worker.SetGridPosition(spawnPoint);
					worker.SetSecondMapSpawnPosition(spawnPoint);
				}
				else
				{
					Vec3Int spawnPoint2 = GetSpawnPoint(SpawnPointType.FriendlyGeneral, num);
					worker.SetGridPosition(spawnPoint2);
					worker.SetSecondMapSpawnPosition(spawnPoint2);
					worker.UpdatePosition(worker.GetPosition());
				}
			}
			foreach (HumanoidInstance nPC in currentVillageData.NPCs)
			{
				if (!nPC.IsEnemy())
				{
					Vec3Int spawnPoint3 = GetSpawnPoint(SpawnPointType.PrisonerGeneral, num);
					nPC.SetGridPosition(spawnPoint3);
					nPC.SetSecondMapSpawnPosition(spawnPoint3);
					nPC.UpdatePosition(nPC.GetPosition());
				}
			}
			foreach (AnimalInstance animal in Animals)
			{
				if (animal.AnimalType != AnimalType.WildAggressive && animal.AnimalType != AnimalType.Wild)
				{
					Vec3Int spawnPoint4 = GetSpawnPoint(SpawnPointType.FriendlyAnimal, num);
					animal.SetGridPosition(spawnPoint4);
					animal.SetSecondMapSpawnPosition(spawnPoint4);
				}
			}
			return true;
		}

		public Vec3Int GetSpawnPoint(SpawnPointType type, int setIndex = 0)
		{
			if (!SaveInfo.HasSpawnPointsSet(setIndex))
			{
				setIndex = 0;
			}
			if (!SaveInfo.HasSpawnPointsType(type, setIndex))
			{
				switch (type)
				{
				case SpawnPointType.EnemyArcher:
				case SpawnPointType.EnemyAnimal:
				case SpawnPointType.EnemyResources:
					type = SpawnPointType.EnemyGeneral;
					break;
				case SpawnPointType.FriendlyArcher:
				case SpawnPointType.FriendlyAnimal:
				case SpawnPointType.FriendlyResources:
				case SpawnPointType.PrisonerGeneral:
					type = SpawnPointType.FriendlyGeneral;
					break;
				}
			}
			List<SpawnPoint> spawnPoints = SaveInfo.GetSpawnPoints(type, setIndex);
			if (spawnPoints.Count == 0)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(60, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\TravelManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No spawn points in save '");
					messageBuilder.AppendFormatted(SaveInfo.Name);
					messageBuilder.AppendLiteral("' for type ");
					messageBuilder.AppendFormatted(type);
					messageBuilder.AppendLiteral(", returning Vec3Int.zero");
				}
				Log.Error(messageBuilder);
				return Vec3Int.zero;
			}
			int index = spawnPointsIndex[type];
			SpawnPoint spawnPoint = spawnPoints[index];
			spawnPointsIndex[type]++;
			if (spawnPointsIndex[type] == spawnPoints.Count)
			{
				spawnPointsIndex[type] = 0;
			}
			return GetSpawnPositionFloodFill(spawnPoint.Position, 99, usedSpawnPointsCache);
		}

		public void SpawnLoot()
		{
			if (!spawnLoot)
			{
				Log.Info("Skipping loot spawn because the flag was set to false (probably because we are debug loading a map)", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\TravelManager.cs");
				return;
			}
			List<ResourceInstance> list = DestinationPlace.GenerateLoot();
			if (list == null)
			{
				return;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\TravelManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Spawning loot:\n");
				messageBuilder.AppendFormatted(list.ToPrettyString(newLineSeparator: true));
				messageBuilder.AppendLiteral("\n");
			}
			Log.Info(messageBuilder);
			using PooledList<ShelfComponentInstance> shelves = VillageManager.ActiveVillage.Map.ShelfComponentManager.ComponentInstances.ToPooledListJanitor();
			using PooledList<StockpileInstance> stockpiles = MonoSingleton<StockpileManager>.Instance.Stockpiles.ToPooledListJanitor();
			foreach (ResourceInstance item in list)
			{
				if (!FillShelves(shelves, item) && !FillStockpiles(stockpiles, item) && !FillResourceSpawnPoints(item))
				{
					throw new Exception($"Failed to find a place to spawn loot resource {item}");
				}
			}
			foreach (ResourceInstance item2 in list)
			{
				item2.Dispose();
			}
		}

		public void SetEnemyOwnedAnimals(ICollection<AnimalInstance> animals)
		{
			enemyOwnedAnimals = new List<AnimalInstance>();
			foreach (AnimalInstance animal in animals)
			{
				if (animal.AnimalType == AnimalType.Domestic)
				{
					enemyOwnedAnimals.Add(animal);
				}
			}
		}

		private void PrepareDataForLoad(List<HumanoidInstance> workers, List<HumanoidInstance> prisoners, List<AnimalInstance> animals, List<ResourceInstance> resources, string startEvent = null)
		{
			this.startEvent = startEvent;
			FVSerializer fVSerializer = new FVSerializer("travelData");
			fVSerializer.Write("workers", workers);
			fVSerializer.Write("prisoners", prisoners);
			fVSerializer.Write("animals", animals);
			fVSerializer.Write("resources", resources);
			fVSerializer.Write("worldMapData", GlobalSaveController.CurrentVillageData.WorldMapData);
			fVSerializer.Write("worldMapTerrainData", GlobalSaveController.CurrentVillageData.WorldMapData.GetBinaryDataToSerialize());
			fVSerializer.Write("dateAndTime", GlobalSaveController.CurrentVillageData.DateAndTime);
			fVSerializer.Write("scheduledWeatherEvents", GlobalSaveController.CurrentVillageData.ScheduledWeatherEvents);
			fVSerializer.Write("weatherEventsHourly", GlobalSaveController.CurrentVillageData.WeatherEventsHourlySerializable);
			fVSerializer.Write("temperatureHourly", GlobalSaveController.CurrentVillageData.TemperatureHourly);
			fVSerializer.Write("researchedNodes", GlobalSaveController.CurrentVillageData.GetUnlockedNodes());
			fVSerializer.Write("unlockedItems", GlobalSaveController.CurrentVillageData.GetUnlockedItems());
			fVSerializer.Write("historyEntries", GlobalSaveController.CurrentVillageData.HistoryEntries);
			fVSerializer.Write("difficultyCurrent", GlobalSaveController.CurrentVillageData.GameParametersCurrent);
			FVDeserializer fVDeserializer = new FVDeserializer("travelData", fVSerializer.GetBytes());
			Workers = fVDeserializer.ReadObjectList<HumanoidInstance>("workers");
			Prisoners = fVDeserializer.ReadObjectList<HumanoidInstance>("prisoners");
			Animals = fVDeserializer.ReadObjectList<AnimalInstance>("animals");
			Resources = fVDeserializer.ReadObjectList<ResourceInstance>("resources");
			WorldMapData = fVDeserializer.ReadObject<WorldMapData>("worldMapData");
			byte[] inputData = fVDeserializer.ReadByteArray("worldMapTerrainData");
			WorldMapData.ReadFromBinaryData(inputData);
			DateAndTime = fVDeserializer.ReadObject<WorldDate>("dateAndTime");
			ScheduledWeatherEvents = fVDeserializer.ReadObjectList<WeatherEventInstance>("scheduledWeatherEvents");
			WeatherEventsHourly = fVDeserializer.ReadObject<SerializableStringIntListDictionary>("weatherEventsHourly");
			TemperatureHourly = fVDeserializer.ReadFloatArray("temperatureHourly");
			ResearchedNodes = fVDeserializer.ReadObjectList<ResearchNodeInstance>("researchedNodes");
			UnlockedItems = fVDeserializer.ReadStringList("unlockedItems");
			HistoryEntries = fVDeserializer.ReadObjectList<HistoryEntry>("historyEntries");
			GameParametersCurrent = fVDeserializer.ReadObject<GameParametersInstance>("difficultyCurrent");
		}

		private void ResetData()
		{
			IsGeneratingNewSecondMap = false;
			TookItemsFromMap = false;
			Workers = new List<HumanoidInstance>();
			Prisoners = new List<HumanoidInstance>();
			Animals = new List<AnimalInstance>();
			Resources = new List<ResourceInstance>();
			WorldMapData = null;
			DateAndTime = null;
			ScheduledWeatherEvents = null;
			WeatherEventsHourly = null;
			TemperatureHourly = null;
			ResearchedNodes = null;
			UnlockedItems = null;
			HistoryEntries = null;
			startEvent = null;
			randomizeSpawnPointSet = false;
			GameParametersCurrent = null;
		}

		private bool TryLoading()
		{
			usedSpawnPointsCache = new HashSet<Vec3Int>();
			MonoSingleton<TaskController>.Instance.Stop();
			MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: true);
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.3f).Then(delegate
			{
				MonoSingleton<CameraManager>.Instance.SetBackground(showLowRes: false);
				MonoSingleton<AddressableSceneLoadingManager>.Instance.ReloadMainScene();
			});
			return true;
		}

		private static bool FillShelves(PooledList<ShelfComponentInstance> shelves, ResourceInstance resource)
		{
			if (shelves.Count <= 0)
			{
				return false;
			}
			using PooledList<ShelfComponentInstance> pooledList = shelves.WherePooled((ShelfComponentInstance shelf) => shelf.CanStore(resource) && shelf.ResourcesFilter.IsValid(resource));
			bool isEnabled;
			while (pooledList.Count > 0 && resource.Amount > 0)
			{
				ShelfComponentInstance shelfComponentInstance = pooledList.PickRandom();
				int amount = resource.Amount;
				foreach (UniversalStorage item in shelfComponentInstance.AllStorage)
				{
					int t = item.StoreResourcePile(resource);
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(28, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\TravelManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Stored ");
						messageBuilder.AppendFormatted(t);
						messageBuilder.AppendLiteral(" of '");
						messageBuilder.AppendFormatted(resource.BlueprintId);
						messageBuilder.AppendLiteral("' on a shelf at ");
						messageBuilder.AppendFormatted(shelfComponentInstance.OwnerBuilding.GridDataPosition);
					}
					Log.Debug(messageBuilder);
					if (resource.Amount <= 0)
					{
						break;
					}
				}
				if (resource.Amount == amount)
				{
					pooledList.Remove(shelfComponentInstance);
					shelves.Remove(shelfComponentInstance);
				}
			}
			isEnabled = resource.Amount <= 0;
			return isEnabled;
		}

		private static bool FillStockpiles(PooledList<StockpileInstance> stockpiles, ResourceInstance resource)
		{
			if (stockpiles.Count <= 0)
			{
				return false;
			}
			using PooledList<StockpileInstance> pooledList = stockpiles.WherePooled((StockpileInstance stockpile) => stockpile.CanStore(resource) && stockpile.ResourcesFilter.IsValid(resource));
			while (pooledList.Count > 0 && resource.Amount > 0)
			{
				StockpileInstance stockpileInstance = pooledList.PickRandom();
				if (!stockpileInstance.TryStore(resource))
				{
					pooledList.Remove(stockpileInstance);
					stockpiles.Remove(stockpileInstance);
				}
			}
			return resource.Amount <= 0;
		}

		private bool FillResourceSpawnPoints(ResourceInstance resource)
		{
			while (resource.Amount > 0)
			{
				Vec3Int lhs = GetSpawnPoint(SpawnPointType.EnemyResources);
				if (lhs == Vec3Int.zero)
				{
					return false;
				}
				int num = Math.Min(resource.Amount, resource.Blueprint.StackingLimit);
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(40, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\TravelManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Stored ");
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(" of '");
					messageBuilder.AppendFormatted(resource.BlueprintId);
					messageBuilder.AppendLiteral("' at a new resource pile at ");
					messageBuilder.AppendFormatted(lhs);
				}
				Log.Debug(messageBuilder);
				MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resource.Clone(num), lhs.ToVector3World());
				resource.Sub(num);
			}
			return true;
		}

		private void InitSpawnPointIndices()
		{
			spawnPointsIndex = new Dictionary<SpawnPointType, int>();
			foreach (SpawnPointType value in Enum.GetValues(typeof(SpawnPointType)))
			{
				spawnPointsIndex.Add(value, 0);
			}
		}

		private static Vec3Int GetSpawnPositionFloodFill(Vec3Int desiredPosition, int spawnRange, HashSet<Vec3Int> usedSpawnPoints)
		{
			VillageMap villageMap = VillageManager.ActiveVillage.Map;
			FloodFillUtil.FloodFillConnections(villageMap, desiredPosition, spawnRange, delegate(MapNode mapNode)
			{
				if (mapNode == null)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (mapNode.WaterDepthLevel == WaterDepthLevel.High || mapNode.WaterDepthLevel == WaterDepthLevel.Medium)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				GridDataType dataType = mapNode.DataType;
				if ((dataType & GridDataType.PlantMapResource) == GridDataType.PlantMapResource)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if ((dataType & GridDataType.ResourcePile) != GridDataType.None)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (dataType.HasFlag(GridDataType.ProductionBuilding) || dataType.HasFlag(GridDataType.Furniture) || dataType.HasFlag(GridDataType.Roof) || dataType.HasFlag(GridDataType.OthersUnfinished) || dataType.HasFlag(GridDataType.FurnitureGate) || dataType.HasFlag(GridDataType.Stairs) || dataType.HasFlag(GridDataType.Trap) || dataType.HasFlag(GridDataType.Grave))
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if ((dataType & GridDataType.BuildingUnfinished) == GridDataType.BuildingUnfinished)
				{
					BaseBuildingInstance building = mapNode.Map.BuildingsManagerMain.GetBuilding(mapNode.Position, ConstructionPhase.Foundation);
					if (building != null && building.BuildingType != BuildingType.Floor)
					{
						return FloodFillUtil.ScanStatus.Continue;
					}
				}
				if ((dataType & GridDataType.BuildingFinished) == GridDataType.BuildingFinished)
				{
					BaseBuildingInstance building2 = mapNode.Map.BuildingsManagerMain.GetBuilding(mapNode.Position, ConstructionPhase.Finished);
					if (building2 != null && !building2.Blueprint.BuildingType.HasFlag(BuildingType.Floor) && !building2.Blueprint.BuildingType.HasFlag(BuildingType.Beam))
					{
						return FloodFillUtil.ScanStatus.Continue;
					}
					desiredPosition = mapNode.Position;
					return FloodFillUtil.ScanStatus.Abort;
				}
				Vec3Int vec3Int = mapNode.Position + Vec3Int.down;
				if (mapNode.IsLayerRamp())
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				MapNode node = villageMap.GetNode(vec3Int);
				if (node == null || node.IsLayerRamp())
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (!MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int))
				{
					BaseBuildingInstance building3 = mapNode.Map.BuildingsManagerMain.GetBuilding(vec3Int, ConstructionPhase.Finished);
					if (building3 == null)
					{
						return FloodFillUtil.ScanStatus.Continue;
					}
					if (!building3.Blueprint.IsWallTypeBuildingWithVerticalStability())
					{
						return FloodFillUtil.ScanStatus.Continue;
					}
				}
				if (mapNode.VoxelType != null)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (usedSpawnPoints.Contains(mapNode.Position))
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				desiredPosition = mapNode.Position;
				return FloodFillUtil.ScanStatus.Abort;
			});
			usedSpawnPoints.Add(desiredPosition);
			return desiredPosition;
		}
	}
}
