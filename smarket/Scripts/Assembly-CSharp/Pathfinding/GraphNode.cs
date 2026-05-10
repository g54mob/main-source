using System;
using System.Collections.Generic;
using Pathfinding.Serialization;
using UnityEngine;

namespace Pathfinding
{
	public abstract class GraphNode
	{
		private int nodeIndex;

		protected uint flags;

		private uint penalty;

		private const int NodeIndexMask = 268435455;

		private const int DestroyedNodeIndex = 268435454;

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

		public const uint MaxGraphIndex = 255u;

		private const int FlagsTagOffset = 19;

		private const uint FlagsTagMask = 16252928u;

		public NavGraph Graph => null;

		public bool Destroyed => false;

		public int NodeIndex
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

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
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal int HierarchicalNodeIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		internal bool IsHierarchicalNodeDirty
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public uint Area => 0u;

		public uint GraphIndex
		{
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

		protected GraphNode(AstarPath astar)
		{
		}

		public void Destroy()
		{
		}

		public void SetConnectivityDirty()
		{
		}

		[Obsolete("This method is deprecated because it never did anything, you can safely remove any calls to this method")]
		public void RecalculateConnectionCosts()
		{
		}

		public virtual void UpdateRecursiveG(Path path, PathNode pathNode, PathHandler handler)
		{
		}

		public abstract void GetConnections(Action<GraphNode> action);

		public abstract void AddConnection(GraphNode node, uint cost);

		public abstract void RemoveConnection(GraphNode node);

		public abstract void ClearConnections(bool alsoReverse);

		public virtual bool ContainsConnection(GraphNode node)
		{
			return false;
		}

		public virtual bool GetPortal(GraphNode other, List<Vector3> left, List<Vector3> right, bool backwards)
		{
			return false;
		}

		public abstract void Open(Path path, PathNode pathNode, PathHandler handler);

		public virtual float SurfaceArea()
		{
			return 0f;
		}

		public virtual Vector3 RandomPointOnSurface()
		{
			return default(Vector3);
		}

		public abstract Vector3 ClosestPointOnNode(Vector3 p);

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
