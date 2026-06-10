using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.RoomDetection
{
	public class RoomDetection : IGameDisposable, IDisposable
	{
		public const MapNodeTags AnyDoorTag = MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.BarnDoor | MapNodeTags.DoorAlwaysOpen | MapNodeTags.EnemyDoorClosed;

		private const GridDataType StairsSlopeDataType = GridDataType.SlopeOrStairs;

		private VillageMap map;

		[NonSerialized]
		private readonly List<Room> roomsForTypeCheck = new List<Room>();

		private readonly HashSet<Region> regionsToCheck = new HashSet<Region>();

		private readonly HashSet<Region> regionsChanged = new HashSet<Region>();

		private readonly Dictionary<Room, HashSet<Region>> roomsRemoved = new Dictionary<Room, HashSet<Region>>();

		private readonly HashSet<Room> roomsToDelete = new HashSet<Room>();

		private readonly Dictionary<Region, Room> roomsByRegion = new Dictionary<Region, Room>();

		private readonly Dictionary<Room, RoomType> roomsCreatedOnThread = new Dictionary<Room, RoomType>();

		[NonSerialized]
		private readonly List<Room> roomsRemovedOnThread = new List<Room>();

		private bool isGameLoaded;

		private int roomTempIndexCounter;

		private BaseTimer tickTimer;

		private UnscaledTimer unscaledTimer;

		private BaseTimer tickRoomsTimer;

		private readonly Stopwatch roomDetTimer = new Stopwatch();

		private ThreadingJobSystem.ThreadedTaskData detectRoomTask;

		private readonly object lockObject = new object();

		private readonly object roomsLock = new object();

		private readonly object roomsRemovedThreadLock = new object();

		private readonly object roomsByRegionLock = new object();

		private readonly object roomsCreatedOnThreadLock = new object();

		[NonSerialized]
		private readonly List<Room> rooms = new List<Room>();

		[NonSerialized]
		private List<Room> roomsWithSingleOwner = new List<Room>();

		public List<Room> RoomsWithSingleOwner => roomsWithSingleOwner;

		public bool HasDisposed { get; private set; }

		public InterpolatedValueList RoomWealthList { get; private set; }

		public InterpolatedValueList RoomSpaceList { get; private set; }

		public InterpolatedValueList RoomBeautyList { get; private set; }

		public RoomImpressivenessSettings RoomImpressivenessSettings { get; private set; }

		public int RoomsCount
		{
			get
			{
				lock (roomsLock)
				{
					return rooms.Count;
				}
			}
		}

		public event Action<IGameDisposable> OnDisposedEvent;

		public RoomDetection(VillageMap map)
		{
			this.map = map;
		}

		public void Initialize()
		{
			RoomWealthList = Repository<RoomImpWealthMultipliersData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			RoomSpaceList = Repository<RoomImpSpaceMultipliersData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			RoomBeautyList = Repository<RoomImpBeautyMultipliersData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			RoomImpressivenessSettings = Repository<RoomImpressivenessSettingsData, RoomImpressivenessSettings>.Instance.GetData<RoomImpressivenessSettings>();
			map.RegionManager.OnRegionRemovingEvent += OnRegionRemoving;
			map.RegionManager.OnRegionAddedEvent += OnRegionAdded;
			map.OnNodeAddedToRegionEvent += OnNodeAddedToRegion;
			map.OnNodeRemovedFromRegionEvent += OnNodeRemovedFromRegion;
			map.OnNodeVoxelTypeChangedEvent += OnNodeVoxelTypeChanged;
			map.OnRegionBecameRoofedEvent += OnRegionBecameRoofed;
			map.ObjectPlacedEvent += OnObjectPlaced;
			map.ObjectRemovedEvent += OnObjectRemoved;
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnDestroyBuilding;
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnFinishedBuilding;
			MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent += OnConstructionCompleted;
			MonoSingleton<BuildingOwnershipController>.Instance.BuildingOwnerRegisteredRefactoredEvent += OnBuildingOwnerRegistered;
			MonoSingleton<BuildingOwnershipController>.Instance.BuildingOwnerUnregisteredRefactoredEvent += OnBuildingOwnerUnregistered;
			MonoSingleton<RoomDetectionController>.Instance.RoomTypeUnlockedEvent += OnRoomTypeUnlocked;
			MonoSingleton<FloraController>.Instance.OnSpawnPlantMapResourceInstanceEvent += OnSpawnPlantMapResourceInstance;
			MonoSingleton<FloraController>.Instance.DestroyResourceEvent += OnDestroyResource;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
			tickTimer = new Timer(0.1f, restartOnEnd: false);
			tickTimer.AddCallback(TimerUpdate);
			tickTimer.Pause();
			isGameLoaded = false;
			tickRoomsTimer = new Timer(0.1f, restartOnEnd: true);
			tickRoomsTimer.AddCallback(TickRooms);
			tickRoomsTimer.RestartTimer();
			unscaledTimer = new UnscaledTimer(0.1f, restartOnEnd: true);
			unscaledTimer.AddCallback(OnUnscaledTimerTick);
			unscaledTimer.RestartTimer();
			roomDetTimer.Stop();
		}

		private void OnUnscaledTimerTick()
		{
			RefreshRenderCulling(MonoSingleton<World>.Instance.ElevationLevel);
		}

		private void OnDestroyResource(PlantMapResourceInstance plantMapResourceInstance)
		{
			plantMapResourceInstance.GetRoom()?.RemoveFromContent(plantMapResourceInstance);
		}

		private void OnSpawnPlantMapResourceInstance(PlantMapResourceInstance plantMapResourceInstance)
		{
			plantMapResourceInstance.GetRoom()?.AddToContent(plantMapResourceInstance);
		}

		public void Dispose()
		{
			if (HasDisposed)
			{
				return;
			}
			HasDisposed = true;
			if (map?.RegionAreaManager != null)
			{
				map.RegionManager.OnRegionRemovingEvent -= OnRegionRemoving;
				map.RegionManager.OnRegionAddedEvent -= OnRegionAdded;
			}
			if (map != null)
			{
				map.OnNodeAddedToRegionEvent -= OnNodeAddedToRegion;
				map.OnNodeRemovedFromRegionEvent -= OnNodeRemovedFromRegion;
				map.OnNodeVoxelTypeChangedEvent -= OnNodeVoxelTypeChanged;
				map.OnRegionBecameRoofedEvent -= OnRegionBecameRoofed;
				map.ObjectPlacedEvent -= OnObjectPlaced;
				map.ObjectRemovedEvent -= OnObjectRemoved;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnDestroyBuilding;
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnFinishedBuilding;
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent -= OnConstructionCompleted;
			}
			if (MonoSingleton<BuildingOwnershipController>.IsInstantiated())
			{
				MonoSingleton<BuildingOwnershipController>.Instance.BuildingOwnerRegisteredRefactoredEvent -= OnBuildingOwnerRegistered;
				MonoSingleton<BuildingOwnershipController>.Instance.BuildingOwnerUnregisteredRefactoredEvent -= OnBuildingOwnerUnregistered;
			}
			if (MonoSingleton<RoomDetectionController>.IsInstantiated())
			{
				MonoSingleton<RoomDetectionController>.Instance.RoomTypeUnlockedEvent -= OnRoomTypeUnlocked;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
			}
			if (MonoSingleton<FloraController>.IsInstantiated())
			{
				MonoSingleton<FloraController>.Instance.OnSpawnPlantMapResourceInstanceEvent -= OnSpawnPlantMapResourceInstance;
				MonoSingleton<FloraController>.Instance.DestroyResourceEvent -= OnDestroyResource;
			}
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.OnDisposedEvent = null;
			map = null;
			regionsChanged.Clear();
			regionsToCheck.Clear();
			roomDetTimer?.Stop();
			tickTimer?.Dispose();
			tickTimer = null;
			tickRoomsTimer?.Dispose();
			tickRoomsTimer = null;
			unscaledTimer?.Dispose();
			unscaledTimer = null;
			foreach (Room room in rooms)
			{
				room.ClearAll();
			}
			rooms.Clear();
			roomsByRegion.Clear();
			lock (roomsCreatedOnThreadLock)
			{
				roomsCreatedOnThread.Clear();
			}
			roomsForTypeCheck.Clear();
			foreach (HashSet<Region> value in roomsRemoved.Values)
			{
				value?.Clear();
			}
			roomsRemoved.Clear();
			roomsRemovedOnThread.Clear();
			roomsToDelete.Clear();
			roomsWithSingleOwner.Clear();
		}

		public void RefreshRenderCulling(float elevationLevel)
		{
			using (ProfilerSampleJanitor.Begin("RoomDetection.RefreshRenderCulling"))
			{
				Vector3 b = MonoSingleton<RtsCamera>.Instance.transform.position;
				Vector2 cameraPositionXZ = b.ToVector2XZ();
				float num = Mathf.Pow(MonoSingleton<RtsCamera>.Instance.MaxRoomContentRenderDistance, 2f);
				float num2 = elevationLevel * (float)World.MapBlockHeight;
				bool roofsVisible = GlobalSaveController.CurrentVillageData.RoofsVisible;
				lock (roomsLock)
				{
					foreach (Room room in rooms)
					{
						bool flag = num2 > room.HighestPoint + (float)World.MapBlockHeight && (!room.HasRoofs || roofsVisible);
						if (flag && room.Center.ToVector3World().DistanceSquared(in b) < num && IsLookingThroughWindow(room, cameraPositionXZ))
						{
							flag = false;
						}
						room.IsContentRenderCulled = flag;
					}
				}
			}
		}

		private static bool IsLookingThroughWindow(Room room, Vector2 cameraPositionXZ)
		{
			if (room.HasOpenPortals == WorldDirection.None)
			{
				return false;
			}
			Vector2 normalized = (cameraPositionXZ - room.Center.ToVector3World().ToVector2XZ()).normalized;
			if (!IsOnSide(room.HasOpenPortals, WorldDirection.N, Vector2.up, normalized) && !IsOnSide(room.HasOpenPortals, WorldDirection.S, Vector2.down, normalized) && !IsOnSide(room.HasOpenPortals, WorldDirection.E, Vector2.right, normalized))
			{
				return IsOnSide(room.HasOpenPortals, WorldDirection.W, Vector2.left, normalized);
			}
			return true;
			static bool IsOnSide(WorldDirection hasOpenWindows, WorldDirection worldDirection, Vector2 worldDirectionVector, Vector2 dirToCamera)
			{
				if ((hasOpenWindows & worldDirection) == 0)
				{
					return false;
				}
				return Vector2.Dot(worldDirectionVector, dirToCamera) > 0.5f;
			}
		}

		public static Room GetClosestReachableRoom(CreatureBase creature, string roomTypeId)
		{
			MapNode mapNode = creature?.GetNode();
			if (mapNode?.Region == null)
			{
				return null;
			}
			return GetClosestReachableRoom(mapNode.Region, mapNode.Position, creature.PathTraversalProvider, roomTypeId);
		}

		public static Room GetClosestReachableRoom(Region fromRegion, Vec3Int gridPosition, PathTraversalProvider pathTraversalProvider, string roomTypeId)
		{
			if (fromRegion == null)
			{
				return null;
			}
			RoomType byID = Repository<RoomTypeRepository, RoomType>.Instance.GetByID(roomTypeId);
			RoomDetection roomDetection = fromRegion.Map.RoomDetection;
			Room result = null;
			float num = float.MaxValue;
			foreach (Room item in roomDetection.IterateRoomsOfType(byID))
			{
				float num2 = Vec3Int.Distance(in gridPosition, item.Center);
				if (!(num2 < num))
				{
					continue;
				}
				bool flag = false;
				foreach (Region region in item.Regions)
				{
					if (PathfinderUtil.IsRegionReachable(pathTraversalProvider, region, fromRegion))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					num = num2;
					result = item;
				}
			}
			return result;
		}

		public IEnumerable<Room> IterateRoomsSafe()
		{
			lock (roomsLock)
			{
				foreach (Room room in rooms)
				{
					yield return room;
				}
			}
		}

		public IEnumerable<Room> IterateRoomsOfType(RoomType roomType)
		{
			lock (roomsLock)
			{
				foreach (Room room in rooms)
				{
					if (room.RoomType == roomType)
					{
						yield return room;
					}
				}
			}
		}

		public IEnumerable<Room> IterateRoomsSafeBackwards()
		{
			lock (roomsLock)
			{
				for (int i = rooms.Count; i >= 0; i--)
				{
					if (i < rooms.Count)
					{
						yield return rooms[i];
					}
				}
			}
		}

		public Room FindBestRoomSafe(Predicate<Room> filter, Func<Room, float> scorer)
		{
			Room result = null;
			float num = 0f;
			lock (roomsLock)
			{
				foreach (Room room in rooms)
				{
					if (filter(room))
					{
						float num2 = scorer(room);
						if (num2 > num)
						{
							num = num2;
							result = room;
						}
					}
				}
				return result;
			}
		}

		public bool AnyRoomSafe(Func<Room, bool> condition)
		{
			lock (roomsLock)
			{
				foreach (Room room in rooms)
				{
					if (condition(room))
					{
						return true;
					}
				}
			}
			return false;
		}

		public Room GetMostImpressiveSingleOwnerRoom(RoomType roomType = null)
		{
			Room room = null;
			foreach (Room item in RoomsWithSingleOwner)
			{
				if (item?.OwnershipByWorker != null && item.OwnershipByWorker.Count == 1 && (roomType == null || item.RoomType == roomType) && (room == null || item.ImpressivenessScore > room.ImpressivenessScore))
				{
					room = item;
				}
			}
			return room;
		}

		public bool GetAllRoomsOfType(string[] roomTypeIds, out List<Room> rooms)
		{
			rooms = new List<Room>();
			lock (roomsLock)
			{
				foreach (string value in roomTypeIds)
				{
					foreach (Room room in this.rooms)
					{
						if ((object)room.RoomType != null && room.RoomType.GetID().Equals(value))
						{
							rooms.Add(room);
						}
					}
				}
			}
			return rooms.Count > 0;
		}

		public bool RoomTypeExists(string roomTypeId)
		{
			lock (roomsLock)
			{
				foreach (Room room in rooms)
				{
					if (room != null && !(room.RoomType == null) && room.RoomType.GetID().Equals(roomTypeId))
					{
						return true;
					}
				}
			}
			return false;
		}

		public Room GetSingleOwnerRoom(HumanoidInstance humanoid, RoomType roomType = null)
		{
			foreach (Room item in RoomsWithSingleOwner)
			{
				if (item?.OwnershipByWorker != null && item.OwnershipByWorker.Count == 1 && item.OwnershipByWorker.ContainsKey(humanoid) && (roomType == null || item.RoomType == roomType))
				{
					return item;
				}
			}
			return null;
		}

		public void ScheduleRoomTypeCheck(Room room)
		{
			if (!roomsForTypeCheck.Contains(room))
			{
				roomsForTypeCheck.Add(room);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsStairsAsWallAt(MapNode node)
		{
			if ((node.DataType & GridDataType.Slope) != GridDataType.None)
			{
				return ((SlopeInstance)node.GetWorldObject(GridDataType.Slope)).Positions[2].Equals(node.Position);
			}
			if ((node.DataType & GridDataType.Stairs) == 0)
			{
				return false;
			}
			StairsComponentInstance componentInstance = node.Map.StairsComponentManager.GetComponentInstance(node.Position);
			if (componentInstance == null || componentInstance.HasDisposed)
			{
				return false;
			}
			if (componentInstance.Blueprint == null)
			{
				return componentInstance.GridDataPosition.Equals(node.Position);
			}
			if (componentInstance.Blueprint.IsStairWall)
			{
				return componentInstance.GridDataPosition.Equals(node.Position);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsRoofAsWallAt(MapNode node)
		{
			if ((node.DataType & GridDataType.Roof) == 0)
			{
				return false;
			}
			BaseBuildingInstance baseBuildingInstance = (BaseBuildingInstance)node.GetWorldObject(GridDataType.Roof);
			if (baseBuildingInstance == null || !baseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Finished))
			{
				return false;
			}
			RoofComponentInstance componentInstance = baseBuildingInstance.Map.RoofComponentManager.GetComponentInstance(baseBuildingInstance);
			RoofComponentBlueprint roofComponentBlueprint = componentInstance?.Blueprint;
			if (roofComponentBlueprint == null)
			{
				return false;
			}
			if (baseBuildingInstance.GridDataPosition.Equals(node.Position) && roofComponentBlueprint.HalfRoof)
			{
				return componentInstance.Scale.y >= World.MapBlockHeight;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool CanGoToNeighbor(MapNode node)
		{
			if ((node.Region == null || !node.Region.IsBridge || (node.Tag & MapNodeTags.Fence) != MapNodeTags.None) && (node.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.BarnDoor | MapNodeTags.DoorAlwaysOpen | MapNodeTags.Wall | MapNodeTags.EnemyDoorClosed)) == 0 && node.VoxelType == null && !IsStairsAsWallAt(node))
			{
				return !IsRoofAsWallAt(node);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool CanGoUpToNode(MapNode fromNode, MapNode toNode)
		{
			if ((toNode.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.BarnDoor | MapNodeTags.DoorAlwaysOpen | MapNodeTags.Wall | MapNodeTags.EnemyDoorClosed)) == 0 && (toNode.DataType & (GridDataType.SlopeOrStairs | GridDataType.BuildingFinished | GridDataType.Roof)) == 0 && toNode.VoxelType == null && fromNode.Coverage == CoverageType.Roofed && (fromNode.DataType & GridDataType.SlopeOrStairs) == 0 && (toNode.DataType & GridDataType.SlopeOrStairs) == 0 && (fromNode.Tag & MapNodeTags.Ladder) == 0 && (toNode.Tag & MapNodeTags.Ladder) == 0)
			{
				if (toNode.Coverage != CoverageType.Roofed && (toNode.DataType & GridDataType.SlopeOrStairs) == 0)
				{
					return (toNode.Tag & MapNodeTags.Ladder) != 0;
				}
				return true;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool CanGoDown(MapNode fromNode, MapNode toNode)
		{
			if ((fromNode.Tag & (MapNodeTags.Wall | MapNodeTags.Floor)) == 0 && (toNode.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.BarnDoor | MapNodeTags.DoorAlwaysOpen | MapNodeTags.Wall | MapNodeTags.EnemyDoorClosed)) == 0 && toNode.VoxelType == null && fromNode.VoxelType == null && fromNode.Coverage == CoverageType.Roofed && (fromNode.DataType & GridDataType.SlopeOrStairs) == 0 && (toNode.DataType & GridDataType.SlopeOrStairs) == 0 && (fromNode.Tag & MapNodeTags.Ladder) == 0 && (toNode.Tag & MapNodeTags.Ladder) == 0 && (toNode.Coverage == CoverageType.Roofed || (toNode.DataType & GridDataType.SlopeOrStairs) != GridDataType.None || (toNode.Tag & MapNodeTags.Ladder) != MapNodeTags.None) && (toNode.Region == null || !toNode.Region.IsBridge))
			{
				Region region = toNode.Region;
				if ((region == null || region.NonRoofedNodesCount != 0) && (toNode.DataType & GridDataType.SlopeOrStairs) != GridDataType.None)
				{
					return (toNode.Tag & MapNodeTags.Ladder) != 0;
				}
				return true;
			}
			return false;
		}

		internal bool HasRoom(Region region)
		{
			if (region == null)
			{
				return false;
			}
			lock (roomsByRegionLock)
			{
				return roomsByRegion.ContainsKey(region);
			}
		}

		internal Room GetRoom(MapNode node)
		{
			if (node == null)
			{
				return null;
			}
			if (node.Region == null)
			{
				lock (roomsLock)
				{
					foreach (Room room in rooms)
					{
						if (room.AllNodes.Contains(node))
						{
							return room;
						}
						if (room.WallNodes != null && room.WallNodes.Contains(node))
						{
							return room;
						}
					}
				}
				return null;
			}
			lock (roomsByRegionLock)
			{
				return roomsByRegion.GetValueOrDefault(node.Region);
			}
		}

		internal Room GetRoom(Vec3Int gridPosition)
		{
			MapNode node = map.GetNode(gridPosition);
			if (node?.Region == null)
			{
				return null;
			}
			return GetRoom(node.Region);
		}

		private static void AddToCheckRegions(in HashSet<Region> updateSet, Region nodeRegion)
		{
			if (!updateSet.Contains(nodeRegion) && !nodeRegion.IsBridge)
			{
				updateSet.Add(nodeRegion);
			}
		}

		private static float CalculateRoofedPercent(IEnumerable<Region> result)
		{
			int num = 0;
			int num2 = 0;
			foreach (Region item in result)
			{
				if (!item.IsBridge)
				{
					num += item.Nodes.Count;
					num2 += item.NonRoofedNodesCount;
				}
			}
			return (float)(num - num2) / (float)num;
		}

		private static string GetRegionsStr(HashSet<Region> result)
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<Region> list = result.ToList();
			list.Sort((Region a, Region b) => string.CompareOrdinal(b.ToString(), a.ToString()));
			foreach (Region item in list)
			{
				stringBuilder.Append(item);
				stringBuilder.Append(" ");
			}
			return stringBuilder.ToString();
		}

		private static bool CheckHasDoorsOrStairs(HashSet<Region> result)
		{
			foreach (Region item in result)
			{
				foreach (Region connection in item.Connections)
				{
					if (connection.IsBridge)
					{
						if ((connection.GridDataType & GridDataType.SlopeOrStairs) != GridDataType.None || (connection.GridDataType & GridDataType.FurnitureGate) != GridDataType.None)
						{
							return true;
						}
						if (connection is RegionBridge regionBridge && (regionBridge.Tags & MapNodeTags.Ladder) != MapNodeTags.None)
						{
							return true;
						}
					}
				}
				foreach (WorldObject reachableBuilding in item.ReachableBuildings)
				{
					if (reachableBuilding.Type == WorldObjectType.Building && (reachableBuilding.GridDataType & GridDataType.BuildingFinished) != GridDataType.None && (((BaseBuildingInstance)reachableBuilding).BuildingType & (BuildingType.Door | BuildingType.BarnDoor)) != 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		private void OnGameLoaded(bool fromSave)
		{
			isGameLoaded = true;
			StartUpdateTimer();
		}

		private void RemoveRoomFromSingleOwnerRooms(Room room)
		{
			if (RoomsWithSingleOwner.Contains(room))
			{
				RoomsWithSingleOwner.Remove(room);
				MonoSingleton<RoomDetectionController>.Instance.SingleOwnerRoomsChanged();
			}
		}

		private void AddRoomToSingleOwnerRooms(Room room)
		{
			if (room != null && room.GetSingleOwner() != null && !RoomsWithSingleOwner.Contains(room))
			{
				RoomsWithSingleOwner.Add(room);
				MonoSingleton<RoomDetectionController>.Instance.SingleOwnerRoomsChanged();
			}
		}

		private void OnBuildingOwnerUnregistered(BaseBuildingInstance baseBuildableObject, HumanoidInstance oldOwner)
		{
			Room room = baseBuildableObject.GetRoom();
			room?.BuildingOwnerUnregistered(baseBuildableObject, oldOwner);
			if (RoomsWithSingleOwner.Contains(room))
			{
				RoomsWithSingleOwner.Remove(room);
				MonoSingleton<RoomDetectionController>.Instance.SingleOwnerRoomsChanged();
			}
		}

		private void OnBuildingOwnerRegistered(BaseBuildingInstance baseBuildableObject)
		{
			Room room = baseBuildableObject.GetRoom();
			room?.BuildingOwnerRegistered(baseBuildableObject);
			if (room != null && room.RoomType.CanBeIndividual && room.GetSingleOwner() != null && !RoomsWithSingleOwner.Contains(room))
			{
				RoomsWithSingleOwner.Add(room);
				RoomsWithSingleOwner.RemoveAll((Room r) => r == null);
				RoomsWithSingleOwner.Sort((Room a, Room b) => b.ImpressivenessScore - a.ImpressivenessScore);
				MonoSingleton<RoomDetectionController>.Instance.SingleOwnerRoomsChanged();
			}
		}

		private void OnRoomTypeUnlocked(RoomType roomTypeUnlocked)
		{
			if (LoadingController.IsLoadingComplete)
			{
				string messageText = MonoSingleton<LocalizationController>.Instance.GetText("bbt_new_room_unlocked") + " " + roomTypeUnlocked.NameLocalized;
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageText);
			}
			foreach (Room room in rooms)
			{
				if (roomTypeUnlocked.CheckRoom(room))
				{
					ScheduleRoomTypeCheck(room);
				}
			}
		}

		private void OnFinishedBuilding(BaseBuildingInstance building)
		{
			if (building != null)
			{
				GetRoom(building.GetNode())?.AddToContent(building);
			}
		}

		private void OnConstructionCompleted(BaseBuildingInstance building)
		{
			Region region = building.GetNode()?.Region;
			if (region != null && !region.HasDisposed && !region.IsEmpty && !region.IsBridge)
			{
				regionsToCheck.Add(region);
				StartUpdateTimer();
			}
		}

		private void OnAutoconstructCompleted(BaseBuildingInstance building)
		{
			if (building != null)
			{
				GetRoom(building.GetNode())?.AddToContent(building);
			}
		}

		private void OnDestroyBuilding(BaseBuildingInstance building)
		{
			if (!LoadingController.IsLeavingMainScene)
			{
				GetRoom(building.GetNode())?.RemoveFromContent(building);
			}
		}

		private void OnObjectPlaced(WorldObject obj)
		{
			if (obj != null && obj.Type == WorldObjectType.ResourcePile)
			{
				GetRoom(obj.GetNode())?.AddToContent(obj);
			}
		}

		private void OnObjectRemoved(WorldObject obj)
		{
			if (obj.Type == WorldObjectType.ResourcePile)
			{
				GetRoom(obj.GetNode())?.RemoveFromContent(obj);
			}
		}

		private void OnNodeRemovedFromRegion(Region region, MapNode node)
		{
			ScheduleDeleteRoomAt(region);
			Area area = region.GetArea();
			if (area != null)
			{
				foreach (Region region2 in area.Regions)
				{
					ScheduleDeleteRoomAt(region2);
				}
			}
			if (region.IsBridge)
			{
				foreach (Region connection in region.Connections)
				{
					ScheduleDeleteRoomAt(connection);
				}
			}
			if (node.Coverage == CoverageType.Outside)
			{
				MapNode nodeBelow = node.GetNodeBelow();
				if (nodeBelow != null)
				{
					regionsChanged.Add(nodeBelow?.Region);
				}
			}
			StartUpdateTimer();
		}

		private void OnNodeVoxelTypeChanged(MapNode node)
		{
			StartUpdateTimer();
		}

		private void OnRegionBecameRoofed(Region region, bool isRoofed)
		{
			if (!region.HasDisposed && !region.IsEmpty && !region.IsBridge)
			{
				regionsToCheck.Add(region);
				StartUpdateTimer();
			}
		}

		private void OnNodeAddedToRegion(Region region, MapNode node)
		{
			foreach (MapNode item in node.ConnectionsSafe)
			{
				if (item?.Region != null)
				{
					ScheduleDeleteRoomAt(item.Region);
					regionsToCheck.Add(item.Region);
				}
			}
			regionsToCheck.Add(node.GetNodeAbove()?.Region);
			regionsToCheck.Add(node.Region);
			StartUpdateTimer();
		}

		private void OnRegionRemoving(Region region)
		{
			ScheduleDeleteRoomAt(region);
			Area area = region.GetArea();
			if (area != null)
			{
				foreach (Region region2 in area.Regions)
				{
					ScheduleDeleteRoomAt(region2);
				}
			}
			StartUpdateTimer();
		}

		private void OnRegionAdded(Region region)
		{
			ScheduleDeleteRoomAt(region);
			foreach (Region connection in region.Connections)
			{
				ScheduleDeleteRoomAt(connection);
			}
			StartUpdateTimer();
		}

		private void StartUpdateTimer()
		{
			if (isGameLoaded)
			{
				tickTimer.RestartTimer();
				tickTimer.Resume();
			}
		}

		private bool CheckRoomHolesFloodFill(HashSet<Region> roomRegions, HashSet<MapNode> nodesProcessed)
		{
			nodesProcessed.Clear();
			Queue<MapNode> queue = QueuePool<MapNode>.Get();
			foreach (Region roomRegion in roomRegions)
			{
				if (roomRegion.IsBridge)
				{
					continue;
				}
				foreach (MapNode node in roomRegion.Nodes)
				{
					if (node != null && (node.DataType & GridDataType.SlopeOrStairs) == 0 && (node.Tag & MapNodeTags.Ladder) == 0)
					{
						queue.Enqueue(node);
						nodesProcessed.Add(node);
					}
				}
			}
			bool flag = false;
			while (queue.Count > 0)
			{
				MapNode mapNode = queue.Dequeue();
				if (mapNode == null)
				{
					continue;
				}
				if (mapNode.Coverage == CoverageType.Outside && (mapNode.DataType & GridDataType.SlopeOrStairs) == 0 && (mapNode.Tag & MapNodeTags.Ladder) == 0)
				{
					flag = true;
					break;
				}
				if ((mapNode.DataType & GridDataType.SlopeOrStairs) != GridDataType.None || (mapNode.Tag & MapNodeTags.Ladder) != MapNodeTags.None)
				{
					continue;
				}
				foreach (MapNode item in mapNode.ConnectionsSafe)
				{
					if (!nodesProcessed.Contains(item) && CanGoToNeighbor(item))
					{
						queue.Enqueue(item);
						nodesProcessed.Add(item);
					}
				}
				MapNode nodeAbove = mapNode.GetNodeAbove();
				MapNode nodeBelow = mapNode.GetNodeBelow();
				if (nodeAbove != null && !nodesProcessed.Contains(nodeAbove) && CanGoUpToNode(mapNode, nodeAbove))
				{
					queue.Enqueue(nodeAbove);
					nodesProcessed.Add(nodeAbove);
				}
				if (nodeBelow != null && !nodesProcessed.Contains(nodeBelow) && CanGoDown(mapNode, nodeBelow))
				{
					queue.Enqueue(nodeBelow);
					nodesProcessed.Add(nodeBelow);
				}
			}
			QueuePool<MapNode>.Return(queue);
			return !flag;
		}

		private bool CanRoomStartFromRegion(Region startRegion, HashSet<Region> processedRegions, HashSet<Region> regionsCannotBeRoom, HashSet<Region> result)
		{
			result.Clear();
			Queue<Region> queue = QueuePool<Region>.Get();
			queue.Enqueue(startRegion);
			bool flag = true;
			if (startRegion.Connections.Count > 0)
			{
				do
				{
					Region region = queue.Dequeue();
					if (region.IsBridge && region is RegionBridge regionBridge && ((regionBridge.Tags & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.BarnDoor | MapNodeTags.DoorAlwaysOpen | MapNodeTags.EnemyDoorClosed)) != MapNodeTags.None || (regionBridge.GridDataType & GridDataType.SlopeOrStairs) != GridDataType.None || (regionBridge.Tags & MapNodeTags.Ladder) != MapNodeTags.None))
					{
						continue;
					}
					lock (roomsByRegionLock)
					{
						if (regionsCannotBeRoom.Contains(region) || roomsByRegion.ContainsKey(region))
						{
							flag = false;
							break;
						}
					}
					if (!processedRegions.Add(region))
					{
						continue;
					}
					if (!region.IsBridge)
					{
						Area area = region.GetArea();
						if (area.ConnectionsCount < area.NodesCount)
						{
							result.Add(region);
						}
					}
					foreach (Region connection in region.Connections)
					{
						if (!processedRegions.Contains(connection) && !queue.Contains(connection) && (!connection.IsBridge || !(connection is RegionBridge regionBridge2) || ((regionBridge2.Tags & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.BarnDoor | MapNodeTags.DoorAlwaysOpen | MapNodeTags.Ladder | MapNodeTags.EnemyDoorClosed)) == 0 && (regionBridge2.GridDataType & GridDataType.SlopeOrStairs) == 0)))
						{
							queue.Enqueue(connection);
						}
					}
				}
				while (queue.Count > 0);
			}
			QueuePool<Region>.Return(queue);
			queue = null;
			if (result.Count == 0)
			{
				return false;
			}
			if (flag)
			{
				float num = CalculateRoofedPercent(result);
				flag = flag && num >= 1f;
			}
			if (flag)
			{
				flag &= CheckHasDoorsOrStairs(result);
			}
			if (!flag)
			{
				foreach (Region item in result)
				{
					regionsCannotBeRoom.Add(item);
				}
			}
			return flag;
		}

		private bool CanBeRoom(Room room)
		{
			if (room.Regions.Count == 0)
			{
				return false;
			}
			HashSet<Region> hashSet = HashSetPool<Region>.Get();
			HashSet<Region> hashSet2 = HashSetPool<Region>.Get();
			HashSet<Region> hashSet3 = HashSetPool<Region>.Get();
			Dictionary<Region, bool> set = DictionaryPool<Region, bool>.Get();
			Queue<Region> set2 = QueuePool<Region>.Get();
			bool flag = true;
			foreach (Region region in room.Regions)
			{
				if (!hashSet.Contains(region))
				{
					flag &= CanRoomStartFromRegion(region, hashSet, hashSet2, hashSet3);
				}
			}
			if (flag)
			{
				HashSet<MapNode> hashSet4 = HashSetPool<MapNode>.Get();
				flag &= CheckRoomHolesFloodFill(hashSet3, hashSet4);
				HashSetPool<MapNode>.Return(hashSet4);
			}
			HashSetPool<Region>.Return(hashSet);
			HashSetPool<Region>.Return(hashSet2);
			HashSetPool<Region>.Return(hashSet3);
			DictionaryPool<Region, bool>.Return(set);
			QueuePool<Region>.Return(set2);
			return flag;
		}

		private void CheckRegionsForRoom()
		{
			if (detectRoomTask != null)
			{
				return;
			}
			HashSet<Region> toCheck = new HashSet<Region>(regionsToCheck);
			Dictionary<Room, HashSet<Region>> roomsDeletedOnMainThread = new Dictionary<Room, HashSet<Region>>(roomsRemoved);
			detectRoomTask = MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(delegate
			{
				lock (lockObject)
				{
					roomDetTimer.Restart();
					int num = 0;
					Dictionary<Region, bool> set = DictionaryPool<Region, bool>.Get();
					HashSet<Region> hashSet = HashSetPool<Region>.Get();
					HashSet<Region> hashSet2 = HashSetPool<Region>.Get();
					Queue<Region> set2 = QueuePool<Region>.Get();
					HashSet<Region> hashSet3 = HashSetPool<Region>.Get();
					HashSet<MapNode> hashSet4 = HashSetPool<MapNode>.Get();
					foreach (Region item in toCheck)
					{
						if (!item.HasDisposed && !hashSet.Contains(item) && GetRoom(item) == null)
						{
							bool flag = CanRoomStartFromRegion(item, hashSet, hashSet2, hashSet3);
							if (flag)
							{
								flag &= CheckRoomHolesFloodFill(hashSet3, hashSet4);
								flag &= !IsSlopeOnlyRegions(hashSet3);
							}
							if (flag)
							{
								CreateRoom(hashSet3, hashSet4, roomsDeletedOnMainThread);
								num++;
							}
						}
					}
					HashSetPool<MapNode>.Return(hashSet4);
					HashSetPool<Region>.Return(hashSet);
					HashSetPool<Region>.Return(hashSet2);
					HashSetPool<Region>.Return(hashSet3);
					DictionaryPool<Region, bool>.Return(set);
					QueuePool<Region>.Return(set2);
					roomDetTimer.Stop();
					lock (roomsRemovedThreadLock)
					{
						bool isEnabled;
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(67, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomDetection.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Check/create rooms finished in ");
							messageBuilder.AppendFormatted(roomDetTimer.ElapsedMilliseconds);
							messageBuilder.AppendLiteral(" ms. Rooms created ");
							messageBuilder.AppendFormatted(num);
							messageBuilder.AppendLiteral(". Rooms removed ");
							messageBuilder.AppendFormatted(roomsRemovedOnThread.Count);
							messageBuilder.AppendLiteral(".");
						}
						Log.Debug(messageBuilder);
					}
					detectRoomTask = null;
					foreach (HashSet<Region> value in roomsDeletedOnMainThread.Values)
					{
						value?.Clear();
					}
					roomsDeletedOnMainThread.Clear();
					return num > 0;
				}
			}, CreateRoomViewMainThread);
		}

		private bool IsSlopeOnlyRegions(HashSet<Region> regions)
		{
			foreach (Region region in regions)
			{
				foreach (MapNode node in region.Nodes)
				{
					if ((node.DataType & GridDataType.Slope) == 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		private void CreateRoomViewMainThread(bool success)
		{
			if (!success)
			{
				detectRoomTask = null;
				return;
			}
			using PooledHashSet<Room> pooledHashSet = HashSetPool<Room>.GetJanitor();
			bool isEnabled;
			lock (roomsRemovedThreadLock)
			{
				if (roomsRemovedOnThread.Count > 0)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(58, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomDetection.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Deleting views for ");
						messageBuilder.AppendFormatted(roomsRemovedOnThread.Count);
						messageBuilder.AppendLiteral(" rooms that were deleted on the thread.");
					}
					Log.Info(messageBuilder);
					foreach (Room item in roomsRemovedOnThread)
					{
						MonoSingleton<RoomDetectionController>.Instance.RoomRemoved(item);
						RemoveRoomFromSingleOwnerRooms(item);
						pooledHashSet.Add(item);
					}
					roomsRemovedOnThread.Clear();
				}
			}
			lock (roomsCreatedOnThreadLock)
			{
				if (roomsCreatedOnThread.Count <= 0)
				{
					return;
				}
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(58, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomDetection.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Creating views for ");
					messageBuilder.AppendFormatted(roomsCreatedOnThread.Count);
					messageBuilder.AppendLiteral(" rooms that were deleted on the thread.");
				}
				Log.Info(messageBuilder);
				foreach (KeyValuePair<Room, RoomType> item2 in roomsCreatedOnThread)
				{
					if (!pooledHashSet.Contains(item2.Key))
					{
						item2.Key.TickImpressiveness();
						MonoSingleton<RoomDetectionController>.Instance.RoomAdded(item2.Key, item2.Value);
						AddRoomToSingleOwnerRooms(item2.Key);
					}
				}
				if (!GlobalSaveController.CurrentVillageData.IsSecondMap)
				{
					MonoSingleton<AchievementManager>.Instance.UnlockAchievement("BUILD_ROOM");
				}
				roomsCreatedOnThread.Clear();
			}
		}

		private void CreateRoom(HashSet<Region> result, HashSet<MapNode> otherNodes, Dictionary<Room, HashSet<Region>> roomsDeletedOnMainThread)
		{
			Room room = new Room(map, result, otherNodes);
			lock (roomsLock)
			{
				rooms.Add(room);
			}
			List<Room> list = new List<Room>();
			foreach (Region region in room.Regions)
			{
				Room room2 = GetRoom(region);
				if (room2 != null && !list.Contains(room2))
				{
					list.Add(room2);
				}
			}
			if (list.Count > 0)
			{
				room.JoinWith(list);
				foreach (Room item in list)
				{
					DeleteRoom(item, fromThread: true);
				}
			}
			room.CreateWallNodes();
			room.CalculateCornerWallNodes();
			room.CalculateCenter();
			room.GatherFloorAndRoofNodes(otherNodes);
			room.FillRoomContent();
			room.GatherDoors();
			room.CalculateRoomType(fireRoomTypeChangeEvent: false);
			lock (roomsByRegionLock)
			{
				foreach (Region region2 in room.Regions)
				{
					roomsByRegion.Add(region2, room);
				}
			}
			foreach (MapNode allNode in room.AllNodes)
			{
				allNode.ForceRefreshBeautyInput();
			}
			Room deletedRoom = GetDeletedRoom(room.Regions, roomsDeletedOnMainThread);
			lock (roomsCreatedOnThreadLock)
			{
				roomsCreatedOnThread.Add(room, deletedRoom?.RoomType);
			}
		}

		private Room GetRoom(Region region)
		{
			if (region == null)
			{
				return null;
			}
			lock (roomsByRegionLock)
			{
				return roomsByRegion.GetValueOrDefault(region);
			}
		}

		private void DeleteRoom(Room room, bool fromThread)
		{
			lock (roomsLock)
			{
				if (!rooms.Contains(room))
				{
					return;
				}
				rooms.Remove(room);
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomDetection.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Deleted room ");
				messageBuilder.AppendFormatted(GetRegionsStr(room.Regions));
			}
			Log.Info(messageBuilder);
			lock (roomsByRegionLock)
			{
				foreach (Region region in room.Regions)
				{
					roomsByRegion.Remove(region);
				}
			}
			foreach (MapNode allNode in room.AllNodes)
			{
				allNode.ForceRefreshBeautyInput();
			}
			if (!fromThread)
			{
				roomsRemoved.Add(room, new HashSet<Region>(room.Regions));
			}
			if (fromThread)
			{
				lock (roomsRemovedThreadLock)
				{
					if (!roomsRemovedOnThread.Contains(room))
					{
						roomsRemovedOnThread.Add(room);
					}
					return;
				}
			}
			MonoSingleton<RoomDetectionController>.Instance.RoomRemoved(room);
			RemoveRoomFromSingleOwnerRooms(room);
			room.ClearAll();
		}

		private void ScheduleDeleteRoomAt(Region region)
		{
			if (region != null)
			{
				Room room = GetRoom(region);
				if (room != null)
				{
					ScheduleDeleteRoom(room);
				}
			}
		}

		private void ScheduleDeleteRoom(Room room)
		{
			roomsToDelete.Add(room);
		}

		private void DeleteRoomAt(Region region, bool deletingFromThread)
		{
			Room room = GetRoom(region);
			if (room != null)
			{
				DeleteRoom(room, deletingFromThread);
			}
		}

		private void DeleteRoomAt(MapNode node, bool deletingFromThread)
		{
			Room room = GetRoom(node);
			if (room != null)
			{
				DeleteRoom(room, deletingFromThread);
			}
		}

		private void TickRooms()
		{
			if (!MonoSingleton<World>.IsInstantiated() || MonoSingleton<World>.IsApplicationIsQuitting())
			{
				return;
			}
			if (roomsForTypeCheck.Count > 0)
			{
				foreach (Room item in roomsForTypeCheck)
				{
					if (item != null && !roomsToDelete.Contains(item))
					{
						item.CalculateRoomType(fireRoomTypeChangeEvent: true);
					}
				}
				roomsForTypeCheck.Clear();
			}
			Room room = null;
			lock (roomsLock)
			{
				foreach (Room room2 in rooms)
				{
					room2.TickImpressiveness();
				}
				if (rooms.Count > 0)
				{
					roomTempIndexCounter %= rooms.Count;
					room = rooms[roomTempIndexCounter];
					roomTempIndexCounter++;
				}
			}
			room?.TickAverageTemperature();
		}

		private void TimerUpdate()
		{
			foreach (Region region in map.RegionManager.Regions)
			{
				if (region.IsBridge)
				{
					continue;
				}
				if (region.IsFullyRoofed())
				{
					if (region.Nodes.Count > 2 && GetRoom(region) == null)
					{
						AddToCheckRegions(in regionsToCheck, region);
					}
				}
				else if (GetRoom(region) != null)
				{
					AddToCheckRegions(in regionsChanged, region);
				}
			}
			regionsChanged.RemoveWhere((Region item) => item?.HasDisposed ?? true);
			if (regionsChanged.Count > 0)
			{
				HashSet<Room> hashSet = HashSetPool<Room>.Get();
				foreach (Region item in regionsChanged)
				{
					if (item != null && !item.HasDisposed)
					{
						Room room = GetRoom(item);
						if (room != null && hashSet.Add(room) && !CanBeRoom(room))
						{
							ScheduleDeleteRoom(room);
						}
					}
				}
				regionsChanged.Clear();
				HashSetPool<Room>.Return(hashSet);
			}
			if (roomsToDelete.Count > 0)
			{
				foreach (Room item2 in roomsToDelete)
				{
					if (item2 == null)
					{
						continue;
					}
					foreach (Region region2 in item2.Regions)
					{
						regionsToCheck.Add(region2);
					}
					DeleteRoom(item2, fromThread: false);
				}
				roomsToDelete.Clear();
			}
			regionsToCheck.RemoveWhere((Region item) => item == null || item.HasDisposed || GetRoom(item) != null);
			if (regionsToCheck.Count > 0)
			{
				CheckRegionsForRoom();
				regionsToCheck.Clear();
			}
			if (roomsRemoved.Count > 0)
			{
				roomsRemoved.Clear();
			}
		}

		private Room GetDeletedRoom(HashSet<Region> newRegions, Dictionary<Room, HashSet<Region>> roomsRemovedOnMainThread)
		{
			foreach (KeyValuePair<Room, HashSet<Region>> item in roomsRemovedOnMainThread)
			{
				if (item.Value.Overlaps(newRegions))
				{
					return item.Key;
				}
			}
			lock (roomsRemovedThreadLock)
			{
				foreach (Room item2 in roomsRemovedOnThread)
				{
					if (item2.Regions.Overlaps(newRegions))
					{
						return item2;
					}
				}
			}
			return null;
		}

		internal void DrawGizmos(Vec3Int cursorGridPosition)
		{
			if (map != null && !HasDisposed)
			{
				MapNode node = map.GetNode(cursorGridPosition);
				if (node != null)
				{
					GetRoom(node)?.DrawGizmos();
				}
			}
		}

		public Room GetRoomForDoor(BaseBuildingInstance door)
		{
			foreach (Room room in rooms)
			{
				if (room.ContainsDoor(door))
				{
					return room;
				}
			}
			return null;
		}
	}
}
