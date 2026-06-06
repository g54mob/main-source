using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Drawing;
using Pathfinding.Graphs.Grid;
using Pathfinding.Graphs.Grid.Rules;
using Pathfinding.Jobs;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	[JsonOptIn]
	[Preserve]
	public class GridGraph : NavGraph, IUpdatableGraph, ITransformedGraph, IRaycastableGraph
	{
		public class TextureData
		{
			public enum ChannelUse
			{
				None = 0,
				Penalty = 1,
				Position = 2,
				WalkablePenalty = 3
			}

			public bool enabled;

			public Texture2D source;

			public float[] factors;

			public ChannelUse[] channels;

			private Color32[] data;

			public void Initialize()
			{
			}

			public void Apply(GridNode node, int x, int z)
			{
			}

			private void ApplyChannel(GridNode node, int x, int z, int value, ChannelUse channelUse, float factor)
			{
			}
		}

		public enum RecalculationMode
		{
			RecalculateFromScratch = 0,
			RecalculateMinimal = 1,
			NoRecalculation = 2
		}

		private class GridGraphMovePromise : IGraphUpdatePromise
		{
			[CompilerGenerated]
			private sealed class _003CPrepare_003Ed__8 : IEnumerator<JobHandle>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private JobHandle _003C_003E2__current;

				public GridGraphMovePromise _003C_003E4__this;

				private int _003Ci_003E5__2;

				private IEnumerator<JobHandle> _003Cit_003E5__3;

				JobHandle IEnumerator<JobHandle>.Current
				{
					[DebuggerHidden]
					get
					{
						return default(JobHandle);
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
				public _003CPrepare_003Ed__8(int _003C_003E1__state)
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
			}

			public GridGraph graph;

			public int dx;

			public int dz;

			private IGraphUpdatePromise[] promises;

			private IntRect[] rects;

			private int3 startingSize;

			private static void DecomposeInsetsToRectangles(int width, int height, int insetLeft, int insetRight, int insetBottom, int insetTop, IntRect[] output)
			{
			}

			public GridGraphMovePromise(GridGraph graph, int dx, int dz)
			{
			}

			[IteratorStateMachine(typeof(_003CPrepare_003Ed__8))]
			public IEnumerator<JobHandle> Prepare()
			{
				return null;
			}

			public void Apply(IGraphUpdateContext ctx)
			{
			}
		}

		private class GridGraphUpdatePromise : IGraphUpdatePromise
		{
			public class NodesHolder
			{
				public GridNodeBase[] nodes;
			}

			[CompilerGenerated]
			private sealed class _003CPrepare_003Ed__22 : IEnumerator<JobHandle>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private JobHandle _003C_003E2__current;

				public GridGraphUpdatePromise _003C_003E4__this;

				private GraphCollision _003Ccollision_003E5__2;

				private GridGraphRules _003Crules_003E5__3;

				private int _003CminLayers_003E5__4;

				private bool _003ClayeredDataLayout_003E5__5;

				private float _003CcharacterHeight_003E5__6;

				private NativeArray<int> _003ClayerCount_003E5__7;

				private IEnumerator<JobHandle> _003Cwait_003E5__8;

				JobHandle IEnumerator<JobHandle>.Current
				{
					[DebuggerHidden]
					get
					{
						return default(JobHandle);
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
				public _003CPrepare_003Ed__22(int _003C_003E1__state)
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
			}

			public GridGraph graph;

			public NodesHolder nodes;

			public JobDependencyTracker dependencyTracker;

			public int3 nodeArrayBounds;

			public IntRect rect;

			public JobHandle nodesDependsOn;

			public Allocator allocationMethod;

			public RecalculationMode recalculationMode;

			public GraphUpdateObject graphUpdateObject;

			private IntBounds writeMaskBounds;

			internal GridGraphRules.Context context;

			private bool emptyUpdate;

			private IntBounds readBounds;

			private IntBounds fullRecalculationBounds;

			public bool ownsJobDependencyTracker;

			private bool isFinalUpdate;

			private GraphTransform transform;

			public int CostEstimate => 0;

			public GridGraphUpdatePromise(GridGraph graph, GraphTransform transform, NodesHolder nodes, int3 nodeArrayBounds, IntRect rect, JobDependencyTracker dependencyTracker, JobHandle nodesDependsOn, Allocator allocationMethod, RecalculationMode recalculationMode, GraphUpdateObject graphUpdateObject, bool ownsJobDependencyTracker, bool isFinalUpdate)
			{
			}

			public static void CalculateRectangles(GridGraph graph, IntRect rect, out IntRect originalRect, out IntRect fullRecalculationRect, out IntRect writeMaskRect, out IntRect readRect)
			{
				originalRect = default(IntRect);
				fullRecalculationRect = default(IntRect);
				writeMaskRect = default(IntRect);
				readRect = default(IntRect);
			}

			[IteratorStateMachine(typeof(_003CPrepare_003Ed__22))]
			public IEnumerator<JobHandle> Prepare()
			{
				return null;
			}

			public void Apply(IGraphUpdateContext ctx)
			{
			}

			public void Dispose()
			{
			}
		}

		private class CombinedGridGraphUpdatePromise : IGraphUpdatePromise
		{
			[CompilerGenerated]
			private sealed class _003CPrepare_003Ed__2 : IEnumerator<JobHandle>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private JobHandle _003C_003E2__current;

				public CombinedGridGraphUpdatePromise _003C_003E4__this;

				private int _003Ci_003E5__2;

				private IEnumerator<JobHandle> _003Cit_003E5__3;

				JobHandle IEnumerator<JobHandle>.Current
				{
					[DebuggerHidden]
					get
					{
						return default(JobHandle);
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
				public _003CPrepare_003Ed__2(int _003C_003E1__state)
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
			}

			private List<IGraphUpdatePromise> promises;

			public CombinedGridGraphUpdatePromise(GridGraph graph, List<GraphUpdateObject> graphUpdates)
			{
			}

			[IteratorStateMachine(typeof(_003CPrepare_003Ed__2))]
			public IEnumerator<JobHandle> Prepare()
			{
				return null;
			}

			public void Apply(IGraphUpdateContext ctx)
			{
			}
		}

		private class GridGraphSnapshot : IGraphSnapshot, IDisposable
		{
			internal GridGraphNodeData nodes;

			internal GridGraph graph;

			public void Dispose()
			{
			}

			public void Restore(IGraphUpdateContext ctx)
			{
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
		public float maxStepHeight;

		[JsonMember]
		public bool maxStepUsesSlope;

		[JsonMember]
		public float maxSlope;

		[JsonMember]
		public int erodeIterations;

		[JsonMember]
		public bool erosionUseTags;

		[JsonMember]
		public int erosionFirstTag;

		[JsonMember]
		public int erosionTagsPrecedenceMask;

		[JsonMember]
		public NumNeighbours neighbours;

		[JsonMember]
		public bool cutCorners;

		[JsonMember]
		[Obsolete("Use the RuleElevationPenalty class instead")]
		public float penaltyPositionOffset;

		[JsonMember]
		[Obsolete("Use the RuleElevationPenalty class instead")]
		public bool penaltyPosition;

		[JsonMember]
		[Obsolete("Use the RuleElevationPenalty class instead")]
		public float penaltyPositionFactor;

		[JsonMember]
		[Obsolete("Use the RuleAnglePenalty class instead")]
		public bool penaltyAngle;

		[JsonMember]
		[Obsolete("Use the RuleAnglePenalty class instead")]
		public float penaltyAngleFactor;

		[JsonMember]
		[Obsolete("Use the RuleAnglePenalty class instead")]
		public float penaltyAnglePower;

		[JsonMember]
		public GridGraphRules rules;

		[JsonMember]
		public bool showMeshOutline;

		[JsonMember]
		public bool showNodeConnections;

		[JsonMember]
		public bool showMeshSurface;

		[JsonMember]
		[Obsolete("Use the RuleTexture class instead")]
		public TextureData textureData;

		[NonSerialized]
		public readonly int[] neighbourOffsets;

		[NonSerialized]
		public readonly uint[] neighbourCosts;

		public static readonly int[] neighbourXOffsets;

		public static readonly int[] neighbourZOffsets;

		internal static readonly int[] hexagonNeighbourIndices;

		internal static readonly int[] axisAlignedNeighbourIndices;

		internal static readonly int[] allNeighbourIndices;

		internal const int HexagonConnectionMask = 175;

		public GridNodeBase[] nodes;

		protected GridGraphNodeData nodeData;

		protected Func<GridNodeBase> newGridNodeDelegate;

		public const int FixedPrecisionScale = 1024;

		public virtual int LayerCount
		{
			get
			{
				return 0;
			}
			protected set
			{
			}
		}

		public virtual int MaxLayers => 0;

		[Obsolete("This field has been renamed to maxStepHeight")]
		public float maxClimb
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected bool useRaycastNormal => false;

		public Vector2 size { get; protected set; }

		internal ref GridGraphNodeData nodeDataRef
		{
			get
			{
				throw null;
			}
		}

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

		public override bool isScanned => false;

		public override Bounds bounds => default(Bounds);

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

		protected override void DisposeUnmanagedData()
		{
		}

		protected override void DestroyAllNodes()
		{
		}

		public override int CountNodes()
		{
			return 0;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
		}

		public static int[] GetNeighbourDirections(NumNeighbours neighbours)
		{
			return null;
		}

		protected virtual GridNodeBase[] AllocateNodesJob(int size, out JobHandle dependency)
		{
			dependency = default(JobHandle);
			return null;
		}

		public override void RelocateNodes(Matrix4x4 deltaMatrix)
		{
		}

		public void RelocateNodes(Vector3 center, Quaternion rotation, float nodeSize, float aspectRatio = 1f, float isometricAngle = 0f)
		{
		}

		public override bool IsInsideBounds(Vector3 point)
		{
			return false;
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

		public void SetGridShape(InspectorGridMode shape)
		{
		}

		public void AlignToTilemap(GridLayout grid)
		{
		}

		public void SetDimensions(int width, int depth, float nodeSize)
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

		public override float NearestNodeDistanceSqrLowerBound(Vector3 position, NNConstraint constraint)
		{
			return 0f;
		}

		protected virtual GridNodeBase GetNearestFromGraphSpace(Vector3 positionGraphSpace)
		{
			return null;
		}

		public override NNInfo GetNearest(Vector3 position, NNConstraint constraint, float maxDistanceSqr)
		{
			return default(NNInfo);
		}

		public override NNInfo RandomPointOnSurface(NNConstraint nnConstraint = null, bool highQuality = true)
		{
			return default(NNInfo);
		}

		public virtual void SetUpOffsetsAndCosts()
		{
		}

		public IGraphUpdatePromise TranslateInDirection(int dx, int dz)
		{
			return null;
		}

		protected override IGraphUpdatePromise ScanInternal(bool async)
		{
			return null;
		}

		public void SetWalkability(bool[] walkability, IntRect rect)
		{
		}

		public void RecalculateAllConnections()
		{
		}

		public void RecalculateConnectionsInRegion(IntRect recalculateRect)
		{
		}

		public void CalculateConnectionsForCellAndNeighbours(int x, int z)
		{
		}

		[Obsolete("This method is very slow since 4.3.80. Use RecalculateConnectionsInRegion or RecalculateAllConnections instead to batch connection recalculations.")]
		public virtual void CalculateConnections(GridNodeBase node)
		{
		}

		[Obsolete("This method is very slow since 4.3.80. Use RecalculateConnectionsInRegion instead to batch connection recalculations.")]
		public virtual void CalculateConnections(int x, int z)
		{
		}

		public override void OnDrawGizmos(DrawingData gizmos, bool drawNodes, RedrawScope redrawScope)
		{
		}

		private void CreateNavmeshSurfaceVisualization(GridNodeBase[] nodes, int nodeCount, GraphGizmoHelper helper)
		{
		}

		public Bounds GetBoundsFromRect(IntRect rect)
		{
			return default(Bounds);
		}

		public IntRect GetRectFromBounds(Bounds bounds)
		{
			return default(IntRect);
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

		public List<GraphNode> GetNodesInRegion(IntRect rect)
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

		IGraphUpdatePromise IUpdatableGraph.ScheduleGraphUpdates(List<GraphUpdateObject> graphUpdates)
		{
			return null;
		}

		public override IGraphSnapshot Snapshot(Bounds bounds)
		{
			return null;
		}

		public bool Linecast(Vector3 from, Vector3 to)
		{
			return false;
		}

		[Obsolete("The hint parameter is deprecated")]
		public bool Linecast(Vector3 from, Vector3 to, GraphNode hint)
		{
			return false;
		}

		[Obsolete("The hint parameter is deprecated")]
		public bool Linecast(Vector3 from, Vector3 to, GraphNode hint, out GraphHitInfo hit)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		protected static long CrossMagnitude(int2 a, int2 b)
		{
			return 0L;
		}

		protected bool ClipLineSegmentToBounds(Vector3 a, Vector3 b, out Vector3 outA, out Vector3 outB)
		{
			outA = default(Vector3);
			outB = default(Vector3);
			return false;
		}

		[Obsolete("The hint parameter is deprecated")]
		public bool Linecast(Vector3 from, Vector3 to, GraphNode hint, out GraphHitInfo hit, List<GraphNode> trace, Func<GraphNode, bool> filter = null)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		public bool Linecast(Vector3 from, Vector3 to, out GraphHitInfo hit, List<GraphNode> trace = null, Func<GraphNode, bool> filter = null)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		[Obsolete("Use Linecast instead")]
		public bool SnappedLinecast(Vector3 from, Vector3 to, GraphNode hint, out GraphHitInfo hit)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		public bool Linecast(GridNodeBase fromNode, GridNodeBase toNode, Func<GraphNode, bool> filter = null)
		{
			return false;
		}

		public bool Linecast(Vector3 from, Vector3 to, out GridHitInfo hit, List<GraphNode> trace = null, Func<GraphNode, bool> filter = null)
		{
			hit = default(GridHitInfo);
			return false;
		}

		public bool Linecast(GridNodeBase fromNode, Vector2 normalizedFromPoint, GridNodeBase toNode, Vector2 normalizedToPoint, out GridHitInfo hit, List<GraphNode> trace = null, Func<GraphNode, bool> filter = null, bool continuePastEnd = false)
		{
			hit = default(GridHitInfo);
			return false;
		}

		public bool Linecast(GridNodeBase fromNode, int2 fixedNormalizedFromPoint, GridNodeBase toNode, int2 fixedNormalizedToPoint, out GridHitInfo hit, List<GraphNode> trace = null, Func<GraphNode, bool> filter = null, bool continuePastEnd = false)
		{
			hit = default(GridHitInfo);
			return false;
		}

		protected override void SerializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected override void DeserializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected void DeserializeNativeData(GraphSerializationContext ctx, bool normalsSerialized)
		{
		}

		protected void SerializeNodeSurfaceNormals(GraphSerializationContext ctx)
		{
		}

		protected void DeserializeNodeSurfaceNormals(GraphSerializationContext ctx, GridNodeBase[] nodes, bool ignoreForCompatibility)
		{
		}

		private void HandleBackwardsCompatibility(GraphSerializationContext ctx)
		{
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
		}
	}
}
