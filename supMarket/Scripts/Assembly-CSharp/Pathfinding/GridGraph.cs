using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[JsonOptIn]
	[Preserve]
	public class GridGraph : NavGraph, IUpdatableGraph, ITransformedGraph
	{
		[CompilerGenerated]
		private sealed class _003CScanInternal_003Ed__88 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Progress _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public GridGraph _003C_003E4__this;

			private int _003CprogressCounter_003E5__2;

			private int _003Cz_003E5__3;

			Progress IEnumerator<Progress>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(Progress);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CScanInternal_003Ed__88(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Progress> IEnumerable<Progress>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[JsonMember]
		public InspectorGridMode inspectorGridMode;

		[JsonMember]
		public InspectorGridHexagonNodeSize inspectorHexagonSizeMode;

		public int width;

		public int depth;

		[JsonMember]
		public float aspectRatio;

		[JsonMember]
		public float isometricAngle;

		public static readonly float StandardIsometricAngle;

		public static readonly float StandardDimetricAngle;

		[JsonMember]
		public bool uniformEdgeCosts;

		[JsonMember]
		public Vector3 rotation;

		[JsonMember]
		public Vector3 center;

		[JsonMember]
		public Vector2 unclampedSize;

		[JsonMember]
		public float nodeSize;

		[JsonMember]
		public GraphCollision collision;

		[JsonMember]
		public float maxClimb;

		[JsonMember]
		public float maxSlope;

		[JsonMember]
		public int erodeIterations;

		[JsonMember]
		public bool erosionUseTags;

		[JsonMember]
		public int erosionFirstTag;

		[JsonMember]
		public NumNeighbours neighbours;

		[JsonMember]
		public bool cutCorners;

		[JsonMember]
		public float penaltyPositionOffset;

		[JsonMember]
		public bool penaltyPosition;

		[JsonMember]
		public float penaltyPositionFactor;

		[JsonMember]
		public bool penaltyAngle;

		[JsonMember]
		public float penaltyAngleFactor;

		[JsonMember]
		public float penaltyAnglePower;

		[JsonMember]
		public bool showMeshOutline;

		[JsonMember]
		public bool showNodeConnections;

		[JsonMember]
		public bool showMeshSurface;

		[NonSerialized]
		public readonly int[] neighbourOffsets;

		[NonSerialized]
		public readonly uint[] neighbourCosts;

		[NonSerialized]
		public readonly int[] neighbourXOffsets;

		[NonSerialized]
		public readonly int[] neighbourZOffsets;

		internal static readonly int[] hexagonNeighbourIndices;

		public const int getNearestForceOverlap = 2;

		public GridNode[] nodes;

		public virtual bool uniformWidthDepthGrid => false;

		public virtual int LayerCount => 0;

		protected bool useRaycastNormal => false;

		public Vector2 size { get; protected set; }

		public GraphTransform transform { get; private set; }

		public bool is2D
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int Width
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Depth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void OnDestroy()
		{
		}

		protected override void DestroyAllNodes()
		{
		}

		private void RemoveGridGraphFromStatic()
		{
		}

		public override int CountNodes()
		{
			return 0;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
		}

		public override void RelocateNodes(Matrix4x4 deltaMatrix)
		{
		}

		public void RelocateNodes(Vector3 center, Quaternion rotation, float nodeSize, float aspectRatio = 1f, float isometricAngle = 0f)
		{
		}

		public Int3 GraphPointToWorld(int x, int z, float height)
		{
			return default(Int3);
		}

		public static float ConvertHexagonSizeToNodeSize(InspectorGridHexagonNodeSize mode, float value)
		{
			return 0f;
		}

		public static float ConvertNodeSizeToHexagonSize(InspectorGridHexagonNodeSize mode, float value)
		{
			return 0f;
		}

		public uint GetConnectionCost(int dir)
		{
			return 0u;
		}

		public GridNode GetNodeConnection(GridNode node, int dir)
		{
			return null;
		}

		public bool HasNodeConnection(GridNode node, int dir)
		{
			return false;
		}

		public void SetNodeConnection(GridNode node, int dir, bool value)
		{
		}

		private GridNode GetNodeConnection(int index, int x, int z, int dir)
		{
			return null;
		}

		public void SetNodeConnection(int index, int x, int z, int dir, bool value)
		{
		}

		public bool HasNodeConnection(int index, int x, int z, int dir)
		{
			return false;
		}

		public void SetGridShape(InspectorGridMode shape)
		{
		}

		public void SetDimensions(int width, int depth, float nodeSize)
		{
		}

		[Obsolete("Use SetDimensions instead")]
		public void UpdateSizeFromWidthDepth()
		{
		}

		[Obsolete("This method has been renamed to UpdateTransform")]
		public void GenerateMatrix()
		{
		}

		public void UpdateTransform()
		{
		}

		public GraphTransform CalculateTransform()
		{
			return null;
		}

		private void CalculateDimensions(out int width, out int depth, out float nodeSize)
		{
			width = default(int);
			depth = default(int);
			nodeSize = default(float);
		}

		public override NNInfoInternal GetNearest(Vector3 position, NNConstraint constraint, GraphNode hint)
		{
			return default(NNInfoInternal);
		}

		public override NNInfoInternal GetNearestForce(Vector3 position, NNConstraint constraint)
		{
			return default(NNInfoInternal);
		}

		public virtual void SetUpOffsetsAndCosts()
		{
		}

		[IteratorStateMachine(typeof(_003CScanInternal_003Ed__88))]
		protected override IEnumerable<Progress> ScanInternal()
		{
			return null;
		}

		[Obsolete("Use RecalculateCell instead which works both for grid graphs and layered grid graphs")]
		public virtual void UpdateNodePositionCollision(GridNode node, int x, int z, bool resetPenalty = true)
		{
		}

		public virtual void RecalculateCell(int x, int z, bool resetPenalties = true, bool resetTags = true)
		{
		}

		protected virtual bool ErosionAnyFalseConnections(GraphNode baseNode)
		{
			return false;
		}

		private void ErodeNode(GraphNode node)
		{
		}

		private void ErodeNodeWithTagsInit(GraphNode node)
		{
		}

		private void ErodeNodeWithTags(GraphNode node, int iteration)
		{
		}

		public virtual void ErodeWalkableArea()
		{
		}

		public void ErodeWalkableArea(int xmin, int zmin, int xmax, int zmax)
		{
		}

		public virtual bool IsValidConnection(GridNodeBase node1, GridNodeBase node2)
		{
			return false;
		}

		public void CalculateConnectionsForCellAndNeighbours(int x, int z)
		{
		}

		[Obsolete("Use the instance function instead")]
		public static void CalculateConnections(GridNode node)
		{
		}

		public virtual void CalculateConnections(GridNodeBase node)
		{
		}

		[Obsolete("Use CalculateConnections(x,z) or CalculateConnections(node) instead")]
		public virtual void CalculateConnections(int x, int z, GridNode node)
		{
		}

		public virtual void CalculateConnections(int x, int z)
		{
		}

		public override void OnDrawGizmos(RetainedGizmos gizmos, bool drawNodes)
		{
		}

		private void CreateNavmeshSurfaceVisualization(GridNodeBase[] nodes, int nodeCount, GraphGizmoHelper helper)
		{
		}

		public IntRect GetRectFromBounds(Bounds bounds)
		{
			return default(IntRect);
		}

		[Obsolete("This method has been renamed to GetNodesInRegion", true)]
		public List<GraphNode> GetNodesInArea(Bounds bounds)
		{
			return null;
		}

		[Obsolete("This method has been renamed to GetNodesInRegion", true)]
		public List<GraphNode> GetNodesInArea(GraphUpdateShape shape)
		{
			return null;
		}

		[Obsolete("This method has been renamed to GetNodesInRegion", true)]
		public List<GraphNode> GetNodesInArea(Bounds bounds, GraphUpdateShape shape)
		{
			return null;
		}

		public List<GraphNode> GetNodesInRegion(Bounds bounds)
		{
			return null;
		}

		public List<GraphNode> GetNodesInRegion(GraphUpdateShape shape)
		{
			return null;
		}

		protected virtual List<GraphNode> GetNodesInRegion(Bounds bounds, GraphUpdateShape shape)
		{
			return null;
		}

		public virtual List<GraphNode> GetNodesInRegion(IntRect rect)
		{
			return null;
		}

		public virtual int GetNodesInRegion(IntRect rect, GridNodeBase[] buffer)
		{
			return 0;
		}

		public virtual GridNodeBase GetNode(int x, int z)
		{
			return null;
		}

		GraphUpdateThreading IUpdatableGraph.CanUpdateAsync(GraphUpdateObject o)
		{
			return default(GraphUpdateThreading);
		}

		void IUpdatableGraph.UpdateAreaInit(GraphUpdateObject o)
		{
		}

		void IUpdatableGraph.UpdateAreaPost(GraphUpdateObject o)
		{
		}

		protected void CalculateAffectedRegions(GraphUpdateObject o, out IntRect originalRect, out IntRect affectRect, out IntRect physicsRect, out bool willChangeWalkability, out int erosion)
		{
			originalRect = default(IntRect);
			affectRect = default(IntRect);
			physicsRect = default(IntRect);
			willChangeWalkability = default(bool);
			erosion = default(int);
		}

		void IUpdatableGraph.UpdateArea(GraphUpdateObject o)
		{
		}

		public bool CheckConnection(GridNode node, int dir)
		{
			return false;
		}

		protected override void SerializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected override void DeserializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected override void DeserializeSettingsCompatibility(GraphSerializationContext ctx)
		{
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
		}
	}
}
