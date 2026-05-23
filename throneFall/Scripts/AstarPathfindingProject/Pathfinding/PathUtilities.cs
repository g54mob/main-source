using System;
using System.Collections.Generic;
using System.Linq;
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
					return (int)math.sign(math.lengthsq(positions[x]) - math.lengthsq(positions[y]));
				}
			}

			public NativeArray<float3> positions;

			public float3 destination;

			public float agentRadius;

			public NativeMovementPlane movementPlane;

			public float CollisionTime(float2 pos1, float2 pos2, float2 v1, float2 v2, float r1, float r2)
			{
				float2 float5 = v1 - v2;
				if (math.all(float5 == float2.zero))
				{
					return float.MaxValue;
				}
				float num = r1 + r2;
				float2 obj = pos2 - pos1;
				float2 float6 = math.normalize(float5);
				float num2 = math.dot(obj, float6);
				float num3 = math.lengthsq(obj - float6 * num2);
				float num4 = num * num - num3;
				if (num4 <= 0f)
				{
					return float.MaxValue;
				}
				float num5 = math.sqrt(num4);
				float num6 = num2 - num5;
				if (num6 < 0f - num)
				{
					return float.MaxValue;
				}
				return num6 * math.rsqrt(math.lengthsq(float5));
			}

			public void Execute()
			{
				if (positions.Length == 0)
				{
					return;
				}
				NativeArray<float2> nativeArray = new NativeArray<float2>(positions.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				NativeArray<int> array = new NativeArray<int>(positions.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				for (int i = 0; i < positions.Length; i++)
				{
					nativeArray[i] = movementPlane.ToPlane(positions[i]);
					array[i] = i;
				}
				float2 zero = float2.zero;
				for (int j = 0; j < nativeArray.Length; j++)
				{
					zero += nativeArray[j];
				}
				zero /= (float)nativeArray.Length;
				for (int k = 0; k < nativeArray.Length; k++)
				{
					nativeArray[k] -= zero;
				}
				array.Sort(new DistanceComparer
				{
					positions = nativeArray
				});
				NativeArray<float> nativeArray2 = new NativeArray<float>(positions.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				for (int l = 0; l < positions.Length; l++)
				{
					float num = float.MaxValue;
					int index = array[l];
					for (int m = 0; m < l; m++)
					{
						int index2 = array[m];
						float y = CollisionTime(nativeArray[index], nativeArray[index2], -nativeArray[index], float2.zero, agentRadius, agentRadius);
						num = math.min(num, y);
					}
					nativeArray2[index] = num;
					nativeArray[index] -= nativeArray[index] * math.min(1f, nativeArray2[array[l]]);
				}
				for (int n = 0; n < positions.Length; n++)
				{
					positions[n] = movementPlane.ToWorld(nativeArray[n]) + destination;
				}
			}
		}

		public enum FormationMode
		{
			SinglePoint = 0,
			Packed = 1
		}

		private class ConstrainToSet : NNConstraint
		{
			public HashSet<GraphNode> nodes;

			public override bool Suitable(GraphNode node)
			{
				return nodes.Contains(node);
			}
		}

		private static Queue<GraphNode> BFSQueue;

		private static Dictionary<GraphNode, int> BFSMap;

		public static bool IsPathPossible(GraphNode node1, GraphNode node2)
		{
			if (node1.Walkable && node2.Walkable)
			{
				return node1.Area == node2.Area;
			}
			return false;
		}

		public static bool IsPathPossible(List<GraphNode> nodes)
		{
			if (nodes.Count == 0)
			{
				return true;
			}
			uint area = nodes[0].Area;
			for (int i = 0; i < nodes.Count; i++)
			{
				if (!nodes[i].Walkable || nodes[i].Area != area)
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsPathPossible(List<GraphNode> nodes, int tagMask)
		{
			if (nodes.Count == 0)
			{
				return true;
			}
			if (((tagMask >> (int)nodes[0].Tag) & 1) == 0)
			{
				return false;
			}
			if (!IsPathPossible(nodes))
			{
				return false;
			}
			List<GraphNode> list = GetReachableNodes(nodes[0], tagMask);
			bool result = true;
			for (int i = 1; i < nodes.Count; i++)
			{
				if (!list.Contains(nodes[i]))
				{
					result = false;
					break;
				}
			}
			ListPool<GraphNode>.Release(ref list);
			return result;
		}

		public static List<GraphNode> GetReachableNodes(GraphNode seed, int tagMask = -1, Func<GraphNode, bool> filter = null)
		{
			Stack<GraphNode> dfsStack = StackPool<GraphNode>.Claim();
			List<GraphNode> reachable = ListPool<GraphNode>.Claim();
			HashSet<GraphNode> map = new HashSet<GraphNode>();
			Action<GraphNode> action = ((tagMask != -1 || filter != null) ? ((Action<GraphNode>)delegate(GraphNode node)
			{
				if (node.Walkable && ((tagMask >> (int)node.Tag) & 1) != 0 && map.Add(node) && (filter == null || filter(node)))
				{
					reachable.Add(node);
					dfsStack.Push(node);
				}
			}) : ((Action<GraphNode>)delegate(GraphNode node)
			{
				if (node.Walkable && map.Add(node))
				{
					reachable.Add(node);
					dfsStack.Push(node);
				}
			}));
			action(seed);
			while (dfsStack.Count > 0)
			{
				dfsStack.Pop().GetConnections(action);
			}
			StackPool<GraphNode>.Release(dfsStack);
			return reachable;
		}

		public static List<GraphNode> BFS(GraphNode seed, int depth, int tagMask = -1, Func<GraphNode, bool> filter = null)
		{
			BFSQueue = BFSQueue ?? new Queue<GraphNode>();
			Queue<GraphNode> que = BFSQueue;
			BFSMap = BFSMap ?? new Dictionary<GraphNode, int>();
			Dictionary<GraphNode, int> map = BFSMap;
			que.Clear();
			map.Clear();
			List<GraphNode> result = ListPool<GraphNode>.Claim();
			int currentDist = -1;
			Action<GraphNode> action = ((tagMask != -1) ? ((Action<GraphNode>)delegate(GraphNode node)
			{
				if (node.Walkable && ((tagMask >> (int)node.Tag) & 1) != 0 && !map.ContainsKey(node) && (filter == null || filter(node)))
				{
					map.Add(node, currentDist + 1);
					result.Add(node);
					que.Enqueue(node);
				}
			}) : ((Action<GraphNode>)delegate(GraphNode node)
			{
				if (node.Walkable && !map.ContainsKey(node) && (filter == null || filter(node)))
				{
					map.Add(node, currentDist + 1);
					result.Add(node);
					que.Enqueue(node);
				}
			}));
			action(seed);
			while (que.Count > 0)
			{
				GraphNode graphNode = que.Dequeue();
				currentDist = map[graphNode];
				if (currentDist >= depth)
				{
					break;
				}
				graphNode.GetConnections(action);
			}
			que.Clear();
			map.Clear();
			return result;
		}

		public static List<Vector3> GetSpiralPoints(int count, float clearance)
		{
			List<Vector3> list = ListPool<Vector3>.Claim(count);
			float num = clearance / (MathF.PI * 2f);
			float num2 = 0f;
			list.Add(InvoluteOfCircle(num, num2));
			for (int i = 0; i < count; i++)
			{
				Vector3 vector = list[list.Count - 1];
				float num3 = (0f - num2) / 2f + Mathf.Sqrt(num2 * num2 / 4f + 2f * clearance / num);
				float num4 = num2 + num3;
				float num5 = num2 + 2f * num3;
				while (num5 - num4 > 0.01f)
				{
					float num6 = (num4 + num5) / 2f;
					if ((InvoluteOfCircle(num, num6) - vector).sqrMagnitude < clearance * clearance)
					{
						num4 = num6;
					}
					else
					{
						num5 = num6;
					}
				}
				list.Add(InvoluteOfCircle(num, num5));
				num2 = num5;
			}
			return list;
		}

		private static Vector3 InvoluteOfCircle(float a, float t)
		{
			return new Vector3(a * (Mathf.Cos(t) + t * Mathf.Sin(t)), 0f, a * (Mathf.Sin(t) - t * Mathf.Cos(t)));
		}

		public static void GetPointsAroundPointWorld(Vector3 p, IRaycastableGraph g, List<Vector3> previousPoints, float radius, float clearanceRadius)
		{
			if (previousPoints.Count != 0)
			{
				Vector3 zero = Vector3.zero;
				for (int i = 0; i < previousPoints.Count; i++)
				{
					zero += previousPoints[i];
				}
				zero /= (float)previousPoints.Count;
				for (int j = 0; j < previousPoints.Count; j++)
				{
					previousPoints[j] -= zero;
				}
				GetPointsAroundPoint(p, g, previousPoints, radius, clearanceRadius);
			}
		}

		public static void GetPointsAroundPoint(Vector3 center, IRaycastableGraph g, List<Vector3> previousPoints, float radius, float clearanceRadius)
		{
			if (g == null)
			{
				throw new ArgumentNullException("g");
			}
			NNInfo nearest = ((g as NavGraph) ?? throw new ArgumentException("g is not a NavGraph")).GetNearest(center, NNConstraint.Walkable);
			center = nearest.position;
			if (nearest.node == null)
			{
				return;
			}
			radius = Mathf.Max(radius, 1.4142f * clearanceRadius * Mathf.Sqrt(previousPoints.Count));
			clearanceRadius *= clearanceRadius;
			for (int i = 0; i < previousPoints.Count; i++)
			{
				Vector3 vector = previousPoints[i];
				float magnitude = vector.magnitude;
				if (magnitude > 0f)
				{
					vector /= magnitude;
				}
				float num = radius;
				vector *= num;
				int num2 = 0;
				while (true)
				{
					Vector3 vector2 = center + vector;
					if (g.Linecast(center, vector2, out var hit))
					{
						if (hit.point == Vector3.zero)
						{
							num2++;
							if (num2 > 8)
							{
								previousPoints[i] = vector2;
								break;
							}
						}
						else
						{
							vector2 = hit.point;
						}
					}
					bool flag = false;
					for (float num3 = 0.1f; num3 <= 1f; num3 += 0.05f)
					{
						Vector3 vector3 = Vector3.Lerp(center, vector2, num3);
						flag = true;
						for (int j = 0; j < i; j++)
						{
							if ((previousPoints[j] - vector3).sqrMagnitude < clearanceRadius)
							{
								flag = false;
								break;
							}
						}
						if (flag || num2 > 8)
						{
							flag = true;
							previousPoints[i] = vector3;
							break;
						}
					}
					if (flag)
					{
						break;
					}
					clearanceRadius *= 0.9f;
					vector = UnityEngine.Random.onUnitSphere * Mathf.Lerp(num, radius, num2 / 5);
					vector.y = 0f;
					num2++;
				}
			}
		}

		public static void FormationPacked(List<Vector3> currentPositions, Vector3 destination, float clearanceRadius, NativeMovementPlane movementPlane)
		{
			NativeArray<float3> positions = new NativeArray<float3>(currentPositions.Count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < positions.Length; i++)
			{
				positions[i] = currentPositions[i];
			}
			new JobFormationPacked
			{
				positions = positions,
				destination = destination,
				agentRadius = clearanceRadius,
				movementPlane = movementPlane
			}.Schedule().Complete();
			for (int j = 0; j < positions.Length; j++)
			{
				currentPositions[j] = positions[j];
			}
			positions.Dispose();
		}

		public static List<Vector3> FormationDestinations(List<IAstarAI> group, Vector3 destination, FormationMode formationMode, float marginFactor = 0.1f)
		{
			if (group.Count == 0)
			{
				return new List<Vector3>();
			}
			List<Vector3> list = group.Select((IAstarAI u) => u.position).ToList();
			if (formationMode == FormationMode.SinglePoint)
			{
				for (int num = 0; num < list.Count; num++)
				{
					list[num] = destination;
				}
			}
			else
			{
				Vector3 previousMean = Vector3.zero;
				for (int num2 = 0; num2 < list.Count; num2++)
				{
					previousMean += list[num2];
				}
				previousMean /= (float)list.Count;
				NativeMovementPlane movementPlane = group[0].movementPlane;
				Debug.Log(((Quaternion)movementPlane.rotation).eulerAngles);
				float num3 = Mathf.Sqrt(list.Average((Vector3 p) => Vector3.SqrMagnitude(p - previousMean))) * 1f;
				if (Vector3.Distance(destination, previousMean) > num3)
				{
					FormationPacked(list, destination, group[0].radius * (1f + marginFactor), movementPlane);
				}
				else
				{
					for (int num4 = 0; num4 < list.Count; num4++)
					{
						list[num4] = destination;
					}
				}
			}
			return list;
		}

		public static void GetPointsAroundPointWorldFlexible(Vector3 center, Quaternion rotation, List<Vector3> positions)
		{
			if (positions.Count == 0)
			{
				return;
			}
			NNInfo nearest = AstarPath.active.GetNearest(center, NNConstraint.Walkable);
			Vector3 groupPos = Vector3.Lerp(nearest.position, (Vector3)nearest.node.position, 0.001f);
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < positions.Count; i++)
			{
				zero += positions[i];
			}
			zero /= (float)positions.Count;
			float maxSqrDistance = 0f;
			for (int j = 0; j < positions.Count; j++)
			{
				positions[j] -= zero;
				maxSqrDistance = Mathf.Max(maxSqrDistance, positions[j].sqrMagnitude);
			}
			maxSqrDistance *= 4f;
			int minNodes = 10;
			List<GraphNode> collection = BFS(nearest.node, int.MaxValue, -1, delegate(GraphNode node)
			{
				minNodes--;
				return minNodes > 0 || ((Vector3)node.position - groupPos).sqrMagnitude < maxSqrDistance;
			});
			NNConstraint constraint = new ConstrainToSet
			{
				nodes = new HashSet<GraphNode>(collection)
			};
			int num = 3;
			for (int num2 = 0; num2 < num; num2++)
			{
				float num3 = 0f;
				Vector3 zero2 = Vector3.zero;
				for (int num4 = 0; num4 < positions.Count; num4++)
				{
					Vector3 vector = rotation * positions[num4];
					Vector3 vector2 = groupPos + vector;
					Vector3 position = AstarPath.active.GetNearest(vector2, constraint).position;
					float num5 = Vector3.Distance(vector2, position);
					zero2 += (position - vector) * num5;
					num3 += num5;
				}
				if (num3 <= 1E-07f)
				{
					break;
				}
				Vector3 position2 = zero2 / num3;
				groupPos = AstarPath.active.GetNearest(position2, constraint).position;
			}
			for (int num6 = 0; num6 < positions.Count; num6++)
			{
				positions[num6] = groupPos + rotation * positions[num6];
			}
		}

		public static List<Vector3> GetPointsOnNodes(List<GraphNode> nodes, int count, float clearanceRadius = 0f)
		{
			if (nodes == null)
			{
				throw new ArgumentNullException("nodes");
			}
			if (nodes.Count == 0)
			{
				throw new ArgumentException("no nodes passed");
			}
			List<Vector3> list = ListPool<Vector3>.Claim(count);
			clearanceRadius *= clearanceRadius;
			if (clearanceRadius > 0f || nodes[0] is TriangleMeshNode || nodes[0] is GridNode)
			{
				List<float> list2 = ListPool<float>.Claim(nodes.Count);
				float num = 0f;
				for (int i = 0; i < nodes.Count; i++)
				{
					float num2 = nodes[i].SurfaceArea();
					num2 += 0.001f;
					num += num2;
					list2.Add(num);
				}
				for (int j = 0; j < count; j++)
				{
					int num3 = 0;
					int num4 = 10;
					Vector3 vector;
					while (true)
					{
						bool flag = true;
						if (num3 >= num4)
						{
							clearanceRadius *= 0.80999994f;
							num4 += 10;
							if (num4 > 100)
							{
								clearanceRadius = 0f;
							}
						}
						float item = UnityEngine.Random.value * num;
						int num5 = list2.BinarySearch(item);
						if (num5 < 0)
						{
							num5 = ~num5;
						}
						if (num5 >= nodes.Count)
						{
							continue;
						}
						vector = nodes[num5].RandomPointOnSurface();
						if (clearanceRadius > 0f)
						{
							for (int k = 0; k < list.Count; k++)
							{
								if ((list[k] - vector).sqrMagnitude < clearanceRadius)
								{
									flag = false;
									break;
								}
							}
						}
						if (flag)
						{
							break;
						}
						num3++;
					}
					list.Add(vector);
				}
				ListPool<float>.Release(ref list2);
			}
			else
			{
				for (int l = 0; l < count; l++)
				{
					list.Add(nodes[UnityEngine.Random.Range(0, nodes.Count)].RandomPointOnSurface());
				}
			}
			return list;
		}
	}
}
