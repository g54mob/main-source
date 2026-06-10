using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Map;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Manager
{
	public static class FloodFillUtil
	{
		public enum ScanStatus
		{
			None = 0,
			InvalidNode = 1,
			Abort = 2,
			Continue = 3
		}

		public static void FloodFillConnections(MapNode start, float rangeLimit, Func<MapNode, ScanStatus> scanNode)
		{
			FloodFillConnections(start.Map, start.Position, start.Position, rangeLimit, scanNode);
		}

		public static void FloodFillConnections(VillageMap map, Vec3Int pos, float rangeLimit, Func<MapNode, ScanStatus> scanNode)
		{
			FloodFillConnections(map, pos, pos, rangeLimit, scanNode);
		}

		public static IEnumerable<MapNode> IterateFloodFill3D(VillageMap map, Vec3Int fillStartGridSpace, float rangeLimit, bool onlyWalkable = true, bool roundedCylinder = false)
		{
			using PooledQueue<MapNode> queue = QueuePool<MapNode>.GetJanitor();
			using PooledHashSet<MapNode> duplicates = HashSetPool<MapNode>.GetJanitor();
			MapNode startNode = map.GetNode(fillStartGridSpace);
			queue.Enqueue(startNode);
			while (queue.Count > 0)
			{
				MapNode node = queue.Dequeue();
				if (!duplicates.Add(node))
				{
					continue;
				}
				if (rangeLimit > 0f)
				{
					if (node.Position.y - fillStartGridSpace.y > 0)
					{
						if (startNode.WorldPosition.DistanceXZ(node.WorldPosition) > rangeLimit)
						{
							continue;
						}
					}
					else if (Vector3.Distance(startNode.WorldPosition, node.WorldPosition) > rangeLimit)
					{
						continue;
					}
				}
				if (onlyWalkable && !node.IsVoxelAir() && !node.IsWalkable)
				{
					continue;
				}
				if (node.IsWalkable)
				{
					yield return node;
				}
				if (node == null || node.Neighbours == null)
				{
					continue;
				}
				foreach (MapNode neighbour in node.Neighbours)
				{
					if (neighbour != null && !duplicates.Contains(neighbour) && (!onlyWalkable || neighbour.IsVoxelAir() || neighbour.IsWalkable))
					{
						queue.Enqueue(neighbour);
					}
				}
			}
		}

		public static IEnumerable<MapNode> IterateFloodFillConnections(VillageMap map, Vec3Int fillStartGridSpace, Vec3Int rangeCheckPoint, float rangeLimit)
		{
			using PooledQueue<MapNode> queue = QueuePool<MapNode>.GetJanitor();
			using PooledHashSet<MapNode> duplicates = HashSetPool<MapNode>.GetJanitor();
			MapNode node = map.GetNode(fillStartGridSpace);
			queue.Enqueue(node);
			float rangeLimitSquared = rangeLimit * rangeLimit;
			while (queue.Count > 0)
			{
				MapNode node2 = queue.Dequeue();
				if (!duplicates.Add(node2) || (rangeLimit > 0f && (float)Vec3Int.DistanceSquared(in rangeCheckPoint, node2.Position) > rangeLimitSquared))
				{
					continue;
				}
				yield return node2;
				foreach (MapNode item in node2.ConnectionsSafe)
				{
					if (item != null && !duplicates.Contains(item))
					{
						queue.Enqueue(item);
					}
				}
			}
		}

		public static IEnumerable<MapNode> IterateFloodFillConnections(MapNode startNode, float rangeLimit, Predicate<MapNode> spreadStopFilter = null, bool preferNonWater = false, Func<MapNode, MapNode, bool> canSpread = null)
		{
			using PooledHashSet<MapNode> duplicates = HashSetPool<MapNode>.GetJanitor();
			using PooledQueue<MapNode> primaryQueue = QueuePool<MapNode>.GetJanitor();
			using PooledQueue<MapNode> secondaryQueue = QueuePool<MapNode>.GetJanitor();
			using PooledQueue<MapNode> deferredYieldQueue = QueuePool<MapNode>.GetJanitor();
			primaryQueue.Enqueue(startNode);
			MapNode node;
			while (primaryQueue.TryDequeue(out node) || secondaryQueue.TryDequeue(out node))
			{
				if (!duplicates.Add(node) || (rangeLimit > 0f && Vec3Int.Distance(startNode.Position, node.Position) > rangeLimit))
				{
					continue;
				}
				if (preferNonWater && node.IsWater)
				{
					deferredYieldQueue.Enqueue(node);
				}
				else
				{
					yield return node;
				}
				if (spreadStopFilter != null && spreadStopFilter(node))
				{
					continue;
				}
				foreach (MapNode item in node.ConnectionsRaw)
				{
					if (item != null && !duplicates.Contains(item) && (canSpread == null || canSpread(node, item)))
					{
						if (preferNonWater && item.IsWater)
						{
							secondaryQueue.Enqueue(item);
						}
						else
						{
							primaryQueue.Enqueue(item);
						}
					}
				}
				node = null;
			}
			MapNode obj;
			while (deferredYieldQueue.TryDequeue(out obj))
			{
				yield return obj;
			}
		}

		[MustDisposeResource]
		public static PooledList<MapNode> ScoreWalkable(IPathfindingAgent agent, MapNode startNode, float rangeLimit, int maxNodes, Func<MapNode, float> scorer, bool debugDraw = false, bool preferNonWater = false, Predicate<MapNode> spreadStopFilter = null, Predicate<MapNode> earlyOut = null, Predicate<MapNode> filter = null)
		{
			PooledList<MapNode> janitor = ListPool<MapNode>.GetJanitor();
			foreach (MapNode item in IterateFloodFillConnections(startNode, rangeLimit, spreadStopFilter, preferNonWater))
			{
				if (item.IsWalkable && PathfinderUtil.IsPathPossible(agent, item) && (filter == null || filter(item)))
				{
					if (earlyOut != null && earlyOut(item))
					{
						janitor.Clear();
						janitor.Add(item);
						return janitor;
					}
					janitor.Add(item);
					if (janitor.Count >= maxNodes)
					{
						break;
					}
				}
			}
			janitor.Sort(delegate(MapNode node1, MapNode node2)
			{
				float value = scorer(node1);
				return scorer(node2).CompareTo(value);
			});
			return janitor;
		}

		public static void FloodFillConnections(VillageMap map, Vec3Int fillStartGridSpace, Vec3Int rangeCheckPoint, float rangeLimit, Func<MapNode, ScanStatus> scanNode)
		{
			HashSet<MapNode> hashSet = HashSetPool<MapNode>.Get();
			Queue<MapNode> queue = QueuePool<MapNode>.Get();
			MapNode node = map.GetNode(fillStartGridSpace);
			queue.Enqueue(node);
			float num = rangeLimit * rangeLimit;
			while (queue.Count > 0)
			{
				MapNode mapNode = queue.Dequeue();
				if (mapNode == null || !hashSet.Add(mapNode) || (rangeLimit > 0f && (float)Vec3Int.DistanceSquared(in rangeCheckPoint, mapNode.Position) > num))
				{
					continue;
				}
				switch (scanNode(mapNode))
				{
				default:
					foreach (MapNode item in mapNode.ConnectionsSafe)
					{
						if (item != null && !hashSet.Contains(item))
						{
							queue.Enqueue(item);
						}
					}
					continue;
				case ScanStatus.InvalidNode:
					continue;
				case ScanStatus.Abort:
					break;
				}
				break;
			}
			HashSetPool<MapNode>.Return(hashSet);
			QueuePool<MapNode>.Return(queue);
		}

		[MustDisposeResource]
		public static PooledList<MapNode> GenerateGridSurfaceNodes(VillageMap map, int gridCellSize)
		{
			PooledList<MapNode> janitor = ListPool<MapNode>.GetJanitor();
			for (int i = 0; i < MonoSingleton<World>.Instance.SizeX; i += gridCellSize)
			{
				for (int j = 0; j < MonoSingleton<World>.Instance.SizeZ; j += gridCellSize)
				{
					for (int num = MonoSingleton<World>.Instance.SizeY; num > 0; num--)
					{
						MapNode node = map.GetNode(new Vec3Int(i, num, j));
						if (node != null && node.IsWalkable)
						{
							janitor.Add(node);
							break;
						}
					}
				}
			}
			return janitor;
		}
	}
}
