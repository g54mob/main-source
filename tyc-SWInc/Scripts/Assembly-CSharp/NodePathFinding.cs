using System;
using System.Collections.Generic;
using UnityEngine;

public static class NodePathFinding<T>
{
	private static HashSet<PathNode<T>> openList = new HashSet<PathNode<T>>();

	private static HashSet<PathNode<T>> closedList = new HashSet<PathNode<T>>();

	private static Dictionary<PathNode<T>, PathNode<T>> cameFrom = new Dictionary<PathNode<T>, PathNode<T>>();

	private static Dictionary<PathNode<T>, float> cost = new Dictionary<PathNode<T>, float>();

	private static SortedLinkedList<float, PathNode<T>> ecost = new SortedLinkedList<float, PathNode<T>>(Comparer<float>.Default);

	private static ObjectPool<List<T>> _pathPool = new ObjectPool<List<T>>(() => new List<T>(), delegate(List<T> x)
	{
		x.Clear();
	});

	private static ObjectPool<List<PathNode<T>>> _pathNodePool = new ObjectPool<List<PathNode<T>>>(() => new List<PathNode<T>>(), delegate(List<PathNode<T>> x)
	{
		x.Clear();
	});

	public static void Claim(List<T> l)
	{
		_pathPool.Claim(l);
	}

	public static void Release(List<T> l)
	{
		_pathPool.Release(l);
	}

	public static void Release(List<PathNode<T>> l)
	{
		_pathNodePool.Release(l);
	}

	public static List<T> FindPath(PathNode<T> start, PathNode<T> end, Func<T, T, float> Distance, Func<T, T, float> Heuristic, Func<object, bool> filter, Func<PathNode<T>, bool> earlyStop = null)
	{
		openList.Clear();
		closedList.Clear();
		cameFrom.Clear();
		cost.Clear();
		ecost.Clear();
		openList.Add(start);
		cost[start] = 0f;
		ecost.Add(Heuristic(start.Point, end.Point), start);
		bool flag = earlyStop != null;
		while (openList.Count > 0)
		{
			PathNode<T> pathNode = ecost.Pop();
			if (pathNode == end || (flag && earlyStop(pathNode)))
			{
				List<T> result = _pathPool.Get();
				ReconstructPath(pathNode, result);
				return result;
			}
			openList.Remove(pathNode);
			closedList.Add(pathNode);
			List<PathNode<T>> connections = pathNode.GetConnections();
			for (int i = 0; i < connections.Count; i++)
			{
				PathNode<T> pathNode2 = connections[i];
				if ((!pathNode2.NullWeight || pathNode2 == end) && !closedList.Contains(pathNode2) && filter(pathNode2.Tag))
				{
					float num = cost[pathNode] + Distance(pathNode.Point, pathNode2.Point) * pathNode2.Weight;
					if (!openList.Contains(pathNode2) || num < cost[pathNode2])
					{
						cameFrom[pathNode2] = pathNode;
						cost[pathNode2] = num;
						ecost.Add(cost[pathNode2] + Heuristic(pathNode2.Point, end.Point) * pathNode2.Weight, pathNode2);
						openList.Add(pathNode2);
					}
				}
			}
		}
		return null;
	}

	public static List<PathNode<T>> FindPathNodes(PathNode<T> start, PathNode<T> end, Func<T, T, float> Distance, Func<T, T, float> Heuristic, Func<object, bool> filter, Func<PathNode<T>, float> weight = null, Func<PathNode<T>, bool> earlyStop = null)
	{
		openList.Clear();
		closedList.Clear();
		cameFrom.Clear();
		cost.Clear();
		ecost.Clear();
		openList.Add(start);
		cost[start] = 0f;
		ecost.Add(Heuristic(start.Point, end.Point), start);
		bool flag = end.AllowCaching();
		bool flag2 = earlyStop != null;
		bool flag3 = weight != null;
		while (openList.Count > 0)
		{
			PathNode<T> pathNode = ecost.Pop();
			if (flag && pathNode.AllowCaching() && pathNode.HasCachedPath(end as PathNode<Vector3>))
			{
				List<PathNode<T>> list = _pathNodePool.Get();
				ReconstructPathNodes(pathNode, list);
				if (list.Count > 0)
				{
					list.RemoveAt(list.Count - 1);
				}
				if (pathNode.FindCachedPath(end as PathNode<Vector3>, list as List<PathNode<Vector3>>))
				{
					return list;
				}
				Release(list);
			}
			if (pathNode == end || (flag2 && earlyStop(pathNode)))
			{
				List<PathNode<T>> result = _pathNodePool.Get();
				ReconstructPathNodes(pathNode, result);
				return result;
			}
			openList.Remove(pathNode);
			closedList.Add(pathNode);
			List<PathNode<T>> connections = pathNode.GetConnections();
			for (int i = 0; i < connections.Count; i++)
			{
				PathNode<T> pathNode2 = connections[i];
				if ((!pathNode2.NullWeight || pathNode2 == end) && !closedList.Contains(pathNode2) && filter(pathNode2.Tag))
				{
					float num = cost[pathNode] + Distance(pathNode.Point, pathNode2.Point) * (flag3 ? weight(pathNode2) : pathNode2.Weight);
					if (!openList.Contains(pathNode2) || num < cost[pathNode2])
					{
						cameFrom[pathNode2] = pathNode;
						cost[pathNode2] = num;
						ecost.Add(cost[pathNode2] + Heuristic(pathNode2.Point, end.Point) * (flag3 ? weight(pathNode2) : pathNode2.Weight), pathNode2);
						openList.Add(pathNode2);
					}
				}
			}
		}
		return null;
	}

	public static List<T> FindPath(PathNode<T> start, PathNode<T> end, Func<T, T, T, float> Distance, Func<T, T, T, float> Heuristic, Func<object, bool> filter)
	{
		openList.Clear();
		closedList.Clear();
		cameFrom.Clear();
		cost.Clear();
		ecost.Clear();
		openList.Add(start);
		cost[start] = 0f;
		ecost.Add(Heuristic(start.Point, start.Point, end.Point), start);
		while (openList.Count > 0)
		{
			PathNode<T> pathNode = ecost.Pop();
			if (pathNode == end)
			{
				List<T> result = _pathPool.Get();
				ReconstructPath(end, result);
				return result;
			}
			openList.Remove(pathNode);
			closedList.Add(pathNode);
			List<PathNode<T>> connections = pathNode.GetConnections();
			for (int i = 0; i < connections.Count; i++)
			{
				PathNode<T> pathNode2 = connections[i];
				if ((!pathNode2.NullWeight || pathNode2 == end) && !closedList.Contains(pathNode2) && filter(pathNode2.Tag))
				{
					float num = cost[pathNode] + Distance(pathNode.Point, pathNode2.Point, end.Point) * pathNode2.Weight;
					if (!openList.Contains(pathNode2) || num < cost[pathNode2])
					{
						cameFrom[pathNode2] = pathNode;
						cost[pathNode2] = num;
						ecost.Add(cost[pathNode2] + Heuristic(pathNode.Point, pathNode2.Point, end.Point) * pathNode2.Weight, pathNode2);
						openList.Add(pathNode2);
					}
				}
			}
		}
		return null;
	}

	private static void ReconstructPath(PathNode<T> currentNode, List<T> result)
	{
		if (cameFrom.ContainsKey(currentNode))
		{
			ReconstructPath(cameFrom[currentNode], result);
		}
		result.Add(currentNode.Point);
	}

	private static void ReconstructPathNodes(PathNode<T> currentNode, List<PathNode<T>> result)
	{
		if (cameFrom.ContainsKey(currentNode))
		{
			ReconstructPathNodes(cameFrom[currentNode], result);
		}
		result.Add(currentNode);
	}
}
