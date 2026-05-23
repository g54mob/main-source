using System;
using System.Collections.Generic;
using System.Linq;
using Barmetler.RoadSystem.Util;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Barmetler.RoadSystem
{
	[ExecuteAlways]
	public class RoadSystem : MonoBehaviour
	{
		public struct Edge
		{
			public Vector3 start;

			public Vector3 end;

			public float cost;
		}

		[Serializable]
		internal class Graph
		{
			[Serializable]
			public class Node : AStar.NodeBase
			{
				public enum NodeType
				{
					INTERSECTION = 0,
					ANCHOR = 1,
					ENTRY_EXIT = 2
				}

				public NodeType nodeType;

				public RoadSystem roadSystem;

				public Intersection intersection;

				public RoadAnchor anchor;

				public Road road;

				public float distanceAlongRoad;

				public Node(RoadSystem roadSystem)
				{
					this.roadSystem = roadSystem;
					nodeType = NodeType.ENTRY_EXIT;
				}

				public Node(Vector3 worldPosition, Road road, float distanceAlongRoad, RoadSystem roadSystem)
				{
					this.roadSystem = roadSystem;
					nodeType = NodeType.ENTRY_EXIT;
					position = roadSystem.transform.InverseTransformPoint(worldPosition);
					this.road = road;
					this.distanceAlongRoad = distanceAlongRoad;
				}

				public Node(Vector3 worldPosition, RoadAnchor anchor, float distanceAlongRoad, RoadSystem roadSystem)
				{
					this.roadSystem = roadSystem;
					nodeType = NodeType.ENTRY_EXIT;
					position = roadSystem.transform.InverseTransformPoint(worldPosition);
					this.anchor = anchor;
					this.distanceAlongRoad = distanceAlongRoad;
				}

				public Node(Intersection intersection, RoadSystem roadSystem)
				{
					this.roadSystem = roadSystem;
					nodeType = NodeType.INTERSECTION;
					this.intersection = intersection;
					position = roadSystem.transform.InverseTransformPoint(intersection.transform.position);
				}

				public Node(RoadAnchor anchor, RoadSystem roadSystem)
				{
					this.roadSystem = roadSystem;
					nodeType = NodeType.ANCHOR;
					this.anchor = anchor;
					position = roadSystem.transform.InverseTransformPoint(anchor.transform.position);
				}

				public Vector3 GetWorldPosition()
				{
					return roadSystem.transform.TransformPoint(position);
				}
			}

			[SerializeField]
			public RoadSystem roadSystem;

			[SerializeField]
			private List<Node> nodes = new List<Node>();

			[SerializeField]
			private TwoDimensionalArray<float> weights = new TwoDimensionalArray<float>(0, 0);

			private TwoDimensionalNativeArray<float> _weightsNativeArray;

			public bool NativeArrayIsCreated => _weightsNativeArray.IsCreated;

			public void InitNativeArray()
			{
				if (_weightsNativeArray.IsCreated)
				{
					_weightsNativeArray.Dispose();
				}
				_weightsNativeArray = new TwoDimensionalNativeArray<float>(weights.Width, weights.Height, Allocator.Persistent);
				_weightsNativeArray.CopyFrom(weights.DirectArray);
			}

			public void DisposeNativeArray()
			{
				if (_weightsNativeArray.IsCreated)
				{
					_weightsNativeArray.Dispose();
				}
			}

			public void ConstructGraph()
			{
				nodes = new List<Node>();
				int num = roadSystem.intersections.Select((Intersection intersection2) => 1 + intersection2.AnchorPoints.Length).Sum();
				weights = new TwoDimensionalArray<float>(num, num);
				for (int num2 = 0; num2 < num; num2++)
				{
					for (int num3 = 0; num3 < num; num3++)
					{
						weights[num2, num3] = float.PositiveInfinity;
					}
				}
				Intersection[] intersections = roadSystem.intersections;
				foreach (Intersection intersection in intersections)
				{
					intersection.Invalidate(updateMesh: false);
					int count = nodes.Count;
					nodes.Add(new Node(intersection, roadSystem));
					for (int num5 = 0; num5 < intersection.AnchorPoints.Length; num5++)
					{
						nodes.Add(new Node(intersection.AnchorPoints[num5], roadSystem));
						TwoDimensionalArray<float> twoDimensionalArray = weights;
						int y = count + num5 + 1;
						float value = (weights[count + num5 + 1, count] = (nodes[count].position - nodes[count + num5 + 1].position).magnitude);
						twoDimensionalArray[count, y] = value;
					}
				}
				Road[] roads = roadSystem.roads;
				foreach (Road road in roads)
				{
					road.OnValidate();
					if ((bool)road.start && (bool)road.end)
					{
						int num6 = FindIndex(road.start, nodes);
						int num7 = FindIndex(road.end, nodes);
						if (num6 != -1 && num7 != -1)
						{
							TwoDimensionalArray<float> twoDimensionalArray2 = weights;
							float value = (weights[num7, num6] = road.GetLength());
							twoDimensionalArray2[num6, num7] = value;
						}
					}
				}
				for (int num8 = 0; num8 < num; num8++)
				{
					for (int num9 = num8; num9 < num; num9++)
					{
						float value2 = (nodes[num8].position - nodes[num9].position).magnitude * roadSystem.DistanceFactor;
						if (float.IsInfinity(weights[num8, num9]))
						{
							weights[num8, num9] = value2;
						}
						if (float.IsInfinity(weights[num9, num8]))
						{
							weights[num9, num8] = value2;
						}
					}
				}
				InitNativeArray();
			}

			public List<Edge> GetEdges()
			{
				List<Edge> list = new List<Edge>();
				for (int i = 0; i < nodes.Count; i++)
				{
					for (int j = 0; j < nodes.Count; j++)
					{
						if ((double)weights[i, j] < 5000.0 && (double)weights[i, j] > 0.001)
						{
							Edge item = new Edge
							{
								start = roadSystem.transform.TransformPoint(nodes[i].position),
								end = roadSystem.transform.TransformPoint(nodes[j].position),
								cost = weights[i, j]
							};
							list.Add(item);
						}
					}
				}
				return list;
			}

			private static int FindIndex(Intersection intersection, List<Node> nodes)
			{
				if (!intersection)
				{
					return -1;
				}
				return nodes.FindIndex(0, nodes.Count, (Node node) => node.nodeType == Node.NodeType.INTERSECTION && node.intersection == intersection);
			}

			private static int FindIndex(RoadAnchor anchor, List<Node> nodes)
			{
				if (!anchor)
				{
					return -1;
				}
				return nodes.FindIndex(0, nodes.Count, (Node node) => node.nodeType == Node.NodeType.ANCHOR && node.anchor == anchor);
			}

			public List<Node> FindPathBurst(Vector3 startPosWorld, Road startRoad, RoadAnchor startAnchor, float startDistanceAlongRoad, Vector3 goalPosWorld, Road goalRoad, RoadAnchor goalAnchor, float goalDistanceAlongRoad, out int stepsTaken, List<Edge> edges = null)
			{
				if (startRoad == null && startAnchor == null)
				{
					throw new ArgumentException("Start must be either a road or an anchor.");
				}
				if (goalRoad == null && goalAnchor == null)
				{
					throw new ArgumentException("Goal must be either a road or an anchor.");
				}
				if (!_weightsNativeArray.IsCreated)
				{
					throw new InvalidOperationException("NativeArray not created.");
				}
				if (_weightsNativeArray.Width != nodes.Count || _weightsNativeArray.Height != nodes.Count)
				{
					throw new InvalidOperationException("NativeArray size does not match nodes size.");
				}
				List<Node> nodesList = nodes.ToList();
				nodesList.Insert(0, (startRoad != null) ? new Node(startPosWorld, startRoad, startDistanceAlongRoad, roadSystem) : new Node(startPosWorld, startAnchor, startDistanceAlongRoad, roadSystem));
				nodesList.Insert(1, (goalRoad != null) ? new Node(goalPosWorld, goalRoad, goalDistanceAlongRoad, roadSystem) : new Node(goalPosWorld, goalAnchor, goalDistanceAlongRoad, roadSystem));
				int num = ((startRoad != null) ? FindIndex(startRoad.start, nodesList) : (-1));
				int num2 = ((startRoad != null) ? FindIndex(startRoad.end, nodesList) : (-1));
				int num3 = ((goalRoad != null) ? FindIndex(goalRoad.start, nodesList) : (-1));
				int num4 = ((goalRoad != null) ? FindIndex(goalRoad.end, nodesList) : (-1));
				int num5 = ((startAnchor != null) ? FindIndex(startAnchor, nodesList) : (-1));
				int num6 = ((goalAnchor != null) ? FindIndex(goalAnchor, nodesList) : (-1));
				int num7 = ((startAnchor != null) ? FindIndex(startAnchor.Intersection, nodesList) : (-1));
				int num8 = ((goalAnchor != null) ? FindIndex(goalAnchor.Intersection, nodesList) : (-1));
				for (int i = 0; i < 2; i++)
				{
					int index = ((i != 0) ? 1 : 0);
					int num9 = ((i == 0) ? num : num3);
					int num10 = ((i == 0) ? num2 : num4);
					int num11 = ((i == 0) ? num5 : num6);
					int num12 = ((i == 0) ? num7 : num8);
					int[] array = new int[4] { num9, num10, num11, num12 };
					foreach (int num13 in array)
					{
						if (num13 != -1 && Vector3.Distance(nodesList[num13].position, nodesList[index].position) < 0.001f)
						{
							nodesList[index].position += Vector3.one * 0.001f;
							if (i == 0)
							{
								startDistanceAlongRoad += 0.001f;
							}
							else
							{
								goalDistanceAlongRoad += 0.001f;
							}
						}
					}
				}
				ExtendedTwoDimensionalNativeArray<float> extendedTwoDimensionalNativeArray = new ExtendedTwoDimensionalNativeArray<float>(_weightsNativeArray, 2, 2, weights.Width + 2, weights.Height + 2, Allocator.TempJob);
				for (int k = 0; k < extendedTwoDimensionalNativeArray.Width; k++)
				{
					for (int l = 0; l < 2; l++)
					{
						int x = k;
						int y = ((l != 0) ? 1 : 0);
						float value = (extendedTwoDimensionalNativeArray[(l != 0) ? 1 : 0, k] = (nodesList[(l != 0) ? 1 : 0].position - nodesList[k].position).magnitude * roadSystem.DistanceFactor);
						extendedTwoDimensionalNativeArray[x, y] = value;
					}
				}
				for (int m = 0; m < 2; m++)
				{
					int num15 = ((m != 0) ? 1 : 0);
					if ((m == 0) ? (startRoad != null) : (goalRoad != null))
					{
						Road obj = ((m == 0) ? startRoad : goalRoad);
						float num16 = ((m == 0) ? startDistanceAlongRoad : goalDistanceAlongRoad);
						int num17 = ((m == 0) ? num : num3);
						int num18 = ((m == 0) ? num2 : num4);
						float length = obj.GetLength();
						if (num17 != -1)
						{
							float value = (extendedTwoDimensionalNativeArray[num15, num17] = num16);
							extendedTwoDimensionalNativeArray[num17, num15] = value;
						}
						if (num18 != -1)
						{
							float value = (extendedTwoDimensionalNativeArray[num15, num18] = length - num16);
							extendedTwoDimensionalNativeArray[num18, num15] = value;
						}
					}
					else
					{
						int num21 = ((m == 0) ? num5 : num6);
						int num22 = ((m == 0) ? num7 : num8);
						if (num21 != -1)
						{
							float value = (extendedTwoDimensionalNativeArray[num15, num21] = Vector3.Distance(nodesList[num21].position, nodesList[num15].position));
							extendedTwoDimensionalNativeArray[num21, num15] = value;
						}
						if (num22 != -1)
						{
							float value = (extendedTwoDimensionalNativeArray[num15, num22] = Vector3.Distance(nodesList[num22].position, nodesList[num15].position));
							extendedTwoDimensionalNativeArray[num22, num15] = value;
						}
					}
				}
				if (startRoad != null && startRoad == goalRoad)
				{
					float value = (extendedTwoDimensionalNativeArray[1, 0] = Mathf.Abs(startDistanceAlongRoad - goalDistanceAlongRoad));
					extendedTwoDimensionalNativeArray[0, 1] = value;
				}
				else if (startAnchor != null && startAnchor == goalAnchor)
				{
					float value = (extendedTwoDimensionalNativeArray[1, 0] = Vector3.Distance(nodesList[0].position, nodesList[1].position));
					extendedTwoDimensionalNativeArray[0, 1] = value;
				}
				if (edges != null)
				{
					edges.Clear();
					for (int n = 0; n < nodesList.Count; n++)
					{
						for (int num27 = 0; num27 < nodesList.Count; num27++)
						{
							if ((double)extendedTwoDimensionalNativeArray[n, num27] < 5000.0 && (double)extendedTwoDimensionalNativeArray[n, num27] > 0.001)
							{
								Edge item = new Edge
								{
									start = roadSystem.transform.TransformPoint(nodesList[n].position),
									end = roadSystem.transform.TransformPoint(nodesList[num27].position),
									cost = extendedTwoDimensionalNativeArray[n, num27]
								};
								edges.Add(item);
							}
						}
					}
				}
				NativeArray<float3> nativeArray = new NativeArray<float3>(nodesList.Count, Allocator.TempJob);
				for (int num28 = 0; num28 < nodesList.Count; num28++)
				{
					nativeArray[num28] = nodesList[num28].position;
				}
				int[] array2 = AStar.FindShortestPath(nativeArray, extendedTwoDimensionalNativeArray, 0, 1, out stepsTaken, AStar.DistanceHeuristic);
				nativeArray.Dispose();
				extendedTwoDimensionalNativeArray.Dispose();
				List<Node> list = new List<Node>(array2.Length);
				list.AddRange(array2.Select((int t) => nodesList[t]));
				return list;
			}
		}

		[SerializeField]
		[HideInInspector]
		private Intersection[] intersections;

		[SerializeField]
		[HideInInspector]
		private Road[] roads;

		[SerializeField]
		[HideInInspector]
		private Graph graph = new Graph();

		public bool ShowDebugInfo = true;

		public bool ShowEdgeWeights = true;

		public float DistanceFactor = 1000f;

		public Intersection[] Intersections => intersections;

		public Road[] Roads => roads;

		private void OnEnable()
		{
			graph.InitNativeArray();
		}

		private void OnDisable()
		{
			graph.DisposeNativeArray();
		}

		private void OnValidate()
		{
			intersections = GetComponentsInChildren<Intersection>();
			roads = GetComponentsInChildren<Road>();
			graph.roadSystem = this;
		}

		public void RebuildAllRoads()
		{
			ConstructGraph();
			Road[] array = roads;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnCurveChanged();
			}
		}

		public float GetMinDistance(Vector3 worldPosition, float stepSize, float yScale, out Road closestRoad, out Vector3 closestPoint, out float distanceAlongRoad)
		{
			closestRoad = null;
			closestPoint = Vector3.zero;
			distanceAlongRoad = 0f;
			float num = float.PositiveInfinity;
			Road[] array = roads;
			foreach (Road road in array)
			{
				if (road.IsMaybeCloser(worldPosition, num * yScale, yScale))
				{
					Vector3 closestPoint2;
					float distanceAlongRoad2;
					float minDistance = road.GetMinDistance(worldPosition, stepSize, yScale, out closestPoint2, out distanceAlongRoad2);
					if (minDistance < num)
					{
						num = minDistance;
						closestRoad = road;
						closestPoint = closestPoint2;
						distanceAlongRoad = distanceAlongRoad2;
					}
				}
			}
			return num;
		}

		public float GetMinDistance(Vector3 worldPosition, float yScale, out Intersection closestIntersection, out RoadAnchor closestAnchor, out Vector3 closestPoint, out float distanceAlongRoad)
		{
			closestIntersection = null;
			closestAnchor = null;
			closestPoint = Vector3.zero;
			distanceAlongRoad = 0f;
			float num = float.PositiveInfinity;
			Intersection[] array = intersections;
			foreach (Intersection intersection in array)
			{
				if (!intersection || !(Vector3.Scale(intersection.transform.position - worldPosition, new Vector3(1f, yScale, 1f)).magnitude - intersection.Radius < num))
				{
					continue;
				}
				RoadAnchor[] anchorPoints = intersection.AnchorPoints;
				foreach (RoadAnchor roadAnchor in anchorPoints)
				{
					Vector3 position = intersection.transform.position;
					Vector3 position2 = roadAnchor.transform.position;
					float magnitude = (position2 - position).magnitude;
					Vector3 normalized = (position2 - position).normalized;
					float num2 = Vector3.Dot(worldPosition - position, normalized);
					Vector3 vector;
					if (num2 < 0f)
					{
						vector = position;
						num2 = 0f;
					}
					else if (num2 > magnitude)
					{
						vector = position2;
						num2 = magnitude;
					}
					else
					{
						vector = position + normalized * num2;
					}
					float magnitude2 = Vector3.Scale(worldPosition - vector, new Vector3(1f, yScale, 1f)).magnitude;
					if (magnitude2 < num)
					{
						num = magnitude2;
						closestPoint = vector;
						distanceAlongRoad = num2;
						closestIntersection = intersection;
						closestAnchor = roadAnchor;
					}
				}
			}
			return num;
		}

		public void ConstructGraph()
		{
			OnValidate();
			graph.ConstructGraph();
		}

		public List<Edge> GetGraphEdges()
		{
			return graph.GetEdges();
		}

		public List<Bezier.OrientedPoint> FindPath(Vector3 startPosWorld, Vector3 goalPosWorld, List<Edge> edges = null, float yScale = 1f, float stepSize = 1f, float minDstToRoadToConnect = 10f)
		{
			int stepsTaken;
			return FindPath(startPosWorld, goalPosWorld, out stepsTaken, edges, yScale, stepSize, minDstToRoadToConnect);
		}

		public List<Bezier.OrientedPoint> FindPath(Vector3 startPosWorld, Vector3 goalPosWorld, out int stepsTaken, List<Edge> edges = null, float yScale = 1f, float stepSize = 1f, float minDstToRoadToConnect = 10f)
		{
			Road closestRoad;
			Vector3 closestPoint;
			float distanceAlongRoad;
			float minDistance = GetMinDistance(startPosWorld, stepSize, yScale, out closestRoad, out closestPoint, out distanceAlongRoad);
			Intersection closestIntersection;
			RoadAnchor closestAnchor;
			Vector3 closestPoint2;
			float distanceAlongRoad2;
			float minDistance2 = GetMinDistance(startPosWorld, yScale, out closestIntersection, out closestAnchor, out closestPoint2, out distanceAlongRoad2);
			bool flag = minDistance < minDistance2;
			Road closestRoad2;
			Vector3 closestPoint3;
			float distanceAlongRoad3;
			float minDistance3 = GetMinDistance(goalPosWorld, stepSize, yScale, out closestRoad2, out closestPoint3, out distanceAlongRoad3);
			RoadAnchor closestAnchor2;
			Vector3 closestPoint4;
			float distanceAlongRoad4;
			float minDistance4 = GetMinDistance(goalPosWorld, yScale, out closestIntersection, out closestAnchor2, out closestPoint4, out distanceAlongRoad4);
			bool flag2 = minDistance3 < minDistance4;
			if (!graph.NativeArrayIsCreated)
			{
				graph.InitNativeArray();
			}
			List<Graph.Node> nodes = graph.FindPathBurst(flag ? closestPoint : closestPoint2, flag ? closestRoad : null, flag ? null : closestAnchor, flag ? distanceAlongRoad : distanceAlongRoad2, flag2 ? closestPoint3 : closestPoint4, flag2 ? closestRoad2 : null, flag2 ? null : closestAnchor2, flag2 ? distanceAlongRoad3 : distanceAlongRoad4, out stepsTaken, edges);
			return GenerateSmoothPath(startPosWorld, goalPosWorld, nodes, stepSize, minDstToRoadToConnect);
		}

		private static List<Bezier.OrientedPoint> GenerateSmoothPath(Vector3 startPosWorld, Vector3 goalPosWorld, List<Graph.Node> nodes, float stepSize = 1f, float minDstToRoadToConnect = 10f, bool onlyNodes = false, bool subdivideStraightLines = false)
		{
			List<Bezier.OrientedPoint> list = new List<Bezier.OrientedPoint>();
			if (onlyNodes)
			{
				list.AddRange(nodes.Select((Graph.Node node3) => new Bezier.OrientedPoint(node3.GetWorldPosition(), Vector3.forward, Vector3.up)));
				return list;
			}
			for (int num = 0; num < nodes.Count - 1; num++)
			{
				Graph.Node node = nodes[num];
				Graph.Node node2 = nodes[num + 1];
				if (!node.roadSystem)
				{
					throw new InvalidOperationException($"nodes contains uninitialized node at index {num}.");
				}
				if (!node2.roadSystem)
				{
					throw new InvalidOperationException($"nodes contains uninitialized node at index {num + 1}.");
				}
				Graph.Node.NodeType nodeType = node.nodeType;
				Graph.Node.NodeType nodeType2 = node2.nodeType;
				if (nodeType != Graph.Node.NodeType.ANCHOR)
				{
					if (nodeType == Graph.Node.NodeType.ENTRY_EXIT)
					{
						if (nodeType2 != Graph.Node.NodeType.ANCHOR)
						{
							if (nodeType2 == Graph.Node.NodeType.ENTRY_EXIT && (bool)node.road && node.road == node2.road)
							{
								float num2 = Mathf.Min(node.distanceAlongRoad, node2.distanceAlongRoad);
								float num3 = Mathf.Max(node.distanceAlongRoad, node2.distanceAlongRoad);
								Bezier.OrientedPoint[] evenlySpacedPoints = node.road.GetEvenlySpacedPoints(stepSize);
								float num4 = 0f;
								int count = list.Count;
								for (int num5 = 0; num5 < evenlySpacedPoints.Length; num5++)
								{
									if (num5 > 0)
									{
										num4 += Vector3.Distance(evenlySpacedPoints[num5 - 1].position, evenlySpacedPoints[num5].position);
									}
									if (num4 > num3)
									{
										break;
									}
									if (num4 >= num2)
									{
										list.Add(evenlySpacedPoints[num5].ToWorldSpace(node.road.transform));
									}
								}
								if (list.Count > count)
								{
									if (node.distanceAlongRoad > node2.distanceAlongRoad)
									{
										list.Reverse(count, list.Count - count);
									}
									list.Insert(count, new Bezier.OrientedPoint(node.GetWorldPosition(), list[count].forward, list[count].normal));
									list.Add(new Bezier.OrientedPoint(node2.GetWorldPosition(), list[list.Count - 1].forward, list[list.Count - 1].normal));
								}
								continue;
							}
						}
						else if ((bool)node.road && (bool)node2.anchor && node.road == node2.anchor.GetConnectedRoad())
						{
							goto IL_039e;
						}
					}
				}
				else if (nodeType2 != Graph.Node.NodeType.ANCHOR)
				{
					if (nodeType2 == Graph.Node.NodeType.ENTRY_EXIT && (bool)node.anchor && (bool)node2.road && node.anchor.GetConnectedRoad() == node2.road)
					{
						goto IL_039e;
					}
				}
				else if ((bool)node.anchor && (bool)node2.anchor && node.anchor != node2.anchor && (bool)node.anchor.GetConnectedRoad() && node.anchor.GetConnectedRoad() == node2.anchor.GetConnectedRoad())
				{
					bool isStart;
					Road road = node.anchor.GetConnectedRoad(out isStart);
					Bezier.OrientedPoint[] evenlySpacedPoints2 = road.GetEvenlySpacedPoints(stepSize);
					IEnumerable<Bezier.OrientedPoint> source;
					if (!isStart)
					{
						source = evenlySpacedPoints2.Reverse();
					}
					else
					{
						IEnumerable<Bezier.OrientedPoint> enumerable = evenlySpacedPoints2;
						source = enumerable;
					}
					list.AddRange(source.Select((Bezier.OrientedPoint point) => point.ToWorldSpace(road.transform)).Skip((list.Count > 0) ? 1 : 0));
					continue;
				}
				Vector3 worldPosition = node.GetWorldPosition();
				Vector3 a = node.anchor?.transform.up ?? node.intersection?.transform.up ?? Vector3.up;
				Vector3 worldPosition2 = node2.GetWorldPosition();
				Vector3 b = node2.anchor?.transform.up ?? node2.intersection?.transform.up ?? Vector3.up;
				float num6 = Vector3.Distance(worldPosition, worldPosition2);
				Vector3 normalized = (worldPosition2 - worldPosition).normalized;
				int num7 = (subdivideStraightLines ? (Mathf.CeilToInt(num6 / stepSize) + 1) : 2);
				for (int num8 = ((list.Count > 0) ? 1 : 0); num8 < num7; num8++)
				{
					float num9 = Mathf.Lerp(0f, num6, (float)num8 / (float)Mathf.Max(1, num7 - 1));
					list.Add(new Bezier.OrientedPoint(worldPosition + num9 * normalized, normalized, Vector3.Lerp(a, b, num9 / num6)));
				}
				continue;
				IL_039e:
				bool flag = node.nodeType == Graph.Node.NodeType.ENTRY_EXIT;
				Road road2 = (flag ? node.road : node2.road);
				RoadAnchor roadAnchor = (flag ? node2.anchor : node.anchor);
				bool flag2 = road2.start == roadAnchor;
				float num10 = (flag ? node.distanceAlongRoad : node2.distanceAlongRoad);
				Bezier.OrientedPoint[] evenlySpacedPoints3 = road2.GetEvenlySpacedPoints(stepSize);
				int count2 = list.Count;
				float num11 = 0f;
				for (int num12 = 0; num12 < evenlySpacedPoints3.Length; num12++)
				{
					if (num12 > 0)
					{
						num11 += Vector3.Distance(evenlySpacedPoints3[num12 - 1].position, evenlySpacedPoints3[num12].position);
					}
					if (flag2 && num11 > num10)
					{
						break;
					}
					if (flag2 ? (num11 <= num10) : (num11 >= num10))
					{
						list.Add(evenlySpacedPoints3[num12].ToWorldSpace(road2.transform));
					}
				}
				bool flag3 = flag == flag2;
				if (list.Count > count2)
				{
					if (flag3)
					{
						list.Reverse(count2, list.Count - count2);
					}
					if (flag)
					{
						list.Insert(count2, new Bezier.OrientedPoint(node.GetWorldPosition(), list[count2].forward, list[count2].normal));
					}
					else
					{
						list.Add(new Bezier.OrientedPoint(node2.GetWorldPosition(), list[list.Count - 1].forward, list[list.Count - 1].normal));
					}
				}
			}
			if (list.Count > 0)
			{
				for (int num13 = 0; num13 < 2; num13++)
				{
					Vector3 vector = ((num13 == 0) ? startPosWorld : goalPosWorld);
					Bezier.OrientedPoint orientedPoint = list[num13 * (list.Count - 1)];
					float magnitude = (vector - orientedPoint.position).magnitude;
					if (!(magnitude >= minDstToRoadToConnect))
					{
						continue;
					}
					int num14 = (int)(magnitude / stepSize);
					for (int num15 = num14 - 1; num15 >= 0; num15--)
					{
						float t = (float)num15 / (float)num14;
						Bezier.OrientedPoint item = new Bezier.OrientedPoint(Vector3.Lerp(vector, orientedPoint.position, t), orientedPoint.forward, orientedPoint.normal);
						if (num13 == 0)
						{
							list.Insert(0, item);
						}
						else
						{
							list.Add(item);
						}
					}
				}
			}
			return list;
		}
	}
}
