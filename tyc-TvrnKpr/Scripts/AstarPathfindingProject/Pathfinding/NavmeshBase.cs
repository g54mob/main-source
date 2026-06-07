using System;
using System.Collections.Generic;
using Pathfinding.Collections;
using Pathfinding.Drawing;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Burst;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public abstract class NavmeshBase : NavGraph, INavmeshHolder, ITransformedGraph, IRaycastableGraph
	{
		public const int VertexIndexMask = 1048575;

		public const int TileIndexMask = 2047;

		public const int TileIndexOffset = 20;

		[JsonMember]
		public Vector3 forcedBoundsSize;

		[JsonMember]
		public bool showMeshOutline;

		[JsonMember]
		public bool showNodeConnections;

		[JsonMember]
		public bool showMeshSurface;

		public int tileXCount;

		public int tileZCount;

		protected NavmeshTile[] tiles;

		[JsonMember]
		[Obsolete("Set the appropriate fields on the NearestNodeConstraint instead")]
		public bool nearestSearchOnlyXZ;

		[JsonMember]
		public bool enableNavmeshCutting;

		public NavmeshUpdates.NavmeshUpdateSettings navmeshUpdateData;

		private int batchTileUpdate;

		private bool batchPendingNavmeshCutting;

		private List<int> batchUpdatedTiles;

		private List<MeshNode> batchNodesToDestroy;

		public GraphTransform transform;

		public Action<NavmeshTile[]> OnRecalculatedTiles;

		private Dictionary<int, int> nodeRecyclingHashBuffer;

		private static readonly byte[] LinecastShapeEdgeLookup;

		public abstract float NavmeshCuttingCharacterRadius { get; }

		public abstract float TileWorldSizeX { get; }

		public abstract float TileWorldSizeZ { get; }

		public abstract float MaxTileConnectionEdgeDistance { get; }

		GraphTransform ITransformedGraph.transform => null;

		public abstract bool RecalculateNormals { get; }

		public override bool isScanned => false;

		public abstract GraphTransform CalculateTransform();

		public NavmeshTile GetTile(int x, int z)
		{
			return null;
		}

		public Int3 GetVertex(int index)
		{
			return default(Int3);
		}

		public Int3 GetVertexInGraphSpace(int index)
		{
			return default(Int3);
		}

		public static int GetTileIndex(int index)
		{
			return 0;
		}

		public int GetVertexArrayIndex(int index)
		{
			return 0;
		}

		public void GetTileCoordinates(int tileIndex, out int x, out int z)
		{
			x = default(int);
			z = default(int);
		}

		public NavmeshTile[] GetTiles()
		{
			return null;
		}

		public Bounds GetTileBounds(IntRect rect)
		{
			return default(Bounds);
		}

		public Bounds GetTileBounds(int x, int z, int width = 1, int depth = 1)
		{
			return default(Bounds);
		}

		public Bounds GetTileBoundsInGraphSpace(IntRect rect)
		{
			return default(Bounds);
		}

		public Bounds GetTileBoundsInGraphSpace(int x, int z, int width = 1, int depth = 1)
		{
			return default(Bounds);
		}

		public Vector2Int GetTileCoordinates(Vector3 position)
		{
			return default(Vector2Int);
		}

		protected override void OnDestroy()
		{
		}

		protected override void DisposeUnmanagedData()
		{
		}

		protected override void DestroyAllNodes()
		{
		}

		public override void RelocateNodes(Matrix4x4 deltaMatrix)
		{
		}

		public void RelocateNodes(GraphTransform newTransform)
		{
		}

		protected NavmeshTile NewEmptyTile(int x, int z)
		{
			return null;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
		}

		public override void GetNodes<T>(GraphNode.NodeActionWithData<T> action, ref T data)
		{
		}

		public IntRect GetTouchingTiles(Bounds bounds, float margin = 0f)
		{
			return default(IntRect);
		}

		public IntRect GetTouchingTilesInGraphSpace(Rect rect)
		{
			return default(IntRect);
		}

		protected void ConnectTileWithNeighbours(NavmeshTile tile, bool onlyUnflagged = false)
		{
		}

		public override float NearestNodeDistanceSqrLowerBound(Vector3 position, ref NearestNodeConstraint constraint)
		{
			return 0f;
		}

		public override NNInfo GetNearest(Vector3 position, ref NearestNodeConstraint constraint)
		{
			return default(NNInfo);
		}

		public override NNInfo RandomPointOnSurface(NearestNodeConstraint constraint, bool highQuality = true)
		{
			return default(NNInfo);
		}

		[Obsolete("Use the overload that takes a NearestNodeConstraint instead. See the migration guide for version 5.4 for more details.")]
		public GraphNode PointOnNavmesh(Vector3 position, NNConstraint constraint)
		{
			return null;
		}

		public GraphNode PointOnNavmesh(Vector3 position, NearestNodeConstraint constraint)
		{
			return null;
		}

		protected void FillWithEmptyTiles()
		{
		}

		protected static void CreateNodeConnections(TriangleMeshNode[] nodes, bool keepExistingConnections)
		{
		}

		internal static void ConnectTiles(NavmeshTile tile1, NavmeshTile tile2, float tileWorldSizeX, float tileWorldSizeZ, float maxTileConnectionEdgeDistance)
		{
		}

		public void StartBatchTileUpdate(bool exclusive = false)
		{
		}

		private static void DestroyNodes(List<MeshNode> nodes)
		{
		}

		private void TryConnect(int tileIdx1, int tileIdx2)
		{
		}

		public void EndBatchTileUpdate()
		{
		}

		public void ClearTiles(IntRect tileRect)
		{
		}

		protected void ClearTile(int x, int z, NavmeshTile replacement)
		{
		}

		private void PrepareNodeRecycling(int x, int z, UnsafeSpan<Int3> verts, UnsafeSpan<int> tris, TriangleMeshNode[] recycledNodeBuffer)
		{
		}

		public void ReplaceTile(int x, int z, Int3[] verts, int[] tris, uint[] tags = null, bool tryPreserveExistingTagsAndPenalties = true)
		{
		}

		public void ReplaceTile(int x, int z, UnsafeSpan<Int3> verts, UnsafeSpan<int> tris, UnsafeSpan<uint> tags, bool tryPreserveExistingTagsAndPenalties = true)
		{
		}

		internal void ReplaceTilePostCut(int x, int z, UnsafeSpan<Int3> verts, UnsafeSpan<int> tris, UnsafeSpan<uint> tags, bool tryPreserveExistingTagsAndPenalties = true, bool preservePreCutData = false)
		{
		}

		internal static void CreateNodes(NavmeshTile tile, UnsafeSpan<int> tris, int tileIndex, uint graphIndex, UnsafeSpan<uint> tags, bool initializeNodes, AstarPath astar, uint initialPenalty, bool tryPreserveExistingTagsAndPenalties)
		{
		}

		public NavmeshBase()
		{
		}

		public bool Linecast(Vector3 start, Vector3 end)
		{
			return false;
		}

		public bool Linecast(Vector3 start, Vector3 end, GraphNode hint, out GraphHitInfo hit)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		public bool Linecast(Vector3 start, Vector3 end, GraphNode hint)
		{
			return false;
		}

		public bool Linecast(Vector3 start, Vector3 end, GraphNode hint, out GraphHitInfo hit, List<GraphNode> trace)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		public bool Linecast(Vector3 start, Vector3 end, out GraphHitInfo hit, ref TraversalConstraint traversalConstraint, List<GraphNode> trace)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		public bool Linecast(Vector3 start, Vector3 end, GraphNode hint, out GraphHitInfo hit, ref TraversalConstraint traversalConstraint, List<GraphNode> trace)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		public static bool Linecast(NavmeshBase graph, Vector3 start, Vector3 end, GraphNode hint, out GraphHitInfo hit)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		static NavmeshBase()
		{
		}

		public static bool Linecast(NavmeshBase graph, Vector3 origin, Vector3 end, GraphNode hint, out GraphHitInfo hit, ref TraversalConstraint traversalConstraint, List<GraphNode> trace)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		[Obsolete("Use the overload that takes a TraversalConstraint instead. See the migration guide for version 5.4 for more information.")]
		public bool Linecast(Vector3 start, Vector3 end, out GraphHitInfo hit, List<GraphNode> trace, Func<GraphNode, bool> filter)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		[Obsolete("Use the overload that takes a TraversalConstraint instead. See the migration guide for version 5.4 for more information.")]
		public bool Linecast(Vector3 start, Vector3 end, GraphNode hint, out GraphHitInfo hit, List<GraphNode> trace, Func<GraphNode, bool> filter)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		[Obsolete("Use the overload that takes a TraversalConstraint instead. See the migration guide for version 5.4 for more information.")]
		public static bool Linecast(NavmeshBase graph, Vector3 origin, Vector3 end, GraphNode hint, out GraphHitInfo hit, List<GraphNode> trace, Func<GraphNode, bool> filter = null)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		private static bool FindNodeAroundVertex(TriangleMeshNode node, TriangleMeshNode targetNode, Int3 vertexInGraphSpace, bool oppositeDirection)
		{
			return false;
		}

		public override void OnDrawGizmos(DrawingData gizmos, bool drawNodes, RedrawScope redrawScope, bool renderInGame)
		{
		}

		private void CreateNavmeshSurfaceVisualization(NavmeshTile[] tiles, int startTile, int endTile, GraphGizmoHelper helper)
		{
		}

		private static void CreateNavmeshOutlineVisualization(NavmeshTile[] tiles, int startTile, int endTile, GraphGizmoHelper helper)
		{
		}

		protected override void SerializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected override void DeserializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
		}
	}
}
