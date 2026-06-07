using System;
using System.Collections.Generic;
using Pathfinding.Collections;
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

			public readonly Vector3 point1 => default(Vector3);

			public readonly Vector3 point2 => default(Vector3);

			public static bool operator ==(Anchor a, Anchor b)
			{
				return false;
			}

			public static bool operator !=(Anchor a, Anchor b)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
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

			public Component component => null;

			public GameObject gameObject => null;

			public OffMeshLinkTracer(OffMeshLinkConcrete link, bool reversed)
			{
				this.link = null;
				relativeStart = default(Vector3);
				relativeEnd = default(Vector3);
				isReverse = false;
			}

			public OffMeshLinkTracer(OffMeshLinkConcrete link, Vector3 relativeStart, Vector3 relativeEnd, bool isReverse)
			{
				this.link = null;
				this.relativeStart = default(Vector3);
				this.relativeEnd = default(Vector3);
				this.isReverse = false;
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

			public GameObject gameObject => null;

			public OffMeshLinkStatus status { get; internal set; }

			public Bounds bounds => default(Bounds);
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

			public IOffMeshLinkHandler handler => null;

			public Component component => null;

			public GameObject gameObject => null;

			public bool Equivalent(OffMeshLinkConcrete other)
			{
				return false;
			}

			public void Disconnect()
			{
			}

			public void Connect(LinkGraph linkGraph, OffMeshLinkSource source)
			{
			}

			public OffMeshLinkTracer GetTracer(LinkNode firstNode)
			{
				return default(OffMeshLinkTracer);
			}
		}

		private AABBTree<OffMeshLinkCombined> tree;

		private List<OffMeshLinkSource> pendingAdd;

		private bool updateScheduled;

		private AstarPath astar;

		public OffMeshLinks(AstarPath astar)
		{
		}

		public List<NavGraph> ConnectedGraphs(OffMeshLinkSource link)
		{
			return null;
		}

		public void Add(OffMeshLinkSource link)
		{
		}

		internal void OnDisable()
		{
		}

		public void Remove(OffMeshLinkSource link)
		{
		}

		private bool ClampSegment(Anchor anchor, GraphMask graphMask, float maxSnappingDistance, out Anchor result, List<GraphNode> nodes)
		{
			result = default(Anchor);
			return false;
		}

		public void DirtyBounds(Bounds bounds)
		{
		}

		public void Dirty(OffMeshLinkSource link)
		{
		}

		internal void DirtyNoSchedule(OffMeshLinkSource link)
		{
		}

		private void ScheduleUpdate()
		{
		}

		public OffMeshLinkTracer GetNearest(Vector3 point, float maxDistance)
		{
			return default(OffMeshLinkTracer);
		}

		internal void Refresh()
		{
		}
	}
}
