using System;
using System.Collections.Generic;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public static class PathUtilities
	{
		[BurstCompile(FloatMode = FloatMode.Fast)]
		private struct JobFormationPacked : IJob
		{
			private struct DistanceComparer : IComparer<int>
			{
				public NativeArray<float2> positions;

				public int Compare(int x, int y)
				{
					return 0;
				}
			}

			public NativeArray<float3> positions;

			public float3 destination;

			public float agentRadius;

			public NativeMovementPlane movementPlane;

			public float CollisionTime(float2 pos1, float2 pos2, float2 v1, float2 v2, float r1, float r2)
			{
				return 0f;
			}

			public void Execute()
			{
			}
		}

		public enum FormationMode
		{
			SinglePoint = 0,
			Packed = 1
		}

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

		public static void FormationPacked(List<Vector3> currentPositions, Vector3 destination, float clearanceRadius, NativeMovementPlane movementPlane)
		{
		}

		public static List<Vector3> FormationDestinations(List<IAstarAI> group, Vector3 destination, FormationMode formationMode, float marginFactor = 0.1f)
		{
			return null;
		}

		public static void GetPointsAroundPointWorldFlexible(Vector3 center, Quaternion rotation, List<Vector3> positions)
		{
		}

		public static List<Vector3> GetPointsOnNodes(List<GraphNode> nodes, int count, float clearanceRadius = 0f)
		{
			return null;
		}
	}
}
