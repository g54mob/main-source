using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using Managers.Selection.EventData;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View.Slope;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class SlopeManager : MonoSingleton<SlopeManager>, IObserver
	{
		[NonSerialized]
		private Dictionary<SlopeInstance, SlopeView> instanceViewDictionary = new Dictionary<SlopeInstance, SlopeView>();

		[NonSerialized]
		private Heightmap heightmap;

		[NonSerialized]
		private VillageMap map;

		[NonSerialized]
		private HashSet<MapNode> refreshSlopeNeighbors;

		public event Action<Vec3Int> OnSlopeDestroyedEvent;

		public void GetSlopesInRange(int y, int minX, int maxX, int minZ, int maxZ, ref List<SlopeInstance> outSelectedSlopes)
		{
			if (y <= 0)
			{
				return;
			}
			Vec3Int gridPosition = new Vec3Int(0, y, 0);
			for (int i = minX; i <= maxX; i++)
			{
				gridPosition.x = i;
				for (int j = minZ; j <= maxZ; j++)
				{
					gridPosition.z = j;
					SlopeInstance slopeAtPosition = MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(gridPosition);
					if (slopeAtPosition != null && !outSelectedSlopes.Contains(slopeAtPosition))
					{
						outSelectedSlopes.Add(slopeAtPosition);
					}
				}
			}
		}

		public IEnumerable<SlopeInstance> EnumerateSlopesInRange(int y, int minX, int maxX, int minZ, int maxZ)
		{
			if (y <= 0)
			{
				yield break;
			}
			using PooledHashSet<SlopeInstance> added = HashSetPool<SlopeInstance>.GetJanitor();
			Vec3Int gridPosition = new Vec3Int(0, y, 0);
			for (int x = minX; x <= maxX; x++)
			{
				gridPosition.x = x;
				for (int z = minZ; z <= maxZ; z++)
				{
					gridPosition.z = z;
					SlopeInstance slopeAtPosition = MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(gridPosition);
					if (slopeAtPosition != null && added.Add(slopeAtPosition))
					{
						yield return slopeAtPosition;
					}
				}
			}
		}

		public SlopeView GetView(SlopeInstance slope)
		{
			instanceViewDictionary.TryGetValue(slope, out var value);
			return value;
		}

		public SlopeInstance GetSlopeAtPosition(Vec3Int gridPosition)
		{
			return map.GetNode(gridPosition)?.GetWorldObject(GridDataType.Slope) as SlopeInstance;
		}

		public bool SlopeExists(Vec3Int pos)
		{
			return SlopeExists(pos.x, pos.y, pos.z);
		}

		public bool SlopeExists(int x, int y, int z)
		{
			int num = GridDataIndexTools.FastTo1DIndex(x, y, z);
			if (num == -1)
			{
				return false;
			}
			MapNode mapNode = map.GridSpaceData[num];
			if ((mapNode.DataType & GridDataType.Slope) == 0)
			{
				return false;
			}
			List<WorldObject> worldObjects = mapNode.WorldObjects;
			int count = worldObjects.Count;
			for (int i = 0; i < count; i++)
			{
				if ((worldObjects[i].GridDataType & GridDataType.Slope) != GridDataType.None)
				{
					return true;
				}
			}
			return false;
		}

		public void DigSlope(SlopeInstance slopeAtPosition)
		{
			slopeAtPosition.OnMarkedForDig();
			instanceViewDictionary.TryGetValue(slopeAtPosition, out var value);
			if (value != null)
			{
				value.MarkForDigging();
			}
		}

		public bool OnDigActionCompleted(SlopeInstance slope)
		{
			bool flag = slope.OnDigActionCompleted();
			if (flag)
			{
				ForceRemoveSlope(slope);
				foreach (Vec3Int position in slope.Positions)
				{
					MonoSingleton<ConstructionController>.Instance.ObjectDestroyedCheckFallDown(position);
				}
			}
			return flag;
		}

		public void SpawnProfileSlopes()
		{
			foreach (SlopeInstance item in (IEnumerable<SlopeInstance>)map.GetWorldObjectsList<SlopeInstance>(GridDataType.Slope, distinct: true))
			{
				item.ReInstantiate();
				SpawnSlopeInstance(item);
				CreateViewForInstance(item);
				if (item.MarkedForDig)
				{
					SlopeView view = GetView(item);
					if (view != null)
					{
						view.MarkForDigging();
					}
				}
			}
			RefreshSlopeNeighbors();
		}

		public void CreateViews(VillageMap villageMap)
		{
			foreach (SlopeInstance item in (IEnumerable<SlopeInstance>)villageMap.GetWorldObjectsList<SlopeInstance>(GridDataType.Slope, distinct: true))
			{
				if (!instanceViewDictionary.ContainsKey(item))
				{
					CreateViewForInstance(item);
				}
			}
		}

		private void CreateViewForInstance(SlopeInstance slope)
		{
			GameObject slopeGameObject = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByID(slope.BlueprintId).Value, slope.WorldPosition, Quaternion.Euler(0f, slope.Angle, 0f));
			SetupSlopeView(slope, slopeGameObject);
		}

		public void ConvertStairsToSlope(BaseBuildingInstance stairsInstance)
		{
			List<Vec3Int> list = new List<Vec3Int>(stairsInstance.Positions);
			list.Reverse();
			SlopeBuildingComponentBlueprint byID = Repository<SlopeBuildingComponentRepository, SlopeBuildingComponentBlueprint>.Instance.GetByID(stairsInstance.Blueprint.SlopeComponentID);
			if (byID == null)
			{
				Log.Warning("Couldn't find slope component blueprint!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\SlopeManager.cs");
				return;
			}
			string voxelTypeID = byID.VoxelTypeID;
			VoxelType byID2 = VoxelTypeRepository.FastInstance.GetByID(voxelTypeID);
			SlopeInstance slope = new SlopeInstance(Repository<SlopeRepository, Slope>.Instance.GetByID("slope"), stairsInstance.WorldPosition, list, stairsInstance.Angle - 90f, "stairsSlope", byID2);
			SpawnSlopeInstance(slope);
			CreateViewForInstance(slope);
			RefreshSlopeNeighbors();
		}

		public void RefreshSlopeNeighbors()
		{
			foreach (MapNode refreshSlopeNeighbor in refreshSlopeNeighbors)
			{
				refreshSlopeNeighbor?.ForceRefresh();
			}
			refreshSlopeNeighbors.Clear();
		}

		public void SpawnSlopeInstance(SlopeInstance slope)
		{
			map.AddToTheWorld(slope);
			foreach (Vec3Int position in slope.Positions)
			{
				map.GetNode(position.x, position.y, position.z)?.UpdateVoxelType(null);
			}
			foreach (MapNode item in slope.Nodes())
			{
				foreach (MapNode item2 in MapNodeUtils.IterateEachNeighbor(item))
				{
					if (!item2.IsLayerRamp())
					{
						refreshSlopeNeighbors.Add(item2);
					}
				}
			}
			foreach (Vec3Int position2 in slope.Positions)
			{
				MapNode node = map.GetNode(position2.x, position2.y, position2.z);
				if (node != null)
				{
					KillPlantsOnNode(node);
				}
				node = map.GetNode(position2.x, position2.y + 1, position2.z);
				if (node != null)
				{
					KillPlantsOnNode(node);
				}
			}
			slope.Map.BuildingsManagerMain.RecalculateReachabilityForNeighbors(slope);
		}

		private static void KillPlantsOnNode(MapNode node)
		{
			List<WorldObject> worldObjects = node.WorldObjects;
			if (worldObjects != null && worldObjects.Count == 0)
			{
				return;
			}
			foreach (WorldObject item in node.WorldObjects.IterateInReverseDynamic())
			{
				if ((item.GridDataType & GridDataType.PlantMapResource) != GridDataType.None)
				{
					((PlantMapResourceInstance)item).Dispose();
				}
			}
		}

		private void TryDeleteDigMarker(DigMarkerResourceInstance digMarker)
		{
			digMarker.DontChangeTerrain();
			MonoSingleton<ReservationManager>.Instance.ReleaseAll(digMarker);
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				if (digMarker != null)
				{
					MonoSingleton<ResourceCommonController>.Instance.DestroyResource(digMarker);
				}
			});
		}

		public void ForceRemoveSlope(SlopeInstance slopeInstance)
		{
			DigMarkerResourceInstance digMarker = slopeInstance.GetDigMarker();
			if (digMarker != null)
			{
				map.BuildingsManagerMain.ConstructionJobManager.RemoveDigJobs(digMarker);
				TryDeleteDigMarker(digMarker);
			}
			map.RemoveFromWorld(slopeInstance);
			SlopeView view = GetView(slopeInstance);
			instanceViewDictionary.Remove(slopeInstance);
			foreach (Vec3Int position in slopeInstance.Positions)
			{
				MonoSingleton<ConstructionController>.Instance.ObjectDestroyedCheckFallDown(position);
			}
			if (view != null)
			{
				view.Dispose();
			}
			Vec3Int gridDataPosition = slopeInstance.GridDataPosition;
			slopeInstance.Dispose();
			this.OnSlopeDestroyedEvent?.Invoke(gridDataPosition);
			VillageManager.ActiveVillage.Map.BuildingsManagerMain.WorldStateChangedRefreshBuildings();
		}

		private void SetupSlopeView(SlopeInstance slopeInstance, GameObject slopeGameObject)
		{
			SlopeView componentInChildren = slopeGameObject.GetComponentInChildren<SlopeView>();
			componentInChildren.Setup(slopeInstance);
			instanceViewDictionary.Add(slopeInstance, componentInChildren);
		}

		private IEnumerator Start()
		{
			map = VillageManager.ActiveVillage.Map;
			heightmap = MonoSingleton<Heightmap>.Instance;
			MonoSingleton<SelectionManager>.Instance.OrderResourceCollectionEvent += OnOrderResourceCollectionEvent;
			map.ObjectRemovedEvent += OnObjectRemoved;
			map.ObjectPlacedEvent += OnObjectPlaced;
			refreshSlopeNeighbors = new HashSet<MapNode>();
			while (map.BuildingsManagerMain == null || !MonoSingleton<GroundController>.IsInstantiated())
			{
				yield return new WaitForSeconds(0.1f);
			}
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent += OnGroundDestroyed;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent += OnGroundDestroyedSingle;
			map.BuildingsManagerMain.StabilityCarrierDestroyedEvent += OnStabilityCarrierDestroyed;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<SelectionManager>.IsInstantiated())
			{
				MonoSingleton<SelectionManager>.Instance.OrderResourceCollectionEvent -= OnOrderResourceCollectionEvent;
			}
			if (map != null)
			{
				map.ObjectRemovedEvent -= OnObjectRemoved;
				map.ObjectPlacedEvent -= OnObjectPlaced;
			}
			if (map?.BuildingsManagerMain != null)
			{
				map.BuildingsManagerMain.StabilityCarrierDestroyedEvent -= OnStabilityCarrierDestroyed;
			}
			if (MonoSingleton<GroundController>.IsInstantiated())
			{
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent -= OnGroundDestroyed;
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent -= OnGroundDestroyedSingle;
			}
			heightmap = null;
			base.OnDestroy();
			this.OnSlopeDestroyedEvent = null;
		}

		private void OnObjectRemoved(WorldObject obj)
		{
			RefreshSlopeReachabilityAroundObject(obj);
		}

		private void OnObjectPlaced(WorldObject obj)
		{
			RefreshSlopeReachabilityAroundObject(obj);
		}

		private void RefreshSlopeReachabilityAroundObject(WorldObject obj)
		{
			if (obj?.Positions == null)
			{
				return;
			}
			List<Vec3Int> list = new List<Vec3Int>();
			if (obj.Positions != null)
			{
				foreach (Vec3Int position in obj.Positions)
				{
					Vec3Int a = position;
					Vec3Int[] neighborsXZ = MapNodeUtils.NeighborsXZ;
					for (int i = 0; i < neighborsXZ.Length; i++)
					{
						Vec3Int b = neighborsXZ[i];
						Vec3Int item = a + b;
						if (!list.Contains(item))
						{
							list.Add(item);
						}
					}
				}
				foreach (Vec3Int position2 in obj.Positions)
				{
					list.Remove(position2);
				}
			}
			else
			{
				list.Add(obj.GridDataPosition);
			}
			List<SlopeInstance> list2 = new List<SlopeInstance>();
			foreach (Vec3Int item2 in list)
			{
				SlopeInstance slopeAtPosition = GetSlopeAtPosition(item2);
				if (slopeAtPosition != null && slopeAtPosition.MarkedForDig && !list2.Contains(slopeAtPosition))
				{
					list2.Add(slopeAtPosition);
					slopeAtPosition.GetDigMarker()?.ReCalculateReachability();
				}
			}
		}

		private void OnOrderResourceCollectionEvent(OrderEventData eventData)
		{
			if (eventData.OrderType != OrderType.Cancel)
			{
				return;
			}
			foreach (SlopeInstance item in EnumerateSlopesInRange((int)(eventData.Y / (float)World.MapBlockHeight) - 1, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y))
			{
				item.OnDigCanceled();
			}
		}

		public void CancelDigMarker(Vec3Int gridPosition)
		{
			GetSlopeAtPosition(gridPosition)?.OnDigCanceled();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsSlopeAt(Vector2Int position2d)
		{
			return IsSlopeAt(position2d.x, position2d.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsSlopeAt(int x, int z)
		{
			int heightAt = heightmap.GetHeightAt(x, z);
			if (!SlopeExists(new Vec3Int(x, heightAt, z)))
			{
				return SlopeExists(new Vec3Int(x, heightAt - 1, z));
			}
			return true;
		}

		private void OnGroundDestroyedSingle(Vec3Int position)
		{
			SlopeInstance[] array = instanceViewDictionary.Keys.ToArray();
			foreach (SlopeInstance slopeInstance in array)
			{
				if (slopeInstance.Positions.Contains(position + Vec3Int.up))
				{
					ForceRemoveSlope(slopeInstance);
				}
			}
		}

		private void OnGroundDestroyed(List<Vec3Int> positions)
		{
			SlopeInstance[] array = instanceViewDictionary.Keys.ToArray();
			foreach (SlopeInstance slopeInstance in array)
			{
				foreach (Vec3Int position in positions)
				{
					Vec3Int a = position;
					if (slopeInstance.Positions.Contains(a + Vec3Int.up))
					{
						ForceRemoveSlope(slopeInstance);
					}
				}
			}
		}

		private void OnStabilityCarrierDestroyed(BaseBuildingInstance buildingInstance, bool replaced)
		{
			if (replaced)
			{
				return;
			}
			Vec3Int a = buildingInstance.GridDataPosition;
			SlopeInstance[] array = instanceViewDictionary.Keys.ToArray();
			foreach (SlopeInstance slopeInstance in array)
			{
				if (slopeInstance.GridDataPosition.Equals(a) || slopeInstance.Positions.Contains(a))
				{
					Vec3Int vec3Int = a + Vec3Int.down;
					if (!map.BuildingsManagerMain.StabilityBuildingExists(vec3Int, (BaseBuildingInstance x) => x.ConstructionPhase == ConstructionPhase.Finished && x.BuildingType != BuildingType.Floor) && !MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int))
					{
						ForceRemoveSlope(slopeInstance);
						break;
					}
				}
				Vec3Int vec3Int2 = a + Vec3Int.up;
				if ((slopeInstance.GridDataPosition.Equals(vec3Int2) || slopeInstance.Positions.Contains(vec3Int2)) && !map.BuildingsManagerMain.StabilityBuildingExists(vec3Int2, (BaseBuildingInstance x) => x.ConstructionPhase == ConstructionPhase.Finished))
				{
					ForceRemoveSlope(slopeInstance);
				}
			}
		}

		public bool IsSlopeTopAtPosition(Vec3Int pos)
		{
			SlopeInstance slopeAtPosition = GetSlopeAtPosition(pos);
			if (slopeAtPosition == null)
			{
				return false;
			}
			return MapRampLogic.GetSlopeHighestNode(slopeAtPosition).Position == pos;
		}
	}
}
