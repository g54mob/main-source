using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Ionic.Crc;
using Ionic.Zip;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI;
using NSMedieval.Controllers;
using NSMedieval.Dictionary;
using NSMedieval.GameDifficulty;
using NSMedieval.GameEventSystem;
using NSMedieval.Heraldry;
using NSMedieval.InfoMessages;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.MovableBuildings;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.Roles;
using NSMedieval.Serialization;
using NSMedieval.Stockpiles;
using NSMedieval.Structs;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI.Statistic;
using NSMedieval.UI.Utils;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Weather;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.State
{
	public class VillageSaveData : ZipSaveData
	{
		[Serializable]
		[FVSerializableKey("Data", "")]
		private sealed class Data : IFVSerializable
		{
			[SerializeField]
			private string name;

			[SerializeField]
			private string folderName;

			[SerializeField]
			private string createdOnGameVersion;

			[SerializeField]
			private string modifiedOnGameVersion;

			[SerializeField]
			private NSMedieval.Model.MapNew.Map mapBlueprint;

			[SerializeField]
			private string mapSizeID;

			[SerializeField]
			private Vec3Int mapSize;

			[SerializeField]
			private MapSize mapSizeInstance;

			[SerializeField]
			private string mapTypeID;

			[SerializeField]
			private string mapSeed;

			[SerializeField]
			private WorldDate dateAndTime;

			[SerializeField]
			private List<HumanoidInstance> mapWorkers = new List<HumanoidInstance>();

			[SerializeField]
			private List<HumanoidInstance> mapNPCs = new List<HumanoidInstance>();

			[SerializeField]
			private List<CommanderAgentBase> commanderAICommanders = new List<CommanderAgentBase>();

			[SerializeField]
			private List<SiegeWeaponComponentInstance> siegeWeapons = new List<SiegeWeaponComponentInstance>();

			[SerializeField]
			private List<ActiveRaidInfo> raids = new List<ActiveRaidInfo>();

			[SerializeField]
			private LastRaidInfo lastRaidInfo = new LastRaidInfo();

			[SerializeField]
			private List<AnimalInstance> animals;

			[SerializeField]
			private StringKeyPair animalSpawnValue = new StringKeyPair();

			[SerializeField]
			private VillageInstance playerVillage;

			[SerializeField]
			private bool firstEnter = true;

			[SerializeField]
			private CameraData cameraData;

			[SerializeField]
			private byte[,,] terrainData;

			[SerializeField]
			private int waterAmountAtNewGame;

			[SerializeField]
			private StringIntDictionary minNumberOfPlants = SerializableDictionary<string, int>.CreateNew<StringIntDictionary>();

			[SerializeField]
			private StringIntDictionary minNumberOfFish = SerializableDictionary<string, int>.CreateNew<StringIntDictionary>();

			[SerializeField]
			private List<string> globalActiveWorkerEffectors = new List<string>();

			[SerializeField]
			private List<ResearchNodeInstance> researchedNodes = new List<ResearchNodeInstance>();

			[SerializeField]
			private List<string> unlockedItems = new List<string>();

			[SerializeField]
			private List<WeatherEventInstance> scheduledWeatherEvents = new List<WeatherEventInstance>();

			[SerializeField]
			private WeatherOverrides weatherOverrides = new WeatherOverrides();

			[SerializeField]
			private SerializableStringIntListDictionary weatherEventsHourly = SerializableDictionary<string, List<int>>.CreateNew<SerializableStringIntListDictionary>();

			[SerializeField]
			private bool temperatureFirstInitDone;

			[SerializeField]
			private float[] temperatureHourly;

			[SerializeField]
			private List<GameEventInstance> activeGameEvents = new List<GameEventInstance>();

			[SerializeField]
			private List<NewsData> activeNews = new List<NewsData>();

			[SerializeField]
			private UniqueIdProvider notificationIdProvider = new UniqueIdProvider();

			[SerializeField]
			private StringLongDictionary scheduledGameEvents = SerializableDictionary<string, long>.CreateNew<StringLongDictionary>();

			[SerializeField]
			private StringIntDictionary daysPastSinceEvent = SerializableDictionary<string, int>.CreateNew<StringIntDictionary>();

			[SerializeField]
			private StringBoolDictionary seenBuildings = SerializableDictionary<string, bool>.CreateNew<StringBoolDictionary>();

			[SerializeField]
			private EventInteractionTypeFloatDictionary interactionTypeGlobalChance = SerializableDictionary<EventInteractionType, float>.CreateNew<EventInteractionTypeFloatDictionary>();

			[SerializeField]
			private List<GameplayTipsSchedule> gameplayTipsSchedule = new List<GameplayTipsSchedule>();

			[SerializeField]
			private bool lastEventWasSiege;

			[SerializeField]
			private bool lastSiegeSucceeded;

			[SerializeField]
			private int siegeComebackCount;

			[SerializeField]
			private GameParametersInstance gameParametersCurrent;

			[SerializeField]
			private bool researchTableBuilt;

			[SerializeField]
			private bool mapTableBuilt;

			[SerializeField]
			private Scenario scenario;

			[SerializeField]
			private List<GraphData> statisticsGraphs;

			[SerializeField]
			private List<HistoryEntry> historyEntries;

			[SerializeField]
			private StatisticData statisticData;

			[SerializeField]
			private float selectedLayer = -1f;

			[SerializeField]
			private bool roofsVisible = true;

			[SerializeField]
			private bool cameraLockedToLayer;

			[SerializeField]
			private int lockedLayerIndex;

			[SerializeField]
			private bool roomsVisible;

			[SerializeField]
			private int heatmapVisible;

			[SerializeField]
			private bool treesVisible = true;

			[SerializeField]
			private bool zoneGridVisible;

			[SerializeField]
			private bool resourceIndicatorsVisible = true;

			[SerializeField]
			private bool resourceGroupsVisible;

			[SerializeField]
			private HashSet<string> existingResources;

			[SerializeField]
			private List<MoveBuildingInfo> moveBuildingInfos = new List<MoveBuildingInfo>();

			[SerializeField]
			private Dictionary<string, float> plantsGrowValue = new Dictionary<string, float>();

			[SerializeField]
			private Dictionary<string, float> fishGrowValue = new Dictionary<string, float>();

			[SerializeField]
			private HashSet<string> animalPlacementEnabled = new HashSet<string>();

			[SerializeField]
			private HashSet<string> almanacEntriesShown = new HashSet<string>();

			[SerializeField]
			private UniqueIdData uniqueIdData = new UniqueIdData();

			[SerializeField]
			private byte[] groundStabilityArray;

			[SerializeField]
			private Queue<QueuedStabilityCalculationInfo> blueprintStabilityCalculationQueue = new Queue<QueuedStabilityCalculationInfo>();

			[SerializeField]
			private Queue<QueuedStabilityCalculationInfo> finishedStabilityCalculationQueue = new Queue<QueuedStabilityCalculationInfo>();

			[SerializeField]
			private Queue<BaseBuildingInstance> destructionQueue = new Queue<BaseBuildingInstance>();

			[SerializeField]
			private HashSet<Vec3Int> toVisitFinished = new HashSet<Vec3Int>();

			[SerializeField]
			private HashSet<Vec3Int> toVisitBlueprint = new HashSet<Vec3Int>();

			[SerializeField]
			private List<ShelfCopySettingsData> shelfCopyData = new List<ShelfCopySettingsData>();

			[SerializeField]
			private List<FuelConsumerCopySettingsData> fuelConsumerCopyData = new List<FuelConsumerCopySettingsData>();

			[SerializeField]
			private List<SiegeWeaponCopySettingsData> siegeWeaponCopySettingsData = new List<SiegeWeaponCopySettingsData>();

			[SerializeField]
			private IWorldMapPlaceReference worldMapPlaceReference;

			[SerializeField]
			private SecondMapLeaveOutcome secondMapLeaveOutcome;

			[SerializeField]
			private int secondMapTimeoutElapsedHours;

			[SerializeField]
			private int timeoutWarningRemainingMinutes;

			[SerializeField]
			private string secondMapId;

			[SerializeField]
			private HashSet<string> shownRoomBuildWarnings = new HashSet<string>();

			private PlayerTriggeredEventSaveData playerTriggeredEventSaveData = new PlayerTriggeredEventSaveData();

			private RolesSaveData rolesSaveData = new RolesSaveData();

			[NonSerialized]
			private bool mapBlueprintReloaded;

			public List<string> GlobalActiveWorkerEffectors => globalActiveWorkerEffectors;

			public List<HumanoidInstance> Workers => mapWorkers;

			public List<HumanoidInstance> NPCs => mapNPCs ?? (mapNPCs = new List<HumanoidInstance>());

			public List<CommanderAgentBase> CommanderAICommanders => commanderAICommanders ?? (commanderAICommanders = new List<CommanderAgentBase>());

			public List<SiegeWeaponComponentInstance> SiegeWeapons => siegeWeapons;

			public VillageInstance PlayerVillage => playerVillage;

			public IWorldMapPlaceReference WorldMapPlaceReference
			{
				get
				{
					return worldMapPlaceReference;
				}
				set
				{
					worldMapPlaceReference = value;
				}
			}

			public bool LastEventWasSiege
			{
				get
				{
					return lastEventWasSiege;
				}
				set
				{
					lastEventWasSiege = value;
				}
			}

			public bool LastSiegeSucceeded
			{
				get
				{
					return lastSiegeSucceeded;
				}
				set
				{
					lastSiegeSucceeded = value;
				}
			}

			public int SiegeComebackCount
			{
				get
				{
					return siegeComebackCount;
				}
				set
				{
					siegeComebackCount = value;
				}
			}

			public GameParametersInstance GameParametersCurrent
			{
				get
				{
					return gameParametersCurrent;
				}
				set
				{
					gameParametersCurrent = value;
				}
			}

			public List<ActiveRaidInfo> Raids => raids;

			public LastRaidInfo LastRaidInfo
			{
				get
				{
					if (lastRaidInfo == null)
					{
						Log.Warning("Last raid info not found in save, creating one.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
						lastRaidInfo = new LastRaidInfo();
						lastRaidInfo.FirstRaid = true;
						lastRaidInfo.Reset();
					}
					return lastRaidInfo;
				}
			}

			public StringKeyPair AnimalSpawnValue => animalSpawnValue;

			public NSMedieval.Model.MapNew.Map MapBlueprint
			{
				get
				{
					if (!mapBlueprintReloaded)
					{
						mapBlueprintReloaded = true;
						if (mapBlueprint != null)
						{
							mapBlueprint = Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID(mapBlueprint.GetID());
						}
						else
						{
							mapBlueprint = Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID(mapTypeID);
						}
						if (mapBlueprint == null)
						{
							bool isEnabled;
							FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("There is no mapBlueprint for ID ");
								messageBuilder.AppendFormatted(mapTypeID);
								messageBuilder.AppendLiteral(", defaulting to map_type_valley");
							}
							Log.Error(messageBuilder);
							mapBlueprint = Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetByID("map_type_valley");
						}
					}
					return mapBlueprint;
				}
			}

			public string MapSizeID => mapSizeID;

			public Vec3Int MapSize => mapSize;

			public string MapTypeID => mapTypeID;

			public string MapSeed => mapSeed;

			public string ProfileName => name;

			public string FolderName
			{
				get
				{
					return folderName;
				}
				set
				{
					folderName = value;
				}
			}

			public WorldDate DateAndTime
			{
				get
				{
					return dateAndTime;
				}
				set
				{
					dateAndTime = value;
				}
			}

			public bool FirstEnter => firstEnter;

			public CameraData CameraData => cameraData;

			public byte[,,] TerrainData => terrainData;

			public int WaterAmountAtNewGame
			{
				get
				{
					return waterAmountAtNewGame;
				}
				set
				{
					waterAmountAtNewGame = value;
				}
			}

			public Dictionary<string, int> MinNumberOfPlants
			{
				get
				{
					if (minNumberOfPlants == null)
					{
						minNumberOfPlants = SerializableDictionary<string, int>.CreateNew<StringIntDictionary>();
					}
					return minNumberOfPlants.Dictionary;
				}
			}

			public Dictionary<string, int> MinNumberOfFish
			{
				get
				{
					if (minNumberOfFish == null)
					{
						minNumberOfFish = SerializableDictionary<string, int>.CreateNew<StringIntDictionary>();
					}
					return minNumberOfFish.Dictionary;
				}
			}

			public Dictionary<string, long> ScheduledGameEvents
			{
				get
				{
					if (scheduledGameEvents == null)
					{
						scheduledGameEvents = SerializableDictionary<string, long>.CreateNew<StringLongDictionary>();
					}
					return scheduledGameEvents.Dictionary;
				}
			}

			public Dictionary<string, int> DaysPastSinceEvent
			{
				get
				{
					if (daysPastSinceEvent == null)
					{
						daysPastSinceEvent = SerializableDictionary<string, int>.CreateNew<StringIntDictionary>();
					}
					return daysPastSinceEvent.Dictionary;
				}
			}

			public Dictionary<string, bool> SeenBuildings
			{
				get
				{
					if (seenBuildings == null)
					{
						seenBuildings = SerializableDictionary<string, bool>.CreateNew<StringBoolDictionary>();
					}
					return seenBuildings.Dictionary;
				}
			}

			public Dictionary<EventInteractionType, float> InteractionTypeGlobalChance
			{
				get
				{
					if (interactionTypeGlobalChance == null)
					{
						interactionTypeGlobalChance = SerializableDictionary<EventInteractionType, float>.CreateNew<EventInteractionTypeFloatDictionary>();
					}
					return interactionTypeGlobalChance.Dictionary;
				}
			}

			public Dictionary<string, List<int>> WeatherEventsHourly
			{
				get
				{
					if (weatherEventsHourly == null)
					{
						weatherEventsHourly = SerializableDictionary<string, List<int>>.CreateNew<SerializableStringIntListDictionary>();
					}
					return weatherEventsHourly.Dictionary;
				}
				set
				{
					WeatherEventsHourly.Clear();
					foreach (KeyValuePair<string, List<int>> item in value)
					{
						WeatherEventsHourly.Add(item.Key, item.Value);
					}
				}
			}

			public SerializableStringIntListDictionary WeatherEventsHourlySerializable
			{
				get
				{
					if (weatherEventsHourly == null)
					{
						weatherEventsHourly = SerializableDictionary<string, List<int>>.CreateNew<SerializableStringIntListDictionary>();
					}
					return weatherEventsHourly;
				}
			}

			public float[] TemperatureHourly
			{
				get
				{
					return temperatureHourly;
				}
				set
				{
					temperatureHourly = value;
				}
			}

			public bool TemperatureFirstInitDone
			{
				get
				{
					return temperatureFirstInitDone;
				}
				set
				{
					temperatureFirstInitDone = value;
				}
			}

			public List<ResearchNodeInstance> ResearchNodes => researchedNodes;

			public List<string> UnlockedItems => unlockedItems;

			public List<WeatherEventInstance> ScheduledWeatherEvents
			{
				get
				{
					return scheduledWeatherEvents;
				}
				set
				{
					scheduledWeatherEvents = value;
				}
			}

			public WeatherOverrides WeatherOverrides
			{
				get
				{
					return weatherOverrides;
				}
				set
				{
					weatherOverrides = value;
				}
			}

			public List<GameEventInstance> ActiveGameEvents
			{
				get
				{
					return activeGameEvents ?? (activeGameEvents = new List<GameEventInstance>());
				}
				set
				{
					activeGameEvents = value;
				}
			}

			public List<NewsData> ActiveNews => activeNews ?? (activeNews = new List<NewsData>());

			public UniqueIdProvider NotificationIdProvider => notificationIdProvider ?? (notificationIdProvider = new UniqueIdProvider());

			public UniqueIdData UniqueIdData => uniqueIdData;

			public string CreatedOnGameVersion => createdOnGameVersion;

			public string ModifiedOnGameVersion => modifiedOnGameVersion;

			public List<GameplayTipsSchedule> GameplayTipsSchedule
			{
				get
				{
					return gameplayTipsSchedule;
				}
				set
				{
					gameplayTipsSchedule = value;
				}
			}

			public bool ResearchTableBuilt
			{
				get
				{
					return researchTableBuilt;
				}
				set
				{
					researchTableBuilt = value;
				}
			}

			public bool MapTableBuilt
			{
				get
				{
					return mapTableBuilt;
				}
				set
				{
					mapTableBuilt = value;
				}
			}

			public Scenario Scenario
			{
				get
				{
					return scenario;
				}
				set
				{
					scenario = value;
				}
			}

			public List<GraphData> StatisticsGraphs
			{
				get
				{
					return statisticsGraphs;
				}
				set
				{
					statisticsGraphs = value;
				}
			}

			public List<HistoryEntry> HistoryEntries
			{
				get
				{
					return historyEntries;
				}
				set
				{
					historyEntries = value;
				}
			}

			public StatisticData StatisticData
			{
				get
				{
					return statisticData;
				}
				set
				{
					statisticData = value;
				}
			}

			public float SelectedLayer
			{
				get
				{
					return selectedLayer;
				}
				set
				{
					selectedLayer = value;
				}
			}

			public bool RoofsVisible
			{
				get
				{
					return roofsVisible;
				}
				set
				{
					roofsVisible = value;
				}
			}

			public bool CameraLockedToLayer
			{
				get
				{
					return cameraLockedToLayer;
				}
				set
				{
					cameraLockedToLayer = value;
				}
			}

			public int LockedLayerIndex
			{
				get
				{
					return lockedLayerIndex;
				}
				set
				{
					lockedLayerIndex = value;
				}
			}

			public int HeatmapVisible
			{
				get
				{
					return heatmapVisible;
				}
				set
				{
					heatmapVisible = value;
				}
			}

			public bool TreesVisible
			{
				get
				{
					return treesVisible;
				}
				set
				{
					treesVisible = value;
				}
			}

			public bool ZoneGridVisible
			{
				get
				{
					return zoneGridVisible;
				}
				set
				{
					zoneGridVisible = value;
				}
			}

			public bool ResourceIndicatorsVisible
			{
				get
				{
					return resourceIndicatorsVisible;
				}
				set
				{
					resourceIndicatorsVisible = value;
				}
			}

			public bool ResourceGroupsVisible
			{
				get
				{
					return resourceGroupsVisible;
				}
				set
				{
					resourceGroupsVisible = value;
				}
			}

			public List<MoveBuildingInfo> MoveBuildingInfos => moveBuildingInfos ?? (moveBuildingInfos = new List<MoveBuildingInfo>());

			public HashSet<string> ExistingResources
			{
				get
				{
					HashSet<string> hashSet = existingResources;
					if (hashSet == null)
					{
						HashSet<string> obj = new HashSet<string> { "wood" };
						HashSet<string> hashSet2 = obj;
						existingResources = obj;
						hashSet = hashSet2;
					}
					return hashSet;
				}
			}

			public Dictionary<string, float> PlantsGrowValue => plantsGrowValue;

			public Dictionary<string, float> FishGrowValue => fishGrowValue ?? (fishGrowValue = new Dictionary<string, float>());

			public PlayerTriggeredEventSaveData PlayerTriggeredEventSaveData => playerTriggeredEventSaveData;

			public RolesSaveData RolesSaveData => rolesSaveData;

			public MapSize MapSizeInstance
			{
				get
				{
					if (mapSizeInstance == null)
					{
						mapSizeInstance = Repository<MapSizeRepository, NSMedieval.Model.MapNew.MapSize>.Instance.GetByID(mapSizeID);
						if (mapSizeInstance == null)
						{
							mapSizeInstance = new MapSize(mapSizeID, MapSize.x, MapSize.y, MapSize.z, 1f);
						}
					}
					return mapSizeInstance;
				}
			}

			public List<AnimalInstance> Animals
			{
				get
				{
					if (animals == null)
					{
						animals = new List<AnimalInstance>();
					}
					return animals;
				}
			}

			public HashSet<string> AnimalPlacementEnabled
			{
				get
				{
					if (animalPlacementEnabled == null)
					{
						animalPlacementEnabled = new HashSet<string>();
					}
					return animalPlacementEnabled;
				}
			}

			public HashSet<string> AlmanacEntriesShown
			{
				get
				{
					if (almanacEntriesShown == null)
					{
						almanacEntriesShown = new HashSet<string>();
					}
					return almanacEntriesShown;
				}
			}

			public byte[] GroundStabilityArray
			{
				get
				{
					return groundStabilityArray;
				}
				set
				{
					groundStabilityArray = value;
				}
			}

			public SecondMapLeaveOutcome SecondMapLeaveOutcome
			{
				get
				{
					return secondMapLeaveOutcome;
				}
				set
				{
					secondMapLeaveOutcome = value;
				}
			}

			public int SecondMapTimeoutElapsedHours
			{
				get
				{
					return secondMapTimeoutElapsedHours;
				}
				set
				{
					secondMapTimeoutElapsedHours = value;
				}
			}

			public int TimeoutWarningRemainingMinutes
			{
				get
				{
					return timeoutWarningRemainingMinutes;
				}
				set
				{
					timeoutWarningRemainingMinutes = value;
				}
			}

			public string SecondMapId
			{
				get
				{
					return secondMapId;
				}
				set
				{
					secondMapId = value;
				}
			}

			public Queue<QueuedStabilityCalculationInfo> BlueprintStabilityCalculationQueue => blueprintStabilityCalculationQueue ?? (blueprintStabilityCalculationQueue = new Queue<QueuedStabilityCalculationInfo>());

			public Queue<QueuedStabilityCalculationInfo> FinishedStabilityCalculationQueue => finishedStabilityCalculationQueue ?? (finishedStabilityCalculationQueue = new Queue<QueuedStabilityCalculationInfo>());

			public Queue<BaseBuildingInstance> DestructionQueue => destructionQueue ?? (destructionQueue = new Queue<BaseBuildingInstance>());

			public HashSet<Vec3Int> ToVisitBlueprint => toVisitBlueprint ?? (toVisitBlueprint = new HashSet<Vec3Int>());

			public HashSet<Vec3Int> ToVisitFinished => toVisitFinished ?? (toVisitFinished = new HashSet<Vec3Int>());

			public List<ShelfCopySettingsData> ShelfCopyData => shelfCopyData ?? (shelfCopyData = new List<ShelfCopySettingsData>());

			public List<FuelConsumerCopySettingsData> FuelConsumerCopyData => fuelConsumerCopyData ?? (fuelConsumerCopyData = new List<FuelConsumerCopySettingsData>());

			public List<SiegeWeaponCopySettingsData> SiegeWeaponCopySettingsData => siegeWeaponCopySettingsData ?? (siegeWeaponCopySettingsData = new List<SiegeWeaponCopySettingsData>());

			public HashSet<string> ShownRoomBuildWarnings => shownRoomBuildWarnings;

			public Data(string villageName, string folderName)
			{
				name = villageName;
				this.folderName = folderName;
				createdOnGameVersion = Application.version;
				playerVillage = new VillageInstance();
				playerVillage.OnCreated();
				dateAndTime = new WorldDate(this);
			}

			public void AddToShownRoomBuildWarnings(string roomId)
			{
				if (shownRoomBuildWarnings == null)
				{
					shownRoomBuildWarnings = new HashSet<string>();
				}
				shownRoomBuildWarnings.Add(roomId);
			}

			public void SetResearchedNodes(List<ResearchNodeInstance> researchedNodes)
			{
				this.researchedNodes = researchedNodes;
			}

			public void SetUnlockedItems(List<string> unlockedItems)
			{
				this.unlockedItems = unlockedItems;
			}

			public void SaveGroundStability(Vec3Int gridPos, byte stability)
			{
				int num = GridDataIndexTools.FastTo1DIndex(gridPos);
				if (stability == 0)
				{
					groundStabilityArray[num] = byte.MaxValue;
				}
				else
				{
					groundStabilityArray[num] = stability;
				}
			}

			public void SaveGroundStability(int nodeIndex, byte stability)
			{
				if (stability == 0)
				{
					groundStabilityArray[nodeIndex] = byte.MaxValue;
				}
				else
				{
					groundStabilityArray[nodeIndex] = stability;
				}
			}

			public void ClearMaxStability(Vec3Int gridPos)
			{
				int num = GridDataIndexTools.FastTo1DIndex(gridPos);
				groundStabilityArray[num] = byte.MaxValue;
			}

			public void ClearMaxStability(int nodeIndex)
			{
				groundStabilityArray[nodeIndex] = byte.MaxValue;
			}

			public static implicit operator bool(Data data)
			{
				return data != null;
			}

			public void SetFirstTime(bool value)
			{
				firstEnter = value;
			}

			public void SetTerrainData(byte[,,] terrainData)
			{
				this.terrainData = terrainData;
			}

			public void SetCameraData(CameraData cameraData)
			{
				this.cameraData = cameraData;
			}

			public void OnBeforeSerialize()
			{
				modifiedOnGameVersion = Application.version;
				if (MonoSingleton<RtsCamera>.IsInstantiated())
				{
					CameraData cameraData = MonoSingleton<RtsCamera>.Instance.GetCameraData();
					if (cameraData != null)
					{
						this.cameraData = cameraData;
					}
				}
				if (MonoSingleton<WeatherManager>.IsInstantiated())
				{
					MonoSingleton<WeatherManager>.Instance.OnGameSaving();
				}
				foreach (HumanoidInstance worker in Workers)
				{
					worker.SyncAffectionToSave();
				}
				foreach (HumanoidInstance nPC in NPCs)
				{
					nPC.SyncAffectionToSave();
				}
				foreach (AnimalInstance animal in Animals)
				{
					animal.SyncAffectionToSave();
				}
			}

			public void SetMapSourceIDs(MapSize mapSize, string mapTypeID, string mapSeed)
			{
				mapSizeID = mapSize.GetID();
				this.mapTypeID = mapTypeID;
				this.mapSeed = mapSeed;
				mapSizeInstance = mapSize;
				this.mapSize = new Vec3Int(mapSize.Width, mapSize.Height, mapSize.Length);
				if (this.mapSize.magnitude == 0f)
				{
					this.mapSize = new Vec3Int(MonoSingleton<World>.Instance.SizeX, MonoSingleton<World>.Instance.SizeY, MonoSingleton<World>.Instance.SizeZ);
				}
			}

			internal void CheckDataIntegrity()
			{
			}

			private void RemoveIfNotInRepository(GridDataType gridDataType)
			{
				IEnumerable<WorldObject> worldObjects = VillageManager.ActiveVillage.Map.GetWorldObjects(gridDataType);
				if (worldObjects == null)
				{
					return;
				}
				foreach (WorldObject item in worldObjects)
				{
					if (item is BaseBuildingInstance baseBuildingInstance && !ExistsInRepository(baseBuildingInstance))
					{
						VillageManager.ActiveVillage.Map.RemoveFromWorld(baseBuildingInstance);
					}
				}
			}

			private void RemoveOldStockpiles()
			{
				IEnumerable<WorldObject> worldObjects = VillageManager.ActiveVillage.Map.GetWorldObjects(GridDataType.Stockpile);
				if (worldObjects == null)
				{
					return;
				}
				foreach (WorldObject item in worldObjects)
				{
					if (item is StockpileInstance { Positions: null } stockpileInstance)
					{
						VillageManager.ActiveVillage.Map.RemoveFromWorld(stockpileInstance);
					}
				}
			}

			private bool ExistsInRepository(BaseBuildingInstance baseBuildingInstance)
			{
				return Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID(baseBuildingInstance.BlueprintId) != null;
			}

			public void Serialize(FVSerializer serializer)
			{
				OnBeforeSerialize();
				serializer.Write("name", name);
				serializer.Write("folderName", folderName);
				serializer.Write("createdOnGameVersion", createdOnGameVersion);
				serializer.Write("modifiedOnGameVersion", modifiedOnGameVersion);
				serializer.Write("mapBlueprint", mapBlueprint);
				serializer.Write("mapSizeID", mapSizeID);
				serializer.Write("mapSize", mapSize);
				serializer.Write("mapSizeInstance", mapSizeInstance);
				serializer.Write("mapTypeID", mapTypeID);
				serializer.Write("mapSeed", mapSeed);
				serializer.Write("dateAndTime", dateAndTime);
				serializer.Write("mapWorkers", mapWorkers);
				serializer.Write("mapNPCs", mapNPCs);
				serializer.Write("siegeWeapons", siegeWeapons);
				serializer.Write("raids", raids);
				serializer.Write("lastRaidInfo", lastRaidInfo);
				serializer.Write("animals", animals);
				serializer.Write("animalSpawnValue", animalSpawnValue);
				serializer.Write("playerVillage", playerVillage);
				serializer.Write("firstEnter", firstEnter);
				serializer.Write("cameraData", cameraData);
				serializer.Write("terrainData", terrainData);
				serializer.Write("minNumberOfPlants", minNumberOfPlants);
				serializer.Write("researchedNodes", researchedNodes);
				serializer.Write("unlockedItems", unlockedItems);
				serializer.Write("scheduledWeatherEvents", scheduledWeatherEvents);
				serializer.Write("weatherEventsHourly", weatherEventsHourly);
				serializer.Write("temperatureFirstInitDone", temperatureFirstInitDone);
				serializer.Write("temperatureHourly", temperatureHourly);
				serializer.Write("activeGameEvents", activeGameEvents);
				serializer.Write("scheduledGameEvents", scheduledGameEvents);
				serializer.Write("daysPastSinceEvent", daysPastSinceEvent);
				serializer.Write("seenBuildings", seenBuildings);
				serializer.Write("interactionTypeGlobalChance", interactionTypeGlobalChance);
				serializer.Write("tutorialSchedule", gameplayTipsSchedule);
				serializer.Write("lastEventWasSiege", lastEventWasSiege);
				serializer.Write("lastSiegeSucceeded", lastSiegeSucceeded);
				serializer.Write("siegeComebackCount", siegeComebackCount);
				serializer.Write("gameDifficultyCurrent", gameParametersCurrent);
				serializer.Write("researchTableBuilt", researchTableBuilt);
				serializer.Write("mapTableBuilt", mapTableBuilt);
				serializer.Write("scenario", scenario);
				serializer.Write("statisticsGraphs", statisticsGraphs);
				serializer.Write("historyEntries", historyEntries);
				serializer.Write("statisticData", statisticData);
				serializer.Write("selectedLayer", selectedLayer);
				serializer.Write("roofsVisible", roofsVisible);
				serializer.Write("cameraLockedToLayer", cameraLockedToLayer);
				serializer.Write("lockedLayerIndex", lockedLayerIndex);
				serializer.Write("roomsVisible", roomsVisible);
				serializer.Write("heatmapVisible", heatmapVisible);
				serializer.Write("treesVisible", treesVisible);
				serializer.Write("zoneGridVisible", zoneGridVisible);
				serializer.Write("resourceIndicatorsVisible", resourceIndicatorsVisible);
				serializer.Write("resourceGroupsVisible", resourceGroupsVisible);
				serializer.Write("existingResources", existingResources);
				serializer.Write("moveBuildingInfos", moveBuildingInfos);
				serializer.Write("plantsGrowValue", plantsGrowValue);
				serializer.Write("animalPlacementEnabled", animalPlacementEnabled);
				serializer.Write("almanacEntriesShown", almanacEntriesShown);
				serializer.Write("activeNews", activeNews);
				serializer.Write("weatherOverrides", weatherOverrides);
				serializer.Write("playerTriggeredEventSaveData", playerTriggeredEventSaveData);
				serializer.Write("notificationIdProvider", notificationIdProvider);
				serializer.Write("rolesSaveData", rolesSaveData);
				serializer.Write("groundStabilityArray", groundStabilityArray);
				serializer.Write("uniqueIdData", uniqueIdData);
				serializer.Write("blueprintStabilityCalculationQueue", blueprintStabilityCalculationQueue);
				serializer.Write("finishedStabilityCalculationQueue", finishedStabilityCalculationQueue);
				serializer.Write("destructionQueue", destructionQueue);
				serializer.Write("toVisitBlueprint", toVisitBlueprint);
				serializer.Write("toVisitFinished", toVisitFinished);
				serializer.Write("shelfCopyData", shelfCopyData);
				serializer.Write("fuelConsumerCopyData", fuelConsumerCopyData);
				serializer.Write("commanderAICommanders", commanderAICommanders);
				serializer.Write("worldMapPlaceReference", worldMapPlaceReference);
				serializer.Write("secondMapTimeoutElapsedHours", secondMapTimeoutElapsedHours);
				serializer.Write("timeoutWarningRemainingMinutes", timeoutWarningRemainingMinutes);
				serializer.WriteEnum("secondMapLeaveOutcome", secondMapLeaveOutcome);
				serializer.Write("secondMapId", secondMapId);
				serializer.Write("shownRoomBuildWarnings", shownRoomBuildWarnings);
				serializer.Write("isDemo", value: false);
			}

			public Data(FVDeserializer deserializer)
			{
				bool num = (bool)deserializer.TryGetTempData("isSecondSaveLoading", false);
				deserializer.RemoveTempData("isSecondSaveLoading");
				_ = (bool)deserializer.TryGetTempData("isTutorial", false);
				deserializer.RemoveTempData("isTutorial");
				name = deserializer.ReadString("name");
				folderName = deserializer.ReadString("folderName");
				createdOnGameVersion = deserializer.ReadString("createdOnGameVersion");
				modifiedOnGameVersion = deserializer.ReadString("modifiedOnGameVersion");
				mapBlueprint = deserializer.ReadObject<NSMedieval.Model.MapNew.Map>("mapBlueprint");
				mapSizeID = deserializer.ReadString("mapSizeID");
				mapSize = deserializer.ReadVec3Int("mapSize");
				mapSizeInstance = deserializer.ReadObject<MapSize>("mapSizeInstance");
				mapTypeID = deserializer.ReadString("mapTypeID");
				mapSeed = deserializer.ReadString("mapSeed");
				dateAndTime = deserializer.ReadObject<WorldDate>("dateAndTime");
				mapWorkers = deserializer.ReadObjectList<HumanoidInstance>("mapWorkers");
				mapNPCs = deserializer.ReadObjectList<HumanoidInstance>("mapNPCs");
				siegeWeapons = deserializer.ReadObjectList("siegeWeapons", new List<SiegeWeaponComponentInstance>());
				raids = deserializer.ReadObjectList<ActiveRaidInfo>("raids");
				lastRaidInfo = deserializer.ReadObject<LastRaidInfo>("lastRaidInfo");
				animals = deserializer.ReadObjectList<AnimalInstance>("animals");
				animalSpawnValue = deserializer.ReadObject<StringKeyPair>("animalSpawnValue");
				playerVillage = deserializer.ReadObject<VillageInstance>("playerVillage");
				firstEnter = deserializer.ReadBool("firstEnter");
				cameraData = deserializer.ReadObject<CameraData>("cameraData");
				terrainData = deserializer.ReadByteArray3D("terrainData");
				minNumberOfPlants = deserializer.ReadObject<StringIntDictionary>("minNumberOfPlants");
				globalActiveWorkerEffectors = deserializer.ReadStringList("globalActiveWorkerEffectors");
				researchedNodes = deserializer.ReadObjectList<ResearchNodeInstance>("researchedNodes");
				unlockedItems = deserializer.ReadStringList("unlockedItems");
				scheduledWeatherEvents = deserializer.ReadObjectList<WeatherEventInstance>("scheduledWeatherEvents");
				weatherEventsHourly = deserializer.ReadObject<SerializableStringIntListDictionary>("weatherEventsHourly");
				temperatureFirstInitDone = deserializer.ReadBool("temperatureFirstInitDone");
				temperatureHourly = deserializer.ReadFloatArray("temperatureHourly");
				activeGameEvents = deserializer.ReadObjectList<GameEventInstance>("activeGameEvents");
				scheduledGameEvents = deserializer.ReadObject<StringLongDictionary>("scheduledGameEvents");
				daysPastSinceEvent = deserializer.ReadObject<StringIntDictionary>("daysPastSinceEvent");
				seenBuildings = deserializer.ReadObject<StringBoolDictionary>("seenBuildings");
				interactionTypeGlobalChance = deserializer.ReadObject<EventInteractionTypeFloatDictionary>("interactionTypeGlobalChance");
				gameplayTipsSchedule = deserializer.ReadObjectList<GameplayTipsSchedule>("tutorialSchedule");
				lastEventWasSiege = deserializer.ReadBool("lastEventWasSiege");
				lastSiegeSucceeded = deserializer.ReadBool("lastSiegeSucceeded");
				siegeComebackCount = deserializer.ReadInt("siegeComebackCount");
				gameParametersCurrent = deserializer.ReadObject<GameParametersInstance>("gameDifficultyCurrent");
				researchTableBuilt = deserializer.ReadBool("researchTableBuilt");
				mapTableBuilt = deserializer.ReadBool("mapTableBuilt");
				scenario = deserializer.ReadObject<Scenario>("scenario");
				statisticsGraphs = deserializer.ReadObjectList<GraphData>("statisticsGraphs");
				historyEntries = deserializer.ReadObjectList<HistoryEntry>("historyEntries");
				statisticData = deserializer.ReadObject<StatisticData>("statisticData");
				selectedLayer = deserializer.ReadFloat("selectedLayer");
				roofsVisible = deserializer.ReadBool("roofsVisible");
				cameraLockedToLayer = deserializer.ReadBool("cameraLockedToLayer");
				lockedLayerIndex = deserializer.ReadInt("lockedLayerIndex");
				roomsVisible = deserializer.ReadBool("roomsVisible");
				heatmapVisible = deserializer.ReadInt("heatmapVisible");
				treesVisible = deserializer.ReadBool("treesVisible");
				zoneGridVisible = deserializer.ReadBool("zoneGridVisible");
				resourceIndicatorsVisible = deserializer.ReadBool("resourceIndicatorsVisible");
				resourceGroupsVisible = deserializer.ReadBool("resourceGroupsVisible");
				existingResources = deserializer.ReadStringHashSet("existingResources");
				moveBuildingInfos = deserializer.ReadObjectList<MoveBuildingInfo>("moveBuildingInfos");
				plantsGrowValue = deserializer.ReadStringFloatDict("plantsGrowValue");
				animalPlacementEnabled = deserializer.ReadStringHashSet("animalPlacementEnabled");
				almanacEntriesShown = deserializer.ReadStringHashSet("almanacEntriesShown");
				activeNews = deserializer.ReadObjectList<NewsData>("activeNews");
				weatherOverrides = deserializer.ReadObject<WeatherOverrides>("weatherOverrides");
				playerTriggeredEventSaveData = deserializer.ReadObject("playerTriggeredEventSaveData", new PlayerTriggeredEventSaveData());
				notificationIdProvider = deserializer.ReadObject<UniqueIdProvider>("notificationIdProvider");
				rolesSaveData = deserializer.ReadObject("rolesSaveData", new RolesSaveData());
				uniqueIdData = deserializer.ReadObject("uniqueIdData", new UniqueIdData());
				groundStabilityArray = deserializer.ReadByteArray("groundStabilityArray");
				blueprintStabilityCalculationQueue = deserializer.ReadObjectQueue<QueuedStabilityCalculationInfo>("blueprintStabilityCalculationQueue");
				finishedStabilityCalculationQueue = deserializer.ReadObjectQueue<QueuedStabilityCalculationInfo>("finishedStabilityCalculationQueue");
				destructionQueue = deserializer.ReadObjectQueue<BaseBuildingInstance>("destructionQueue");
				toVisitBlueprint = deserializer.ReadObjectHashSet<Vec3Int>("toVisitBlueprint");
				toVisitFinished = deserializer.ReadObjectHashSet<Vec3Int>("toVisitFinished");
				shelfCopyData = deserializer.ReadObjectList<ShelfCopySettingsData>("shelfCopyData");
				fuelConsumerCopyData = deserializer.ReadObjectList<FuelConsumerCopySettingsData>("fuelConsumerCopyData");
				commanderAICommanders = deserializer.ReadObjectList<CommanderAgentBase>("commanderAICommanders");
				worldMapPlaceReference = deserializer.ReadObject<IWorldMapPlaceReference>("worldMapPlaceReference");
				secondMapTimeoutElapsedHours = deserializer.ReadInt("secondMapTimeoutElapsedHours");
				timeoutWarningRemainingMinutes = deserializer.ReadInt("timeoutWarningRemainingMinutes");
				secondMapLeaveOutcome = deserializer.ReadEnum("secondMapLeaveOutcome", SecondMapLeaveOutcome.LeftWithoutEngagingEnemy);
				secondMapId = deserializer.ReadString("secondMapId");
				shownRoomBuildWarnings = deserializer.ReadStringHashSet("shownRoomBuildWarnings", new HashSet<string>());
				if (!num)
				{
					MigrateGameDifficulty();
					MigrateGameplayTipsSchedule();
				}
			}

			private void MigrateGameDifficulty()
			{
				if (ApplicationVersionUtils.CompareVersion(ModifiedOnGameVersion, "0.28.0") >= 0)
				{
					return;
				}
				HashSet<string> hashSet = new HashSet<string> { "thundertstormEvent", "blightEvent", "animalRaidEvent", "animalDomesticSingleEvent", "hailstormEvent", "coldsnapEvent", "heatwaveEvent", "enemyRaidEvent", "useSeeds", "enemiesHaveTrebuchet" };
				HashSet<SerializableIdValuePair> hashSet2 = new HashSet<SerializableIdValuePair>();
				bool isEnabled;
				foreach (string key in gameParametersCurrent.OptionsDictionary.Dictionary.Keys)
				{
					if (!hashSet.Contains(key) || gameParametersCurrent.GetById(key) < 1f)
					{
						continue;
					}
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(23, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Found game parameter ");
						messageBuilder.AppendFormatted(key);
						messageBuilder.AppendLiteral(", ");
						messageBuilder.AppendFormatted(gameParametersCurrent.GetById(key));
					}
					Log.Debug(messageBuilder);
					SerializableIdValuePair[] defaultGameParameters = Repository<ScenarioRepository, Scenario>.Instance.GetDefaultGameParameters();
					foreach (SerializableIdValuePair serializableIdValuePair in defaultGameParameters)
					{
						if (!(serializableIdValuePair.Id != key))
						{
							hashSet2.Add(serializableIdValuePair);
						}
					}
				}
				foreach (SerializableIdValuePair item in hashSet2)
				{
					FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(46, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Migrating old GameDifficulty option ");
						messageBuilder2.AppendFormatted(item.Id);
						messageBuilder2.AppendLiteral(" from ");
						messageBuilder2.AppendFormatted(gameParametersCurrent.GetById(item.Id));
						messageBuilder2.AppendLiteral(" to ");
						messageBuilder2.AppendFormatted(item.Value);
					}
					Log.Info(messageBuilder2);
					gameParametersCurrent.SetById(item.Id, item.Value);
				}
			}

			public void MigrateGameplayTipsSchedule()
			{
				if (!this.gameplayTipsSchedule.Any((GameplayTipsSchedule gts) => string.IsNullOrEmpty(gts.TipId)))
				{
					return;
				}
				List<GameplayTipsSchedule> source = new List<GameplayTipsSchedule>(this.gameplayTipsSchedule);
				this.gameplayTipsSchedule.Clear();
				foreach (GameplayTipsScheduler item in Repository<GameplayTipsScheduleRepository, GameplayTipsScheduler>.Instance.GetAllItems())
				{
					GameplayTipsSchedule gameplayTipsSchedule = new GameplayTipsSchedule(item.GetID(), item.DisplayHour, item.TipId, item.SkipIfTutorialCompleted);
					this.gameplayTipsSchedule.Add(gameplayTipsSchedule);
					GameplayTipsSchedule gameplayTipsSchedule2 = source.FirstOrDefault((GameplayTipsSchedule sch) => sch.TipNotificationId.Equals(item.GetID()));
					if (gameplayTipsSchedule2 != null && gameplayTipsSchedule2.IsShown)
					{
						gameplayTipsSchedule.SetTipShown();
					}
				}
			}
		}

		[Serializable]
		private sealed class SaveInfo
		{
			[SerializeField]
			private string createdOnVersion;

			[SerializeField]
			private string modifiedOnVersion;

			public string CreatedOnVersion => createdOnVersion;

			public string ModifiedOnVersion => modifiedOnVersion;

			public SaveInfo(string createdOnVersion, string modifiedOnVersion)
			{
				this.modifiedOnVersion = modifiedOnVersion;
				this.createdOnVersion = createdOnVersion;
			}
		}

		public const string UserDataDirectory = "UserData";

		public static readonly string TempHeraldryDirectory = "UserData/Heraldry";

		public static readonly string CustomScenarioDirectory = "UserData/Scenarios";

		public const string SaveEntryMapNodes = "MapNodes.bin";

		public const string SaveEntryWorldObjects = "WorldObjects.bin";

		private const string SaveEntryVillageSaveData = "VillageSaveData.json";

		private const string SaveEntryDataReferenceMap = "DataReferences.bin";

		private const string SaveEntryWorldMap = "WorldMap.json";

		private const string SaveEntryWorldReferenceMap = "WorldReferences.bin";

		private const string SaveEntryWorldMapTerrain = "WorldMapTerrain.bin";

		private const string SaveInfoData = "SaveInfo.json";

		private const string MetaDataSaveInfo = "save.meta";

		private const string SaveEntryTemperature = "MapTemperature.bin";

		private const string SaveEntrySnowGrassWetness = "SnowGrassWet.bin";

		private const string SaveEntryWater = "Water.bin";

		private const string SaveEntryFire = "Fire.bin";

		private const string SecondMapDirectory = "SecondMap/";

		private static readonly string[] VillageSaveDataFiles = new string[2] { "MapNodes.bin", "WorldObjects.bin" };

		private const string SaveEntryHeraldry = "Heraldry.json";

		public const string SaveEntryHeraldryPattern = "HeraldryPattern.png";

		public const string SaveEntryHeraldryCrest = "HeraldryCrest.png";

		private static readonly string HeraldryPatternTemp = TempHeraldryDirectory + "/HeraldryPattern.png";

		private static readonly string HeraldryCrestTemp = TempHeraldryDirectory + "/HeraldryCrest.png";

		public static readonly string HeraldryJsonTemp = TempHeraldryDirectory + "/TempHeraldry.json";

		private static readonly string[] SaveMustContainFiles = new string[3] { "VillageSaveData.json", "WorldMap.json", "WorldMapTerrain.bin" };

		private Data data;

		private WorldMapData worldMapData;

		private Dictionary<int, HumanoidInstance> workersById;

		private bool workersByIdInitialized;

		private string fileName;

		private string folderName;

		public Texture2D MapMaskTexture;

		public Texture2D EffectMaskTexture;

		private bool isSecondMap;

		private bool isSecondMapFirstTime;

		public byte[] HeightmapData { get; set; }

		public byte[] HeightmapDataNoPassthroughFloors { get; set; }

		public string FileName => fileName;

		public string Name => ProfileData.ProfileName;

		public string FolderName => ProfileData.FolderName;

		public NSMedieval.Model.MapNew.Map MapBlueprint => ProfileData.MapBlueprint;

		public WorldDate DateAndTime => ProfileData.DateAndTime;

		public VillageInstance PlayerVillage => ProfileData.PlayerVillage;

		public List<HumanoidInstance> Workers => ProfileData.Workers;

		public List<HumanoidInstance> NPCs => ProfileData.NPCs;

		public List<SiegeWeaponComponentInstance> SiegeWeapons => ProfileData.SiegeWeapons;

		public List<CommanderAgentBase> CommanderAICommanders => ProfileData.CommanderAICommanders;

		public WorldMapPlace WorldMapPlace
		{
			get
			{
				if (!IsSecondMap)
				{
					return WorldMapData.PlayerVillagePlace;
				}
				return ProfileData.WorldMapPlaceReference?.Value;
			}
		}

		public IWorldMapPlaceReference WorldMapPlaceReference => ProfileData.WorldMapPlaceReference;

		public bool LastSiegeSucceeded
		{
			get
			{
				return ProfileData.LastSiegeSucceeded;
			}
			set
			{
				ProfileData.LastSiegeSucceeded = value;
			}
		}

		public bool LastEventWasSiege
		{
			get
			{
				return ProfileData.LastEventWasSiege;
			}
			set
			{
				ProfileData.LastEventWasSiege = value;
			}
		}

		public int SiegeComebackCount
		{
			get
			{
				return ProfileData.SiegeComebackCount;
			}
			set
			{
				ProfileData.SiegeComebackCount = value;
			}
		}

		public Scenario Scenario
		{
			get
			{
				return ProfileData.Scenario;
			}
			set
			{
				ProfileData.Scenario = value;
			}
		}

		public List<GraphData> StatisticsGraphs
		{
			get
			{
				return ProfileData.StatisticsGraphs;
			}
			set
			{
				ProfileData.StatisticsGraphs = value;
			}
		}

		public GameParametersInstance GameParametersCurrent
		{
			get
			{
				if (ProfileData.GameParametersCurrent == null)
				{
					Log.Info("GameParameters are not set properly. Setting it to \"blueprint_scenario\" default preset", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
					ProfileData.GameParametersCurrent = new GameParametersInstance(Repository<ScenarioRepository, Scenario>.Instance.GetDefaultGameParameters());
				}
				return ProfileData.GameParametersCurrent;
			}
			set
			{
				ProfileData.GameParametersCurrent = value;
			}
		}

		public List<HistoryEntry> HistoryEntries
		{
			get
			{
				return ProfileData.HistoryEntries;
			}
			set
			{
				ProfileData.HistoryEntries = value;
			}
		}

		public StatisticData StatisticData
		{
			get
			{
				return ProfileData.StatisticData;
			}
			set
			{
				ProfileData.StatisticData = value;
			}
		}

		public float SelectedLayer
		{
			get
			{
				return ProfileData.SelectedLayer;
			}
			set
			{
				ProfileData.SelectedLayer = value;
			}
		}

		public bool RoofsVisible
		{
			get
			{
				return ProfileData.RoofsVisible;
			}
			set
			{
				ProfileData.RoofsVisible = value;
			}
		}

		public bool CameraLockedToLayer
		{
			get
			{
				return ProfileData.CameraLockedToLayer;
			}
			set
			{
				ProfileData.CameraLockedToLayer = value;
			}
		}

		public int LockedLayerIndex
		{
			get
			{
				return ProfileData.LockedLayerIndex;
			}
			set
			{
				ProfileData.LockedLayerIndex = value;
			}
		}

		public int HeatmapVisible
		{
			get
			{
				return ProfileData.HeatmapVisible;
			}
			set
			{
				ProfileData.HeatmapVisible = value;
			}
		}

		public bool TreesVisible
		{
			get
			{
				return ProfileData.TreesVisible;
			}
			set
			{
				ProfileData.TreesVisible = value;
			}
		}

		public bool ZoneGridVisible
		{
			get
			{
				return ProfileData.ZoneGridVisible;
			}
			set
			{
				ProfileData.ZoneGridVisible = value;
			}
		}

		public bool ResourceIndicatorsVisible
		{
			get
			{
				return ProfileData.ResourceIndicatorsVisible;
			}
			set
			{
				ProfileData.ResourceIndicatorsVisible = value;
			}
		}

		public bool ResourceGroupsVisible
		{
			get
			{
				return ProfileData.ResourceGroupsVisible;
			}
			set
			{
				ProfileData.ResourceGroupsVisible = value;
			}
		}

		public List<MoveBuildingInfo> MoveBuildingInfos => ProfileData.MoveBuildingInfos;

		public List<ActiveRaidInfo> Raids => ProfileData.Raids;

		public LastRaidInfo LastRaidInfo => ProfileData.LastRaidInfo;

		public ICollection<AnimalInstance> Animals => ProfileData.Animals;

		public int AnimalsCount => ProfileData.Animals.Count;

		public StringKeyPair AnimalSpawnValue => ProfileData.AnimalSpawnValue;

		public bool FirstEnter => ProfileData.FirstEnter;

		public CameraData CameraData => data.CameraData;

		public byte[,,] TerrainData => data.TerrainData;

		public string MapSizeID => data.MapSizeID;

		public string MapTypeID => data.MapTypeID;

		public Vec3Int MapSize => data.MapSize;

		public bool IsSecondMap => isSecondMap;

		public bool IsSecondMapThreadSafe
		{
			get
			{
				return Volatile.Read(ref isSecondMap);
			}
			set
			{
				Volatile.Write(ref isSecondMap, value);
			}
		}

		public bool IsSecondMapFirstTime => isSecondMapFirstTime;

		public WorldMapData WorldMapData => worldMapData;

		public string MapSeed => data.MapSeed;

		public Dictionary<string, int> MinNumberOfPlants => ProfileData.MinNumberOfPlants;

		public Dictionary<string, int> MinNumberOfFish => ProfileData.MinNumberOfFish;

		public Dictionary<string, long> ScheduledGameEvents => ProfileData.ScheduledGameEvents;

		public Dictionary<string, int> DaysPastSinceEvent => ProfileData.DaysPastSinceEvent;

		public Dictionary<string, bool> SeenBuildings => ProfileData.SeenBuildings;

		public Dictionary<EventInteractionType, float> InteractionTypeGlobalChance => ProfileData.InteractionTypeGlobalChance;

		public Dictionary<string, List<int>> WeatherEventsHourly
		{
			get
			{
				return ProfileData.WeatherEventsHourly;
			}
			set
			{
				ProfileData.WeatherEventsHourly = value;
			}
		}

		public SerializableStringIntListDictionary WeatherEventsHourlySerializable => ProfileData.WeatherEventsHourlySerializable;

		public float[] TemperatureHourly
		{
			get
			{
				return ProfileData.TemperatureHourly;
			}
			set
			{
				ProfileData.TemperatureHourly = value;
			}
		}

		public bool TemperatureFirstInitDone
		{
			get
			{
				return ProfileData.TemperatureFirstInitDone;
			}
			set
			{
				ProfileData.TemperatureFirstInitDone = value;
			}
		}

		public List<string> GlobalActiveWorkerEffectors => ProfileData.GlobalActiveWorkerEffectors;

		public List<WeatherEventInstance> ScheduledWeatherEvents
		{
			get
			{
				return data.ScheduledWeatherEvents;
			}
			set
			{
				data.ScheduledWeatherEvents = value;
			}
		}

		public WeatherOverrides WeatherOverrides
		{
			get
			{
				return data.WeatherOverrides;
			}
			set
			{
				data.WeatherOverrides = value;
			}
		}

		public List<GameEventInstance> ActiveGameEvents => data.ActiveGameEvents;

		public List<NewsData> ActiveNews => data.ActiveNews;

		public UniqueIdProvider NewsMessageIdProvider => data.NotificationIdProvider;

		public UniqueIdData UniqueIdData => data.UniqueIdData;

		public bool ResearchTableBuilt
		{
			get
			{
				return data.ResearchTableBuilt;
			}
			set
			{
				data.ResearchTableBuilt = value;
			}
		}

		public bool MapTableBuilt
		{
			get
			{
				return data.MapTableBuilt;
			}
			set
			{
				data.MapTableBuilt = value;
			}
		}

		public int WaterAmountAtNewGame
		{
			get
			{
				return data.WaterAmountAtNewGame;
			}
			set
			{
				data.WaterAmountAtNewGame = value;
			}
		}

		public List<GameplayTipsSchedule> GameplayTipsSchedule => ProfileData.GameplayTipsSchedule;

		public string CreatedOnGameVersion => data?.CreatedOnGameVersion;

		public string ModifiedOnGameVersion => data?.ModifiedOnGameVersion;

		public HashSet<string> ExistingResources => ProfileData.ExistingResources;

		public Dictionary<string, float> PlantsGrowValue => ProfileData.PlantsGrowValue;

		public Dictionary<string, float> FishGrowValue => ProfileData.FishGrowValue;

		public PlayerTriggeredEventSaveData PlayerTriggeredEventSaveData => ProfileData.PlayerTriggeredEventSaveData;

		public RolesSaveData RolesSaveData => ProfileData.RolesSaveData;

		public byte[] GroundStabilityArray
		{
			get
			{
				return ProfileData.GroundStabilityArray;
			}
			set
			{
				ProfileData.GroundStabilityArray = value;
			}
		}

		public SecondMapLeaveOutcome SecondMapLeaveOutcome
		{
			get
			{
				return ProfileData.SecondMapLeaveOutcome;
			}
			set
			{
				ProfileData.SecondMapLeaveOutcome = value;
			}
		}

		public int SecondMapTimeoutElapsedHours
		{
			get
			{
				return ProfileData.SecondMapTimeoutElapsedHours;
			}
			set
			{
				ProfileData.SecondMapTimeoutElapsedHours = value;
			}
		}

		public int TimeoutWarningRemainingMinutes
		{
			get
			{
				return ProfileData.TimeoutWarningRemainingMinutes;
			}
			set
			{
				ProfileData.TimeoutWarningRemainingMinutes = value;
			}
		}

		public string SecondMapId
		{
			get
			{
				return ProfileData.SecondMapId;
			}
			set
			{
				ProfileData.SecondMapId = value;
			}
		}

		public HashSet<string> ShownRoomBuildWarnings => ProfileData.ShownRoomBuildWarnings;

		public int GetFinishedStabilityCalculationQueueCount => ProfileData.FinishedStabilityCalculationQueue.Count;

		public int GetBlueprintStabilityCalculationQueueCount => ProfileData.BlueprintStabilityCalculationQueue.Count;

		public List<ShelfCopySettingsData> ShelfCopyData => ProfileData.ShelfCopyData;

		public List<FuelConsumerCopySettingsData> FuelConsumerCopySettingsData => ProfileData.FuelConsumerCopyData;

		public List<SiegeWeaponCopySettingsData> SiegeWeaponCopySettingsData => ProfileData.SiegeWeaponCopySettingsData;

		public Queue<BaseBuildingInstance> DestructionQueue => ProfileData.DestructionQueue;

		private Data ProfileData => data;

		public MapSize MapSizeInstance => data.MapSizeInstance;

		public VillageSaveData(string saveFileName, string villageName, string folderName, string rootFolderName = null)
			: base(saveFileName, folderName, rootFolderName)
		{
			fileName = saveFileName;
			this.folderName = folderName;
			if (!File.Exists(ZipFileName))
			{
				if (string.IsNullOrEmpty(villageName))
				{
					throw new Exception("villageName is null in VillageSaveData constructor.");
				}
				data = new Data(villageName, folderName);
				worldMapData = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data;
			}
		}

		public VillageSaveData(VillageSaveData originSaveData, string fileName, string folderName, string rootFolderName = null)
			: base(fileName, folderName, rootFolderName)
		{
			this.fileName = fileName;
			this.folderName = folderName;
			string text = originSaveData.data.ProfileName ?? "";
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception("ProfileName is null or empty!");
			}
			data = new Data(text, folderName);
			data.DateAndTime = originSaveData.DateAndTime;
			worldMapData = originSaveData.worldMapData;
			isSecondMap = true;
		}

		public VillageSaveData(Dictionary<string, byte[]> cachedData)
			: base(cachedData)
		{
		}

		public static bool ValidateSave(VillageSaveInfo saveInfo)
		{
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(23, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Validating save file: ");
				messageBuilder.AppendFormatted(saveInfo.FolderName);
				messageBuilder.AppendLiteral("/");
				messageBuilder.AppendFormatted(saveInfo.FileName);
			}
			Log.Info(messageBuilder);
			string absoluteSaveFilename = GlobalSaveController.GetAbsoluteSaveFilename(saveInfo.FileName, saveInfo.FolderName);
			bool isEnabled2;
			try
			{
				if (!ZipFile.IsZipFile(absoluteSaveFilename))
				{
					Log.Info("Validation failed: file is not a valid zip archive.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
					isEnabled = false;
					return isEnabled;
				}
			}
			catch (UnauthorizedAccessException)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(34, 2, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled2)
				{
					messageBuilder.AppendLiteral("Unauthorized access to save file ");
					messageBuilder.AppendFormatted(saveInfo.FolderName);
					messageBuilder.AppendLiteral("/");
					messageBuilder.AppendFormatted(saveInfo.FileName);
				}
				Log.Info(messageBuilder);
				isEnabled = false;
				return isEnabled;
			}
			ZipFile zipFile;
			try
			{
				zipFile = ZipFile.Read(absoluteSaveFilename);
				if (zipFile == null)
				{
					Log.Info("Validation failed: cannot open save file.", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
					isEnabled = false;
					return isEnabled;
				}
				string[] saveMustContainFiles = SaveMustContainFiles;
				foreach (string text in saveMustContainFiles)
				{
					if (!zipFile.ContainsEntry(text))
					{
						messageBuilder = new FVLogInfoInterpolationHandler(47, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
						if (isEnabled2)
						{
							messageBuilder.AppendLiteral("Validation failed: save does not contain file\"");
							messageBuilder.AppendFormatted(text);
							messageBuilder.AppendLiteral("\"");
						}
						Log.Info(messageBuilder);
						isEnabled = false;
						return isEnabled;
					}
				}
			}
			catch (Exception ex2)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(19, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled2)
				{
					messageBuilder.AppendLiteral("Validation failed: ");
					messageBuilder.AppendFormatted(ex2.Message);
				}
				Log.Info(messageBuilder);
				isEnabled = false;
				return isEnabled;
			}
			zipFile.Dispose();
			return true;
		}

		public void AddToShownRoomBuildWarnings(string roomId)
		{
			ProfileData.AddToShownRoomBuildWarnings(roomId);
		}

		public void EnqueueFinished(QueuedStabilityCalculationInfo info)
		{
			if (ProfileData.ToVisitFinished.Add(info.Position))
			{
				ProfileData.FinishedStabilityCalculationQueue.Enqueue(info);
			}
		}

		public void EnqueueBlueprint(QueuedStabilityCalculationInfo info)
		{
			if (ProfileData.ToVisitBlueprint.Add(info.Position))
			{
				ProfileData.BlueprintStabilityCalculationQueue.Enqueue(info);
			}
		}

		public QueuedStabilityCalculationInfo DequeueFinished()
		{
			QueuedStabilityCalculationInfo result = ProfileData.FinishedStabilityCalculationQueue.Dequeue();
			ProfileData.ToVisitFinished.Remove(result.Position);
			return result;
		}

		public QueuedStabilityCalculationInfo DequeueBlueprint()
		{
			QueuedStabilityCalculationInfo result = ProfileData.BlueprintStabilityCalculationQueue.Dequeue();
			ProfileData.ToVisitBlueprint.Remove(result.Position);
			return result;
		}

		public void SaveShelfCopyData(ShelfCopySettingsData shelfCopyData)
		{
			if (shelfCopyData != null && !ProfileData.ShelfCopyData.Any((ShelfCopySettingsData x) => x.TargetBuilding == shelfCopyData.TargetBuilding))
			{
				ProfileData.ShelfCopyData.Add(shelfCopyData);
			}
		}

		public void DeleteShelfCopyData(ShelfCopySettingsData shelfCopyData)
		{
			ProfileData.ShelfCopyData.Remove(shelfCopyData);
		}

		public void SaveFuelConsumerCopyData(FuelConsumerCopySettingsData fuelConsumerCopySettingsData)
		{
			if (fuelConsumerCopySettingsData != null && !ProfileData.FuelConsumerCopyData.Any((FuelConsumerCopySettingsData x) => x.TargetBuilding == fuelConsumerCopySettingsData.TargetBuilding))
			{
				ProfileData.FuelConsumerCopyData.Add(fuelConsumerCopySettingsData);
			}
		}

		public void DeleteFuelConsumerCopyData(FuelConsumerCopySettingsData fuelConsumerCopySettingsData)
		{
			ProfileData.FuelConsumerCopyData.Remove(fuelConsumerCopySettingsData);
		}

		public void SaveSiegeWeaponCopyData(SiegeWeaponCopySettingsData siegeWeaponCopySettingsData)
		{
			if (siegeWeaponCopySettingsData != null && !ProfileData.FuelConsumerCopyData.Any((FuelConsumerCopySettingsData x) => x.TargetBuilding == siegeWeaponCopySettingsData.TargetBuilding))
			{
				ProfileData.SiegeWeaponCopySettingsData.Add(siegeWeaponCopySettingsData);
			}
		}

		public void DeleteSiegeWeaponCopyData(SiegeWeaponCopySettingsData siegeWeaponCopySettingsData)
		{
			ProfileData.SiegeWeaponCopySettingsData.Remove(siegeWeaponCopySettingsData);
		}

		public void RemoveCopyData(BaseBuildingInstance destroyedBuilding)
		{
			ProfileData.ShelfCopyData.RemoveWhere((ShelfCopySettingsData x) => x.TargetBuilding == destroyedBuilding);
			ProfileData.FuelConsumerCopyData.RemoveWhere((FuelConsumerCopySettingsData x) => x.TargetBuilding == destroyedBuilding);
		}

		public void CheckDataIntegrity()
		{
			data.CheckDataIntegrity();
		}

		public bool Unlocked(string id)
		{
			return data.UnlockedItems.Contains(id);
		}

		public void SetMapSourceIDs(MapSize mapSize, string mapTypeID, string mapSeed)
		{
			data.SetMapSourceIDs(mapSize, mapTypeID, mapSeed);
		}

		public void SetFileName(string filename, string folderName)
		{
			fileName = filename;
			this.folderName = folderName;
			data.FolderName = folderName;
			ZipChangeFileName(filename, folderName);
		}

		public void SetFileName(string filename, string folderName, string rootFolderName)
		{
			fileName = filename;
			this.folderName = folderName;
			data.FolderName = folderName;
			SetZipFileName(filename, folderName, rootFolderName);
		}

		public void SetFolderName(string folderName)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Setting folder name to ");
				messageBuilder.AppendFormatted(folderName);
				messageBuilder.AppendLiteral(" on load.");
			}
			Log.Info(messageBuilder);
			this.folderName = folderName;
			data.FolderName = folderName;
		}

		public void SetRootFolderName(string rootFolderName)
		{
			SetZipFileName(fileName, folderName, rootFolderName);
		}

		public void SetIsSecondMap()
		{
			isSecondMap = true;
		}

		public void SetIsSecondMapFirstTime()
		{
			isSecondMapFirstTime = true;
		}

		public void AddWorker(HumanoidInstance newHumanoid)
		{
			if (ProfileData.Workers.Contains(newHumanoid))
			{
				Log.Warning("Tried to same humanoid multiple times! " + newHumanoid, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				return;
			}
			ProfileData.Workers.Add(newHumanoid);
			AddToWorkersById(newHumanoid);
		}

		public void RemoveWorker(HumanoidInstance instance)
		{
			ProfileData.Workers.Remove(instance);
			RemoveFromWorkersById(instance);
		}

		private void AddToWorkersById(HumanoidInstance humanoidInstance)
		{
			if (!workersByIdInitialized)
			{
				InitializeWorkersById();
			}
			if (!workersById.ContainsKey(humanoidInstance.UniqueId))
			{
				workersById.Add(humanoidInstance.UniqueId, humanoidInstance);
			}
		}

		private void RemoveFromWorkersById(HumanoidInstance humanoidInstance)
		{
			if (!workersByIdInitialized)
			{
				InitializeWorkersById();
			}
			if (workersById.ContainsKey(humanoidInstance.UniqueId))
			{
				workersById.Remove(humanoidInstance.UniqueId);
			}
		}

		private void InitializeWorkersById()
		{
			workersByIdInitialized = true;
			workersById = new Dictionary<int, HumanoidInstance>();
			foreach (HumanoidInstance worker in Workers)
			{
				workersById.Add(worker.UniqueId, worker);
			}
		}

		public void AddNPC(HumanoidInstance instance)
		{
			if (ProfileData.NPCs.Contains(instance))
			{
				Log.Warning("Tried to same humanoid multiple times! " + instance, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				return;
			}
			ProfileData.NPCs.Add(instance);
			AddToWorkersById(instance);
		}

		public void RemoveNPC(HumanoidInstance instance)
		{
			ProfileData.NPCs.Remove(instance);
			RemoveFromWorkersById(instance);
		}

		public bool HasRaidWithId(int id)
		{
			ActiveRaidInfo activeRaidInfo = ProfileData.Raids.Find((ActiveRaidInfo item) => item.RaidId == id);
			if (activeRaidInfo == null)
			{
				return false;
			}
			return activeRaidInfo.RaidId == id;
		}

		public void AddMinute(ushort scondsCount = 1)
		{
			ProfileData.DateAndTime.AddMinute(scondsCount);
		}

		public void SetFirstTime(bool value)
		{
			ProfileData.SetFirstTime(value);
		}

		public void SetTerrainData(byte[,,] terrainData)
		{
			ProfileData.SetTerrainData(terrainData);
		}

		public void SetGameplayTipsSchedule(List<GameplayTipsSchedule> list)
		{
			ProfileData.GameplayTipsSchedule = list;
		}

		public void SetWorldMapData(WorldMapData worldMapData)
		{
			this.worldMapData = worldMapData;
		}

		public void SetWorldMapPlaceReference(IWorldMapPlaceReference value)
		{
			ProfileData.WorldMapPlaceReference = value;
		}

		public void SetDateAndTime(WorldDate dateAndTime)
		{
			ProfileData.DateAndTime = dateAndTime;
		}

		public void SetScheduledWeatherEvents(List<WeatherEventInstance> weatherEvents)
		{
			ScheduledWeatherEvents = weatherEvents;
		}

		public void SetWeatherEventsHourly(SerializableStringIntListDictionary weatherEventsHourly)
		{
			WeatherEventsHourly = weatherEventsHourly.Dictionary;
		}

		public void SetTemperatureHourly(float[] temperatureHourly)
		{
			TemperatureFirstInitDone = true;
			TemperatureHourly = temperatureHourly;
		}

		public bool HasData()
		{
			return data != null;
		}

		public List<ResearchNodeInstance> GetUnlockedNodes()
		{
			return data.ResearchNodes;
		}

		public void SetUnlockedNodes(List<ResearchNodeInstance> researchNodes)
		{
			data.SetResearchedNodes(researchNodes);
		}

		public void AddResearchedNode(ResearchNodeInstance node)
		{
			if (data.ResearchNodes.Contains(node))
			{
				return;
			}
			data.ResearchNodes.Add(node);
			foreach (ResearchUnlock unlock in node.Blueprint.Unlocks)
			{
				AddUnlockedItem(unlock.UnlockId);
			}
		}

		public void RemoveResearchedNode(ResearchNodeInstance node)
		{
			if (!data.ResearchNodes.Contains(node))
			{
				return;
			}
			data.ResearchNodes.Remove(node);
			foreach (ResearchUnlock unlock in node.Blueprint.Unlocks)
			{
				RemoveUnlockedItem(unlock.UnlockId);
			}
		}

		public void AddUnlockedItem(string id)
		{
			if (!ProfileData.UnlockedItems.Contains(id))
			{
				data.UnlockedItems.Add(id);
			}
		}

		public void RemoveUnlockedItem(string id)
		{
			if (ProfileData.UnlockedItems.Contains(id))
			{
				data.UnlockedItems.Remove(id);
			}
		}

		public List<string> GetUnlockedItems()
		{
			return data.UnlockedItems;
		}

		public void SetUnlockedItems(List<string> unlockedItems)
		{
			data.SetUnlockedItems(unlockedItems);
		}

		public int IndexOfAnimal(AnimalInstance animal)
		{
			return ProfileData.Animals.IndexOf(animal);
		}

		public AnimalInstance GetAnimalByIndex(int index)
		{
			if (index < 0 || index >= ProfileData.Animals.Count)
			{
				return null;
			}
			return ProfileData.Animals[index];
		}

		public void AddAnimal(AnimalInstance animalInstance)
		{
			ProfileData.Animals.Add(animalInstance);
		}

		public bool RemoveAnimal(AnimalInstance animalInstance)
		{
			return ProfileData.Animals.Remove(animalInstance);
		}

		public void SetAnimalPlacementEnabled(string animalSpawnerId, bool isSpawnerEnabled)
		{
			if (isSpawnerEnabled)
			{
				if (!ProfileData.AnimalPlacementEnabled.Contains(animalSpawnerId))
				{
					ProfileData.AnimalPlacementEnabled.Add(animalSpawnerId);
				}
			}
			else if (ProfileData.AnimalPlacementEnabled.Contains(animalSpawnerId))
			{
				ProfileData.AnimalPlacementEnabled.Remove(animalSpawnerId);
			}
		}

		public bool IsAnimalPlacementEnabled(string animalSpawnerId)
		{
			return ProfileData.AnimalPlacementEnabled.Contains(animalSpawnerId);
		}

		public void SetAlmanacEntryShown(string almanacEntryId)
		{
			ProfileData.AlmanacEntriesShown.Add(almanacEntryId);
		}

		public bool IsAlmanacEntryShown(string almanacEntryId)
		{
			return ProfileData.AlmanacEntriesShown.Contains(almanacEntryId);
		}

		public void SaveGroundStability(Vec3Int gridPos, byte stability)
		{
			ProfileData.SaveGroundStability(gridPos, stability);
		}

		public void SaveGroundStability(int nodeIndex, byte stability)
		{
			ProfileData.SaveGroundStability(nodeIndex, stability);
		}

		public void ClearMaxStability(Vec3Int gridPos)
		{
			ProfileData.ClearMaxStability(gridPos);
		}

		public void ClearMaxStability(int nodeIndex)
		{
			ProfileData.ClearMaxStability(nodeIndex);
		}

		public HumanoidInstance GetWorkerByCreationID(int id)
		{
			if (!workersByIdInitialized)
			{
				InitializeWorkersById();
			}
			return workersById.GetValueOrDefault(id);
		}

		internal void DeserializeFromCache()
		{
			if (!HasCache())
			{
				Log.Error("Deserialization from cache failed. Cache is empty!", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
			}
			DebugTimer.StartTimer("DeserializeTimer");
			CacheOpen();
			data = CacheReadCustomBinMultiFile<Data>("VillageSaveData.json", "DataReferences.bin", VillageSaveDataFiles);
			worldMapData = CacheReadCustomBin<WorldMapData>("WorldMap.json", "WorldReferences.bin");
			byte[] inputData = CacheReadBytes("WorldMapTerrain.bin");
			worldMapData.ReadFromBinaryData(inputData);
			byte[] array = CacheReadBytes("MapTemperature.bin");
			if (array != null && array.Length != 0)
			{
				PlayerVillage.TemperatureBytesLoaded = array;
			}
			byte[] array2 = CacheReadBytes("SnowGrassWet.bin");
			if (array2 != null && array2.Length != 0)
			{
				PlayerVillage.SnowGrassWetDataBytesLoaded = array2;
			}
			byte[] array3 = CacheReadBytes("Water.bin");
			if (array3 != null && array3.Length != 0)
			{
				PlayerVillage.WaterDataBytes = array3;
			}
			byte[] array4 = CacheReadBytes("Fire.bin");
			if (array4 != null && array4.Length != 0)
			{
				PlayerVillage.FireDataBytes = array4;
			}
			LoadHeraldryFromCache();
			LoadTexturesFromCache();
			LoadHeightmapFromCache();
			DebugTimer.EndTimer("DeserializeTimer");
		}

		internal void Deserialize(bool isSecondSave = false, bool isTutorial = false)
		{
			ZipOpen();
			DebugTimer.StartTimer("DeserializeTimer");
			if (ZipContains(Path.Combine("SecondMap/", "VillageSaveData.json").Replace('\\', '/')))
			{
				LoadSaveFilesToCache();
				SetCustomZipFolder("SecondMap/");
				isSecondMap = true;
			}
			data = ZipReadCustomBinMultiFile<Data>("VillageSaveData.json", "DataReferences.bin", VillageSaveDataFiles, isSecondSave, isTutorial);
			if (!isSecondSave)
			{
				worldMapData = ZipReadCustomBin<WorldMapData>("WorldMap.json", "WorldReferences.bin");
				byte[] inputData = ZipReadBytes("WorldMapTerrain.bin");
				worldMapData.ReadFromBinaryData(inputData);
			}
			byte[] array = ZipReadBytes("MapTemperature.bin");
			if (array != null && array.Length != 0)
			{
				PlayerVillage.TemperatureBytesLoaded = array;
			}
			byte[] array2 = ZipReadBytes("SnowGrassWet.bin");
			if (array2 != null && array2.Length != 0)
			{
				PlayerVillage.SnowGrassWetDataBytesLoaded = array2;
			}
			byte[] array3 = ZipReadBytes("Water.bin");
			if (array3 != null && array3.Length != 0)
			{
				PlayerVillage.WaterDataBytes = array3;
			}
			byte[] array4 = ZipReadBytes("Fire.bin");
			if (array4 != null && array4.Length != 0)
			{
				PlayerVillage.FireDataBytes = array4;
			}
			if (!isSecondSave)
			{
				LoadHeraldryFromSave();
			}
			LoadTexturesFromZip();
			LoadHeightmapFromZip();
			OnAfterDeserialize();
			DebugTimer.EndTimer("DeserializeTimer");
		}

		public void OnAfterDeserialize()
		{
			if (!string.IsNullOrEmpty(data.CreatedOnGameVersion))
			{
				Log.Info("Deserialized save created on version: " + data.CreatedOnGameVersion, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
			}
			else
			{
				Log.Info("Deserialized save created on version: No version specified", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
			}
		}

		private void LoadSaveFilesToCache()
		{
			CacheOpen();
			ZipReadCustomBinMultiFileToCache("VillageSaveData.json", "DataReferences.bin", VillageSaveDataFiles);
			ZipReadCustomBinToCache("WorldMap.json", "WorldReferences.bin");
			ZipReadBytesToCache("WorldMapTerrain.bin");
			ZipReadBytesToCache("MapTemperature.bin");
			ZipReadBytesToCache("SnowGrassWet.bin");
			ZipReadBytesToCache("Water.bin");
			ZipReadBytesToCache("Fire.bin");
			ZipReadBytesToCache("Heraldry.json");
			ZipReadBytesToCache("HeraldryPattern.png");
			ZipReadBytesToCache("HeraldryCrest.png");
			ZipReadBytesToCache("mapMaskTexture.raw");
			ZipReadBytesToCache("effectMaskTexture.raw");
			ZipReadBytesToCache("heightmap.bin");
			ZipReadBytesToCache("heightmapNoPassthroughFloors.bin");
			ZipReadFolderToCache("MapChunks");
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Cached ");
				messageBuilder.AppendFormatted(base.CachedSaveData.Count);
				messageBuilder.AppendLiteral(" files to RAM.");
			}
			Log.Debug(messageBuilder);
			CacheClose();
		}

		private void LoadTexturesFromZip()
		{
			try
			{
				Vec3Int mapSize = MapSize;
				ref int x = ref mapSize.x;
				Vec3Int mapSize2 = MapSize;
				ref int y = ref mapSize2.y;
				Vec3Int mapSize3 = MapSize;
				MapGenerationTextures.GetTextureSize(in x, in y, in mapSize3.z, out var textureWidth, out var textureHeight);
				int num = textureWidth * textureHeight * 4;
				byte[] array = ZipReadBytes("mapMaskTexture.raw");
				if (array != null && num == array.Length)
				{
					MapMaskTexture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, mipChain: false);
					MapMaskTexture.LoadRawTextureData(array);
					MapMaskTexture.Apply(updateMipmaps: false);
				}
				array = ZipReadBytes("effectMaskTexture.raw");
				if (array != null && num == array.Length)
				{
					EffectMaskTexture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, mipChain: false);
					EffectMaskTexture.LoadRawTextureData(array);
					EffectMaskTexture.Apply(updateMipmaps: false);
				}
			}
			catch (Exception ex)
			{
				Log.Warning("Exception during LoadTexturesFromZip: ", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				Log.Warning(ex.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
			}
		}

		private void LoadTexturesFromCache()
		{
			try
			{
				Vec3Int mapSize = MapSize;
				ref int x = ref mapSize.x;
				Vec3Int mapSize2 = MapSize;
				ref int y = ref mapSize2.y;
				Vec3Int mapSize3 = MapSize;
				MapGenerationTextures.GetTextureSize(in x, in y, in mapSize3.z, out var textureWidth, out var textureHeight);
				int num = textureWidth * textureHeight * 4;
				byte[] array = CacheReadBytes("mapMaskTexture.raw");
				if (array != null && num == array.Length)
				{
					MapMaskTexture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, mipChain: false);
					MapMaskTexture.LoadRawTextureData(array);
					MapMaskTexture.Apply(updateMipmaps: false);
				}
				array = CacheReadBytes("effectMaskTexture.raw");
				if (array != null && num == array.Length)
				{
					EffectMaskTexture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, mipChain: false);
					EffectMaskTexture.LoadRawTextureData(array);
					EffectMaskTexture.Apply(updateMipmaps: false);
				}
			}
			catch (Exception ex)
			{
				Log.Warning("Exception during LoadTexturesFromZip: ", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				Log.Warning(ex.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
			}
		}

		private void LoadHeightmapFromZip()
		{
			HeightmapData = ZipReadBytes("heightmap.bin");
			HeightmapDataNoPassthroughFloors = ZipReadBytes("heightmapNoPassthroughFloors.bin");
		}

		private void LoadHeightmapFromCache()
		{
			HeightmapData = CacheReadBytes("heightmap.bin");
			HeightmapDataNoPassthroughFloors = CacheReadBytes("heightmapNoPassthroughFloors.bin");
		}

		internal void Serialize(bool isSecondSave = false)
		{
			FilePathUtils.CheckAndCreatePath(ZipFileName);
			ZipOpen();
			PlayerVillage.Map.BeforeSerialize();
			ZipWriteCustomBinMultiFile("VillageSaveData.json", "DataReferences.bin", VillageSaveDataFiles, data);
			PlayerVillage.Map.AfterSerialize();
			if (!isSecondSave)
			{
				worldMapData = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data;
				ZipWriteCustomBin("WorldMap.json", "WorldReferences.bin", worldMapData);
				ZipWriteBytes("WorldMapTerrain.bin", worldMapData.GetBinaryDataToSerialize());
			}
			ZipWriteBytes("SnowGrassWet.bin", PlayerVillage.Map.SnowGrassWetnessManager.GetBinaryDataToSerialize());
			ZipWriteBytes("MapTemperature.bin", PlayerVillage.Map.TemperatureManager.GetBinaryDataToSerialize());
			ZipWriteBytes("Water.bin", PlayerVillage.Map.WaterManager.WaterSimLogic.GetBinaryDataToSerialize());
			ZipWriteBytes("Fire.bin", PlayerVillage.Map.FireSimLogic.GetBinaryDataToSerialize());
			WriteInfoFileToSave();
			if (!isSecondSave)
			{
				WriteMetaData(ZipFileName, writeIntoSave: true);
			}
			MonoSingleton<World>.Instance.ChunkGenerator.SaveChunksToZip();
			MonoSingleton<GroundManager>.Instance.MapGenerationTextures.SaveTexturesToZip(this);
			MonoSingleton<Heightmap>.Instance.SaveHeightmapToZip(this);
			if (!isSecondSave)
			{
				WriteHeraldryToSave();
				DebugEventLog.FinalizeToFile(this);
			}
			if (!ZipSave())
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("save_failed"));
			}
		}

		internal void SerializeWithCache()
		{
			FilePathUtils.CheckAndCreatePath(ZipFileName);
			ZipOpen();
			ResetCustomZipFolder();
			WriteCachedSaveDataToZip();
			PlayerVillage.Map.BeforeSerialize();
			SetCustomZipFolder("SecondMap/");
			ZipWriteCustomBinMultiFile("VillageSaveData.json", "DataReferences.bin", VillageSaveDataFiles, data);
			PlayerVillage.Map.AfterSerialize();
			worldMapData = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data;
			ZipWriteCustomBin("WorldMap.json", "WorldReferences.bin", worldMapData);
			ZipWriteBytes("WorldMapTerrain.bin", worldMapData.GetBinaryDataToSerialize());
			ZipWriteBytes("SnowGrassWet.bin", PlayerVillage.Map.SnowGrassWetnessManager.GetBinaryDataToSerialize());
			ZipWriteBytes("MapTemperature.bin", PlayerVillage.Map.TemperatureManager.GetBinaryDataToSerialize());
			ZipWriteBytes("Water.bin", PlayerVillage.Map.WaterManager.WaterSimLogic.GetBinaryDataToSerialize());
			ZipWriteBytes("Fire.bin", PlayerVillage.Map.FireSimLogic.GetBinaryDataToSerialize());
			MonoSingleton<World>.Instance.ChunkGenerator.SaveChunksToZip();
			MonoSingleton<GroundManager>.Instance.MapGenerationTextures.SaveTexturesToZip(this);
			MonoSingleton<Heightmap>.Instance.SaveHeightmapToZip(this);
			WriteHeraldryToSave();
			ResetCustomZipFolder();
			WriteInfoFileToSave();
			WriteMetaData(ZipFileName, writeIntoSave: true);
			ResetCustomZipFolder();
			if (ZipSave())
			{
				DebugEventLog.FinalizeToFile(this);
			}
			else
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("save_failed"));
			}
		}

		private void WriteMetaData(string zipFileName, bool writeIntoSave)
		{
			string path = zipFileName + ".meta";
			string text = JsonUtility.ToJson(new VillageSaveMeta(this), prettyPrint: true);
			File.WriteAllText(path, text);
			if (writeIntoSave)
			{
				byte[] bytes = Encoding.ASCII.GetBytes(text);
				ZipWriteBytes("save.meta", bytes);
			}
		}

		internal void SerializeToRam()
		{
			CacheOpen();
			PlayerVillage.Map.BeforeSerialize();
			CacheWriteCustomBinMultiFile("VillageSaveData.json", "DataReferences.bin", VillageSaveDataFiles, data);
			PlayerVillage.Map.AfterSerialize();
			worldMapData = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data;
			CacheWriteCustomBin("WorldMap.json", "WorldReferences.bin", worldMapData);
			CacheWriteBytes("WorldMapTerrain.bin", worldMapData.GetBinaryDataToSerialize());
			CacheWriteBytes("SnowGrassWet.bin", PlayerVillage.Map.SnowGrassWetnessManager.GetBinaryDataToSerialize());
			CacheWriteBytes("MapTemperature.bin", PlayerVillage.Map.TemperatureManager.GetBinaryDataToSerialize());
			CacheWriteBytes("Water.bin", PlayerVillage.Map.WaterManager.WaterSimLogic.GetBinaryDataToSerialize());
			CacheWriteBytes("Fire.bin", PlayerVillage.Map.FireSimLogic.GetBinaryDataToSerialize());
			WriteInfoFileToSave();
			MonoSingleton<World>.Instance.ChunkGenerator.SaveChunksToCache();
			MonoSingleton<GroundManager>.Instance.MapGenerationTextures.SaveTexturesToCache(this);
			MonoSingleton<Heightmap>.Instance.SaveHeightmapToCache(this);
			WriteHeraldryToCache();
			if (!CacheSave())
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("save_failed"));
			}
		}

		private static string ConvertFromUtfString(string utfCodesString)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			int length = utfCodesString.Length;
			while (num < length)
			{
				int num2 = num + 1;
				char c = utfCodesString[num];
				if (num2 < length && num + 6 <= length)
				{
					char c2 = utfCodesString[num2];
					if (c == '\\' && c2 == 'u')
					{
						int utf = int.Parse(utfCodesString.Substring(num + 2, 4), NumberStyles.HexNumber);
						stringBuilder.Append(char.ConvertFromUtf32(utf));
						num += 6;
						continue;
					}
				}
				if (c != '\\')
				{
					stringBuilder.Append(c);
				}
				num++;
			}
			return stringBuilder.ToString();
		}

		public static string ReadProfileNameFromZip(string zipFilePath)
		{
			ZipFile zipFile = null;
			CrcCalculatorStream crcCalculatorStream = null;
			bool isEnabled;
			try
			{
				zipFile = ZipFile.Read(zipFilePath);
				crcCalculatorStream = zipFile["VillageSaveData.json"].OpenReader();
				byte[] array = new byte[2048];
				crcCalculatorStream.Read(array, 0, 2048);
				StringReader stringReader = new StringReader(Encoding.UTF8.GetString(array, 0, array.Length));
				string text = string.Empty;
				string text2;
				do
				{
					text2 = stringReader.ReadLine();
					if (text2 == null || string.IsNullOrEmpty(text2))
					{
						continue;
					}
					text2 = text2.Replace(",", string.Empty).Replace("\"", string.Empty).Trim();
					if (!text2.StartsWith("name:"))
					{
						continue;
					}
					text = text2.Substring(text2.LastIndexOf(":", StringComparison.CurrentCultureIgnoreCase) + 1).Trim();
					if (text.Contains("\\u"))
					{
						text = ConvertFromUtfString(text);
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Utf16 converted village name is : ");
							messageBuilder.AppendFormatted(text);
						}
						Log.Info(messageBuilder);
					}
					if (text.Length == 0 || text.Contains("\\u"))
					{
						text = "Old Saves";
					}
					break;
				}
				while (!string.IsNullOrEmpty(text2));
				crcCalculatorStream.Close();
				crcCalculatorStream = null;
				zipFile.Dispose();
				zipFile = null;
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
			}
			catch (Exception ex)
			{
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(68, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Error during reading settlement name from zip file ");
					messageBuilder2.AppendFormatted(zipFilePath);
					messageBuilder2.AppendLiteral(". Error message: ");
					messageBuilder2.AppendFormatted(ex.Message);
				}
				Log.Warning(messageBuilder2);
				crcCalculatorStream?.Close();
				zipFile?.Dispose();
			}
			return "Old Saves";
		}

		public static string ReadModifiedVersionFromZip(string zipFilePath)
		{
			ZipFile zipFile = null;
			CrcCalculatorStream crcCalculatorStream = null;
			try
			{
				string text = null;
				string text2 = null;
				zipFile = ZipFile.Read(zipFilePath);
				if (zipFile.ContainsEntry("SaveInfo.json"))
				{
					crcCalculatorStream = zipFile["SaveInfo.json"].OpenReader();
				}
				else
				{
					if (!zipFile.ContainsEntry("VillageSaveData.json"))
					{
						zipFile.Dispose();
						return "Error";
					}
					crcCalculatorStream = zipFile["VillageSaveData.json"].OpenReader();
				}
				byte[] array = new byte[2048];
				crcCalculatorStream.Read(array, 0, 2048);
				StringReader stringReader = new StringReader(Encoding.UTF8.GetString(array, 0, array.Length));
				string text3;
				do
				{
					text3 = stringReader.ReadLine();
					if (text3 == null || string.IsNullOrEmpty(text3))
					{
						continue;
					}
					text3 = text3.Replace(",", string.Empty).Replace("\"", string.Empty).Trim();
					if (text3.StartsWith("modifiedOnVersion:"))
					{
						text = text3.Substring(text3.LastIndexOf(":", StringComparison.CurrentCultureIgnoreCase) + 1).Trim();
					}
					else if (text3.StartsWith("modifiedOnGameVersion"))
					{
						text = text3.Substring(text3.LastIndexOf(":", StringComparison.CurrentCultureIgnoreCase) + 1).Trim();
					}
					else if (text3.Contains("modifiedOnGameVersion"))
					{
						text = text3.Substring(text3.LastIndexOf(":", StringComparison.CurrentCultureIgnoreCase) + 1).Trim();
					}
					else
					{
						if (!text3.Contains("createdOnGameVersion"))
						{
							continue;
						}
						text2 = text3.Substring(text3.LastIndexOf(":", StringComparison.CurrentCultureIgnoreCase) + 1).Trim();
					}
					if (text != null && text.Contains("\\u"))
					{
						text = ConvertFromUtfString(text);
						bool isEnabled;
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Utf16 converted modifiedVersion is : ");
							messageBuilder.AppendFormatted(text);
						}
						Log.Info(messageBuilder);
					}
					if (!string.IsNullOrEmpty(text) && (text.Length == 0 || text.Contains("\\u")))
					{
						text = string.Empty;
					}
					break;
				}
				while (!string.IsNullOrEmpty(text3));
				crcCalculatorStream.Close();
				crcCalculatorStream = null;
				zipFile.Dispose();
				zipFile = null;
				if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
				{
					text = text2;
				}
				return text;
			}
			catch (Exception)
			{
				crcCalculatorStream?.Close();
				zipFile?.Dispose();
				crcCalculatorStream = null;
				zipFile = null;
				return "Error";
			}
		}

		private void WriteInfoFileToSave()
		{
			string s = JsonUtility.ToJson(new SaveInfo(data.CreatedOnGameVersion, data.ModifiedOnGameVersion), prettyPrint: true);
			try
			{
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				ZipWriteBytes("SaveInfo.json", bytes);
			}
			catch (Exception ex)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error copying SaveInfoData.json to save:\n");
					messageBuilder.AppendFormatted(ex.Message);
				}
				Log.Info(messageBuilder);
				throw;
			}
		}

		public void CopyHeraldryToSave()
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder;
			if (!SavFileExists())
			{
				messageBuilder = new FVLogInfoInterpolationHandler(52, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot copy heraldry to save ");
					messageBuilder.AppendFormatted(folderName);
					messageBuilder.AppendLiteral("/");
					messageBuilder.AppendFormatted(fileName);
					messageBuilder.AppendLiteral(". File does not exist.");
				}
				Log.Info(messageBuilder);
				return;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Copying heraldry to save ");
				messageBuilder.AppendFormatted(folderName);
				messageBuilder.AppendLiteral("/");
				messageBuilder.AppendFormatted(fileName);
			}
			Log.Info(messageBuilder);
			bool flag = IsZipOpen();
			if (!flag)
			{
				ZipOpen();
			}
			try
			{
				WriteHeraldryToSave();
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
			}
			if (!flag)
			{
				if (!ZipSave())
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("save_failed"));
				}
				ZipClose();
			}
		}

		private void WriteHeraldryToSave(bool readFromDisk = false)
		{
			bool isEnabled;
			try
			{
				string heraldryJsonFromZip = FileUtils.SafeReadAllText(Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryJsonTemp));
				MonoSingleton<HeraldryManager>.Instance.SavingHeraldryToJson(ref heraldryJsonFromZip);
				ZipWriteText("Heraldry.json", heraldryJsonFromZip);
			}
			catch (Exception ex)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error copying TempHeraldry.json to save:\n");
					messageBuilder.AppendFormatted(ex.Message);
				}
				Log.Info(messageBuilder);
				throw;
			}
			try
			{
				byte[] array = null;
				byte[] array2 = null;
				if (readFromDisk)
				{
					string filePath = Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryCrestTemp).Replace("\\", "/");
					string filePath2 = Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryPatternTemp).Replace("\\", "/");
					array = HeraldryManager.ReadHeraldryFileFromDisk(filePath);
					array2 = HeraldryManager.ReadHeraldryFileFromDisk(filePath2);
				}
				else
				{
					if (MonoSingleton<HeraldryManager>.Instance.Crest != null && MonoSingleton<HeraldryManager>.Instance.Crest.sprite != null && MonoSingleton<HeraldryManager>.Instance.Crest.sprite.texture != null)
					{
						array = MonoSingleton<HeraldryManager>.Instance.Crest.sprite.texture.EncodeToPNG();
					}
					if (MonoSingleton<HeraldryManager>.Instance.Pattern != null && MonoSingleton<HeraldryManager>.Instance.Pattern.sprite != null && MonoSingleton<HeraldryManager>.Instance.Pattern.sprite.texture != null)
					{
						array2 = MonoSingleton<HeraldryManager>.Instance.Pattern.sprite.texture.EncodeToPNG();
					}
				}
				if (array != null)
				{
					ZipWriteBytes("HeraldryCrest.png", array);
				}
				if (array2 != null)
				{
					ZipWriteBytes("HeraldryPattern.png", array2);
				}
			}
			catch (Exception ex2)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(54, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error copying ");
					messageBuilder.AppendFormatted("HeraldryCrest.png");
					messageBuilder.AppendLiteral(" or ");
					messageBuilder.AppendFormatted("HeraldryPattern.png");
					messageBuilder.AppendLiteral(" from temp heraldry folder to save:\n");
					messageBuilder.AppendFormatted(ex2.Message);
				}
				Log.Info(messageBuilder);
				throw;
			}
		}

		private void WriteHeraldryToCache(bool readFromDisk = false)
		{
			bool isEnabled;
			try
			{
				byte[] array = FileUtils.SafeReadAllBytes(Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryJsonTemp));
				CacheWriteBytes("Heraldry.json", array);
			}
			catch (Exception ex)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error copying TempHeraldry.json to save:\n");
					messageBuilder.AppendFormatted(ex.Message);
				}
				Log.Info(messageBuilder);
				throw;
			}
			try
			{
				byte[] array2 = null;
				byte[] array3 = null;
				if (readFromDisk)
				{
					string filePath = Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryCrestTemp).Replace("\\", "/");
					string filePath2 = Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryPatternTemp).Replace("\\", "/");
					array2 = HeraldryManager.ReadHeraldryFileFromDisk(filePath);
					array3 = HeraldryManager.ReadHeraldryFileFromDisk(filePath2);
				}
				else
				{
					if (MonoSingleton<HeraldryManager>.Instance.Crest != null && MonoSingleton<HeraldryManager>.Instance.Crest.sprite != null && MonoSingleton<HeraldryManager>.Instance.Crest.sprite.texture != null)
					{
						array2 = MonoSingleton<HeraldryManager>.Instance.Crest.sprite.texture.EncodeToPNG();
					}
					if (MonoSingleton<HeraldryManager>.Instance.Pattern != null && MonoSingleton<HeraldryManager>.Instance.Pattern.sprite != null && MonoSingleton<HeraldryManager>.Instance.Pattern.sprite.texture != null)
					{
						array3 = MonoSingleton<HeraldryManager>.Instance.Pattern.sprite.texture.EncodeToPNG();
					}
				}
				if (array2 != null)
				{
					CacheWriteBytes("HeraldryCrest.png", array2);
				}
				if (array3 != null)
				{
					CacheWriteBytes("HeraldryPattern.png", array3);
				}
			}
			catch (Exception ex2)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(54, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error copying ");
					messageBuilder.AppendFormatted("HeraldryCrest.png");
					messageBuilder.AppendLiteral(" or ");
					messageBuilder.AppendFormatted("HeraldryPattern.png");
					messageBuilder.AppendLiteral(" from temp heraldry folder to save:\n");
					messageBuilder.AppendFormatted(ex2.Message);
				}
				Log.Info(messageBuilder);
				throw;
			}
		}

		private void LoadHeraldryFromSave()
		{
			bool isEnabled;
			try
			{
				string text = ZipReadText("Heraldry.json");
				byte[] byteArrayCrest = ZipReadBytes("HeraldryPattern.png");
				byte[] byteArrayCrest2 = ZipReadBytes("HeraldryCrest.png");
				if (string.IsNullOrEmpty(text) || byteArrayCrest == null || byteArrayCrest2 == null)
				{
					return;
				}
				string text2 = Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryPatternTemp);
				string text3 = Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryCrestTemp);
				string path = Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryJsonTemp);
				FilePathUtils.CheckAndCreatePath(Path.Combine(FileReaders.Get.GetPersistentDataPath(), TempHeraldryDirectory));
				try
				{
					File.Delete(text2);
					File.Delete(text3);
					File.Delete(path);
				}
				catch (Exception ex)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Error deleting temporary heraldry files. Error: ");
						messageBuilder.AppendFormatted(ex.Message);
					}
					Log.Info(messageBuilder);
				}
				HeraldryManager.WriteHeraldryFileToDisk(ref byteArrayCrest, text2);
				HeraldryManager.WriteHeraldryFileToDisk(ref byteArrayCrest2, text3);
				MonoSingleton<HeraldryManager>.Instance.HeraldryJsonLoaded(text);
				try
				{
					FileUtils.SafeWriteAllText(path, text);
				}
				catch (Exception ex2)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(53, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Cannot write heraldry json from save to disk. Error: ");
						messageBuilder.AppendFormatted(ex2.Message);
					}
					Log.Info(messageBuilder);
				}
			}
			catch (Exception ex3)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error copying heraldry images to disk. Error:\n");
					messageBuilder.AppendFormatted(ex3.Message);
				}
				Log.Info(messageBuilder);
				throw;
			}
		}

		private void LoadHeraldryFromCache()
		{
			bool isEnabled;
			try
			{
				byte[] array = CacheReadBytes("Heraldry.json");
				byte[] byteArrayCrest = CacheReadBytes("HeraldryPattern.png");
				byte[] byteArrayCrest2 = CacheReadBytes("HeraldryCrest.png");
				if (array == null || byteArrayCrest == null || byteArrayCrest2 == null)
				{
					return;
				}
				string text = Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryPatternTemp);
				string text2 = Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryCrestTemp);
				string path = Path.Combine(FileReaders.Get.GetPersistentDataPath(), HeraldryJsonTemp);
				FilePathUtils.CheckAndCreatePath(Path.Combine(FileReaders.Get.GetPersistentDataPath(), TempHeraldryDirectory));
				try
				{
					File.Delete(text);
					File.Delete(text2);
					File.Delete(path);
				}
				catch (Exception ex)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Error deleting temporary heraldry files. Error: ");
						messageBuilder.AppendFormatted(ex.Message);
					}
					Log.Info(messageBuilder);
				}
				HeraldryManager.WriteHeraldryFileToDisk(ref byteArrayCrest, text);
				HeraldryManager.WriteHeraldryFileToDisk(ref byteArrayCrest2, text2);
				try
				{
					FileUtils.SafeWriteAllBytes(path, array);
				}
				catch (Exception ex2)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(53, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Cannot write heraldry json from save to disk. Error: ");
						messageBuilder.AppendFormatted(ex2.Message);
					}
					Log.Info(messageBuilder);
				}
			}
			catch (Exception ex3)
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\VillageSaveData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error copying heraldry images to disk. Error:\n");
					messageBuilder.AppendFormatted(ex3.Message);
				}
				Log.Info(messageBuilder);
				throw;
			}
		}

		public void Destroy()
		{
			if (data != null)
			{
				data.PlayerVillage?.Dispose();
				data = null;
			}
		}
	}
}
