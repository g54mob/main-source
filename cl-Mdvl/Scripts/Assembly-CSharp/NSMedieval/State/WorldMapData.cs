using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Factions;
using NSMedieval.GameEventSystem;
using NSMedieval.GlobalStats;
using NSMedieval.Model;
using NSMedieval.Model.SecondMap;
using NSMedieval.Objectives;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using Objectives;
using Repository.Map;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("WorldMapData", "")]
	public class WorldMapData : IFVSerializable
	{
		private delegate bool CheckPossiblePosition(List<Vector2Int> foundPositions, Vector2Int position);

		[SerializeField]
		private SerializableVector2Int villagePosition;

		[SerializeField]
		private SerializableVector2Int worldMapResolution;

		[SerializeField]
		private List<GlobalStatInstance> globalStatInstances;

		[SerializeField]
		private ObjectiveInstance activeObjective;

		[SerializeField]
		private Dictionary<string, int> raidsWonForObjective;

		[SerializeField]
		private Dictionary<string, int> eventsEndedCount;

		[SerializeField]
		private readonly HashSet<string> unlockedRoomTypes;

		[SerializeField]
		private readonly HashSet<string> unlockedGameEvents;

		[SerializeField]
		private HashSet<string> tradeDeals;

		[SerializeField]
		private readonly Dictionary<string, int> npcsArrivedCountByEvent;

		[SerializeField]
		private readonly Dictionary<string, int> playerTriggeredEventsEndedById;

		[SerializeField]
		private Queue<bool> raidWinHistory = new Queue<bool>();

		[NonSerialized]
		private FactionGameModeSettings factionSettings;

		private bool factionSettingsInitialized;

		[SerializeField]
		private List<FactionInstance> factionInstances;

		[SerializeField]
		private List<FactionRelationInstance> factionRelations;

		[SerializeField]
		private List<CaravanInstance> caravans = new List<CaravanInstance>();

		[SerializeField]
		private HashSet<CaravanInstance> caravansInPreparation = new HashSet<CaravanInstance>();

		[SerializeField]
		private List<VillagePlace> villagePlaces;

		[SerializeField]
		private HashSet<WorldMapMarkerPlace> markers;

		[SerializeField]
		private UniqueIdProvider worldMapMarkerIdProvider = new UniqueIdProvider();

		[NonSerialized]
		private HashSet<VillagePlace> notPositioned;

		[NonSerialized]
		private HashSet<Vector2Int> availablePositions;

		[NonSerialized]
		private HashSet<FactionInstance> factionsOnMap = new HashSet<FactionInstance>();

		[NonSerialized]
		private float[,] heightmap;

		[NonSerialized]
		private byte[,] mapTypes;

		[NonSerialized]
		private PlayerVillagePlace playerVillagePlace;

		public List<VillagePlace> VillagePlaces => villagePlaces;

		public List<FactionInstance> FactionInstances => factionInstances;

		public HashSet<FactionInstance> FactionsOnMap => factionsOnMap;

		public List<GlobalStatInstance> GlobalStatInstances => globalStatInstances;

		public HashSet<string> UnlockedRoomTypes => unlockedRoomTypes;

		public HashSet<string> UnlockedGameEvents => unlockedGameEvents;

		public Dictionary<string, int> PlayerTriggeredEventsEndedById => playerTriggeredEventsEndedById;

		public UniqueIdProvider WorldMapMarkerIdProvider => worldMapMarkerIdProvider ?? (worldMapMarkerIdProvider = new UniqueIdProvider());

		public ObjectiveInstance ActiveObjective => activeObjective;

		public FactionGameModeSettings FactionSettings
		{
			get
			{
				if (!factionSettingsInitialized)
				{
					factionSettings = Repository<FactionGameModeSettingsData, FactionGameModeSettings>.Instance.GetData<FactionGameModeSettings>();
					factionSettingsInitialized = true;
				}
				return factionSettings;
			}
		}

		public PlayerVillagePlace PlayerVillagePlace
		{
			get
			{
				if (playerVillagePlace == null)
				{
					playerVillagePlace = new PlayerVillagePlace();
				}
				return playerVillagePlace;
			}
		}

		public Vector2Int VillagePosition
		{
			get
			{
				return villagePosition;
			}
			set
			{
				villagePosition = value;
			}
		}

		public Vector2Int WorldMapResolution
		{
			get
			{
				return worldMapResolution;
			}
			set
			{
				worldMapResolution = value;
			}
		}

		public float[,] Heightmap
		{
			get
			{
				return heightmap;
			}
			set
			{
				heightmap = value;
			}
		}

		public byte[,] MapTypes
		{
			get
			{
				return mapTypes;
			}
			set
			{
				mapTypes = value;
			}
		}

		public Queue<bool> RaidWinHistory => raidWinHistory;

		public List<FactionRelationInstance> FactionRelations => factionRelations;

		public HashSet<CaravanInstance> CaravansInPreparation => caravansInPreparation ?? (caravansInPreparation = new HashSet<CaravanInstance>());

		public List<CaravanInstance> Caravans
		{
			get
			{
				if (caravans == null)
				{
					caravans = new List<CaravanInstance>();
				}
				return caravans;
			}
		}

		public HashSet<WorldMapMarkerPlace> Markers => markers ?? (markers = new HashSet<WorldMapMarkerPlace>());

		public IEnumerable<HumanoidInstance> CaravanHumans
		{
			get
			{
				foreach (CaravanInstance caravanInstance in Caravans)
				{
					if (caravanInstance?.Workers != null)
					{
						foreach (HumanoidInstance worker in caravanInstance.Workers)
						{
							if (worker != null)
							{
								yield return worker;
							}
						}
					}
					if (caravanInstance == null || caravanInstance.Creatures == null)
					{
						continue;
					}
					foreach (CreatureBase creature in caravanInstance.Creatures)
					{
						if (creature != null && creature is HumanoidInstance humanoidInstance)
						{
							yield return humanoidInstance;
						}
					}
				}
			}
		}

		public IEnumerable<HumanoidInstance> CaravanWorkers
		{
			get
			{
				foreach (CaravanInstance caravan in Caravans)
				{
					if (caravan?.Workers == null)
					{
						continue;
					}
					foreach (HumanoidInstance worker in caravan.Workers)
					{
						if (worker != null)
						{
							yield return worker;
						}
					}
				}
			}
		}

		public HashSet<string> TradeDeals => tradeDeals;

		public WorldMapData()
		{
			unlockedGameEvents = new HashSet<string>();
			unlockedRoomTypes = new HashSet<string>();
			npcsArrivedCountByEvent = new Dictionary<string, int>();
			playerTriggeredEventsEndedById = new Dictionary<string, int>();
			globalStatInstances = new List<GlobalStatInstance>();
			raidsWonForObjective = new Dictionary<string, int>();
			eventsEndedCount = new Dictionary<string, int>();
			tradeDeals = new HashSet<string>();
		}

		public byte[] GetBinaryDataToSerialize()
		{
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			for (int i = 0; i < heightmap.GetLength(0); i++)
			{
				for (int j = 0; j < heightmap.GetLength(1); j++)
				{
					binaryWriter.Write(mapTypes[i, j]);
					binaryWriter.Write(heightmap[i, j]);
					float value = 0f;
					binaryWriter.Write(value);
				}
			}
			return memoryStream.GetBuffer();
		}

		public void ReadFromBinaryData(byte[] inputData)
		{
			heightmap = new float[worldMapResolution.x, worldMapResolution.y];
			mapTypes = new byte[worldMapResolution.x, worldMapResolution.y];
			using MemoryStream input = new MemoryStream(inputData);
			using BinaryReader binaryReader = new BinaryReader(input);
			WorldMapSettings data = Repository<WorldMapSettingsData, WorldMapSettings>.Instance.GetData<WorldMapSettings>();
			data.Init();
			for (int i = 0; i < worldMapResolution.x; i++)
			{
				for (int j = 0; j < worldMapResolution.y; j++)
				{
					byte b = binaryReader.ReadByte();
					mapTypes[i, j] = b;
					if (data.GetCellTypeByID(b) == null)
					{
						mapTypes[i, j] = 0;
					}
					heightmap[i, j] = binaryReader.ReadSingle();
					binaryReader.ReadSingle();
				}
			}
		}

		public void GameLoaded(bool fromSave)
		{
			if (fromSave)
			{
				activeObjective?.UnlockRoomTypes();
				activeObjective?.UnlockGameEvents();
			}
		}

		public void CheckUpdateOldSave()
		{
			CollectUsedFactions();
			if (factionInstances == null || factionInstances.Count == 0)
			{
				Log.Info("Updating old save: adding factions and village places!", "C:\\GIT\\dev\\Assets\\Scripts\\State\\Map\\WorldMapData.cs");
				InitFactionInstances();
				InitFactionRelations();
				InitEnabledFactions();
				return;
			}
			foreach (Faction faction in Repository<FactionRepository, Faction>.Instance.GetAllItems())
			{
				if (!factionInstances.Any((FactionInstance f) => faction.GetID().Equals(f.BlueprintId)))
				{
					FactionInstance item = new FactionInstance(faction);
					factionInstances.Add(item);
				}
			}
		}

		private void CollectUsedFactions()
		{
			foreach (VillagePlace villagePlace in VillagePlaces)
			{
				factionsOnMap.Add(villagePlace.FactionInstance);
			}
			int num = new System.Random(MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Seed).Next(0, 99);
			foreach (VillagePlacement item2 in FactionSettings.VillagePlacement)
			{
				FactionType factionType = Repository<FactionTypeRepository, FactionType>.Instance.GetByID(item2.FactionType);
				if (factionType.HideOnMap)
				{
					FactionInstance[] array = FactionInstances.Where((FactionInstance fi) => fi.Blueprint.FactionType == factionType).ToArray();
					for (int num2 = 0; num2 < item2.FactionCount; num2++)
					{
						FactionInstance item = array[(num2 + num) % array.Length];
						factionsOnMap.Add(item);
					}
				}
			}
		}

		public void OnNewGameStarted()
		{
			InitFactionInstances();
			InitFactionRelations();
			InitEnabledFactions();
		}

		public void SetActiveObjective(Objective objectiveBlueprint)
		{
			ObjectiveInstance t = new ObjectiveInstance(objectiveBlueprint);
			bool isEnabled;
			if (activeObjective != null)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(35, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Map\\WorldMapData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Overwriting active objective ");
					messageBuilder.AppendFormatted(activeObjective);
					messageBuilder.AppendLiteral(" with ");
					messageBuilder.AppendFormatted(objectiveBlueprint.ToString());
				}
				Log.Warning(messageBuilder);
			}
			FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Map\\WorldMapData.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Setting active objective to ");
				messageBuilder2.AppendFormatted(t);
			}
			Log.Info(messageBuilder2);
			activeObjective = t;
			MonoSingleton<GlobalStatController>.Instance.ObjectiveActivated(activeObjective);
			MonoSingleton<ObjectiveManager>.Instance.SetActiveObjective(activeObjective);
		}

		private string GetRandomVillageName(System.Random random)
		{
			string name;
			do
			{
				name = Repository<VillageNameRepository, VillageNames>.Instance.GetRandomName(random);
				if (name != null)
				{
					continue;
				}
				int count = Repository<VillageNameRepository, VillageNames>.Instance.Names.Count;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(121, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Map\\WorldMapData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("VillageNameRepository.GetRandomName() returned null. Number of names in repository: ");
					messageBuilder.AppendFormatted(count);
					messageBuilder.AppendLiteral(". Trying to get a name from OldNames.");
				}
				Log.Error(messageBuilder);
				name = Repository<VillageNameRepository, VillageNames>.Instance.GetRandomOldName(random);
				if (name == null)
				{
					count = Repository<VillageNameRepository, VillageNames>.Instance.OldNames.Count;
					messageBuilder = new FVLogErrorInterpolationHandler(123, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Map\\WorldMapData.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("VillageNameRepository.GetRandomOldName() also returned null. Number of old names in repository: ");
						messageBuilder.AppendFormatted(count);
						messageBuilder.AppendLiteral(". An Exception will happen!");
					}
					Log.Error(messageBuilder);
				}
			}
			while (villagePlaces.Exists((VillagePlace item) => item.Name.Equals(name) || name.Equals(MonoSingleton<GameStartController>.Instance.SelectedVillageName)));
			return name;
		}

		private void InitEnabledFactions()
		{
			villagePlaces = new List<VillagePlace>();
			System.Random random = new System.Random(MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Seed);
			foreach (VillagePlacement item in FactionSettings.VillagePlacement)
			{
				Log.Debug("VILLAGE PLACEMENT " + item.FactionType + " x " + item.FactionCount + " x " + item.VillagesCountPerFaction, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Map\\WorldMapData.cs");
				List<FactionInstance> list = new List<FactionInstance>(factionInstances);
				FactionType ft = Repository<FactionTypeRepository, FactionType>.Instance.GetByID(item.FactionType);
				list.RemoveAll((FactionInstance item) => !item.Blueprint.FactionType.Equals(ft));
				using PooledList<FactionInstance> pooledList = list.Shuffle().ToPooledListJanitor();
				for (int num = 0; num < item.FactionCount; num++)
				{
					FactionInstance factionInstance = pooledList[num % pooledList.Count];
					for (int num2 = 0; num2 < item.VillagesCountPerFaction; num2++)
					{
						string randomVillageName = GetRandomVillageName(random);
						if (factionInstance.Blueprint.Placement.Equals(VillagePlacementType.Clustered))
						{
							villagePlaces.Insert(0, new VillagePlace(randomVillageName, factionInstance));
						}
						else
						{
							villagePlaces.Add(new VillagePlace(randomVillageName, factionInstance));
						}
						bool isEnabled;
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Map\\WorldMapData.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Creating village: ");
							messageBuilder.AppendFormatted(randomVillageName);
							messageBuilder.AppendLiteral("; faction: ");
							messageBuilder.AppendFormatted(factionInstance?.BlueprintId);
						}
						Log.Debug(messageBuilder);
					}
				}
			}
			availablePositions = new HashSet<Vector2Int>();
			int limit = 15;
			for (int num3 = 0; num3 < worldMapResolution.x; num3++)
			{
				for (int num4 = 0; num4 < worldMapResolution.y; num4++)
				{
					if (!TooCloseToCorners(num3, num4, limit) && !TooCloseToPlayerVillage(num3, num4))
					{
						availablePositions.Add(new Vector2Int(num3, num4));
					}
				}
			}
			notPositioned = new HashSet<VillagePlace>(villagePlaces);
			foreach (VillagePlace villagePlace in villagePlaces)
			{
				villagePlace.Position = GetVillagePosition(villagePlace, random);
				villagePlace.MapType = GetCellType(villagePlace.Position).MapType;
				villagePlace.SetMapInfo(Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetRandomSave(SecondMapType.Settlement, villagePlace.MapType));
				notPositioned.Remove(villagePlace);
			}
		}

		public void AddToNpcArrivedByEvent(HumanoidInstance humanoidInstance, GameEventInstance fromEvent)
		{
			string iD = fromEvent.Blueprint.GetID();
			if (!npcsArrivedCountByEvent.TryAdd(iD, 1))
			{
				npcsArrivedCountByEvent[iD]++;
			}
			MonoSingleton<GameEventSystemController>.Instance.NpcArrivedToEvent(iD);
		}

		public int GetNpcsArrivedCountByEvent(GameEventInstance fromEvent)
		{
			string iD = fromEvent.Blueprint.GetID();
			return npcsArrivedCountByEvent.GetValueOrDefault(iD);
		}

		public int GetNpcsArrivedCountByEvent(string eventBlueprintId)
		{
			return npcsArrivedCountByEvent.GetValueOrDefault(eventBlueprintId);
		}

		public void IncrementPlayerTriggeredEventsEndedById(string eventId)
		{
			if (!playerTriggeredEventsEndedById.TryAdd(eventId, 1))
			{
				playerTriggeredEventsEndedById[eventId]++;
			}
		}

		public void IncrementRaidsWonForObjective(string objectiveId)
		{
			if (!raidsWonForObjective.TryAdd(objectiveId, 1))
			{
				raidsWonForObjective[objectiveId]++;
			}
		}

		public int GetRaidsWonForObjective(string objectiveId)
		{
			return raidsWonForObjective.GetValueOrDefault(objectiveId, 0);
		}

		public void IncreaseEndedEventCount(string blueprintId)
		{
			if (!eventsEndedCount.TryAdd(blueprintId, 1))
			{
				eventsEndedCount[blueprintId]++;
			}
		}

		public int GetEndedEventCount(string blueprintId)
		{
			return eventsEndedCount.GetValueOrDefault(blueprintId);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool LimitEdge(float ii, float jj, float limit)
		{
			if (jj < ii && ii < limit)
			{
				return jj < limit;
			}
			return false;
		}

		private bool TooCloseToPlayerVillage(int i, int j)
		{
			return (villagePosition - new Vector2Int(i, j)).magnitude <= 6f;
		}

		private bool TooCloseToCorners(int i, int j, int limit)
		{
			int num = limit - i;
			int num2 = j;
			if (LimitEdge(num, num2, limit))
			{
				return true;
			}
			num = limit - i;
			num2 = worldMapResolution.y - j;
			if (LimitEdge(num, num2, limit))
			{
				return true;
			}
			num = limit - (worldMapResolution.x - i);
			num2 = worldMapResolution.y - j;
			if (LimitEdge(num, num2, limit))
			{
				return true;
			}
			num = limit - (worldMapResolution.x - i);
			num2 = j;
			if (LimitEdge(num, num2, limit))
			{
				return true;
			}
			return false;
		}

		private Vector2Int GetVillagePosition(VillagePlace place, System.Random random)
		{
			if (place.FactionInstance.Blueprint.Placement.Equals(VillagePlacementType.Random))
			{
				return GetVillagePositionRandom(place, random);
			}
			return GetVillagePositionClustered(place, random);
		}

		private Vector2Int GetVillagePositionClustered(VillagePlace place, System.Random random)
		{
			if (notPositioned.Count == villagePlaces.Count)
			{
				return GetVillagePositionRandom(place, random);
			}
			int num = 2;
			int num2 = 6;
			IEnumerable<VillagePlace> source = villagePlaces.Where((VillagePlace item) => !notPositioned.Contains(item) && item.FactionInstance.Blueprint.FactionType.Equals(place.FactionInstance.Blueprint.FactionType));
			if (!source.Any())
			{
				return GetVillagePositionRandom(place, random);
			}
			Vector2Int vector2Int = default(Vector2Int);
			do
			{
				int index = random.Next() % source.Count();
				VillagePlace villagePlace = source.ElementAt(index);
				float num3 = (float)random.NextDouble() * (float)(num2 - num) + (float)num;
				float f = (float)random.NextDouble() * 2f * MathF.PI;
				vector2Int.x = (int)((float)villagePlace.Position.x + Mathf.Sin(f) * num3);
				vector2Int.y = (int)((float)villagePlace.Position.y + Mathf.Cos(f) * num3);
			}
			while (!availablePositions.Contains(vector2Int));
			RemoveAvailablePosAround(vector2Int);
			return vector2Int;
		}

		public bool CheckCellTypes(List<string> cellTypes, Vector2Int pos)
		{
			int id = mapTypes[pos.x, pos.y];
			WorldMapSettings settings = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Settings;
			foreach (string cellType in cellTypes)
			{
				if (settings.CheckId(id, cellType))
				{
					return true;
				}
			}
			return false;
		}

		public bool CheckCellType(string cellType, Vector2Int pos)
		{
			int id = mapTypes[pos.x, pos.y];
			return MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Settings.CheckId(id, cellType);
		}

		public WorldMapCellType GetCellType(Vector2Int pos)
		{
			int id = mapTypes[pos.x, pos.y];
			return MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Settings.GetCellTypeByID(id);
		}

		private Vector2Int GetVillagePositionRandom(VillagePlace place, System.Random random)
		{
			if (place.FactionInstance.Blueprint.MapCellTypes.Count > 0)
			{
				IEnumerable<Vector2Int> source = availablePositions.Where((Vector2Int item) => CheckCellTypes(place.FactionInstance.Blueprint.MapCellTypes, item));
				if (source.Any())
				{
					Vector2Int vector2Int = source.ElementAtOrDefault(random.Next() % source.Count());
					RemoveAvailablePosAround(vector2Int);
					return vector2Int;
				}
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Map\\WorldMapData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Selecting max for ");
					messageBuilder.AppendFormatted(place.FactionInstance.BlueprintId);
				}
				Log.Debug(messageBuilder);
				float selectedValue = availablePositions.Min((Vector2Int pos) => heightmap[pos.x, pos.y]);
				Vector2Int vector2Int2 = availablePositions.First((Vector2Int pos) => Math.Abs(heightmap[pos.x, pos.y] - selectedValue) < 0.0001f);
				RemoveAvailablePosAround(vector2Int2);
				return vector2Int2;
			}
			Vector2Int vector2Int3 = availablePositions.ElementAtOrDefault(random.Next() % availablePositions.Count);
			RemoveAvailablePosAround(vector2Int3);
			return vector2Int3;
		}

		private void RemoveAvailablePosAround(Vector2Int position, int radius = 4)
		{
			int radiusSqr = radius * radius;
			availablePositions.RemoveWhere((Vector2Int item) => (item - position).sqrMagnitude <= radiusSqr);
		}

		private void InitFactionInstances()
		{
			if (factionInstances == null)
			{
				factionInstances = new List<FactionInstance>();
			}
			else
			{
				factionInstances.Clear();
			}
			foreach (Faction allItem in Repository<FactionRepository, Faction>.Instance.GetAllItems())
			{
				FactionInstance item = new FactionInstance(allItem);
				factionInstances.Add(item);
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Map\\WorldMapData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creatad ");
				messageBuilder.AppendFormatted(factionInstances.Count);
				messageBuilder.AppendLiteral(" faction instances");
			}
			Log.Debug(messageBuilder);
		}

		private void InitFactionRelations()
		{
			if (factionRelations == null)
			{
				factionRelations = new List<FactionRelationInstance>();
			}
			else
			{
				factionRelations.Clear();
			}
			foreach (FactionRelation relation in Repository<FactionRelationsData, NSMedieval.Factions.FactionRelations>.Instance.GetData<FactionRelations>().Relations)
			{
				factionRelations.Add(relation.CreateFactionInstance());
			}
		}

		public IEnumerable<FactionInstance> GetFactionsOfFactionType(string factionTypeId)
		{
			return factionInstances.Where((FactionInstance faction) => faction.Blueprint.FactionType.GetID().Equals(factionTypeId));
		}

		public HashSet<FactionInstance> GetEnemyFaction(FactionInstance faction)
		{
			float min = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings.NeutralRange.Min;
			_ = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionInstances;
			HashSet<FactionInstance> hashSet = new HashSet<FactionInstance>();
			foreach (FactionRelationInstance factionRelation in factionRelations)
			{
				if (factionRelation.Friendliness > min || string.IsNullOrEmpty(factionRelation.FactionA) || string.IsNullOrEmpty(factionRelation.FactionB) || (!factionRelation.FactionA.Equals(faction.Blueprint.FactionType.GetID()) && !factionRelation.FactionB.Equals(faction.Blueprint.FactionType.GetID())))
				{
					continue;
				}
				string factionTypeId = (factionRelation.FactionA.Equals(faction.Blueprint.FactionType.GetID()) ? factionRelation.FactionB : factionRelation.FactionA);
				IEnumerable<FactionInstance> factionsOfFactionType = GetFactionsOfFactionType(factionTypeId);
				if (factionsOfFactionType == null || !factionsOfFactionType.Any())
				{
					continue;
				}
				foreach (FactionInstance item in factionsOfFactionType)
				{
					if (item != null && VillagePlaceExistsForFaction(item.BlueprintId))
					{
						hashSet.Add(item);
					}
				}
			}
			return hashSet;
		}

		public bool VillagePlaceExistsForFaction(string factionId)
		{
			foreach (FactionInstance item in factionsOnMap)
			{
				if (item.BlueprintId == factionId)
				{
					return true;
				}
			}
			return false;
		}

		public HumanoidInstance GetWorkerInstanceFromCaravans(int uniqueId)
		{
			foreach (CaravanInstance caravan in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.Caravans)
			{
				foreach (HumanoidInstance worker in caravan.Workers)
				{
					if (worker.UniqueId == uniqueId)
					{
						return worker;
					}
				}
			}
			return null;
		}

		public void InitAfterLoad()
		{
			foreach (VillagePlace villagePlace in villagePlaces)
			{
				villagePlace.InitAfterLoad();
			}
			factionInstances.FirstOrDefault((FactionInstance faction) => faction.BlueprintId == "non_partisan_nomads")?.SetPlayerFriendliness(0f, showNotification: false, processRelatedFactions: false);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("villagePosition", villagePosition);
			serializer.Write("worldMapResolution", worldMapResolution);
			serializer.Write("raidWinHistory", raidWinHistory);
			serializer.Write("factionInstances", factionInstances);
			serializer.Write("factionRelations", factionRelations);
			serializer.Write("caravans", caravans);
			serializer.Write("caravansInPreparation", caravansInPreparation);
			serializer.Write("villagePlaces", villagePlaces);
			serializer.Write("markers", markers);
			serializer.Write("worldMapMarkerIdProvider", worldMapMarkerIdProvider);
			serializer.Write("globalStatInstances", globalStatInstances);
			serializer.Write("activeObjective", activeObjective);
			serializer.Write("unlockedRoomTypes", unlockedRoomTypes);
			serializer.Write("unlockedGameEvents", unlockedGameEvents);
			serializer.Write("tradeDeals", tradeDeals);
			serializer.Write("npcsArrivedCountByEvent", npcsArrivedCountByEvent);
			serializer.Write("playerTriggeredEventsEndedById", playerTriggeredEventsEndedById);
			serializer.Write("raidsWonForObjective", raidsWonForObjective);
			serializer.Write("eventsEndedCount", eventsEndedCount);
			if (activeObjective != null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Map\\WorldMapData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Loaded active objective: ");
					messageBuilder.AppendFormatted(activeObjective);
				}
				Log.Info(messageBuilder);
			}
		}

		public WorldMapData(FVDeserializer deserializer)
		{
			villagePosition = deserializer.ReadVec2Int("villagePosition");
			worldMapResolution = deserializer.ReadVec2Int("worldMapResolution");
			raidWinHistory = deserializer.ReadBoolQueue("raidWinHistory");
			factionInstances = deserializer.ReadObjectList<FactionInstance>("factionInstances");
			factionRelations = deserializer.ReadObjectList<FactionRelationInstance>("factionRelations");
			caravans = deserializer.ReadObjectList<CaravanInstance>("caravans");
			caravansInPreparation = deserializer.ReadObjectHashSet<CaravanInstance>("caravansInPreparation");
			villagePlaces = deserializer.ReadObjectList<VillagePlace>("villagePlaces");
			markers = deserializer.ReadObjectHashSet<WorldMapMarkerPlace>("markers");
			worldMapMarkerIdProvider = deserializer.ReadObject<UniqueIdProvider>("worldMapMarkerIdProvider");
			activeObjective = deserializer.ReadObject<ObjectiveInstance>("activeObjective");
			unlockedRoomTypes = deserializer.ReadStringHashSet("unlockedRoomTypes");
			unlockedGameEvents = deserializer.ReadStringHashSet("unlockedGameEvents");
			tradeDeals = deserializer.ReadStringHashSet("tradeDeals");
			globalStatInstances = deserializer.ReadObjectList<GlobalStatInstance>("globalStatInstances");
			npcsArrivedCountByEvent = deserializer.ReadStringIntDict("npcsArrivedCountByEvent");
			playerTriggeredEventsEndedById = deserializer.ReadStringIntDict("playerTriggeredEventsEndedById");
			raidsWonForObjective = deserializer.ReadStringIntDict("raidsWonForObjective");
			eventsEndedCount = deserializer.ReadStringIntDict("eventsEndedCount");
			if (unlockedGameEvents == null)
			{
				unlockedGameEvents = new HashSet<string>();
			}
			if (tradeDeals == null)
			{
				tradeDeals = new HashSet<string>();
			}
			if (unlockedRoomTypes == null)
			{
				unlockedRoomTypes = new HashSet<string>();
			}
			if (npcsArrivedCountByEvent == null)
			{
				npcsArrivedCountByEvent = new Dictionary<string, int>();
			}
			if (playerTriggeredEventsEndedById == null)
			{
				playerTriggeredEventsEndedById = new Dictionary<string, int>();
			}
			if (raidsWonForObjective == null)
			{
				raidsWonForObjective = new Dictionary<string, int>();
			}
			if (eventsEndedCount == null)
			{
				eventsEndedCount = new Dictionary<string, int>();
			}
			if (globalStatInstances == null)
			{
				globalStatInstances = new List<GlobalStatInstance>();
			}
		}

		public bool AddToTradeDeals(CaravanInstance caravanInstance, FactionInstance factionInstance)
		{
			bool num = tradeDeals.Add(factionInstance.BlueprintId);
			if (num)
			{
				MonoSingleton<CaravanController>.Instance.TradeDealMade(caravanInstance, factionInstance);
				factionInstance.AddFriendliness(20f);
			}
			return num;
		}

		public bool RemoveTradeDeal(FactionInstance factionInstance)
		{
			bool num = tradeDeals.Remove(factionInstance.BlueprintId);
			if (num)
			{
				MonoSingleton<CaravanController>.Instance.TradeDealRemoved(factionInstance);
			}
			return num;
		}

		public WorldMapMarkerPlace GetTradeDealMarker(Faction factionInstanceBlueprint)
		{
			foreach (WorldMapMarkerPlace marker in markers)
			{
				if (marker.HasTradeDeal && marker.FactionInstance.Blueprint == factionInstanceBlueprint)
				{
					return marker;
				}
			}
			return null;
		}
	}
}
