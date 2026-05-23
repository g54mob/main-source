using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public abstract class GraphNode
	{
		public delegate void GetConnectionsWithData<T>(GraphNode node, ref T data);

		private int nodeIndex;

		protected uint flags;

		private const uint NodeIndexMask = 268435455u;

		public const uint DestroyedNodeIndex = 268435454u;

		public const int InvalidNodeIndex = 0;

		private const int TemporaryFlag1Mask = 268435456;

		private const int TemporaryFlag2Mask = 536870912;

		public Int3 position;

		private const int FlagsWalkableOffset = 0;

		private const uint FlagsWalkableMask = 1u;

		private const int FlagsHierarchicalIndexOffset = 1;

		private const uint HierarchicalIndexMask = 262142u;

		private const int HierarchicalDirtyOffset = 18;

		private const uint HierarchicalDirtyMask = 262144u;

		private const int FlagsGraphOffset = 24;

		private const uint FlagsGraphMask = 4278190080u;

		public const uint MaxHierarchicalNodeIndex = 131071u;

		public const uint MaxGraphIndex = 254u;

		public const uint InvalidGraphIndex = 255u;

		private const int FlagsTagOffset = 19;

		public const int MaxTagIndex = 31;

		private const uint FlagsTagMask = 16252928u;

		public NavGraph Graph => AstarData.GetGraph(this);

		public bool Destroyed => NodeIndex == 268435454;

		public uint NodeIndex
		{
			get
			{
				return (uint)(nodeIndex & 0xFFFFFFF);
			}
			internal set
			{
				nodeIndex = (nodeIndex & -268435456) | (int)value;
			}
		}

		internal virtual int PathNodeVariants => 1;

		internal bool TemporaryFlag1
		{
			get
			{
				return (nodeIndex & 0x10000000) != 0;
			}
			set
			{
				nodeIndex = (nodeIndex & -268435457) | (value ? 268435456 : 0);
			}
		}

		internal bool TemporaryFlag2
		{
			get
			{
				return (nodeIndex & 0x20000000) != 0;
			}
			set
			{
				nodeIndex = (nodeIndex & -536870913) | (value ? 536870912 : 0);
			}
		}

		public uint Flags
		{
			get
			{
				return flags;
			}
			set
			{
				flags = value;
			}
		}

		public uint Penalty
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public bool Walkable
		{
			get
			{
				return (flags & 1) != 0;
			}
			set
			{
				flags = (flags & 0xFFFFFFFEu) | (uint)(value ? 1 : 0);
				AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
			}
		}

		internal int HierarchicalNodeIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (int)((flags & 0x3FFFE) >> 1);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				flags = (flags & 0xFFFC0001u) | (uint)(value << 1);
			}
		}

		internal bool IsHierarchicalNodeDirty
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (flags & 0x40000) != 0;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				flags = (flags & 0xFFFBFFFFu) | (uint)((value ? 1 : 0) << 18);
			}
		}

		public uint Area => AstarPath.active.hierarchicalGraph.GetConnectedComponent(HierarchicalNodeIndex);

		public uint GraphIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (flags & 0xFF000000u) >> 24;
			}
			set
			{
				flags = (flags & 0xFFFFFF) | (value << 24);
			}
		}

		public uint Tag
		{
			get
			{
				return (flags & 0xF80000) >> 19;
			}
			set
			{
				flags = (flags & 0xFF07FFFFu) | ((value << 19) & 0xF80000);
			}
		}

		public void Destroy()
		{
			if (!Destroyed)
			{
				ClearConnections();
				if (AstarPath.active != null)
				{
					AstarPath.active.DestroyNode(this);
				}
				NodeIndex = 268435454u;
			}
		}

		public void SetConnectivityDirty()
		{
			AstarPath.active.hierarchicalGraph.AddDirtyNode(this);
		}

		public virtual void GetConnections(Action<GraphNode> action, int connectionFilter = 32)
		{
			GetConnections(delegate(GraphNode node, ref Action<GraphNode> reference)
			{
				reference(node);
			}, ref action, connectionFilter);
		}

		public abstract void GetConnections<T>(GetConnectionsWithData<T> action, ref T data, int connectionFilter = 32);

		public static void Connect(GraphNode lhs, GraphNode rhs, uint cost, OffMeshLinks.Directionality directionality = OffMeshLinks.Directionality.TwoWay)
		{
			lhs.AddPartialConnection(rhs, cost, isOutgoing: true, directionality == OffMeshLinks.Directionality.TwoWay);
			rhs.AddPartialConnection(lhs, cost, directionality == OffMeshLinks.Directionality.TwoWay, isIncoming: true);
		}

		public static void Disconnect(GraphNode lhs, GraphNode rhs)
		{
			lhs.RemovePartialConnection(rhs);
			rhs.RemovePartialConnection(lhs);
		}

		[Obsolete("Use the static Connect method instead, or AddPartialConnection if you really need to")]
		public void AddConnection(GraphNode node, uint cost)
		{
			AddPartialConnection(node, cost, isOutgoing: true, isIncoming: true);
		}

		[Obsolete("Use the static Disconnect method instead, or RemovePartialConnection if you really need to")]
		public void RemoveConnection(GraphNode node)
		{
			RemovePartialConnection(node);
		}

		public abstract void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming);

		public abstract void RemovePartialConnection(GraphNode node);

		public abstract void ClearConnections(bool alsoReverse = true);

		[Obsolete("Use ContainsOutgoingConnection instead")]
		public bool ContainsConnection(GraphNode node)
		{
			return ContainsOutgoingConnection(node);
		}

		public virtual bool ContainsOutgoingConnection(GraphNode node)
		{
			bool data = false;
			GetConnections(delegate(GraphNode neighbour, ref bool contains)
			{
				contains |= neighbour == node;
			}, ref data);
			return data;
		}

		[Obsolete("Use GetPortal(GraphNode, out Vector3, out Vector3) instead")]
		public bool GetPortal(GraphNode other, List<Vector3> left, List<Vector3> right, bool backwards)
		{
			if (!backwards && GetPortal(other, out var left2, out var right2))
			{
				if (left != null)
				{
					left.Add(left2);
					right.Add(right2);
				}
				return true;
			}
			return false;
		}

		public virtual bool GetPortal(GraphNode other, out Vector3 left, out Vector3 right)
		{
			left = Vector3.zero;
			right = Vector3.zero;
			return false;
		}

		public abstract void Open(Path path, uint pathNodeIndex, uint gScore);

		public abstract void OpenAtPoint(Path path, uint pathNodeIndex, Int3 position, uint gScore);

		public virtual Int3 DecodeVariantPosition(uint pathNodeIndex, uint fractionAlongEdge)
		{
			return position;
		}

		public virtual float SurfaceArea()
		{
			return 0f;
		}

		public virtual Vector3 RandomPointOnSurface()
		{
			return (Vector3)position;
		}

		public abstract Vector3 ClosestPointOnNode(Vector3 p);

		public virtual bool ContainsPoint(Int3 point)
		{
			return ContainsPoint((Vector3)point);
		}

		public abstract bool ContainsPoint(Vector3 point);

		public abstract bool ContainsPointInGraphSpace(Int3 point);

		public virtual int GetGizmoHashCode()
		{
			return (int)((uint)position.GetHashCode() ^ (19 * Penalty) ^ (41 * (flags & 0xFFF80001u)));
		}

		public virtual void SerializeNode(GraphSerializationContext ctx)
		{
			ctx.writer.Write(Penalty);
			ctx.writer.Write(Flags & 0xFFF80001u);
		}

		public virtual void DeserializeNode(GraphSerializationContext ctx)
		{
			Penalty = ctx.reader.ReadUInt32();
			Flags = (ctx.reader.ReadUInt32() & 0xFFF80001u) | (Flags & 0x7FFFE);
			GraphIndex = ctx.graphIndex;
		}

		public virtual void SerializeReferences(GraphSerializationContext ctx)
		{
		}

		public virtual void DeserializeReferences(GraphSerializationContext ctx)
		{
		}
	}
}
