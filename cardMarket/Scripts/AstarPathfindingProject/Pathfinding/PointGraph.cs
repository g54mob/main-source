using System;
using System.Collections.Generic;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	[JsonOptIn]
	[Preserve]
	public class PointGraph : NavGraph, IUpdatableGraph
	{
		public enum NodeDistanceMode
		{
			Node = 0,
			Connection = 1
		}

		private class PointGraphScanPromise : IGraphUpdatePromise
		{
			public PointGraph graph;

			private PointKDTree lookupTree;

			private PointNode[] nodes;

			public IEnumerator<JobHandle> Prepare()
			{
				Transform root = graph.root;
				if (root == null)
				{
					GameObject[] array = ((graph.searchTag != null) ? GameObject.FindGameObjectsWithTag(graph.searchTag) : null);
					if (array == null)
					{
						nodes = new PointNode[0];
					}
					else
					{
						nodes = graph.CreateNodes(array.Length);
						for (int i = 0; i < array.Length; i++)
						{
							PointNode obj = nodes[i];
							obj.position = (Int3)array[i].transform.position;
							obj.Walkable = true;
							obj.gameObject = array[i].gameObject;
						}
					}
				}
				else if (!graph.recursive)
				{
					int childCount = root.childCount;
					nodes = graph.CreateNodes(childCount);
					int num = 0;
					foreach (Transform item in root)
					{
						PointNode obj2 = nodes[num];
						obj2.position = (Int3)item.position;
						obj2.Walkable = true;
						obj2.gameObject = item.gameObject;
						num++;
					}
				}
				else
				{
					int count = CountChildren(root);
					nodes = graph.CreateNodes(count);
					int c = 0;
					AddChildren(nodes, ref c, root);
				}
				yield return default(JobHandle);
				lookupTree = BuildNodeLookup(nodes, nodes.Length, graph.optimizeForSparseGraph);
				foreach (float item2 in ConnectNodesAsync(nodes, nodes.Length, lookupTree, graph.maxDistance, graph.limits, graph))
				{
					_ = item2;
					yield return default(JobHandle);
				}
			}

			public void Apply(IGraphUpdateContext ctx)
			{
				graph.DestroyAllNodes();
				graph.lookupTree = lookupTree;
				graph.nodes = nodes;
				graph.nodeCount = nodes.Length;
				graph.maximumConnectionLength = ((graph.nearestNodeDistanceMode == NodeDistanceMode.Connection) ? LongestConnectionLength(nodes, nodes.Length) : 0);
			}
		}

		private class PointGraphUpdatePromise : IGraphUpdatePromise
		{
			public PointGraph graph;

			public List<GraphUpdateObject> graphUpdates;

			public void Apply(IGraphUpdateContext ctx)
			{
				PointNode[] nodes = graph.nodes;
				for (int i = 0; i < graphUpdates.Count; i++)
				{
					GraphUpdateObject graphUpdateObject = graphUpdates[i];
					for (int j = 0; j < graph.nodeCount; j++)
					{
						PointNode pointNode = nodes[j];
						if (graphUpdateObject.bounds.Contains((Vector3)pointNode.position))
						{
							graphUpdateObject.WillUpdateNode(pointNode);
							graphUpdateObject.Apply(pointNode);
						}
					}
					if (!graphUpdateObject.updatePhysics)
					{
						continue;
					}
					Bounds bounds = graphUpdateObject.bounds;
					if (graph.thickRaycast)
					{
						bounds.Expand(graph.thickRaycastRadius * 2f);
					}
					List<Connection> list = ListPool<Connection>.Claim();
					for (int k = 0; k < graph.nodeCount; k++)
					{
						PointNode pointNode2 = graph.nodes[k];
						Vector3 a = (Vector3)pointNode2.position;
						List<Connection> list2 = null;
						for (int l = 0; l < graph.nodeCount; l++)
						{
							if (l == k)
							{
								continue;
							}
							Vector3 b = (Vector3)nodes[l].position;
							if (!VectorMath.SegmentIntersectsBounds(bounds, a, b))
							{
								continue;
							}
							PointNode pointNode3 = nodes[l];
							bool flag = pointNode2.ContainsOutgoingConnection(pointNode3);
							float dist;
							bool flag2 = graph.IsValidConnection(pointNode2, pointNode3, out dist);
							if (list2 == null && flag != flag2)
							{
								list.Clear();
								list2 = list;
								list2.AddRange(pointNode2.connections);
							}
							if (!flag && flag2)
							{
								uint cost = (uint)Mathf.RoundToInt(dist * 1000f);
								list2.Add(new Connection(pointNode3, cost, isOutgoing: true, isIncoming: true));
								graph.RegisterConnectionLength((pointNode3.position - pointNode2.position).sqrMagnitudeLong);
							}
							else
							{
								if (!flag || flag2)
								{
									continue;
								}
								for (int m = 0; m < list2.Count; m++)
								{
									if (list2[m].node == pointNode3)
									{
										list2.RemoveAt(m);
										break;
									}
								}
							}
						}
						if (list2 != null)
						{
							pointNode2.connections = list2.ToArray();
							pointNode2.SetConnectivityDirty();
						}
					}
					ListPool<Connection>.Release(ref list);
					ctx.DirtyBounds(graphUpdateObject.bounds);
				}
				ListPool<GraphUpdateObject>.Release(ref graphUpdates);
			}
		}

		[JsonMember]
		public Transform root;

		[JsonMember]
		public string searchTag;

		[JsonMember]
		public float maxDistance;

		[JsonMember]
		public Vector3 limits;

		[JsonMember]
		public bool raycast = true;

		[JsonMember]
		public bool use2DPhysics;

		[JsonMember]
		public bool thickRaycast;

		[JsonMember]
		public float thickRaycastRadius = 1f;

		[JsonMember]
		public bool recursive = true;

		[JsonMember]
		public LayerMask mask;

		[JsonMember]
		public bool optimizeForSparseGraph;

		private PointKDTree lookupTree = new PointKDTree();

		private long maximumConnectionLength;

		public PointNode[] nodes;

		[JsonMember]
		public NodeDistanceMode nearestNodeDistanceMode;

		public int nodeCount { get; protected set; }

		public override bool isScanned => nodes != null;

		public override int CountNodes()
		{
			return nodeCount;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
			if (nodes != null)
			{
				int num = nodeCount;
				for (int i = 0; i < num; i++)
				{
					action(nodes[i]);
				}
			}
		}

		public override NNInfo GetNearest(Vector3 position, NNConstraint constraint, float maxDistanceSqr)
		{
			if (nodes == null)
			{
				return NNInfo.Empty;
			}
			Int3 @int = (Int3)position;
			if (optimizeForSparseGraph)
			{
				if (nearestNodeDistanceMode == NodeDistanceMode.Node)
				{
					float distanceSqr = maxDistanceSqr;
					GraphNode nearest = lookupTree.GetNearest(@int, constraint, ref distanceSqr);
					return new NNInfo(nearest, (Vector3)nearest.position, distanceSqr);
				}
				GraphNode nearestConnection = lookupTree.GetNearestConnection(@int, constraint, maximumConnectionLength);
				if (nearestConnection == null)
				{
					return NNInfo.Empty;
				}
				return FindClosestConnectionPoint(nearestConnection as PointNode, position, maxDistanceSqr);
			}
			PointNode pointNode = null;
			long num = AstarMath.SaturatingConvertFloatToLong(maxDistanceSqr * 1000f * 1000f);
			for (int i = 0; i < nodeCount; i++)
			{
				PointNode pointNode2 = nodes[i];
				long sqrMagnitudeLong = (@int - pointNode2.position).sqrMagnitudeLong;
				if (sqrMagnitudeLong < num && (constraint == null || constraint.Suitable(pointNode2)))
				{
					num = sqrMagnitudeLong;
					pointNode = pointNode2;
				}
			}
			if (!(1.0000001E-06f * (float)num < maxDistanceSqr) || pointNode == null)
			{
				return NNInfo.Empty;
			}
			return new NNInfo(pointNode, (Vector3)pointNode.position, 1.0000001E-06f * (float)num);
		}

		private NNInfo FindClosestConnectionPoint(PointNode node, Vector3 position, float maxDistanceSqr)
		{
			Vector3 position2 = (Vector3)node.position;
			Connection[] connections = node.connections;
			Vector3 vector = (Vector3)node.position;
			if (connections != null)
			{
				for (int i = 0; i < connections.Length; i++)
				{
					Vector3 lineEnd = ((Vector3)connections[i].node.position + vector) * 0.5f;
					Vector3 vector2 = VectorMath.ClosestPointOnSegment(vector, lineEnd, position);
					float sqrMagnitude = (vector2 - position).sqrMagnitude;
					if (sqrMagnitude < maxDistanceSqr)
					{
						maxDistanceSqr = sqrMagnitude;
						position2 = vector2;
					}
				}
			}
			return new NNInfo(node, position2, maxDistanceSqr);
		}

		public PointNode AddNode(Int3 position)
		{
			return AddNode(new PointNode(active), position);
		}

		public T AddNode<T>(T node, Int3 position) where T : PointNode
		{
			AssertSafeToUpdateGraph();
			if (nodes == null || nodeCount == nodes.Length)
			{
				PointNode[] array = new PointNode[(nodes != null) ? Math.Max(nodes.Length + 4, nodes.Length * 2) : 4];
				if (nodes != null)
				{
					nodes.CopyTo(array, 0);
				}
				nodes = array;
			}
			node.SetPosition(position);
			node.GraphIndex = graphIndex;
			node.Walkable = true;
			nodes[nodeCount] = node;
			nodeCount++;
			if (optimizeForSparseGraph)
			{
				AddToLookup(node);
			}
			return node;
		}

		protected static int CountChildren(Transform tr)
		{
			int num = 0;
			foreach (Transform item in tr)
			{
				num++;
				num += CountChildren(item);
			}
			return num;
		}

		protected static void AddChildren(PointNode[] nodes, ref int c, Transform tr)
		{
			foreach (Transform item in tr)
			{
				nodes[c].position = (Int3)item.position;
				nodes[c].Walkable = true;
				nodes[c].gameObject = item.gameObject;
				c++;
				AddChildren(nodes, ref c, item);
			}
		}

		public void RebuildNodeLookup()
		{
			lookupTree = BuildNodeLookup(nodes, nodeCount, optimizeForSparseGraph);
			RebuildConnectionDistanceLookup();
		}

		private static PointKDTree BuildNodeLookup(PointNode[] nodes, int nodeCount, bool optimizeForSparseGraph)
		{
			if (optimizeForSparseGraph && nodes != null)
			{
				PointKDTree pointKDTree = new PointKDTree();
				pointKDTree.Rebuild(nodes, 0, nodeCount);
				return pointKDTree;
			}
			return null;
		}

		public void RebuildConnectionDistanceLookup()
		{
			if (nearestNodeDistanceMode == NodeDistanceMode.Connection)
			{
				maximumConnectionLength = LongestConnectionLength(nodes, nodeCount);
			}
			else
			{
				maximumConnectionLength = 0L;
			}
		}

		private static long LongestConnectionLength(PointNode[] nodes, int nodeCount)
		{
			long num = 0L;
			for (int i = 0; i < nodeCount; i++)
			{
				PointNode pointNode = nodes[i];
				Connection[] connections = pointNode.connections;
				if (connections != null)
				{
					for (int j = 0; j < connections.Length; j++)
					{
						long sqrMagnitudeLong = (pointNode.position - connections[j].node.position).sqrMagnitudeLong;
						num = Math.Max(num, sqrMagnitudeLong);
					}
				}
			}
			return num;
		}

		private void AddToLookup(PointNode node)
		{
			lookupTree.Add(node);
		}

		public void RegisterConnectionLength(long sqrLength)
		{
			maximumConnectionLength = Math.Max(maximumConnectionLength, sqrLength);
		}

		protected virtual PointNode[] CreateNodes(int count)
		{
			PointNode[] array = new PointNode[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = new PointNode(active);
			}
			return array;
		}

		protected override IGraphUpdatePromise ScanInternal()
		{
			return new PointGraphScanPromise
			{
				graph = this
			};
		}

		public void ConnectNodes()
		{
			AssertSafeToUpdateGraph();
			IEnumerator<float> enumerator = ConnectNodesAsync(nodes, nodeCount, lookupTree, maxDistance, limits, this).GetEnumerator();
			while (enumerator.MoveNext())
			{
			}
			RebuildConnectionDistanceLookup();
		}

		private static IEnumerable<float> ConnectNodesAsync(PointNode[] nodes, int nodeCount, PointKDTree lookupTree, float maxDistance, Vector3 limits, PointGraph graph)
		{
			if (!(maxDistance >= 0f))
			{
				yield break;
			}
			List<Connection> connections = new List<Connection>();
			List<GraphNode> candidateConnections = new List<GraphNode>();
			long maxSquaredRange;
			if (maxDistance == 0f && (limits.x == 0f || limits.y == 0f || limits.z == 0f))
			{
				maxSquaredRange = long.MaxValue;
			}
			else
			{
				maxSquaredRange = (long)(Mathf.Max(limits.x, Mathf.Max(limits.y, Mathf.Max(limits.z, maxDistance))) * 1000f) + 1;
				maxSquaredRange *= maxSquaredRange;
			}
			for (int i = 0; i < nodeCount; i++)
			{
				if (i % 512 == 0)
				{
					yield return (float)i / (float)nodeCount;
				}
				connections.Clear();
				PointNode pointNode = nodes[i];
				if (lookupTree != null)
				{
					candidateConnections.Clear();
					lookupTree.GetInRange(pointNode.position, maxSquaredRange, candidateConnections);
					for (int j = 0; j < candidateConnections.Count; j++)
					{
						PointNode pointNode2 = candidateConnections[j] as PointNode;
						if (pointNode2 != pointNode && graph.IsValidConnection(pointNode, pointNode2, out var dist))
						{
							connections.Add(new Connection(pointNode2, (uint)Mathf.RoundToInt(dist * 1000f), isOutgoing: true, isIncoming: true));
						}
					}
				}
				else
				{
					for (int k = 0; k < nodeCount; k++)
					{
						if (i != k)
						{
							PointNode pointNode3 = nodes[k];
							if (graph.IsValidConnection(pointNode, pointNode3, out var dist2))
							{
								connections.Add(new Connection(pointNode3, (uint)Mathf.RoundToInt(dist2 * 1000f), isOutgoing: true, isIncoming: true));
							}
						}
					}
				}
				pointNode.connections = connections.ToArray();
				pointNode.SetConnectivityDirty();
			}
		}

		public virtual bool IsValidConnection(GraphNode a, GraphNode b, out float dist)
		{
			dist = 0f;
			if (!a.Walkable || !b.Walkable)
			{
				return false;
			}
			Vector3 vector = (Vector3)(b.position - a.position);
			if ((!Mathf.Approximately(limits.x, 0f) && Mathf.Abs(vector.x) > limits.x) || (!Mathf.Approximately(limits.y, 0f) && Mathf.Abs(vector.y) > limits.y) || (!Mathf.Approximately(limits.z, 0f) && Mathf.Abs(vector.z) > limits.z))
			{
				return false;
			}
			dist = vector.magnitude;
			if (maxDistance == 0f || dist < maxDistance)
			{
				if (raycast)
				{
					Ray ray = new Ray((Vector3)a.position, vector);
					Ray ray2 = new Ray((Vector3)b.position, -vector);
					if (use2DPhysics)
					{
						if (thickRaycast)
						{
							if (!Physics2D.CircleCast(ray.origin, thickRaycastRadius, ray.direction, dist, mask))
							{
								return !Physics2D.CircleCast(ray2.origin, thickRaycastRadius, ray2.direction, dist, mask);
							}
							return false;
						}
						if (!Physics2D.Linecast((Vector3)a.position, (Vector3)b.position, mask))
						{
							return !Physics2D.Linecast((Vector3)b.position, (Vector3)a.position, mask);
						}
						return false;
					}
					if (thickRaycast)
					{
						if (!Physics.SphereCast(ray, thickRaycastRadius, dist, mask))
						{
							return !Physics.SphereCast(ray2, thickRaycastRadius, dist, mask);
						}
						return false;
					}
					if (!Physics.Linecast((Vector3)a.position, (Vector3)b.position, mask))
					{
						return !Physics.Linecast((Vector3)b.position, (Vector3)a.position, mask);
					}
					return false;
				}
				return true;
			}
			return false;
		}

		IGraphUpdatePromise IUpdatableGraph.ScheduleGraphUpdates(List<GraphUpdateObject> graphUpdates)
		{
			if (!isScanned)
			{
				return null;
			}
			return new PointGraphUpdatePromise
			{
				graph = this,
				graphUpdates = graphUpdates
			};
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
			RebuildNodeLookup();
		}

		public override void RelocateNodes(Matrix4x4 deltaMatrix)
		{
			base.RelocateNodes(deltaMatrix);
			RebuildNodeLookup();
		}

		protected override void SerializeExtraInfo(GraphSerializationContext ctx)
		{
			if (nodes == null)
			{
				ctx.writer.Write(-1);
			}
			ctx.writer.Write(nodeCount);
			for (int i = 0; i < nodeCount; i++)
			{
				if (nodes[i] == null)
				{
					ctx.writer.Write(-1);
					continue;
				}
				ctx.writer.Write(0);
				nodes[i].SerializeNode(ctx);
			}
		}

		protected override void DeserializeExtraInfo(GraphSerializationContext ctx)
		{
			int num = ctx.reader.ReadInt32();
			if (num == -1)
			{
				nodes = null;
				return;
			}
			nodes = new PointNode[num];
			nodeCount = num;
			for (int i = 0; i < nodes.Length; i++)
			{
				if (ctx.reader.ReadInt32() != -1)
				{
					nodes[i] = new PointNode(active);
					nodes[i].DeserializeNode(ctx);
				}
			}
		}
	}
}
