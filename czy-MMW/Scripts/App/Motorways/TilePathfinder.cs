using System.Collections.Generic;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways
{
	public class TilePathfinder
	{
		private class PathNode
		{
			public Vector2Int position;

			public int cost;

			public int totalCost;

			public PathNode previousNode;
		}

		private const int MaximumIterations = 300;

		private const int DiagonalCost = 99;

		private const int StraightCost = 70;

		private readonly List<PathNode> _pathfindNodePool = new List<PathNode>(100);

		private const int NodesToAllocate = 100;

		private int _usedNodeCount;

		private readonly List<PathNode> _openList = new List<PathNode>();

		private readonly Dictionary<Vector2Int, PathNode> _openListIndex = new Dictionary<Vector2Int, PathNode>();

		private readonly Dictionary<Vector2Int, PathNode> _closedListIndex = new Dictionary<Vector2Int, PathNode>();

		private readonly List<Vector2Int> _path = new List<Vector2Int>();

		private int _iterationCount;

		public TilePathfinder()
		{
			for (int i = 0; i < 100; i++)
			{
				_pathfindNodePool.Add(new PathNode());
			}
		}

		public IEnumerable<Vector2Int> GetPathBetweenPoints(Vector2Int start, Vector2Int end, ISimulation simulation, City city, ICollection<Vector2Int> blockedPositions = null)
		{
			_openList.Clear();
			_openListIndex.Clear();
			_closedListIndex.Clear();
			_usedNodeCount = 0;
			_iterationCount = 0;
			PathNode pathNode = CreateNode(start, 0, CalculateMetroDistanceBetweenTiles(start, end), null);
			TilemapModel model = simulation.GetModel<TilemapModel>();
			while (pathNode.position != end && _iterationCount < 300)
			{
				_iterationCount++;
				Vector2Int[] directionToTileAdjacencyOffset = TileUtilities.DirectionToTileAdjacencyOffset;
				for (int i = 0; i < directionToTileAdjacencyOffset.Length; i++)
				{
					Vector2Int vector2Int = directionToTileAdjacencyOffset[i];
					Vector2Int vector2Int2 = pathNode.position + vector2Int;
					if (!city.Definition.TileIsBuildable(vector2Int2) || (blockedPositions != null && blockedPositions.Contains(vector2Int2)))
					{
						continue;
					}
					if (vector2Int2 != end)
					{
						Tile tile = model.GetTile(vector2Int2);
						if (tile != null && !tile.CanDrawRoadsOn())
						{
							continue;
						}
					}
					int estimatedRemainingCost = CalculateMetroDistanceBetweenTiles(vector2Int2, end);
					int num = ((vector2Int.x == 0 || vector2Int.y == 0) ? 70 : 99);
					PathNode pathNode2 = CreateNode(vector2Int2, pathNode.cost + num, estimatedRemainingCost, pathNode);
					bool flag = false;
					PathNode value2;
					if (_openListIndex.TryGetValue(vector2Int2, out var value))
					{
						if (pathNode2.totalCost >= value.totalCost)
						{
							continue;
						}
						_openListIndex.Remove(vector2Int2);
						flag = true;
					}
					else if (_closedListIndex.TryGetValue(vector2Int2, out value2))
					{
						if (pathNode2.totalCost >= value2.totalCost)
						{
							continue;
						}
						_closedListIndex.Remove(vector2Int2);
					}
					int j;
					for (j = 0; j < _openList.Count && _openList[j].totalCost <= pathNode2.totalCost; j++)
					{
					}
					if (flag)
					{
						for (int k = j; k < _openList.Count; k++)
						{
							if (_openList[k].position == vector2Int2)
							{
								_openList.RemoveAt(k);
								break;
							}
						}
					}
					_openList.Insert(j, pathNode2);
					_openListIndex.Add(pathNode2.position, pathNode2);
				}
				_closedListIndex.Add(pathNode.position, pathNode);
				if (_openList.Count <= 0)
				{
					break;
				}
				pathNode = _openList[0];
				_openList.RemoveAt(0);
				_openListIndex.Remove(pathNode.position);
			}
			if (pathNode.position != end)
			{
				return null;
			}
			_path.Clear();
			while (pathNode != null)
			{
				_path.Add(pathNode.position);
				pathNode = pathNode.previousNode;
			}
			_path.Reverse();
			return _path;
		}

		private PathNode CreateNode(Vector2Int position, int cost, int estimatedRemainingCost, PathNode previousNode)
		{
			if (_usedNodeCount >= _pathfindNodePool.Count)
			{
				for (int i = 0; i < 20; i++)
				{
					_pathfindNodePool.Add(new PathNode());
				}
			}
			PathNode pathNode = _pathfindNodePool[_usedNodeCount];
			pathNode.position = position;
			pathNode.cost = cost;
			pathNode.totalCost = cost + estimatedRemainingCost;
			pathNode.previousNode = previousNode;
			_usedNodeCount++;
			return pathNode;
		}

		private static int CalculateMetroDistanceBetweenTiles(Vector2Int startPosition, Vector2Int endPosition)
		{
			int a = Mathf.Abs(startPosition.x - endPosition.x);
			int b = Mathf.Abs(startPosition.y - endPosition.y);
			int num = Mathf.Max(a, b);
			int num2 = Mathf.Min(a, b);
			return num2 * 99 + (num - num2) * 70;
		}
	}
}
