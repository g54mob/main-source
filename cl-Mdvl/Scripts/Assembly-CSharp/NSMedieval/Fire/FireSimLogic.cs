using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Weather;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace NSMedieval.Fire
{
	public class FireSimLogic
	{
		public delegate void FireNodesOperationDelegate(NativeArray<int> nodeIndicesOnFire, int nodeIndicesOnFireCount, NativeArray<float> flameData, NativeArray<byte> flameType);

		public delegate void OilBlobNodesOperationDelegate(NativeArray<int> oilBlobNodeIndices, int oilBlobNodeIndicesCount, NativeArray<float> oilBlobHealth, NativeArray<byte> oilBlobType);

		private static int mapSizeX;

		private static int mapSizeY;

		private static int mapSizeZ;

		private static NativeArray<float> fireDataNative;

		private static NativeArray<float> fireDataNativeOutput;

		private static ComputeBuffer fireDataComputeBuffer;

		private static NativeArray<float> fireTemperatureFront;

		private static NativeArray<float> fireTemperatureBack;

		private static NativeArray<float> flammabilityNative;

		private static NativeArray<float> flammabilityNativeOutput;

		private static NativeArray<bool> coverage;

		private static NativeArray<float> gridHealthOverride;

		private static NativeArray<float> fireDamageAccumulated;

		private static NativeArray<float> fireDamageAccumulatedOutput;

		private static NativeArray<byte> fireNeighborsArray;

		private static NativeArray<int> nodesOnFireArray;

		private static NativeArray<int> nodesOnFireArrayOutput;

		private static NativeArray<byte> oilBlobType;

		private static NativeArray<bool> isPlantCanopy;

		private static NativeArray<float> oilBlobHealth;

		private static NativeArray<float> oilBlobHealthOutput;

		private static NativeArray<int> oilBlobNodesArrayOutput;

		private static NativeArray<int> oilBlobNodesArray;

		private static NativeArray<byte> flameType;

		private static NativeArray<byte> flameTypeOutput;

		private static NativeArray<int> neighborFlameTypesFront;

		private static NativeArray<int> neighborFlameTypesBack;

		private static NativeArray<uint> snowGrassWetnessData;

		private static NativeArray<float> waterDataDisplay;

		private static NativeParallelHashSet<int> fireNodesAdded;

		private static NativeParallelHashSet<int> fireNodesRemoved;

		private static NativeParallelHashSet<int> isFireNeighborFront;

		private static NativeParallelHashSet<int> isFireNeighborBack;

		public static readonly Vec3Int[] FirePossibleNeighbors3d = new Vec3Int[22]
		{
			new Vec3Int(-1, 0, -1),
			new Vec3Int(0, 0, -1),
			new Vec3Int(1, 0, -1),
			new Vec3Int(-1, 0, 0),
			new Vec3Int(1, 0, 0),
			new Vec3Int(-1, 0, 1),
			new Vec3Int(0, 0, 1),
			new Vec3Int(1, 0, 1),
			new Vec3Int(-1, -1, -1),
			new Vec3Int(0, -1, -1),
			new Vec3Int(1, -1, -1),
			new Vec3Int(-1, -1, 1),
			new Vec3Int(0, -1, 1),
			new Vec3Int(1, -1, 1),
			new Vec3Int(-1, 1, -1),
			new Vec3Int(0, 1, -1),
			new Vec3Int(1, 1, -1),
			new Vec3Int(-1, 1, 0),
			new Vec3Int(1, 1, 0),
			new Vec3Int(-1, 1, 1),
			new Vec3Int(0, 1, 1),
			new Vec3Int(1, 1, 1)
		};

		private const float FireSpreadInterval = 10f;

		private const long DamageTickMaxMilliseconds = 2L;

		private const int FireJobDurationFrames = 3;

		private FireSettings fireSettings;

		private readonly VillageMap map;

		private int dataLength;

		private readonly Dictionary<int, float> flammabilityOverrideAdded = new Dictionary<int, float>();

		private readonly Dictionary<int, bool> shadowCasterChanged = new Dictionary<int, bool>();

		private bool isLoaded;

		public int[] FlameCountByFlameType = new int[2];

		private Dictionary<int, float> fireValuesToChange;

		private Dictionary<int, byte> flameTypeToChange;

		private Dictionary<int, float> oilBlobValuesToChange;

		private Dictionary<int, byte> oilBlobTypeToChange;

		private bool isTickerStarted;

		private HashSet<MapNode> flammabilityChangedSet;

		private Dictionary<int, CoverageType> coverageChangedDictionary;

		private HashSet<int> nodesReachedMaxFire;

		private NativeArray<float> temperatureByFlameType;

		private readonly object fireDataNativeLock = new object();

		private NativeArray<int> neighborsX;

		private NativeArray<int> neighborsY;

		private NativeArray<int> neighborsZ;

		private NativeArray<int> neighbors3dX;

		private NativeArray<int> neighbors3dY;

		private NativeArray<int> neighbors3dZ;

		private NativeArray<int> intProperties;

		private NativeArray<int> fireCountByFlameType;

		private int fireNodesCount;

		private int oilBlobNodesCount;

		private object isFireNeighborFrontLock = new object();

		private readonly object nodesOnFireLock = new object();

		private JobHandle fireLogicJobHandle;

		private FireLogicJob fireLogicJob;

		private bool isFireJobScheduled;

		private float deltaTime;

		private float deltaTimeMultiplier = 1f;

		private float spreadTimer;

		private float spreadSpeed = 1f;

		private int frameCounter;

		private int nodesOnFireArrayTickIndex;

		private Dictionary<byte, ThermalModel> thermalModelByFlameType;

		public bool FirstFireTickDone { get; private set; }

		public NativeArray<float> FireTemperature => fireTemperatureFront;

		public ComputeBuffer FireDataComputeBuffer => fireDataComputeBuffer;

		public NativeArray<float> OilBlobHealth => oilBlobHealth;

		public NativeArray<int> OilBlobNodesArray => oilBlobNodesArray;

		public int OilBlobNodesCount => oilBlobNodesCount;

		public int DataLength => dataLength;

		public int FireNodesCount => fireNodesCount;

		public NativeArray<float> FlammabilityNative => flammabilityNative;

		public NativeArray<float> FireDamageAccumulated => fireDamageAccumulated;

		public IEnumerable<int> IsFireNeighbor
		{
			get
			{
				lock (isFireNeighborFrontLock)
				{
					foreach (int item in isFireNeighborFront)
					{
						yield return item;
					}
				}
			}
		}

		public NativeArray<int> NeighborFlameTypesFront => neighborFlameTypesFront;

		private static Vec3Int[] FireJobSpreadNeighbors => MapNodeUtils.Neighbors3DNonDiagonal;

		public bool FireSimEnabled { get; set; } = true;

		public NativeArray<byte> OilBlobType => oilBlobType;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			mapSizeX = 0;
			mapSizeY = 0;
			mapSizeZ = 0;
		}

		public static void InitStaticArrays()
		{
			fireDataNative = ArrayStorage.GetNativeArray<float>("fireDataNative", GridDataIndexTools.MaxDataLength);
			fireDataNativeOutput = ArrayStorage.GetNativeArray<float>("fireDataNativeOutput", GridDataIndexTools.MaxDataLength);
			fireTemperatureFront = ArrayStorage.GetNativeArray<float>("fireTemperatureFront", GridDataIndexTools.MaxDataLength);
			fireTemperatureBack = ArrayStorage.GetNativeArray<float>("fireTemperatureBack", GridDataIndexTools.MaxDataLength);
			flammabilityNative = ArrayStorage.GetNativeArray<float>("flammabilityNative", GridDataIndexTools.MaxDataLength);
			flammabilityNativeOutput = ArrayStorage.GetNativeArray<float>("flammabilityNativeOutput", GridDataIndexTools.MaxDataLength);
			flameType = ArrayStorage.GetNativeArray<byte>("flameType", GridDataIndexTools.MaxDataLength);
			flameTypeOutput = ArrayStorage.GetNativeArray<byte>("flameTypeOutput", GridDataIndexTools.MaxDataLength);
			coverage = ArrayStorage.GetNativeArray<bool>("coverage", GridDataIndexTools.MaxDataLength);
			gridHealthOverride = ArrayStorage.GetNativeArray<float>("gridHealthOverride", GridDataIndexTools.MaxDataLength);
			fireDamageAccumulated = ArrayStorage.GetNativeArray<float>("fireDamageAccumulated", GridDataIndexTools.MaxDataLength);
			fireDamageAccumulatedOutput = ArrayStorage.GetNativeArray<float>("fireDamageAccumulatedOutput", GridDataIndexTools.MaxDataLength);
			fireNeighborsArray = ArrayStorage.GetNativeArray<byte>("fireNeighborsArray", GridDataIndexTools.MaxDataLength);
			isPlantCanopy = ArrayStorage.GetNativeArray<bool>("isPlantCanopy", GridDataIndexTools.MaxDataLength);
			nodesOnFireArray = ArrayStorage.GetNativeArray<int>("nodesOnFireArray", GridDataIndexTools.MaxDataLength);
			nodesOnFireArrayOutput = ArrayStorage.GetNativeArray<int>("nodesOnFireArrayOutput", GridDataIndexTools.MaxDataLength);
			oilBlobHealth = ArrayStorage.GetNativeArray<float>("oilBlobHealth", GridDataIndexTools.MaxDataLength);
			oilBlobHealthOutput = ArrayStorage.GetNativeArray<float>("oilBlobHealthOutput", GridDataIndexTools.MaxDataLength);
			oilBlobType = ArrayStorage.GetNativeArray<byte>("oilBlobType", GridDataIndexTools.MaxDataLength);
			oilBlobNodesArray = ArrayStorage.GetNativeArray<int>("oilBlobNodesArray", GridDataIndexTools.MaxDataLength);
			oilBlobNodesArrayOutput = ArrayStorage.GetNativeArray<int>("oilBlobNodesArrayOutput", GridDataIndexTools.MaxDataLength);
			neighborFlameTypesFront = ArrayStorage.GetNativeArray<int>("neighborFlameTypesFront", GridDataIndexTools.MaxDataLength);
			neighborFlameTypesBack = ArrayStorage.GetNativeArray<int>("neighborFlameTypesBack", GridDataIndexTools.MaxDataLength);
			snowGrassWetnessData = ArrayStorage.GetNativeArray<uint>("snowGrassWetnessData", GridDataIndexTools.MaxDataLength);
			waterDataDisplay = ArrayStorage.GetNativeArray<float>("waterDataDisplay", GridDataIndexTools.MaxDataLength);
			fireNodesAdded = ArrayStorage.GetNativeParallelHashSet<int>("fireNodesAdded", GridDataIndexTools.MaxDataLength);
			fireNodesRemoved = ArrayStorage.GetNativeParallelHashSet<int>("fireNodesRemoved", GridDataIndexTools.MaxDataLength);
			isFireNeighborFront = ArrayStorage.GetNativeParallelHashSet<int>("isFireNeighborFront", GridDataIndexTools.MaxDataLength);
			isFireNeighborBack = ArrayStorage.GetNativeParallelHashSet<int>("isFireNeighborBack", GridDataIndexTools.MaxDataLength);
			fireDataComputeBuffer = ArrayStorage.GetComputeBuffer("fireDataComputeBuffer", GridDataIndexTools.MaxDataLength, 4);
		}

		private void ClearStaticArrays()
		{
			ArrayStorage.ClearNativeArray(fireDataNative, dataLength);
			ArrayStorage.ClearNativeArray(fireDataNativeOutput, dataLength);
			ArrayStorage.ClearNativeArray(fireTemperatureFront, dataLength);
			ArrayStorage.ClearNativeArray(fireTemperatureBack, dataLength);
			ArrayStorage.ClearNativeArray(flammabilityNative, dataLength);
			ArrayStorage.ClearNativeArray(flammabilityNativeOutput, dataLength);
			ArrayStorage.ClearNativeArray(flameType, dataLength);
			ArrayStorage.ClearNativeArray(flameTypeOutput, dataLength);
			ArrayStorage.ClearNativeArray(coverage, dataLength);
			ArrayStorage.ClearNativeArray(gridHealthOverride, dataLength);
			ArrayStorage.ClearNativeArray(fireDamageAccumulated, dataLength);
			ArrayStorage.ClearNativeArray(fireDamageAccumulatedOutput, dataLength);
			ArrayStorage.ClearNativeArray(fireNeighborsArray, dataLength);
			ArrayStorage.ClearNativeArray(isPlantCanopy, dataLength);
			ArrayStorage.ClearNativeArray(nodesOnFireArray, dataLength);
			ArrayStorage.ClearNativeArray(nodesOnFireArrayOutput, dataLength);
			ArrayStorage.ClearNativeArray(oilBlobHealth, dataLength);
			ArrayStorage.ClearNativeArray(oilBlobHealthOutput, dataLength);
			ArrayStorage.ClearNativeArray(oilBlobType, dataLength);
			ArrayStorage.ClearNativeArray(oilBlobNodesArray, dataLength);
			ArrayStorage.ClearNativeArray(oilBlobNodesArrayOutput, dataLength);
			ArrayStorage.ClearNativeArray(neighborFlameTypesFront, dataLength);
			ArrayStorage.ClearNativeArray(neighborFlameTypesBack, dataLength);
			ArrayStorage.ClearNativeArray(snowGrassWetnessData, dataLength);
			ArrayStorage.ClearNativeArray(waterDataDisplay, dataLength);
			fireNodesAdded.Clear();
			fireNodesRemoved.Clear();
			isFireNeighborFront.Clear();
			isFireNeighborBack.Clear();
		}

		public FireSimLogic(int mapSizeX, int mapSizeY, int mapSizeZ, VillageMap map)
		{
			this.map = map;
			FireSimLogic.mapSizeX = mapSizeX;
			FireSimLogic.mapSizeY = mapSizeY;
			FireSimLogic.mapSizeZ = mapSizeZ;
			Initialize();
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			MonoSingleton<WorldTimeManager>.Instance.SeasonUpdateEvent += OnSeasonUpdate;
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnDestroyBuilding;
			MonoSingleton<SceneController>.Instance.SceneSetup += OnSceneSetup;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent += OnGroundDestroyed;
		}

		public bool IsPlantCanopyOnFire(int index)
		{
			return isPlantCanopy[index];
		}

		public void NodesOnFireSafeOperation(FireNodesOperationDelegate operation)
		{
			lock (nodesOnFireLock)
			{
				lock (fireDataNativeLock)
				{
					operation?.Invoke(nodesOnFireArray, fireNodesCount, fireDataNative, flameType);
				}
			}
		}

		public IEnumerable<int> NodesOnFire()
		{
			lock (nodesOnFireLock)
			{
				lock (fireDataNativeLock)
				{
					for (int i = 0; i < fireNodesCount; i++)
					{
						yield return nodesOnFireArray[i];
					}
				}
			}
		}

		public IEnumerable<int> OilBlobNodes()
		{
			lock (nodesOnFireLock)
			{
				lock (fireDataNativeLock)
				{
					for (int i = 0; i < oilBlobNodesCount; i++)
					{
						yield return oilBlobNodesArray[i];
					}
				}
			}
		}

		public void Dispose()
		{
			StopTicking();
			fireLogicJobHandle.Complete();
			neighborsX.Dispose(fireLogicJobHandle);
			neighborsY.Dispose(fireLogicJobHandle);
			neighborsZ.Dispose(fireLogicJobHandle);
			neighbors3dX.Dispose(fireLogicJobHandle);
			neighbors3dY.Dispose(fireLogicJobHandle);
			neighbors3dZ.Dispose(fireLogicJobHandle);
			temperatureByFlameType.Dispose(fireLogicJobHandle);
			fireNodesAdded.Clear();
			isFireNeighborFront.Clear();
			isFireNeighborBack.Clear();
			intProperties.Dispose(fireLogicJobHandle);
			fireCountByFlameType.Dispose(fireLogicJobHandle);
			coverageChangedDictionary.Clear();
			flammabilityChangedSet.Clear();
			fireValuesToChange.Clear();
			oilBlobValuesToChange.Clear();
			flameTypeToChange.Clear();
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (map != null)
			{
				map.NodeFlammabilityChangedEvent -= OnNodeFlammabilityChanged;
				map.NodeTagChangedEvent -= OnNodeTagChanged;
				map.NodeIsShadowCasterChangedEvent -= OnNodeIsShadowCasterChanged;
				map.CoverageChangedEvent -= OnCoverageChanged;
			}
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.SeasonUpdateEvent -= OnSeasonUpdate;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnDestroyBuilding;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.SceneSetup -= OnSceneSetup;
			}
			if (MonoSingleton<GroundController>.IsInstantiated())
			{
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent -= OnGroundDestroyed;
			}
		}

		public void GetDebugInfo(Vec3Int pos, StringBuilder fireInfoStringBuilder)
		{
			int num = GridDataIndexTools.FastTo1DIndex(pos);
			if (num != -1)
			{
				float flammability = GetFlammability(num);
				float fireData = GetFireData(num);
				float num2 = fireDamageAccumulated[num];
				float num3 = GetGrassFlammability(num) * fireLogicJob.GrassFlammabilityBySeason;
				fireInfoStringBuilder.Clear();
				fireInfoStringBuilder.AppendFormat("[Voxel] Fire: {0:F3}, Flammability: {1:F2}\n[Voxel] Grass: {2:F2}, Fire Damage: {3:F2}\nOil: {4:F2}, Oil Type: {5}\n", fireData, flammability, num3, num2, oilBlobHealth[num], oilBlobType[num]);
				MapNode mapNode = VillageManager.ActiveVillage.Map.GridSpaceData[num];
				fireInfoStringBuilder.AppendFormat("[Voxel] Shadow casters: {0}, temperature: {1}c\n", mapNode.ShadowCasterPlantsCount, map.TemperatureManager.GetTemperature(mapNode.Index));
				fireInfoStringBuilder.AppendFormat("[Map] fire damage since burning: {0:F2}\n", map.TotalFireDamageSinceBurning);
				long num4 = math.max(0L, GlobalSaveController.CurrentVillageData.DateAndTime.CurrentTimeTutorialAware - map.FireStartTimeMinutes);
				if (map.TotalFireDamageSinceBurning <= 0f)
				{
					num4 = 0L;
				}
				fireInfoStringBuilder.AppendFormat("[Map] Time since fire start: {0}, spread speed: {1}\n", num4, spreadSpeed);
				fireInfoStringBuilder.AppendFormat("[Map] Flames count: {0}, Start rain: {1}\n", fireNodesCount, ShouldStartRain());
				fireInfoStringBuilder.AppendFormat("[Map] Plain fire count: {0}, greek fire count: {1}\n", GetFlameCount(0), GetFlameCount(1));
			}
		}

		public void ForceRefreshFlammability(MapNode node)
		{
			flammabilityChangedSet.Add(node);
		}

		public void DebugClearAllFire()
		{
			for (int i = 0; i < DataLength; i++)
			{
				SetFireData(i, 0f);
				SetFlammabilityOverride(i, 0f);
				SetFlameType(i, 0);
			}
			nodesReachedMaxFire.Clear();
		}

		public float GetFireData(int index)
		{
			lock (fireDataNativeLock)
			{
				return fireDataNative[index];
			}
		}

		public bool IsOilBlobAt(in Vec3Int gridPosition)
		{
			return OilBlobHealth[GridDataIndexTools.FastTo1DIndexNoCheck(gridPosition)] > 0f;
		}

		public bool IsOilBlobAt(int index)
		{
			return OilBlobHealth[index] > 0f;
		}

		public bool IsGreekOilBlobAt(in Vec3Int gridPosition)
		{
			if (OilBlobType[GridDataIndexTools.FastTo1DIndexNoCheck(gridPosition)] != 1)
			{
				return false;
			}
			return IsOilBlobAt(in gridPosition);
		}

		public bool IsGreekOilBlobAt(int index)
		{
			if (OilBlobType[index] != 1)
			{
				return false;
			}
			return IsOilBlobAt(index);
		}

		public float GetFireData(Vec3Int gridPosition)
		{
			if (!GridDataIndexTools.InRange(gridPosition))
			{
				return 0f;
			}
			lock (fireDataNativeLock)
			{
				return fireDataNative[GridDataIndexTools.FastTo1DIndexNoCheck(gridPosition)];
			}
		}

		public bool IsFireAt(Vec3Int gridPosition)
		{
			if (!GridDataIndexTools.InRange(gridPosition))
			{
				return false;
			}
			lock (fireDataNativeLock)
			{
				return fireDataNative[GridDataIndexTools.FastTo1DIndexNoCheck(gridPosition)] > 0f;
			}
		}

		public bool IsFireAt(MapNode node)
		{
			lock (fireDataNativeLock)
			{
				return fireDataNative[node.Index] > 0f;
			}
		}

		public bool IsFireAt(int nodeIndex)
		{
			lock (fireDataNativeLock)
			{
				return fireDataNative[nodeIndex] > 0f;
			}
		}

		public int GetFlameType(int index)
		{
			lock (fireDataNativeLock)
			{
				return flameType[index];
			}
		}

		public float GetFlammability(int index)
		{
			return flammabilityNative[index];
		}

		public float GetFireDamageAccumulated(int index)
		{
			return fireDamageAccumulated[index];
		}

		public void SetFireData(int index, float value)
		{
			lock (fireDataNativeLock)
			{
				if (!fireValuesToChange.TryAdd(index, value))
				{
					fireValuesToChange[index] = value;
				}
			}
		}

		public void SetFlammabilityOverride(int index, float value)
		{
			flammabilityOverrideAdded.TryAdd(index, value);
		}

		public void SetDeltaTimeMultiplier(float deltaTimeMultiplier)
		{
			this.deltaTimeMultiplier = deltaTimeMultiplier;
		}

		public void SetFlameType(int nodeIndex, byte flameType)
		{
			if (!flameTypeToChange.TryAdd(nodeIndex, flameType))
			{
				flameTypeToChange[nodeIndex] = flameType;
			}
		}

		public int GetFlameCount(int flameTypeIndex)
		{
			return FlameCountByFlameType[flameTypeIndex];
		}

		private void OnMapLoaded(bool fromSave)
		{
			MapNode.RefreshFlammabilityEnabled = true;
			MapNode[] gridSpaceData = map.GridSpaceData;
			for (int i = 0; i < gridSpaceData.Length; i++)
			{
				MapNode mapNode = gridSpaceData[i];
				mapNode.RefreshFlammability();
				RefreshFlammabilityInArray(mapNode);
				if (mapNode.Coverage == CoverageType.Roofed)
				{
					coverage[i] = true;
				}
			}
			map.NodeFlammabilityChangedEvent += OnNodeFlammabilityChanged;
			map.NodeTagChangedEvent += OnNodeTagChanged;
			map.NodeIsShadowCasterChangedEvent += OnNodeIsShadowCasterChanged;
			map.CoverageChangedEvent += OnCoverageChanged;
			CopyToReadArrays();
			isLoaded = true;
			if (fireNodesCount > 0)
			{
				MonoSingleton<FireController>.Instance.FirstFireLit();
			}
		}

		private void OnNodeFlammabilityChanged(MapNode node)
		{
			flammabilityChangedSet.Add(node);
		}

		private void OnNodeTagChanged(MapNode node, MapNodeTags oldTag)
		{
			if (isLoaded && (oldTag & MapNodeTags.VerticalFireBlocker) != (node.Tag & MapNodeTags.VerticalFireBlocker))
			{
				flammabilityChangedSet.Add(node);
			}
		}

		private void OnCoverageChanged(int nodeIndex, CoverageType coverage)
		{
			coverageChangedDictionary.TryAdd(nodeIndex, coverage);
		}

		private void OnNodeIsShadowCasterChanged(MapNode node, bool isShadowCaster)
		{
			if (!shadowCasterChanged.TryAdd(node.Index, isShadowCaster))
			{
				shadowCasterChanged[node.Index] = isShadowCaster;
			}
		}

		private void OnSeasonUpdate()
		{
			RefreshSeasonGrassFlammability();
		}

		private void OnGroundDestroyed(List<Vec3Int> positions)
		{
			MapNode[] gridSpaceData = map.GridSpaceData;
			foreach (Vec3Int position in positions)
			{
				int num = GridDataIndexTools.FastTo1DIndex(position);
				if (num != -1)
				{
					MapNode nodeAbove = gridSpaceData[num].GetNodeAbove();
					if (nodeAbove != null && oilBlobHealth[nodeAbove.Index] > 0f)
					{
						SetOilBlobHealth(nodeAbove.Index, 0f, 0);
						SetOilBlobHealth(nodeAbove.Index, 0f, 1);
					}
				}
			}
		}

		private void OnSceneSetup()
		{
			StartTicking();
		}

		private void OnDestroyBuilding(BaseBuildingInstance building)
		{
			if (building?.Blueprint == null || building.Positions == null || LoadingController.IsSceneTransition || building.ConstructionPhase != ConstructionPhase.Finished || !building.HealthDepleted)
			{
				return;
			}
			float spawnFireOnDestroy = building.Blueprint.SpawnFireOnDestroy;
			foreach (Vec3Int position in building.Positions)
			{
				int num = GridDataIndexTools.FastTo1DIndexNoCheck(position);
				MapNode mapNode = building.Map.GridSpaceData[num];
				if (spawnFireOnDestroy > 0f)
				{
					SetFireData(num, spawnFireOnDestroy);
				}
				else if (mapNode.Flammability <= 0f && (building.BuildingType & BuildingType.Trap) == 0)
				{
					SetFireData(num, 0f);
				}
			}
		}

		private void Initialize()
		{
			fireSettings = Repository<FireSettingsData, FireSettings>.Instance.GetData<FireSettings>();
			GridDataIndexTools.InitialiseFastMethods(mapSizeX, mapSizeY, mapSizeZ);
			dataLength = mapSizeX * mapSizeY * mapSizeZ;
			InitStaticArrays();
			ClearStaticArrays();
			nodesReachedMaxFire = new HashSet<int>();
			fireValuesToChange = new Dictionary<int, float>();
			oilBlobValuesToChange = new Dictionary<int, float>();
			oilBlobTypeToChange = new Dictionary<int, byte>();
			flameTypeToChange = new Dictionary<int, byte>();
			flammabilityChangedSet = new HashSet<MapNode>();
			coverageChangedDictionary = new Dictionary<int, CoverageType>();
			intProperties = new NativeArray<int>(2, Allocator.Persistent);
			fireCountByFlameType = new NativeArray<int>(2, Allocator.Persistent);
			neighborsX = new NativeArray<int>(FireJobSpreadNeighbors.Length, Allocator.Persistent);
			neighborsY = new NativeArray<int>(FireJobSpreadNeighbors.Length, Allocator.Persistent);
			neighborsZ = new NativeArray<int>(FireJobSpreadNeighbors.Length, Allocator.Persistent);
			neighbors3dX = new NativeArray<int>(FirePossibleNeighbors3d.Length, Allocator.Persistent);
			neighbors3dY = new NativeArray<int>(FirePossibleNeighbors3d.Length, Allocator.Persistent);
			neighbors3dZ = new NativeArray<int>(FirePossibleNeighbors3d.Length, Allocator.Persistent);
			temperatureByFlameType = new NativeArray<float>(new float[2] { fireSettings.FireTemperatureBoost, fireSettings.GreekFireTemperatureBoost }, Allocator.Persistent);
			for (int i = 0; i < FireJobSpreadNeighbors.Length; i++)
			{
				neighborsX[i] = FireJobSpreadNeighbors[i].x;
				neighborsY[i] = FireJobSpreadNeighbors[i].y;
				neighborsZ[i] = FireJobSpreadNeighbors[i].z;
			}
			for (int j = 0; j < FirePossibleNeighbors3d.Length; j++)
			{
				neighbors3dX[j] = FirePossibleNeighbors3d[j].x;
				neighbors3dY[j] = FirePossibleNeighbors3d[j].y;
				neighbors3dZ[j] = FirePossibleNeighbors3d[j].z;
			}
			fireLogicJob = new FireLogicJob
			{
				FireDataNative = fireDataNativeOutput,
				FlammabilityNative = flammabilityNativeOutput,
				FireDamageAccumulated = fireDamageAccumulatedOutput,
				FireNeighborsArray = fireNeighborsArray,
				IsPlantCanopy = isPlantCanopy,
				DataLength = DataLength,
				NeighborsX = neighborsX,
				NeighborsY = neighborsY,
				NeighborsZ = neighborsZ,
				Neighbors3dX = neighbors3dX,
				Neighbors3dY = neighbors3dY,
				Neighbors3dZ = neighbors3dZ,
				NodesOnFireArray = nodesOnFireArrayOutput,
				FlameType = flameTypeOutput,
				GridHealthOverride = gridHealthOverride,
				FireTemperature = fireTemperatureBack,
				OilBlobHealth = oilBlobHealthOutput,
				OilBlobType = oilBlobType,
				IntProperties = intProperties,
				FlameCountByFlameType = fireCountByFlameType,
				OilBlobNodesArray = oilBlobNodesArrayOutput,
				IsFireNeighbor = isFireNeighborFront,
				NeighborFlameTypes = neighborFlameTypesFront,
				FireNodesAdded = fireNodesAdded,
				FireNodesRemoved = fireNodesRemoved,
				TemperatureByFlameType = temperatureByFlameType
			};
			RefreshSeasonGrassFlammability();
			thermalModelByFlameType = new Dictionary<byte, ThermalModel>();
			thermalModelByFlameType.Add(0, Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID("fire"));
			thermalModelByFlameType.Add(1, Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID("greek_fire"));
		}

		private float GetGrassFlammability(int index)
		{
			float grassHealth = map.SnowGrassWetnessManager.GetGrassHealth(index);
			if (grassHealth > 0f)
			{
				MapNode nodeBelow = map.GridSpaceData[index].GetNodeBelow();
				if (nodeBelow != null && nodeBelow.VoxelType != null)
				{
					return math.clamp(grassHealth + nodeBelow.VoxelType.GrassFlammabilityAdd, 0f, 1f);
				}
			}
			return grassHealth;
		}

		private void RefreshFlammabilityInArray(MapNode node)
		{
			float flammability = node.Flammability;
			flammabilityNativeOutput[node.Index] = ((flammability < 0f) ? 0f : flammability);
		}

		public void DrawGizmos()
		{
			Color color = Gizmos.color;
			Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
			foreach (int item in IsFireNeighbor)
			{
				float x = GridDataIndexTools.GetX(item);
				float y = (float)GridDataIndexTools.GetY(item) * 3f;
				float z = GridDataIndexTools.GetZ(item);
				Gizmos.DrawCube(new Vector3(x, y, z), Vector3.one);
			}
			Gizmos.color = new Color(0f, 1f, 0f, 0.25f);
			Vector3 size = new Vector3(1f, 3f, 1f);
			for (int i = 0; i < DataLength; i++)
			{
				if (isPlantCanopy[i])
				{
					float x2 = GridDataIndexTools.GetX(i);
					float y2 = (float)GridDataIndexTools.GetY(i) * 3f + 1.5f;
					float z2 = GridDataIndexTools.GetZ(i);
					Gizmos.DrawCube(new Vector3(x2, y2, z2), size);
				}
			}
			Gizmos.color = color;
		}

		private void CopyToReadArrays()
		{
			lock (fireDataNativeLock)
			{
				NativeArray<float>.Copy(fireDataNativeOutput, fireDataNative, DataLength);
				NativeArray<float>.Copy(fireDamageAccumulatedOutput, fireDamageAccumulated, DataLength);
				NativeArray<float>.Copy(flammabilityNativeOutput, flammabilityNative, DataLength);
				NativeArray<byte>.Copy(flameTypeOutput, flameType, DataLength);
				NativeArray<float>.Copy(oilBlobHealthOutput, oilBlobHealth, DataLength);
			}
			fireDataComputeBuffer.SetData(fireDataNative, 0, 0, DataLength);
			int key;
			if (flammabilityOverrideAdded.Count > 0)
			{
				foreach (KeyValuePair<int, float> item in flammabilityOverrideAdded)
				{
					item.Deconstruct(out key, out var value);
					int index = key;
					float value2 = value;
					gridHealthOverride[index] = value2;
				}
				flammabilityOverrideAdded.Clear();
			}
			if (shadowCasterChanged.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, bool> item2 in shadowCasterChanged)
			{
				item2.Deconstruct(out key, out var value3);
				int num = key;
				bool flag = (isPlantCanopy[num] = value3);
				if (!flag && flammabilityNative[num] <= 0f && fireDataNativeOutput[num] > 0f)
				{
					fireDataNativeOutput[num] = 0f;
					fireNodesRemoved.Add(num);
				}
			}
			shadowCasterChanged.Clear();
		}

		private void RefreshSeasonGrassFlammability()
		{
			Season season = GlobalSaveController.CurrentVillageData.DateAndTime.Season;
			fireLogicJob.GrassFlammabilityBySeason = season.GrassFlammability;
		}

		private void ScheduleFireJob()
		{
			if (isFireJobScheduled || LoadingController.IsLeavingMainScene || MonoSingleton<LoadingController>.IsApplicationIsQuitting())
			{
				return;
			}
			isFireJobScheduled = true;
			fireLogicJob.MapSizeX = mapSizeX;
			fireLogicJob.MapSizeY = mapSizeY;
			fireLogicJob.MapSizeZ = mapSizeZ;
			fireLogicJob.DeltaTime = math.max(0.001f, deltaTimeMultiplier) * deltaTime;
			fireLogicJob.FrameCount = Time.frameCount;
			float byId = GlobalSaveController.CurrentVillageData.GameParametersCurrent.GetById("fireSpreadSpeedMultiplier");
			if (byId > 0f)
			{
				fireLogicJob.CanSpreadToNeighbors = spreadTimer > 10f / byId;
				if (fireLogicJob.CanSpreadToNeighbors)
				{
					spreadTimer = 0f;
				}
			}
			else
			{
				fireLogicJob.CanSpreadToNeighbors = false;
				spreadTimer = 0f;
			}
			CopyToReadArrays();
			int key;
			float value;
			foreach (KeyValuePair<int, float> item in fireValuesToChange)
			{
				item.Deconstruct(out key, out value);
				int num = key;
				float num2 = value;
				if (fireDataNative[num] <= 0f && num2 > 0f)
				{
					fireNodesAdded.Add(num);
				}
				else if (fireDataNative[num] > 0f && num2 <= 0f)
				{
					fireNodesRemoved.Add(num);
				}
				fireDataNativeOutput[num] = num2;
				fireDataNative[num] = num2;
			}
			fireValuesToChange.Clear();
			foreach (KeyValuePair<int, float> item2 in oilBlobValuesToChange)
			{
				item2.Deconstruct(out key, out value);
				int index = key;
				float value2 = value;
				oilBlobHealthOutput[index] = value2;
			}
			oilBlobValuesToChange.Clear();
			byte value3;
			foreach (KeyValuePair<int, byte> item3 in oilBlobTypeToChange)
			{
				item3.Deconstruct(out key, out value3);
				int index2 = key;
				byte value4 = value3;
				oilBlobType[index2] = value4;
			}
			oilBlobTypeToChange.Clear();
			foreach (KeyValuePair<int, byte> item4 in flameTypeToChange)
			{
				item4.Deconstruct(out key, out value3);
				int index3 = key;
				byte value5 = value3;
				flameTypeOutput[index3] = value5;
			}
			flameTypeToChange.Clear();
			ApplyFlammabilityChanges();
			ApplyCoverageChanges();
			fireLogicJob.FireDataNative = fireDataNativeOutput;
			fireLogicJob.FireDamageAccumulated = fireDamageAccumulatedOutput;
			map.SnowGrassWetnessManager.CopyData(snowGrassWetnessData);
			map.WaterManager.WaterSimLogic.CopyWaterDataTo(waterDataDisplay);
			uint num3 = (uint)(UnityEngine.Random.value * 4.2949673E+09f);
			fireLogicJob.RandomGenerator.InitState((num3 == 0) ? 1u : num3);
			fireLogicJob.Coverage = coverage;
			fireLogicJob.SnowGrassWetness = snowGrassWetnessData;
			fireLogicJob.WaterDataDisplay = waterDataDisplay;
			fireLogicJob.RainAmount = MonoSingleton<WeatherManager>.Instance.RainEffectWeight;
			fireLogicJob.SnowAmount = MonoSingleton<WeatherManager>.Instance.SnowEffectWeight;
			NativeArray<float> nativeArray = fireTemperatureBack;
			NativeArray<float> nativeArray2 = fireTemperatureFront;
			fireTemperatureFront = nativeArray;
			fireTemperatureBack = nativeArray2;
			lock (isFireNeighborFrontLock)
			{
				NativeParallelHashSet<int> nativeParallelHashSet = isFireNeighborBack;
				NativeParallelHashSet<int> nativeParallelHashSet2 = isFireNeighborFront;
				isFireNeighborFront = nativeParallelHashSet;
				isFireNeighborBack = nativeParallelHashSet2;
			}
			NativeArray<int> nativeArray3 = neighborFlameTypesBack;
			NativeArray<int> nativeArray4 = neighborFlameTypesFront;
			neighborFlameTypesFront = nativeArray3;
			neighborFlameTypesBack = nativeArray4;
			fireLogicJob.FireTemperature = fireTemperatureBack;
			fireLogicJob.IsFireNeighbor = isFireNeighborBack;
			fireLogicJob.NeighborFlameTypes = neighborFlameTypesBack;
			fireLogicJobHandle = IJobExtensions.Schedule(fireLogicJob);
			deltaTime = 0f;
		}

		private void ApplyFlammabilityChanges()
		{
			if (flammabilityChangedSet.Count == 0)
			{
				return;
			}
			foreach (MapNode item in flammabilityChangedSet)
			{
				RefreshFlammabilityInArray(item);
			}
			flammabilityChangedSet.Clear();
		}

		private void ApplyCoverageChanges()
		{
			foreach (KeyValuePair<int, CoverageType> item in coverageChangedDictionary)
			{
				item.Deconstruct(out var key, out var value);
				int index = key;
				CoverageType coverageType = value;
				coverage[index] = coverageType == CoverageType.Roofed;
			}
			coverageChangedDictionary.Clear();
		}

		private void CompleteFireJob()
		{
			fireLogicJobHandle.Complete();
			int num = fireNodesCount;
			fireNodesCount = fireLogicJob.GetNodesOnFireCount();
			oilBlobNodesCount = fireLogicJob.GetOilBlobsCount();
			FlameCountByFlameType[0] = fireLogicJob.FlameCountByFlameType[0];
			FlameCountByFlameType[1] = fireLogicJob.FlameCountByFlameType[1];
			lock (nodesOnFireLock)
			{
				NativeArray<int>.Copy(nodesOnFireArrayOutput, nodesOnFireArray, DataLength);
				NativeArray<int>.Copy(oilBlobNodesArrayOutput, oilBlobNodesArray, DataLength);
			}
			isFireJobScheduled = false;
			if (num != fireNodesCount)
			{
				if (num == 0)
				{
					MonoSingleton<FireController>.Instance.FirstFireLit();
					ResetTotalFireDamageCounter();
					map.FireStartTimeMinutes = GlobalSaveController.CurrentVillageData.DateAndTime.CurrentTimeTutorialAware;
				}
				if (fireNodesCount == 0)
				{
					MonoSingleton<FireController>.Instance.LastFirePutOut();
					ResetTotalFireDamageCounter();
				}
			}
			FirstFireTickDone = true;
		}

		private void ResetTotalFireDamageCounter()
		{
			map.TotalFireDamageSinceBurning = 0f;
			spreadSpeed = 1f;
		}

		private void StartTicking()
		{
			if (!isTickerStarted)
			{
				isTickerStarted = true;
				MonoSingleton<SceneController>.Instance.Tick += OnTick;
				MonoSingleton<SceneController>.Instance.LateTick += OnLateTick;
			}
		}

		private void StopTicking()
		{
			if (isTickerStarted)
			{
				isTickerStarted = false;
				if (MonoSingleton<SceneController>.IsInstantiated())
				{
					MonoSingleton<SceneController>.Instance.Tick -= OnTick;
					MonoSingleton<SceneController>.Instance.LateTick -= OnLateTick;
				}
			}
		}

		private void OnTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("FireSimLogic.Tick"))
			{
				if (isLoaded && FireSimEnabled && deltaTime > 0f)
				{
					spreadTimer += deltaTime * spreadSpeed;
					spreadSpeed = math.max(0f, fireSettings.FireSlowdownByTotalDamage.GetMultiplierInterpolated((int)map.TotalFireDamageSinceBurning));
					if (ShouldStartRain() && !MonoSingleton<WeatherManager>.Instance.IsEventRunning("rain"))
					{
						WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
						MonoSingleton<WeatherManager>.Instance.ForceStartEvent("rain", dateAndTime.CurrentTimeTutorialAware, 500L, removeScheduledParallelEvents: true);
					}
					ScheduleFireJob();
				}
			}
		}

		private bool ShouldStartRain()
		{
			long currentTimeTutorialAware = GlobalSaveController.CurrentVillageData.DateAndTime.CurrentTimeTutorialAware;
			bool flag = map.TotalFireDamageSinceBurning >= fireSettings.FireDamageThresholdStartRain && (float)(currentTimeTutorialAware - map.FireStartTimeMinutes) >= fireSettings.FireTimeThresholdStartRain && (float)fireNodesCount >= fireSettings.FireCountThresholdRain;
			if (flag)
			{
				WeatherEvent byID = Repository<WeatherEventRepository, WeatherEvent>.Instance.GetByID("rain");
				bool isEnabled;
				foreach (string item in byID.IgnoredWhenGameEventsRunning)
				{
					if (MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsEventRunning(item))
					{
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(49, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Fire\\FireSimLogic.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Cannot start rain because game event ");
							messageBuilder.AppendFormatted(item);
							messageBuilder.AppendLiteral(" is running.");
						}
						Log.Debug(messageBuilder);
						isEnabled = false;
						return isEnabled;
					}
				}
				foreach (string skipIfExist in byID.SkipIfExists)
				{
					if (MonoSingleton<WeatherManager>.Instance.IsEventRunning(skipIfExist))
					{
						bool isEnabled2;
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(52, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\Fire\\FireSimLogic.cs");
						if (isEnabled2)
						{
							messageBuilder.AppendLiteral("Cannot start rain because weather event ");
							messageBuilder.AppendFormatted(skipIfExist);
							messageBuilder.AppendLiteral(" is running.");
						}
						Log.Debug(messageBuilder);
						isEnabled = false;
						return isEnabled;
					}
				}
			}
			return flag;
		}

		private void OnLateTick(float deltaTime)
		{
			using (ProfilerSampleJanitor.Begin("FireSimLogic.LateTick"))
			{
				if (!isLoaded || LoadingController.IsLeavingMainScene || MonoSingleton<LoadingController>.IsApplicationIsQuitting() || (deltaTime <= 0f && fireLogicJobHandle.IsCompleted))
				{
					return;
				}
				this.deltaTime += deltaTime / 3f;
				frameCounter++;
				if (frameCounter % 3 != 0)
				{
					TickGridDataHealth();
				}
				else
				{
					if (!fireLogicJobHandle.IsCompleted)
					{
						return;
					}
					CompleteFireJob();
					if (FireSimEnabled)
					{
						TickGridDataHealth();
						if (!fireNodesAdded.IsEmpty)
						{
							MonoSingleton<FireController>.Instance.FireAdded(fireNodesAdded);
							fireNodesAdded.Clear();
						}
						if (!fireNodesRemoved.IsEmpty)
						{
							MonoSingleton<FireController>.Instance.FireRemoved(fireNodesRemoved);
							fireNodesRemoved.Clear();
						}
					}
				}
			}
		}

		private void TickGridDataHealth()
		{
			if (!isLoaded)
			{
				return;
			}
			int num = 0;
			long num2 = DateTime.Now.ToUnixTimeMilliseconds();
			if (nodesOnFireArrayTickIndex >= fireNodesCount)
			{
				nodesOnFireArrayTickIndex = 0;
			}
			using (PooledHashSet<int> pooledHashSet = HashSetPool<int>.GetJanitor())
			{
				using PooledHashSet<int> pooledHashSet2 = HashSetPool<int>.GetJanitor();
				float grassDamageMultiplier = fireSettings.GrassDamageMultiplier;
				while (nodesOnFireArrayTickIndex < fireNodesCount)
				{
					int num3 = nodesOnFireArray[nodesOnFireArrayTickIndex];
					if (fireDataNative[num3] >= 1f && nodesReachedMaxFire.Add(num3))
					{
						pooledHashSet.Add(num3);
					}
					if (fireDamageAccumulated[num3] > 0f)
					{
						float grassHealth = map.SnowGrassWetnessManager.GetGrassHealth(num3);
						if (grassHealth > 0f)
						{
							float num4 = fireDamageAccumulated[num3] * grassDamageMultiplier * 0.1f;
							grassHealth -= num4;
							map.SnowGrassWetnessManager.SetGrassHealth(num3, grassHealth);
							map.TotalFireDamageSinceBurning += num4;
						}
						MapNode mapNode = map.GridSpaceData[num3];
						if (mapNode != null)
						{
							foreach (WorldObject item in mapNode.WorldObjects.IterateInReverseDynamic())
							{
								if (item.HasDisposed || !(item is IStatsOwner statsOwner))
								{
									continue;
								}
								DealFireDamageToWorldObject(statsOwner, num3, item);
								if ((item.GridDataType & GridDataType.Trap) != GridDataType.None)
								{
									TrapComponentInstance componentInstance = ((BaseBuildingInstance)item).GetComponentInstance<TrapComponentInstance>();
									if (componentInstance != null && componentInstance.Blueprint.TriggerOnFire > 0f && componentInstance.Operational && fireDataNative[num3] >= componentInstance.Blueprint.TriggerOnFire)
									{
										componentInstance.Trigger();
									}
								}
							}
							foreach (PlantMapResourceInstance item2 in mapNode.ShadowCasterPlants.IterateInReverseDynamic())
							{
								if (!item2.HasDisposed && item2.CurrentPhase != -1)
								{
									DealFireDamageToWorldObject(item2, num3, item2);
								}
							}
						}
						if (GetGrassFlammability(num3) <= 0f && (mapNode == null || mapNode.Flammability <= 0f))
						{
							flammabilityNative[num3] = 0f;
							flammabilityChangedSet.Add(map.GridSpaceData[num3]);
						}
					}
					fireDamageAccumulated[num3] = 0f;
					nodesOnFireArrayTickIndex++;
					num++;
					if (num % 10 == 0 && DateTime.Now.ToUnixTimeMilliseconds() - num2 >= 2)
					{
						break;
					}
				}
				foreach (int item3 in pooledHashSet)
				{
					map.GridSpaceData[item3].ReachedMaxFire = true;
					map.GridSpaceData[item3].RefreshTags();
				}
				foreach (int item4 in nodesReachedMaxFire)
				{
					if (fireDataNative[item4] < 1f)
					{
						pooledHashSet2.Add(item4);
					}
				}
				if (pooledHashSet2.Count <= 0)
				{
					return;
				}
				foreach (int item5 in pooledHashSet2)
				{
					map.GridSpaceData[item5].ReachedMaxFire = false;
					map.GridSpaceData[item5].RefreshTags();
				}
				nodesReachedMaxFire.ExceptWith(pooledHashSet2);
			}
			void DealFireDamageToWorldObject(IStatsOwner statsOwner2, int nodeIndex, WorldObject worldObject)
			{
				if (statsOwner2.Stats != null && !statsOwner2.Stats.HasDisposed)
				{
					StatInstance stat = statsOwner2.Stats.GetStat(StatType.Health);
					if (stat != null)
					{
						float num5 = fireDamageAccumulated[nodeIndex] * worldObject.Flammability * 0.1f;
						float num6 = stat.Current - num5;
						map.TotalFireDamageSinceBurning += num5;
						bool disableShaker = stat.DisableShaker;
						stat.DisableShaker = true;
						if (stat.IsAtMinimum(num6))
						{
							if (worldObject.DestroyByFire())
							{
								stat.SetCurrent(num6);
							}
						}
						else
						{
							stat.SetCurrent(num6);
						}
						stat.DisableShaker = disableShaker;
					}
				}
			}
		}

		public byte[] GetBinaryDataToSerialize()
		{
			using MemoryStream memoryStream = new MemoryStream(4 + fireNodesCount * 16 + 1);
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(fireNodesCount);
			foreach (int item in NodesOnFire())
			{
				binaryWriter.Write(item);
				binaryWriter.Write(fireDataNative[item]);
				int value = flameType[item];
				binaryWriter.Write(value);
				binaryWriter.Write(0);
			}
			binaryWriter.Write(oilBlobNodesCount);
			foreach (int item2 in OilBlobNodes())
			{
				binaryWriter.Write(item2);
				binaryWriter.Write(oilBlobHealth[item2]);
				int value2 = oilBlobType[item2];
				binaryWriter.Write(value2);
				int value3 = 0;
				binaryWriter.Write(value3);
			}
			return memoryStream.GetBuffer();
		}

		public void ReadFromBinaryData(byte[] inputData)
		{
			if (inputData == null || inputData.Length == 0)
			{
				return;
			}
			using MemoryStream input = new MemoryStream(inputData);
			using BinaryReader binaryReader = new BinaryReader(input);
			int num = binaryReader.ReadInt32();
			fireNodesCount = 0;
			for (int i = 0; i < num; i++)
			{
				int num2 = binaryReader.ReadInt32();
				float num3 = binaryReader.ReadSingle();
				byte value = (byte)(binaryReader.ReadInt32() & 0xFF);
				binaryReader.ReadInt32();
				if (!(num3 <= 0f))
				{
					nodesOnFireArray[fireNodesCount] = num2;
					nodesOnFireArrayOutput[fireNodesCount] = num2;
					fireDataNativeOutput[num2] = num3;
					fireDataNative[num2] = num3;
					flameTypeOutput[num2] = value;
					flameType[num2] = value;
					fireNodesCount++;
				}
			}
			try
			{
				oilBlobNodesCount = binaryReader.ReadInt32();
				for (int j = 0; j < oilBlobNodesCount; j++)
				{
					int num4 = binaryReader.ReadInt32();
					float value2 = binaryReader.ReadSingle();
					byte value3 = (byte)(binaryReader.ReadInt32() & 0xFF);
					binaryReader.ReadInt32();
					oilBlobNodesArray[j] = num4;
					oilBlobHealthOutput[num4] = value2;
					oilBlobType[num4] = value3;
				}
			}
			catch (EndOfStreamException)
			{
				oilBlobNodesCount = 0;
			}
		}

		public void SetOilBlobHealth(int index, float health, byte oilBlobType)
		{
			if (!oilBlobValuesToChange.TryAdd(index, health))
			{
				oilBlobValuesToChange[index] = health;
			}
			if (!oilBlobTypeToChange.TryAdd(index, oilBlobType))
			{
				oilBlobTypeToChange[index] = oilBlobType;
			}
		}

		public ThermalModel GetFireThermalModel(int index)
		{
			byte key = flameType[index];
			return thermalModelByFlameType[key];
		}
	}
}
