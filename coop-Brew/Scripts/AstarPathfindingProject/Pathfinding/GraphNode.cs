using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Serialization;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	public abstract class GraphNode
	{
		public delegate void GetConnectionsWithData<T>(GraphNode node, ref T data);

		private int nodeIndex;

		protected uint flags;

		private uint penalty;

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

		public NavGraph Graph => null;

		public bool Destroyed
		{
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
		}

		public uint NodeIndex
		{
			[IgnoredByDeepProfiler]
			get
			{
				return 0u;
			}
			[IgnoredByDeepProfiler]
			internal set
			{
			}
		}

		internal virtual int PathNodeVariants => 0;

		internal bool TemporaryFlag1
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal bool TemporaryFlag2
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public uint Flags
		{
			get
			{
				return 0u;
			}
			set
			{
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
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		internal int HierarchicalNodeIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			get
			{
				return 0;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		internal bool IsHierarchicalNodeDirty
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			get
			{
				return false;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			set
			{
			}
		}

		public uint Area => 0u;

		public uint GraphIndex
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[IgnoredByDeepProfiler]
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint Tag
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public void Destroy()
		{
		}

		public void SetConnectivityDirty()
		{
		}

		public virtual void GetConnections(Action<GraphNode> action, int connectionFilter = 32)
		{
		}

		public abstract void GetConnections<T>(GetConnectionsWithData<T> action, ref T data, int connectionFilter = 32);

		public static void Connect(GraphNode lhs, GraphNode rhs, uint cost, OffMeshLinks.Directionality directionality = OffMeshLinks.Directionality.TwoWay)
		{
		}

		public static void Disconnect(GraphNode lhs, GraphNode rhs)
		{
		}

		[Obsolete("Use the static Connect method instead, or AddPartialConnection if you really need to")]
		public void AddConnection(GraphNode node, uint cost)
		{
		}

		[Obsolete("Use the static Disconnect method instead, or RemovePartialConnection if you really need to")]
		public void RemoveConnection(GraphNode node)
		{
		}

		public abstract void AddPartialConnection(GraphNode node, uint cost, bool isOutgoing, bool isIncoming);

		public abstract void RemovePartialConnection(GraphNode node);

		public abstract void ClearConnections(bool alsoReverse = true);

		[Obsolete("Use ContainsOutgoingConnection instead")]
		public bool ContainsConnection(GraphNode node)
		{
			return false;
		}

		public virtual bool ContainsOutgoingConnection(GraphNode node)
		{
			return false;
		}

		[Obsolete("Use GetPortal(GraphNode, out Vector3, out Vector3) instead")]
		public bool GetPortal(GraphNode other, List<Vector3> left, List<Vector3> right, bool backwards)
		{
			return false;
		}

		public virtual bool GetPortal(GraphNode other, out Vector3 left, out Vector3 right)
		{
			left = default(Vector3);
			right = default(Vector3);
			return false;
		}

		public abstract void Open(Path path, uint pathNodeIndex, uint gScore);

		public abstract void OpenAtPoint(Path path, uint pathNodeIndex, Int3 position, uint gScore);

		public virtual Int3 DecodeVariantPosition(uint pathNodeIndex, uint fractionAlongEdge)
		{
			return default(Int3);
		}

		public virtual float SurfaceArea()
		{
			return 0f;
		}

		public virtual Vector3 RandomPointOnSurface()
		{
			return default(Vector3);
		}

		public abstract Vector3 ClosestPointOnNode(Vector3 p);

		public virtual bool ContainsPoint(Int3 point)
		{
			return false;
		}

		public abstract bool ContainsPoint(Vector3 point);

		public abstract bool ContainsPointInGraphSpace(Int3 point);

		public virtual int GetGizmoHashCode()
		{
			return 0;
		}

		public virtual void SerializeNode(GraphSerializationContext ctx)
		{
		}

		public virtual void DeserializeNode(GraphSerializationContext ctx)
		{
		}

		public virtual void SerializeReferences(GraphSerializationContext ctx)
		{
		}

		public virtual void DeserializeReferences(GraphSerializationContext ctx)
		{
		}
	}
}
