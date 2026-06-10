using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StorageUniversal;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.Village.Map.Pathfinding
{
	public static class PathfinderUtil
	{
		public static class LineOfSightFilters
		{
			public static bool IgnoreEndNode(Vector3 end, RaycastHit[] hits, int hitsCount)
			{
				if (hitsCount != 1)
				{
					return false;
				}
				return Vector3.Distance(hits[0].point, end) <= 0.9f;
			}
		}

		public static bool EnableCaching = false;

		private static readonly Dictionary<ulong, Dictionary<PathTraversalProvider, bool>> ReachabilityCache = new Dictionary<ulong, Dictionary<PathTraversalProvider, bool>>();

		private static readonly object ReachabilityCacheLock = new object();

		private static long lastCacheClearTime = 0L;

		private const long CacheClearIntervalTicks = 50000000L;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			EnableCaching = false;
			foreach (Dictionary<PathTraversalProvider, bool> value in ReachabilityCache.Values)
			{
				value.Clear();
			}
			ReachabilityCache.Clear();
			lastCacheClearTime = 0L;
		}

		public static List<WorldObject> FindNearbyObject(IPathfindingAgent agent, Vec3Int startPos, float maxDistance, Func<WorldObject, int> condition)
		{
			List<WorldObject> result = ListPool<WorldObject>.Get();
			FloodFillUtil.FloodFillConnections(agent.Map, startPos, maxDistance, delegate(MapNode node)
			{
				if (!IsPathPossible(agent, startPos, node.Position))
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				if (!node.HasWorldObjects())
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				foreach (WorldObject worldObject in node.WorldObjects)
				{
					if (!worldObject.HasDisposed)
					{
						switch (condition(worldObject))
						{
						case -1:
							return FloodFillUtil.ScanStatus.Abort;
						case 1:
							result.Add(worldObject);
							break;
						case 2:
							result.Add(worldObject);
							return FloodFillUtil.ScanStatus.Abort;
						}
					}
				}
				return FloodFillUtil.ScanStatus.Continue;
			});
			return result;
		}

		public static IGoapTargetable GetClosestReachable(IPathfindingAgent agent, IEnumerable<IGoapTargetable> searchSet, Func<IGoapTargetable, bool> condition = null, Func<IGoapTargetable, float> getPriority = null, float distanceLimit = 99999f)
		{
			return GetClosestReachable(agent, agent.GetGridPosition(), searchSet, condition, getPriority, distanceLimit);
		}

		public static IGoapTargetable GetClosestReachable(IPathfindingAgent agent, Vec3Int checkPos, IEnumerable<IGoapTargetable> searchSet, Func<IGoapTargetable, bool> condition = null, Func<IGoapTargetable, float> getPriority = null, float distanceLimit = 99999f)
		{
			if (searchSet == null)
			{
				return null;
			}
			distanceLimit *= distanceLimit;
			IGoapTargetable result = null;
			int num = int.MaxValue;
			float num2 = float.MinValue;
			foreach (IGoapTargetable item in searchSet)
			{
				if (item.HasDisposed)
				{
					continue;
				}
				int num3 = Vec3Int.DistanceSquared(item.GetGridPosition(), in checkPos);
				if ((float)num3 > distanceLimit)
				{
					continue;
				}
				float num4 = 0f;
				if (getPriority != null)
				{
					num4 = getPriority(item);
					if (num4 < num2 || (Math.Abs(num2 - num4) < 0.0001f && num < num3))
					{
						continue;
					}
				}
				else if (num3 > num)
				{
					continue;
				}
				if (IsPathPossible(agent, item) && (condition == null || condition(item)))
				{
					num = num3;
					result = item;
					num2 = num4;
				}
			}
			return result;
		}

		public static IGoapTargetable GetClosestReachable(IPathfindingAgent agent, Vec3Int checkPos, PooledDictionary<IGoapTargetable, Vec3Int> searchSet, Func<IGoapTargetable, bool> condition = null, Func<IGoapTargetable, float> getPriority = null, float distanceLimit = 99999f)
		{
			distanceLimit *= distanceLimit;
			IGoapTargetable result = null;
			int num = int.MaxValue;
			float num2 = float.MinValue;
			foreach (KeyValuePair<IGoapTargetable, Vec3Int> item in searchSet)
			{
				IGoapTargetable key = item.Key;
				Vec3Int a = item.Value;
				if (key.HasDisposed)
				{
					continue;
				}
				int num3 = Vec3Int.DistanceSquared(in a, in checkPos);
				if ((float)num3 > distanceLimit)
				{
					continue;
				}
				float num4 = 0f;
				if (getPriority != null)
				{
					num4 = getPriority(key);
					if (num4 < num2 || (Math.Abs(num2 - num4) < 0.0001f && num < num3))
					{
						continue;
					}
				}
				else if (num3 > num)
				{
					continue;
				}
				if (IsPathPossible(agent, a) && (condition == null || condition(key)))
				{
					num = num3;
					result = key;
					num2 = num4;
				}
			}
			return result;
		}

		public static bool IsPathPossible(IPathfindingAgent agent, IGoapTargetable target, WalkableModel walkableModelOverride = null)
		{
			if (CombatUtils.IsNullOrDisposed(agent, target))
			{
				return false;
			}
			if (!(target is WorldObject worldObject))
			{
				return IsPathPossible(agent, target.GetGridPosition(), walkableModelOverride);
			}
			Vec3Int reachedPosition;
			if (worldObject.ReachablePositions == null || worldObject.ReachablePositions.Count < 1)
			{
				return CheckNoReachablePositionsPathPossible(agent, out reachedPosition, worldObject, worldObject.Positions, walkableModelOverride);
			}
			foreach (Vec3Int reachablePosition in worldObject.ReachablePositions)
			{
				if (IsPathPossible(agent, reachablePosition, walkableModelOverride))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsPathPossible(IPathfindingAgent agent, IGoapTargetable target, bool preferEmptyNodes, in WorldDirection avoidReachableDirections, out Vec3Int reachedPosition, bool preferSameYLevel = false)
		{
			if (CombatUtils.IsNullOrDisposed(agent, target))
			{
				reachedPosition = default(Vec3Int);
				return false;
			}
			reachedPosition = Vec3Int.zero;
			if (!(target is WorldObject worldObject))
			{
				if (target is IDoorOrGate doorOrGate)
				{
					reachedPosition = doorOrGate.GetUsePosition(agent);
					return IsPathPossible(agent, reachedPosition);
				}
				if (target is BaseComponentInstance obj)
				{
					return IsPathPossible(agent, obj, out reachedPosition);
				}
				reachedPosition = target.GetGridPosition();
				return IsPathPossible(agent, reachedPosition);
			}
			if (worldObject.ReachablePositions == null || worldObject.ReachablePositions.Count < 1)
			{
				return CheckNoReachablePositionsPathPossible(agent, out reachedPosition, worldObject, worldObject.Positions);
			}
			if (preferEmptyNodes)
			{
				float num = float.MaxValue;
				reachedPosition = new Vec3Int(int.MaxValue, int.MaxValue, int.MaxValue);
				Vec3Int rhs = agent.GetGridPosition();
				float num2 = (preferSameYLevel ? 1000f : 1f);
				foreach (Vec3Int reachablePosition in worldObject.ReachablePositions)
				{
					Vec3Int lhs = reachablePosition;
					if (lhs == rhs && avoidReachableDirections == WorldDirection.None && lhs != worldObject.GridDataPosition)
					{
						reachedPosition = lhs;
						return true;
					}
					if (IsPathPossible(agent, lhs))
					{
						MapNode node = agent.Map.GetNode(lhs);
						float num3 = (int)node.CreaturesCount;
						if (lhs == worldObject.GridDataPosition)
						{
							num3 += 30000f;
						}
						if ((avoidReachableDirections & ReachabilityUtil.GetNeighbourDirection(worldObject.GridDataPosition, lhs)) != WorldDirection.None)
						{
							num3 += 20000f;
						}
						if (node.IsWater)
						{
							num3 += 10000f;
						}
						num3 += lhs.ToVector3World().Distance(agent.GetPosition());
						num3 += num2 * (float)Mathf.Abs(lhs.y - rhs.y);
						if (num3 < num)
						{
							num = num3;
							reachedPosition = lhs;
						}
					}
				}
				return reachedPosition.x != int.MaxValue;
			}
			foreach (Vec3Int reachablePosition2 in worldObject.ReachablePositions)
			{
				if (IsPathPossible(agent, reachablePosition2))
				{
					reachedPosition = reachablePosition2;
					return true;
				}
			}
			return false;
		}

		private static bool CheckNoReachablePositionsPathPossible(IPathfindingAgent agent, out Vec3Int reachedPosition, WorldObject obj, List<Vec3Int> objPositions, WalkableModel walkableModelOverride = null)
		{
			reachedPosition = default(Vec3Int);
			if (obj.GridDataType == GridDataType.DigMarkerResourceToMine)
			{
				return false;
			}
			MapNode node = obj.GetNode();
			if (!node.IsWalkable && objPositions != null && objPositions.Count > 0)
			{
				foreach (Vec3Int objPosition in objPositions)
				{
					node = obj.Map.GetNode(objPosition);
					if (node == null || node.IsWalkable)
					{
						break;
					}
				}
			}
			if (node == null || !node.IsWalkable)
			{
				return false;
			}
			reachedPosition = node.Position;
			return IsPathPossible(agent, node, walkableModelOverride);
		}

		public static bool IsPathPossible(IPathfindingAgent agent, BaseComponentInstance obj, out Vec3Int reachedPosition)
		{
			reachedPosition = Vec3Int.zero;
			Vec3Int reachedPosition2;
			if (obj.ReachablePositions == null || obj.ReachablePositions.Count < 1)
			{
				return CheckNoReachablePositionsPathPossible(agent, out reachedPosition2, obj.OwnerBuilding, obj.Positions);
			}
			foreach (Vec3Int reachablePosition in obj.ReachablePositions)
			{
				if (IsPathPossible(agent, reachablePosition))
				{
					reachedPosition = reachablePosition;
					return true;
				}
			}
			return false;
		}

		public static bool IsPathPossible(WalkableModel walkableModel, Vec3Int startPosition, WorldObject obj)
		{
			if (walkableModel == null || obj == null || obj.HasDisposed)
			{
				return false;
			}
			if (obj.ReachablePositions == null || obj.ReachablePositions.Count < 1)
			{
				MapNode node = obj.GetNode();
				if (obj.GridDataType == GridDataType.DigMarkerResourceToMine)
				{
					return false;
				}
				if (!node.IsWalkable)
				{
					List<Vec3Int> positions = obj.Positions;
					if (positions != null && positions.Count > 0)
					{
						foreach (Vec3Int position in obj.Positions)
						{
							node = obj.Map.GetNode(position);
							if (node == null || node.IsWalkable)
							{
								break;
							}
						}
					}
				}
				if (node == null || !node.IsWalkable)
				{
					return false;
				}
				return IsPathPossible(walkableModel, obj.Map.GetNode(startPosition), obj.Map.GetNode(obj.GridDataPosition));
			}
			foreach (Vec3Int reachablePosition in obj.ReachablePositions)
			{
				if (IsPathPossible(walkableModel, obj.Map.GetNode(startPosition), obj.Map.GetNode(reachablePosition)))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsPathPossibleProduction(IPathfindingAgent agent, ProductionInstance production)
		{
			ProductionComponentInstance ownerProductionComponentInstance = production.OwnerProductionComponentInstance;
			if (ownerProductionComponentInstance == null)
			{
				return false;
			}
			foreach (Vec3Int workplacePosition in ownerProductionComponentInstance.WorkplacePositions)
			{
				if (IsPathPossible(agent, workplacePosition))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsPathPossible(WalkableModel walkableModel, uint areaId, WorldObject obj)
		{
			if (walkableModel == null || obj == null || obj.HasDisposed)
			{
				return false;
			}
			VillageMap map = obj.Map;
			PathTraversalProvider traversalProvider = walkableModel?.StaticTraversalProvider;
			if (obj.ReachablePositions == null || obj.ReachablePositions.Count < 1)
			{
				MapNode node = obj.GetNode();
				if (obj.GridDataType == GridDataType.DigMarkerResourceToMine)
				{
					return false;
				}
				if (!node.IsWalkable)
				{
					List<Vec3Int> positions = obj.Positions;
					if (positions != null && positions.Count > 0)
					{
						foreach (Vec3Int position in obj.Positions)
						{
							node = map.GetNode(position);
							if (node == null || node.IsWalkable)
							{
								break;
							}
						}
					}
				}
				if (node == null || !node.IsWalkable)
				{
					return false;
				}
				return IsAreaReachable(traversalProvider, map, areaId, node.Area);
			}
			foreach (Vec3Int reachablePosition in obj.ReachablePositions)
			{
				if (IsAreaReachable(traversalProvider, map, areaId, map.GetNode(reachablePosition).Area))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsPathPossible(WalkableModel walkableModel, uint startAreaId, uint endAreaId, VillageMap villageMap)
		{
			return IsAreaReachable(walkableModel?.StaticTraversalProvider, villageMap, startAreaId, endAreaId);
		}

		public static bool IsPathPossible(IPathfindingAgent agent, MapNode node, WalkableModel walkableModelOverride = null)
		{
			return IsPathPossible((walkableModelOverride != null) ? walkableModelOverride : agent?.WalkableModel, agent?.GetNode(), node);
		}

		public static bool IsPathPossible(IPathfindingAgent agent, Vec3Int pos, WalkableModel walkableModelOverride = null)
		{
			return IsPathPossible((walkableModelOverride != null) ? walkableModelOverride : agent?.WalkableModel, agent?.GetNode(), agent?.Map?.GetNode(pos));
		}

		public static bool IsPathPossible(IPathfindingAgent agent, IEnumerable<Vec3Int> pos)
		{
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return false;
			}
			foreach (Vec3Int po in pos)
			{
				if (IsPathPossible(agent.WalkableModel, agent.GetNode(), agent.Map.GetNode(po)))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsPathPossible(IPathfindingAgent agent, Vec3Int pos1, Vec3Int pos2)
		{
			return IsPathPossible(agent.WalkableModel, agent.Map.GetNode(pos1), agent.Map.GetNode(pos2));
		}

		public static bool IsPathPossible(WalkableModel model, VillageMap map, Vec3Int pos1, Vec3Int pos2)
		{
			return IsPathPossible(model, map.GetNode(pos1), map.GetNode(pos2));
		}

		public static bool IsPathPossible(WalkableModel walkableModel, MapNode node, Vec3Int pos)
		{
			return IsPathPossible(walkableModel, node, node.Map.GetNode(pos));
		}

		public static bool IsPathPossible(WalkableModel walkableModel, MapNode node1, MapNode node2)
		{
			if (walkableModel == null || node1 == null || node2 == null || node1.Map != node2.Map)
			{
				return false;
			}
			return IsRegionReachable(walkableModel, node1.Region, node2.Region);
		}

		public static bool IsRegionReachable(WalkableModel walkableModel, Region startRegion, Region endRegion)
		{
			return IsRegionReachable(walkableModel?.StaticTraversalProvider, startRegion, endRegion);
		}

		public static bool IsRegionReachable(PathTraversalProvider provider, Region startRegion, Region endRegion)
		{
			if (startRegion == null || endRegion == null || startRegion.HasDisposed || endRegion.HasDisposed)
			{
				return false;
			}
			if (provider == null)
			{
				Log.Warning("WARNING: Is region reachable called without walkable model! Using default provider. ", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\PathfinderUtil.cs");
				provider = PathTraversalProvider.DefaultProvider;
			}
			uint area = startRegion.Area;
			uint area2 = endRegion.Area;
			return IsAreaReachable(provider, startRegion.Map, area, area2);
		}

		public static bool IsAreaReachable(PathTraversalProvider traversalProvider, VillageMap map, uint startArea, uint endArea)
		{
			if (startArea == endArea)
			{
				return true;
			}
			if (startArea == 0 || endArea == 0 || traversalProvider == null)
			{
				return false;
			}
			ulong key = 0uL;
			if (EnableCaching)
			{
				key = ((startArea >= endArea) ? (((ulong)startArea << 32) | endArea) : (((ulong)endArea << 32) | startArea));
				lock (ReachabilityCacheLock)
				{
					Dictionary<PathTraversalProvider, bool> value;
					bool value2;
					if (DateTime.UtcNow.Ticks - lastCacheClearTime > 50000000)
					{
						ClearIsPathPossibleCache();
					}
					else if (ReachabilityCache.TryGetValue(key, out value) && value.TryGetValue(traversalProvider, out value2))
					{
						return value2;
					}
				}
			}
			bool flag = AreaFloodFill.IsPathPossible(traversalProvider, map, startArea, endArea);
			if (EnableCaching)
			{
				lock (ReachabilityCacheLock)
				{
					if (ReachabilityCache.TryGetValue(key, out var value3))
					{
						if (!value3.ContainsKey(traversalProvider))
						{
							value3.Add(traversalProvider, flag);
						}
					}
					else
					{
						Dictionary<PathTraversalProvider, bool> dictionary = DictionaryPool<PathTraversalProvider, bool>.Get();
						dictionary.Add(traversalProvider, flag);
						ReachabilityCache.Add(key, dictionary);
					}
				}
			}
			return flag;
		}

		public static void ClearIsPathPossibleCache()
		{
			lastCacheClearTime = DateTime.UtcNow.Ticks;
			lock (ReachabilityCacheLock)
			{
				if (ReachabilityCache.Count == 0)
				{
					return;
				}
				foreach (KeyValuePair<ulong, Dictionary<PathTraversalProvider, bool>> item in ReachabilityCache)
				{
					DictionaryPool<PathTraversalProvider, bool>.Return(item.Value);
				}
				ReachabilityCache.Clear();
			}
		}

		public static IStorage FindNearestStorage(IPathfindingAgent agent, ResourceInstance toStore, ZonePriority minimumPriority = ZonePriority.None, bool enablePriorityFallback = false)
		{
			if (toStore == null)
			{
				return null;
			}
			IStorage storage = (IStorage)GetClosestReachable(agent, MonoSingleton<StorageCommonManager>.Instance.AllStorages, (IGoapTargetable o) => ((IStorage)o).CanStore(toStore, (CreatureBase)agent) && ((IStorage)o).Priority > minimumPriority, (IGoapTargetable o) => (float)((IStorage)o).Priority);
			if (enablePriorityFallback && storage == null && minimumPriority != ZonePriority.None)
			{
				storage = (IStorage)GetClosestReachable(agent, MonoSingleton<StorageCommonManager>.Instance.AllStorages, (IGoapTargetable o) => ((IStorage)o).CanStore(toStore, (CreatureBase)agent), (IGoapTargetable o) => (float)((IStorage)o).Priority);
			}
			return storage;
		}

		public static List<TargetObject> FindClosestWaterSource(ResourcePileInstance pile, WellComponentInstance well, TempPathfindingPointInstance point, IPathfindingAgent agent)
		{
			List<WorldObject> list = ListPool<WorldObject>.Get();
			if (pile != null)
			{
				list.Add(pile);
			}
			if (well?.OwnerBuilding != null)
			{
				list.Add(well.OwnerBuilding);
			}
			if (point != null)
			{
				list.Add(point);
			}
			if (list.Count == 0)
			{
				return null;
			}
			return PathfinderMedieval.FindMedievalObjects(agent, list, (WorldObject x) => x != null && !x.HasDisposed, list.Count, shouldSort: true);
		}
	}
}
