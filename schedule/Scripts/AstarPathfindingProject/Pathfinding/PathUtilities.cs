using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public static class PathUtilities
	{
		private static Queue<GraphNode> BFSQueue;

		private static Dictionary<GraphNode, int> BFSMap;

		public static bool IsPathPossible(GraphNode node1, GraphNode node2)
		{
			return false;
		}

		public static bool IsPathPossible(List<GraphNode> nodes)
		{
			return false;
		}

		public static bool IsPathPossible(List<GraphNode> nodes, int tagMask)
		{
			return false;
		}

		public static List<GraphNode> GetReachableNodes(GraphNode seed, int tagMask = -1, Func<GraphNode, bool> filter = null)
		{
			return null;
		}

		public static List<GraphNode> BFS(GraphNode seed, int depth, int tagMask = -1, Func<GraphNode, bool> filter = null)
		{
			return null;
		}

		public static List<Vector3> GetSpiralPoints(int count, float clearance)
		{
			return null;
		}

		private static Vector3 InvoluteOfCircle(float a, float t)
		{
			return default(Vector3);
		}

		public static void GetPointsAroundPointWorld(Vector3 p, IRaycastableGraph g, List<Vector3> previousPoints, float radius, float clearanceRadius)
		{
		}

		public static void GetPointsAroundPoint(Vector3 center, IRaycastableGraph g, List<Vector3> previousPoints, float radius, float clearanceRadius)
		{
		}

		public static List<Vector3> GetPointsOnNodes(List<GraphNode> nodes, int count, float clearanceRadius = 0f)
		{
			return null;
		}
	}
}
