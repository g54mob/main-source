using System;
using System.Collections.Generic;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.Village.Map
{
	public static class MapNodeUtils
	{
		public static readonly int[] NeighborsHorizontalX = new int[4] { 1, -1, 0, 0 };

		public static readonly int[] NeighborsHorizontalZ = new int[4] { 0, 0, -1, 1 };

		public static readonly int[] NeighborsHorizontalDiagonalX = new int[4] { 1, 1, -1, -1 };

		public static readonly int[] NeighborsHorizontalDiagonalZ = new int[4] { 1, -1, 1, -1 };

		public static readonly Vec3Int[] Neighbors3DNonDiagonal = new Vec3Int[6]
		{
			new Vec3Int(1, 0, 0),
			new Vec3Int(-1, 0, 0),
			new Vec3Int(0, 0, 1),
			new Vec3Int(0, 0, -1),
			new Vec3Int(0, 1, 0),
			new Vec3Int(0, -1, 0)
		};

		public static readonly Vec3Int[] NeighborsXZNonDiagonal = new Vec3Int[4]
		{
			new Vec3Int(1, 0, 0),
			new Vec3Int(-1, 0, 0),
			new Vec3Int(0, 0, 1),
			new Vec3Int(0, 0, -1)
		};

		public static readonly Vec3Int[] NeighborsXZ = new Vec3Int[8]
		{
			new Vec3Int(1, 0, 0),
			new Vec3Int(-1, 0, 0),
			new Vec3Int(0, 0, 1),
			new Vec3Int(0, 0, -1),
			new Vec3Int(1, 0, 1),
			new Vec3Int(1, 0, -1),
			new Vec3Int(-1, 0, 1),
			new Vec3Int(-1, 0, -1)
		};

		public static readonly Vec3Int[] NeighborsXZUpDown = new Vec3Int[10]
		{
			new Vec3Int(1, 0, 0),
			new Vec3Int(-1, 0, 0),
			new Vec3Int(0, 0, 1),
			new Vec3Int(0, 0, -1),
			new Vec3Int(1, 0, 1),
			new Vec3Int(1, 0, -1),
			new Vec3Int(-1, 0, 1),
			new Vec3Int(-1, 0, -1),
			new Vec3Int(0, 1, 0),
			new Vec3Int(0, -1, 0)
		};

		public static readonly Vec3Int[] NeighborsXZUp = new Vec3Int[9]
		{
			new Vec3Int(1, 0, 0),
			new Vec3Int(-1, 0, 0),
			new Vec3Int(0, 0, 1),
			new Vec3Int(0, 0, -1),
			new Vec3Int(1, 0, 1),
			new Vec3Int(1, 0, -1),
			new Vec3Int(-1, 0, 1),
			new Vec3Int(-1, 0, -1),
			new Vec3Int(0, 1, 0)
		};

		public static readonly Vec3Int[] NeighborsXZRadius2 = new Vec3Int[12]
		{
			new Vec3Int(-1, 0, -2),
			new Vec3Int(0, 0, -2),
			new Vec3Int(1, 0, -2),
			new Vec3Int(-1, 0, 2),
			new Vec3Int(0, 0, 2),
			new Vec3Int(1, 0, 2),
			new Vec3Int(-2, 0, -1),
			new Vec3Int(-2, 0, 0),
			new Vec3Int(-2, 0, 1),
			new Vec3Int(2, 0, -1),
			new Vec3Int(2, 0, 0),
			new Vec3Int(2, 0, 1)
		};

		public static MapNode GetClosestNode(this IEnumerable<MapNode> nodes, Vec3Int pos, Func<MapNode, bool> validator = null)
		{
			MapNode result = null;
			float num = float.MaxValue;
			foreach (MapNode node in nodes)
			{
				if (validator == null || validator(node))
				{
					float num2 = Vec3Int.Distance(node.Position, in pos);
					if (num2 < num)
					{
						num = num2;
						result = node;
					}
				}
			}
			return result;
		}

		public static void ForEachNeighbour(MapNode centerNode, Func<MapNode, bool> callback)
		{
			ForEachNeighbour(centerNode.Map, centerNode.Position, callback);
		}

		public static void ForEachNeighbourOnLevel(MapNode centerNode, Func<MapNode, bool> callback)
		{
			if (centerNode == null)
			{
				return;
			}
			VillageMap map = centerNode.Map;
			Vec3Int position = centerNode.Position;
			for (int i = position.x - 1; i <= position.x + 1; i++)
			{
				for (int j = position.z - 1; j <= position.z + 1; j++)
				{
					MapNode node = map.GetNode(i, position.y, j);
					if (node != null && !callback(node))
					{
						return;
					}
				}
			}
		}

		public static IEnumerable<MapNode> IterateEachNeighbourOnLevel(MapNode centerNode)
		{
			if (centerNode == null)
			{
				yield break;
			}
			VillageMap map = centerNode.Map;
			Vec3Int pos = centerNode.Position;
			for (int x = pos.x - 1; x <= pos.x + 1; x++)
			{
				for (int z = pos.z - 1; z <= pos.z + 1; z++)
				{
					if (x != pos.x || z != pos.z)
					{
						MapNode node = map.GetNode(x, pos.y, z);
						if (node != null)
						{
							yield return node;
						}
					}
				}
			}
		}

		public static void ForEachNonDiagonalNeighbourOnLevel(MapNode centerNode, Func<MapNode, bool> callback)
		{
			if (centerNode == null)
			{
				return;
			}
			Vec3Int[] neighborsXZNonDiagonal = NeighborsXZNonDiagonal;
			for (int i = 0; i < neighborsXZNonDiagonal.Length; i++)
			{
				Vec3Int a = neighborsXZNonDiagonal[i];
				Vec3Int vec3Int = a + centerNode.Position;
				MapNode mapNode = centerNode.Map?.GetNode(vec3Int.x, vec3Int.y, vec3Int.z);
				if (mapNode != null && !callback(mapNode))
				{
					break;
				}
			}
		}

		public static void ForEachNeighbour(VillageMap villageMap, Vec3Int position, Func<MapNode, bool> callback)
		{
			Vec3Int vec3Int = position - Vec3Int.one;
			Vec3Int vec3Int2 = position + Vec3Int.one;
			for (int i = vec3Int.y; i <= vec3Int2.y; i++)
			{
				for (int j = vec3Int.x; j <= vec3Int2.x; j++)
				{
					for (int k = vec3Int.z; k <= vec3Int2.z; k++)
					{
						MapNode node = villageMap.GetNode(j, i, k);
						if (node != null && !callback(node))
						{
							return;
						}
					}
				}
			}
		}

		public static IEnumerable<MapNode> IterateEachNeighbor(MapNode node, bool skipSelf = false)
		{
			Vec3Int startPos = node.Position - Vec3Int.one;
			Vec3Int endPos = node.Position + Vec3Int.one;
			VillageMap villageMap = node.Map;
			int selfNodeId = node.Index;
			for (int y = startPos.y; y <= endPos.y; y++)
			{
				for (int x = startPos.x; x <= endPos.x; x++)
				{
					for (int z = startPos.z; z <= endPos.z; z++)
					{
						MapNode node2 = villageMap.GetNode(x, y, z);
						if (node2 != null && (!skipSelf || selfNodeId != node2.Index))
						{
							yield return node2;
						}
					}
				}
			}
		}

		public static IEnumerable<MapNode> IterateNeighboursNonDiagonal(MapNode node)
		{
			VillageMap map = node.Map;
			Vec3Int position = node.Position;
			Vec3Int[] neighbors3DNonDiagonal = Neighbors3DNonDiagonal;
			for (int i = 0; i < neighbors3DNonDiagonal.Length; i++)
			{
				Vec3Int vec3Int = neighbors3DNonDiagonal[i];
				MapNode node2 = map.GetNode(vec3Int.x + position.x, vec3Int.y + position.y, vec3Int.z + position.z);
				if (node2 != null)
				{
					yield return node2;
				}
			}
		}

		public static IEnumerable<MapNode> IterateNeighboursXZ(this MapNode mapNode, bool nonDiagonal = false)
		{
			Vec3Int[] array = (nonDiagonal ? NeighborsXZNonDiagonal : NeighborsXZ);
			Vec3Int[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Vec3Int vec3Int = array2[i];
				MapNode node = mapNode.Map.GetNode(vec3Int.x + mapNode.Position.x, vec3Int.y + mapNode.Position.y, vec3Int.z + mapNode.Position.z);
				if (node != null)
				{
					yield return node;
				}
			}
		}

		public static IEnumerable<MapNode> IterateNeighboursXZAndSelf(this MapNode mapNode)
		{
			yield return mapNode;
			Vec3Int[] neighborsXZ = NeighborsXZ;
			for (int i = 0; i < neighborsXZ.Length; i++)
			{
				Vec3Int vec3Int = neighborsXZ[i];
				MapNode node = mapNode.Map.GetNode(vec3Int.x + mapNode.Position.x, vec3Int.y + mapNode.Position.y, vec3Int.z + mapNode.Position.z);
				if (node != null)
				{
					yield return node;
				}
			}
		}

		public static void ForEachConnectedInRadius(MapNode node, float radiusMin, float radiusMax, Func<MapNode, bool> callback)
		{
			Queue<MapNode> queue = new Queue<MapNode>();
			HashSet<MapNode> hashSet = new HashSet<MapNode> { node };
			Vec3Int a = node.Position;
			foreach (MapNode item in node.ConnectionsSafe)
			{
				queue.Enqueue(item);
			}
			while (queue.Count > 0)
			{
				MapNode mapNode = queue.Dequeue();
				if (!hashSet.Add(mapNode))
				{
					continue;
				}
				float num = Vec3Int.Distance(in a, mapNode.Position);
				if (num <= radiusMax && num >= radiusMin && !callback(mapNode))
				{
					break;
				}
				foreach (MapNode item2 in mapNode.ConnectionsSafe)
				{
					float num2 = Vec3Int.Distance(in a, item2.Position);
					if (!(num2 > radiusMax) && !(num2 < radiusMin) && !hashSet.Contains(item2))
					{
						queue.Enqueue(item2);
					}
				}
			}
		}

		public static IEnumerable<MapNode> IterateConnectedNodes(MapNode node, float radiusMin, float radiusMax, Func<MapNode, bool> shouldContinueIteration)
		{
			using PooledQueue<MapNode> toProcess = QueuePool<MapNode>.GetJanitor();
			using PooledHashSet<MapNode> processed = HashSetPool<MapNode>.GetJanitor();
			processed.Add(node);
			foreach (MapNode item in node.ConnectionsSafe)
			{
				toProcess.Enqueue(item);
			}
			Vec3Int startNodePosition = node.Position;
			while (toProcess.Count > 0)
			{
				MapNode currentNode = toProcess.Dequeue();
				if (!processed.Add(currentNode))
				{
					continue;
				}
				float num = Vec3Int.Distance(in startNodePosition, currentNode.Position);
				if (num <= radiusMax && num >= radiusMin)
				{
					if (shouldContinueIteration != null && !shouldContinueIteration(currentNode))
					{
						break;
					}
					yield return currentNode;
				}
				foreach (MapNode item2 in currentNode.ConnectionsSafe)
				{
					float num2 = Vec3Int.Distance(in startNodePosition, item2.Position);
					if (!(num2 > radiusMax) && !(num2 < radiusMin) && !processed.Contains(item2))
					{
						toProcess.Enqueue(item2);
					}
				}
			}
		}

		public static int GetNodeCountInRadius(MapNode node, float radius, Func<MapNode, bool> condition)
		{
			if (node == null)
			{
				return 0;
			}
			int num = 0;
			Vec3Int position = node.Position;
			int num2 = (int)Math.Ceiling(radius);
			for (int i = position.x - num2; i <= position.x + num2; i++)
			{
				for (int j = position.z - num2; j <= position.z + num2; j++)
				{
					MapNode node2 = node.Map.GetNode(i, position.y, j);
					if (node2 != null && condition(node2))
					{
						num++;
					}
				}
			}
			return num;
		}
	}
}
