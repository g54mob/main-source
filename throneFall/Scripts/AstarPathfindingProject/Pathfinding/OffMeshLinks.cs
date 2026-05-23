using System;
using System.Collections.Generic;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Util;
using Unity.Collections;
using UnityEngine;

namespace Pathfinding
{
	public class OffMeshLinks
	{
		public struct Anchor
		{
			public Vector3 center;

			public Quaternion rotation;

			public float width;

			public readonly Vector3 point1 => center + rotation * new Vector3(-0.5f * width, 0f, 0f);

			public readonly Vector3 point2 => center + rotation * new Vector3(0.5f * width, 0f, 0f);

			public static bool operator ==(Anchor a, Anchor b)
			{
				if (a.center == b.center && a.rotation == b.rotation)
				{
					return a.width == b.width;
				}
				return false;
			}

			public static bool operator !=(Anchor a, Anchor b)
			{
				if (!(a.center != b.center) && !(a.rotation != b.rotation))
				{
					return a.width != b.width;
				}
				return true;
			}

			public override bool Equals(object obj)
			{
				if (obj is Anchor)
				{
					return this == (Anchor)obj;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (((center.GetHashCode() * 23) ^ rotation.GetHashCode()) * 23) ^ width.GetHashCode();
			}
		}

		public enum Directionality
		{
			OneWay = 0,
			TwoWay = 1
		}

		[Flags]
		public enum OffMeshLinkStatus
		{
			Inactive = 1,
			Pending = 2,
			Active = 4,
			FailedToConnectStart = 9,
			FailedToConnectEnd = 0x11,
			PendingRemoval = 0x20
		}

		public readonly struct OffMeshLinkTracer
		{
			public readonly OffMeshLinkConcrete link;

			public readonly Vector3 relativeStart;

			public readonly Vector3 relativeEnd;

			public readonly bool isReverse;

			public Component component => link.component;

			public GameObject gameObject => link.gameObject;

			public OffMeshLinkTracer(OffMeshLinkConcrete link, bool reversed)
			{
				this.link = link;
				relativeStart = (reversed ? link.end.center : link.start.center);
				relativeEnd = (reversed ? link.start.center : link.end.center);
				isReverse = reversed;
			}

			public OffMeshLinkTracer(OffMeshLinkConcrete link, Vector3 relativeStart, Vector3 relativeEnd, bool isReverse)
			{
				this.link = link;
				this.relativeStart = relativeStart;
				this.relativeEnd = relativeEnd;
				this.isReverse = isReverse;
			}
		}

		public class OffMeshLinkSource
		{
			public Anchor start;

			public Anchor end;

			public Directionality directionality;

			public PathfindingTag tag;

			public float costFactor;

			public float maxSnappingDistance;

			public GraphMask graphMask;

			public IOffMeshLinkHandler handler;

			public Component component;

			internal AABBTree<OffMeshLinkCombined>.Key treeKey;

			public GameObject gameObject
			{
				get
				{
					if (!(component != null))
					{
						return null;
					}
					return component.gameObject;
				}
			}

			public OffMeshLinkStatus status { get; internal set; } = OffMeshLinkStatus.Inactive;

			public Bounds bounds
			{
				get
				{
					Bounds result = default(Bounds);
					result.SetMinMax(start.point1, start.point2);
					result.Encapsulate(end.point1);
					result.Encapsulate(end.point2);
					result.Expand(maxSnappingDistance * 2f);
					return result;
				}
			}
		}

		internal class OffMeshLinkCombined
		{
			public OffMeshLinkSource source;

			public OffMeshLinkConcrete concrete;
		}

		public class OffMeshLinkConcrete
		{
			public Anchor start;

			public Anchor end;

			public GraphNode[] startNodes;

			public GraphNode[] endNodes;

			public LinkNode startLinkNode;

			public LinkNode endLinkNode;

			public Directionality directionality;

			public PathfindingTag tag;

			public float costFactor;

			internal bool staleConnections;

			internal OffMeshLinkSource source;

			public IOffMeshLinkHandler handler => source.handler;

			public Component component => source.component;

			public GameObject gameObject
			{
				get
				{
					if (!(source.component != null))
					{
						return null;
					}
					return source.component.gameObject;
				}
			}

			public bool Equivalent(OffMeshLinkConcrete other)
			{
				if (start != other.start)
				{
					return false;
				}
				if (end != other.end)
				{
					return false;
				}
				if (startNodes.Length != other.startNodes.Length || endNodes.Length != other.endNodes.Length)
				{
					return false;
				}
				if (directionality != other.directionality || (uint)tag != (uint)other.tag || costFactor != other.costFactor)
				{
					return false;
				}
				for (int i = 0; i < startNodes.Length; i++)
				{
					if (startNodes[i] != other.startNodes[i])
					{
						return false;
					}
				}
				for (int j = 0; j < endNodes.Length; j++)
				{
					if (endNodes[j] != other.endNodes[j])
					{
						return false;
					}
				}
				return true;
			}

			public void Disconnect()
			{
				if (startLinkNode != null && !startLinkNode.Destroyed)
				{
					LinkGraph obj = startLinkNode.Graph as LinkGraph;
					obj.RemoveNode(startLinkNode);
					obj.RemoveNode(endLinkNode);
				}
				startLinkNode = null;
				endLinkNode = null;
			}

			public void Connect(LinkGraph linkGraph, OffMeshLinkSource source)
			{
				startLinkNode = linkGraph.AddNode();
				startLinkNode.linkSource = source;
				startLinkNode.linkConcrete = this;
				startLinkNode.position = (Int3)start.center;
				startLinkNode.Tag = tag;
				endLinkNode = linkGraph.AddNode();
				endLinkNode.position = (Int3)end.center;
				endLinkNode.linkSource = source;
				endLinkNode.linkConcrete = this;
				endLinkNode.Tag = tag;
				for (int i = 0; i < startNodes.Length; i++)
				{
					float magnitude = (VectorMath.ClosestPointOnSegment(start.point1, start.point2, (Vector3)startNodes[i].position) - (Vector3)startNodes[i].position).magnitude;
					uint cost = (uint)(1000f * magnitude);
					GraphNode.Connect(startNodes[i], startLinkNode, cost, directionality);
				}
				for (int j = 0; j < endNodes.Length; j++)
				{
					float magnitude2 = (VectorMath.ClosestPointOnSegment(end.point1, end.point2, (Vector3)endNodes[j].position) - (Vector3)endNodes[j].position).magnitude;
					uint cost2 = (uint)(1000f * magnitude2);
					GraphNode.Connect(endLinkNode, endNodes[j], cost2, directionality);
				}
				uint cost3 = (uint)(1000f * costFactor * (end.center - start.center).magnitude);
				GraphNode.Connect(startLinkNode, endLinkNode, cost3, directionality);
				staleConnections = false;
			}

			public OffMeshLinkTracer GetTracer(LinkNode firstNode)
			{
				return new OffMeshLinkTracer(this, firstNode == endLinkNode);
			}
		}

		private AABBTree<OffMeshLinkCombined> tree = new AABBTree<OffMeshLinkCombined>();

		private List<OffMeshLinkSource> pendingAdd = new List<OffMeshLinkSource>();

		private bool updateScheduled;

		private AstarPath astar;

		private NNConstraint cachedNNConstraint = NNConstraint.Walkable;

		public OffMeshLinks(AstarPath astar)
		{
			this.astar = astar;
		}

		public List<NavGraph> ConnectedGraphs(OffMeshLinkSource link)
		{
			List<NavGraph> list = ListPool<NavGraph>.Claim();
			if (link.status != OffMeshLinkStatus.Active)
			{
				return list;
			}
			OffMeshLinkConcrete concrete = tree[link.treeKey].concrete;
			for (int i = 0; i < concrete.startNodes.Length; i++)
			{
				NavGraph graph = concrete.startNodes[i].Graph;
				if (!list.Contains(graph))
				{
					list.Add(graph);
				}
			}
			for (int j = 0; j < concrete.endNodes.Length; j++)
			{
				NavGraph graph2 = concrete.endNodes[j].Graph;
				if (!list.Contains(graph2))
				{
					list.Add(graph2);
				}
			}
			return list;
		}

		public void Add(OffMeshLinkSource link)
		{
			if (link == null)
			{
				throw new ArgumentNullException("link");
			}
			if (link.status != OffMeshLinkStatus.Inactive)
			{
				throw new ArgumentException("Link is already added");
			}
			pendingAdd.Add(link);
			link.status = OffMeshLinkStatus.Pending;
			ScheduleUpdate();
		}

		internal void OnDisable()
		{
			List<OffMeshLinkCombined> list = new List<OffMeshLinkCombined>();
			tree.Query(new Bounds(Vector3.zero, Vector3.positiveInfinity), list);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].source.status = OffMeshLinkStatus.Inactive;
				list[i].source.treeKey = default(AABBTree<OffMeshLinkCombined>.Key);
			}
			tree.Clear();
			for (int j = 0; j < pendingAdd.Count; j++)
			{
				pendingAdd[j].status = OffMeshLinkStatus.Inactive;
				pendingAdd[j].treeKey = default(AABBTree<OffMeshLinkCombined>.Key);
			}
			pendingAdd.Clear();
		}

		public void Remove(OffMeshLinkSource link)
		{
			if (link == null)
			{
				throw new ArgumentNullException("link");
			}
			if (link.status != OffMeshLinkStatus.Inactive && (link.status & OffMeshLinkStatus.PendingRemoval) == 0)
			{
				if (link.status == OffMeshLinkStatus.Pending)
				{
					link.status = OffMeshLinkStatus.Inactive;
					pendingAdd.Remove(link);
				}
				else
				{
					link.status |= OffMeshLinkStatus.Pending | OffMeshLinkStatus.PendingRemoval;
					tree.Tag(link.treeKey);
				}
				ScheduleUpdate();
			}
		}

		private bool ClampSegment(Anchor anchor, GraphMask graphMask, float maxSnappingDistance, out Anchor result, List<GraphNode> nodes)
		{
			NNConstraint nNConstraint = cachedNNConstraint;
			nNConstraint.distanceMetric = DistanceMetric.Euclidean;
			nNConstraint.graphMask = graphMask;
			NNInfo nNInfo = astar.GetNearest(0.5f * (anchor.point1 + anchor.point2), nNConstraint);
			if (nNInfo.distanceCostSqr > maxSnappingDistance * maxSnappingDistance)
			{
				nNInfo = default(NNInfo);
			}
			if (nNInfo.node == null)
			{
				result = default(Anchor);
				return false;
			}
			if (anchor.width > 0f && nNInfo.node.Graph is IRaycastableGraph raycastableGraph)
			{
				Vector3 vector = 0.5f * (anchor.point2 - anchor.point1);
				raycastableGraph.Linecast(nNInfo.position, nNInfo.position - vector, nNInfo.node, out var hit, nodes);
				raycastableGraph.Linecast(nNInfo.position, nNInfo.position + vector, nNInfo.node, out var hit2, nodes);
				result = new Anchor
				{
					center = (hit.point + hit2.point) * 0.5f,
					rotation = anchor.rotation,
					width = (hit.point - hit2.point).magnitude
				};
				nodes.Sort((GraphNode a, GraphNode b) => a.NodeIndex.CompareTo(b.NodeIndex));
				for (int num = nodes.Count - 1; num >= 0; num--)
				{
					GraphNode graphNode = nodes[num];
					for (int num2 = num - 1; num2 >= 0; num2--)
					{
						if (nodes[num2] == graphNode)
						{
							nodes.RemoveAtSwapBack(num);
							break;
						}
					}
				}
			}
			else
			{
				result = new Anchor
				{
					center = nNInfo.position,
					rotation = anchor.rotation,
					width = 0f
				};
				nodes.Add(nNInfo.node);
			}
			return true;
		}

		public void DirtyBounds(Bounds bounds)
		{
			tree.Tag(bounds);
		}

		public void Dirty(OffMeshLinkSource link)
		{
			DirtyNoSchedule(link);
			ScheduleUpdate();
		}

		internal void DirtyNoSchedule(OffMeshLinkSource link)
		{
			tree.Tag(link.treeKey);
		}

		private void ScheduleUpdate()
		{
			if (!updateScheduled && !astar.isScanning && !astar.IsAnyWorkItemInProgress)
			{
				updateScheduled = true;
				astar.AddWorkItem((Action)delegate
				{
				});
			}
		}

		public OffMeshLinkTracer GetNearest(Vector3 point, float maxDistance)
		{
			if (maxDistance < 0f)
			{
				return default(OffMeshLinkTracer);
			}
			if (!float.IsFinite(maxDistance))
			{
				throw new ArgumentOutOfRangeException("maxDistance");
			}
			List<OffMeshLinkCombined> list = ListPool<OffMeshLinkCombined>.Claim();
			tree.Query(new Bounds(point, new Vector3(2f * maxDistance, 2f * maxDistance, 2f * maxDistance)), list);
			OffMeshLinkConcrete offMeshLinkConcrete = null;
			bool reversed = false;
			float num = maxDistance * maxDistance;
			for (int i = 0; i < list.Count; i++)
			{
				OffMeshLinkConcrete concrete = list[i].concrete;
				float num2 = VectorMath.SqrDistancePointSegment(concrete.start.point1, concrete.start.point2, point);
				if (num2 < num)
				{
					num = num2;
					offMeshLinkConcrete = concrete;
					reversed = false;
				}
				num2 = VectorMath.SqrDistancePointSegment(concrete.end.point1, concrete.end.point2, point);
				if (num2 < num)
				{
					num = num2;
					offMeshLinkConcrete = concrete;
					reversed = true;
				}
			}
			ListPool<OffMeshLinkCombined>.Release(ref list);
			if (offMeshLinkConcrete == null)
			{
				return default(OffMeshLinkTracer);
			}
			return new OffMeshLinkTracer(offMeshLinkConcrete, reversed);
		}

		internal void Refresh()
		{
			updateScheduled = false;
			List<OffMeshLinkCombined> list = ListPool<OffMeshLinkCombined>.Claim();
			tree.QueryTagged(list, clearTags: true);
			for (int i = 0; i < pendingAdd.Count; i++)
			{
				OffMeshLinkSource offMeshLinkSource = pendingAdd[i];
				OffMeshLinkCombined offMeshLinkCombined = new OffMeshLinkCombined
				{
					source = offMeshLinkSource,
					concrete = null
				};
				offMeshLinkSource.treeKey = tree.Add(offMeshLinkSource.bounds, offMeshLinkCombined);
				list.Add(offMeshLinkCombined);
			}
			pendingAdd.Clear();
			List<GraphNode> list2 = ListPool<GraphNode>.Claim();
			List<GraphNode> list3 = ListPool<GraphNode>.Claim();
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = 0; k < j; k++)
				{
					if (list[j].source == list[k].source)
					{
						throw new Exception("Duplicate link");
					}
				}
				OffMeshLinkSource source = list[j].source;
				OffMeshLinkCombined offMeshLinkCombined2 = tree[source.treeKey];
				OffMeshLinkConcrete concrete = offMeshLinkCombined2.concrete;
				if ((source.status & OffMeshLinkStatus.PendingRemoval) != 0)
				{
					if (concrete != null)
					{
						concrete.Disconnect();
						offMeshLinkCombined2.concrete = null;
					}
					tree.Remove(source.treeKey);
					source.treeKey = default(AABBTree<OffMeshLinkCombined>.Key);
					source.status = OffMeshLinkStatus.Inactive;
					continue;
				}
				list2.Clear();
				if (!ClampSegment(source.start, source.graphMask, source.maxSnappingDistance, out var result, list2))
				{
					if (concrete != null)
					{
						concrete.Disconnect();
						offMeshLinkCombined2.concrete = null;
					}
					source.status = OffMeshLinkStatus.FailedToConnectStart;
					continue;
				}
				list3.Clear();
				if (!ClampSegment(source.end, source.graphMask, source.maxSnappingDistance, out var result2, list3))
				{
					if (concrete != null)
					{
						concrete.Disconnect();
						offMeshLinkCombined2.concrete = null;
					}
					source.status = OffMeshLinkStatus.FailedToConnectEnd;
					continue;
				}
				OffMeshLinkConcrete offMeshLinkConcrete = new OffMeshLinkConcrete
				{
					start = result,
					end = result2,
					startNodes = list2.ToArrayFromPool(),
					endNodes = list3.ToArrayFromPool(),
					source = source,
					directionality = source.directionality,
					tag = source.tag,
					costFactor = source.costFactor
				};
				if (concrete != null && !concrete.staleConnections && concrete.Equivalent(offMeshLinkConcrete))
				{
					source.status &= ~OffMeshLinkStatus.Pending;
					continue;
				}
				if (concrete != null)
				{
					concrete.Disconnect();
					ArrayPool<GraphNode>.Release(ref concrete.startNodes);
					ArrayPool<GraphNode>.Release(ref concrete.endNodes);
				}
				if (astar.data.linkGraph == null)
				{
					astar.data.AddGraph<LinkGraph>();
				}
				offMeshLinkConcrete.Connect(astar.data.linkGraph, source);
				offMeshLinkCombined2.concrete = offMeshLinkConcrete;
				source.status = OffMeshLinkStatus.Active;
			}
			ListPool<OffMeshLinkCombined>.Release(ref list);
			ListPool<GraphNode>.Release(ref list2);
			ListPool<GraphNode>.Release(ref list3);
		}
	}
}
