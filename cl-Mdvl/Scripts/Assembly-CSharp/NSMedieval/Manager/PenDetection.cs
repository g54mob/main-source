using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Terrain;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Manager
{
	public class PenDetection : MonoSingleton<PenDetection>
	{
		[NonSerialized]
		private VillageMap map;

		private readonly List<AnimalPenInstance> animalPens = new List<AnimalPenInstance>();

		private readonly Queue<Region> regionsToRefresh = new Queue<Region>();

		private int delayBeforeRefresh;

		public IEnumerable<AnimalPenInstance> AnimalPens => animalPens;

		public event Action OnPensRefreshed;

		public void PenMarkerWaterLevelChanged(PenMarkerComponentInstance penMarkerInstance)
		{
			Region region = penMarkerInstance.GetNode().Region;
			if (region != null)
			{
				ScheduleRegionRefresh(region);
				GetPen(region)?.OnMarkerDeleted(penMarkerInstance);
			}
			MapNode node = penMarkerInstance.GetNode();
			if (node == null)
			{
				return;
			}
			foreach (MapNode item in node.ConnectionsSafe)
			{
				ScheduleRegionRefresh(item.Region);
			}
		}

		public bool CanBeAddedToSomePen(AnimalInstance instance)
		{
			AnimalPenInstance pen;
			return CanBeAddedToSomePen(instance, out pen);
		}

		public bool CanBeAddedToSomePen(AnimalInstance instance, out AnimalPenInstance pen)
		{
			if (!instance.Blueprint.CanBeInPen)
			{
				pen = null;
				return false;
			}
			pen = animalPens.FirstOrDefault((AnimalPenInstance item) => item.CanTakeAnimal(instance));
			return pen != null;
		}

		public MapNode GetAvailablePenNodeForAnimal(AnimalInstance instance)
		{
			if (!instance.Blueprint.CanBeInPen || animalPens.Count == 0)
			{
				return null;
			}
			TagTraversalProvider tmpProvider = new TagTraversalProvider((TagTraversalProvider)instance.PathTraversalProvider);
			tmpProvider.NotWalkableTags &= ~(MapNodeTags.DoorWorkerWalkable | MapNodeTags.Fence | MapNodeTags.BarnDoor | MapNodeTags.ClosedFenceGate);
			foreach (AnimalPenInstance animalPen in animalPens)
			{
				if (CombatUtils.IsNullOrDisposed(instance) || !animalPen.CanTakeAnimal(instance))
				{
					continue;
				}
				foreach (Region item in animalPen.Regions.Where((Region region) => !region.IsBridge).Shuffle())
				{
					MapNode mapNode = item.Nodes.Where((MapNode node) => PathfinderUtil.IsRegionReachable(tmpProvider, instance.GetNode().Region, node.Region)).PickRandom();
					if (mapNode != null)
					{
						return mapNode;
					}
				}
			}
			return null;
		}

		public AnimalPenInstance GetPen(MapNode mapNode)
		{
			if (mapNode == null || mapNode.Region == null)
			{
				return null;
			}
			return GetPen(mapNode.Region);
		}

		public AnimalPenInstance GetPen(Region region)
		{
			foreach (AnimalPenInstance animalPen in animalPens)
			{
				if (animalPen.ContainsRegion(region))
				{
					return animalPen;
				}
			}
			return null;
		}

		public bool IsAnimalInOwnPen(AnimalInstance animalInstance)
		{
			return GetPen(animalInstance.GetNode())?.CanTakeAnimal(animalInstance) ?? false;
		}

		private void Start()
		{
			map = VillageManager.ActiveVillage.Map;
			MonoSingleton<SceneController>.Instance.LateTick += OnLateTick;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
		}

		private void OnWaterLevelChanged(HashSet<int> waterVoxels, HashSet<int> waterVoxelsNeighbors)
		{
			foreach (AnimalPenInstance animalPen in animalPens)
			{
				foreach (Region region in animalPen.Regions)
				{
					Area area = region.GetArea();
					if (area != null && area.IsTouchingEdge)
					{
						ScheduleRegionRefresh(region);
					}
				}
			}
		}

		private void LockStateChanged(BaseBuildingInstance building)
		{
			if (building == null || building.Blueprint == null)
			{
				return;
			}
			BuildingType buildingType = BuildingType.AnyDoor;
			if (!buildingType.HasFlag(building.BuildingType) && !building.Blueprint.IsRegionBridge)
			{
				return;
			}
			MapNode node = building.GetNode();
			ScheduleRegionRefresh(node.Region);
			foreach (MapNode item in node.ConnectionsSafe)
			{
				ScheduleRegionRefresh(item.Region);
			}
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnAfterConstructionCompleted;
				MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnDestroyBuilding;
				MonoSingleton<ConstructionController>.Instance.LockStateChangedEvent -= LockStateChanged;
				MonoSingleton<ConstructionController>.Instance.OnDoorLockStateChangedEvent -= LockStateChanged;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.LateTick -= OnLateTick;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (MonoSingleton<GroundController>.IsInstantiated())
			{
				MonoSingleton<GroundController>.Instance.NewVoxelSavedEvent -= OnNewVoxelSaved;
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent -= OnGroundDestroyed;
			}
			if (map?.WaterManager != null)
			{
				map.WaterManager.WaterLevelChangedEvent -= OnWaterLevelChanged;
			}
			if (map?.RegionManager != null)
			{
				map.RegionManager.OnRegionAddedEvent -= OnRegionAdded;
			}
			map = null;
			base.OnDestroy();
		}

		private static bool CheckRegion(Region region)
		{
			if (region.HasMapEdgeNodes)
			{
				return false;
			}
			if (region.IsBridge)
			{
				return (((RegionBridge)region).Tags & (MapNodeTags.BarnDoor | MapNodeTags.DoorAlwaysOpen)) != 0;
			}
			if (region.Connections.Count == 0)
			{
				return false;
			}
			return true;
		}

		private static HashSet<Region> GetPossiblePenRegions(Region startRegion)
		{
			if (!CheckRegion(startRegion))
			{
				return null;
			}
			Area areaById = startRegion.Map.RegionAreaManager.GetAreaById(startRegion.Area);
			if (areaById == null || areaById.Regions.Count == 0 || areaById.IsTouchingEdge || areaById.HasDisposed)
			{
				return null;
			}
			HashSet<Region> hashSet = new HashSet<Region>();
			HashSet<Region> hashSet2 = HashSetPool<Region>.Get();
			Queue<Region> queue = QueuePool<Region>.Get();
			queue.Enqueue(startRegion);
			do
			{
				Region region = queue.Dequeue();
				hashSet2.Add(region);
				if (startRegion.Map.RegionAreaManager.GetAreaById(region.Area).IsTouchingEdge)
				{
					HashSetPool<Region>.Return(hashSet2);
					QueuePool<Region>.Return(queue);
					return null;
				}
				hashSet.Add(region);
				foreach (Region connection in region.Connections)
				{
					if (!hashSet2.Contains(connection) && (!connection.IsBridge || !(connection is RegionBridge regionBridge) || (regionBridge.Tags & MapNodeTags.DoorAlwaysOpen) != MapNodeTags.None || ((regionBridge.Tags & MapNodeTags.ClosedFenceGate) == 0 && (regionBridge.Tags & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked)) == 0 && ((regionBridge.Tags & MapNodeTags.BarnDoor) != MapNodeTags.None || (regionBridge.GridDataType & (GridDataType.SlopeOrStairs | GridDataType.FurnitureGate)) != GridDataType.None) && (regionBridge.Tags & MapNodeTags.Fence) == 0)) && !queue.Contains(connection))
					{
						queue.Enqueue(connection);
					}
				}
			}
			while (queue.Count > 0);
			HashSetPool<Region>.Return(hashSet2);
			QueuePool<Region>.Return(queue);
			return hashSet;
		}

		public static int GetAreaConnectionsCount(IEnumerable<Region> regions)
		{
			HashSet<Area> hashSet = HashSetPool<Area>.Get();
			foreach (Region region in regions)
			{
				if (region.GetArea() != null)
				{
					hashSet.Add(region.GetArea());
				}
			}
			int num = 0;
			foreach (Area item in hashSet)
			{
				num += item.ConnectionsCount;
			}
			HashSetPool<Area>.Return(hashSet);
			return num;
		}

		private static bool IsClosedArea(Region startRegion)
		{
			if (startRegion.HasMapEdgeNodes)
			{
				return false;
			}
			Area areaById = startRegion.Map.RegionAreaManager.GetAreaById(startRegion.Area);
			if (areaById == null)
			{
				return false;
			}
			return !areaById.IsTouchingEdge;
		}

		private void OnAfterConstructionCompleted(BaseBuildingInstance building)
		{
			if (building == null || building.Blueprint == null)
			{
				return;
			}
			bool num = building.Blueprint.BuildingType == BuildingType.PenMarker;
			bool flag = building.Blueprint.IsWallTypeBuilding();
			bool flag2 = building.Blueprint.BuildingType == BuildingType.Fence;
			if (!num && !flag && !flag2)
			{
				return;
			}
			Region region = building.GetNode()?.Region;
			if (region != null)
			{
				ScheduleRegionRefresh(region);
				AnimalPenInstance pen = GetPen(region);
				if (pen != null)
				{
					PenMarkerComponentInstance componentInstance = building.Map.PenMarkerComponentManager.GetComponentInstance(building);
					pen.OnMarkerAdded(componentInstance);
				}
			}
			MapNode node = building.GetNode();
			if (node == null)
			{
				return;
			}
			foreach (MapNode item in node.ConnectionsSafe)
			{
				ScheduleRegionRefresh(item.Region);
			}
		}

		private void OnDestroyBuilding(BaseBuildingInstance building)
		{
			if (building == null || building.Blueprint == null)
			{
				return;
			}
			bool num = building.Blueprint.BuildingType == BuildingType.PenMarker;
			bool flag = building.Blueprint.IsWallTypeBuilding();
			bool flag2 = building.Blueprint.BuildingType == BuildingType.Fence;
			if (!num && !flag && !flag2)
			{
				return;
			}
			Region region = building.GetNode()?.Region;
			if (region != null)
			{
				ScheduleRegionRefresh(region);
				AnimalPenInstance pen = GetPen(region);
				if (pen != null)
				{
					PenMarkerComponentInstance componentInstance = building.Map.PenMarkerComponentManager.GetComponentInstance(building);
					pen.OnMarkerDeleted(componentInstance);
				}
			}
			MapNode node = building.GetNode();
			if (node == null)
			{
				return;
			}
			foreach (MapNode item in node.ConnectionsSafe)
			{
				ScheduleRegionRefresh(item.Region);
			}
		}

		private void OnLateTick(float t)
		{
			using (ProfilerSampleJanitor.Begin("PenDetection.LateTick"))
			{
				if (delayBeforeRefresh > 0)
				{
					delayBeforeRefresh--;
				}
				else
				{
					if (!regionsToRefresh.Any())
					{
						return;
					}
					while (regionsToRefresh.Any())
					{
						Region startRegion = regionsToRefresh.Dequeue();
						RefreshRegion(startRegion);
					}
					foreach (AnimalPenInstance item in animalPens.IterateInReverseDynamic())
					{
						if (item != null && !item.AllMarkersValid())
						{
							RemovePen(item);
						}
					}
					this.OnPensRefreshed?.Invoke();
				}
			}
		}

		private void OnMapLoaded(bool fromSave)
		{
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnAfterConstructionCompleted;
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnDestroyBuilding;
			MonoSingleton<ConstructionController>.Instance.LockStateChangedEvent += LockStateChanged;
			MonoSingleton<ConstructionController>.Instance.OnDoorLockStateChangedEvent += LockStateChanged;
			MonoSingleton<GroundController>.Instance.NewVoxelSavedEvent += OnNewVoxelSaved;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent += OnGroundDestroyed;
			map.WaterManager.WaterLevelChangedEvent += OnWaterLevelChanged;
			map.RegionManager.OnRegionAddedEvent += OnRegionAdded;
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (!fromSave)
			{
				return;
			}
			foreach (Region region in map.RegionManager.Regions)
			{
				if (!region.HasMapEdgeNodes)
				{
					ScheduleRegionRefresh(region);
				}
			}
		}

		private void OnGroundDestroyed(List<Vec3Int> positions)
		{
			if (map == null)
			{
				return;
			}
			foreach (Vec3Int position in positions)
			{
				MapNode node = map.GetNode(position);
				if (node?.Region == null)
				{
					continue;
				}
				ScheduleRegionRefresh(node.Region);
				foreach (MapNode item in node.ConnectionsSafe)
				{
					if (item?.Region != null)
					{
						ScheduleRegionRefresh(item.Region);
					}
				}
			}
		}

		private void OnNewVoxelSaved(BaseBuildingInstance obj)
		{
			MapNode node = obj.GetNode();
			if (node == null)
			{
				return;
			}
			if (node.Region != null)
			{
				ScheduleRegionRefresh(node.Region);
			}
			foreach (MapNode item in node.ConnectionsSafe)
			{
				if (item.Region != null)
				{
					ScheduleRegionRefresh(item.Region);
				}
			}
		}

		private void OnRegionAdded(Region region)
		{
			ScheduleRegionRefresh(region);
		}

		private void RemovePen(AnimalPenInstance pen)
		{
			animalPens.Remove(pen);
			HashSet<Region> hashSet = HashSetPool<Region>.Get();
			foreach (Region region in pen.Regions)
			{
				hashSet.UnionWith(region.Connections);
			}
			hashSet.ExceptWith(pen.Regions);
			foreach (Region item in hashSet)
			{
				ScheduleRegionRefresh(item);
			}
			HashSetPool<Region>.Return(hashSet);
			MonoSingleton<PenController>.Instance.PenRemoved(pen);
		}

		private void RefreshRegion(Region startRegion)
		{
			if (startRegion == null || startRegion.HasDisposed || startRegion.IsEmpty)
			{
				return;
			}
			AnimalPenInstance pen = GetPen(startRegion);
			if (startRegion.HasMapEdgeNodes)
			{
				if (pen != null)
				{
					RemovePen(pen);
				}
				return;
			}
			if (pen != null && GetAreaConnectionsCount(pen.Regions) == 0)
			{
				RemovePen(pen);
				return;
			}
			HashSet<Region> possiblePenRegions = GetPossiblePenRegions(startRegion);
			bool flag = possiblePenRegions?.Any((Region region) => region.HasPenMarker) ?? false;
			if (pen == null)
			{
				if (flag && !HasPenWithRegions(possiblePenRegions))
				{
					CreateNewPen(possiblePenRegions);
				}
			}
			else if (!flag)
			{
				RemovePen(pen);
			}
			else
			{
				pen.ReplaceRegions(possiblePenRegions);
				MonoSingleton<PenController>.Instance.PenRegionRefreshed(pen);
			}
		}

		private bool HasPenWithRegions(ISet<Region> possiblePenRegions)
		{
			foreach (AnimalPenInstance animalPen in animalPens)
			{
				if (possiblePenRegions.SetEquals(animalPen.Regions))
				{
					return true;
				}
			}
			return false;
		}

		private void ScheduleRegionRefresh(Region region)
		{
			if (region != null && !regionsToRefresh.Contains(region))
			{
				delayBeforeRefresh = 5;
				regionsToRefresh.Enqueue(region);
			}
		}

		private void CreateNewPen(HashSet<Region> regions)
		{
			AnimalPenInstance animalPenInstance = null;
			List<AnimalPenInstance> list = new List<AnimalPenInstance>();
			foreach (Region region in regions)
			{
				AnimalPenInstance pen = GetPen(region);
				if (pen != null)
				{
					if (animalPenInstance == null)
					{
						animalPenInstance = pen;
					}
					if (pen != animalPenInstance && !list.Contains(pen))
					{
						list.Add(pen);
					}
				}
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				if (MonoSingleton<AnimalManager>.IsInstantiated())
				{
					MonoSingleton<AnimalManager>.Instance.RefreshAllMarkForRoping();
				}
			});
			if (animalPenInstance == null)
			{
				AnimalPenInstance animalPenInstance2 = new AnimalPenInstance(regions);
				animalPens.Add(animalPenInstance2);
				MonoSingleton<PenController>.Instance.PenAdded(animalPenInstance2);
				return;
			}
			foreach (AnimalPenInstance item in list)
			{
				animalPens.Remove(item);
				MonoSingleton<PenController>.Instance.PenRemoved(item);
			}
			animalPenInstance.ReplaceRegions(regions);
			MonoSingleton<PenController>.Instance.PenRegionRefreshed(animalPenInstance);
		}
	}
}
