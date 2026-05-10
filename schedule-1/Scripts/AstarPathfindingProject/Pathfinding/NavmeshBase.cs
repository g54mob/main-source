using System;
using System.Collections.Generic;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	public abstract class NavmeshBase : NavGraph, INavmesh, INavmeshHolder, ITransformedGraph, IRaycastableGraph
	{
		public const int VertexIndexMask = 4095;

		public const int TileIndexMask = 524287;

		public const int TileIndexOffset = 12;

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
		public bool nearestSearchOnlyXZ;

		[JsonMember]
		public bool enableNavmeshCutting;

		internal readonly NavmeshUpdates.NavmeshUpdateSettings navmeshUpdateData;

		private bool batchTileUpdate;

		private List<int> batchUpdatedTiles;

		private List<MeshNode> batchNodesToDestroy;

		public GraphTransform transform;

		public Action<NavmeshTile[]> OnRecalculatedTiles;

		private static readonly NNConstraint NNConstraintDistanceXZ;

		private Dictionary<int, int> nodeRecyclingHashBuffer;

		private static readonly NNConstraint NNConstraintNoneXZ;

		private static readonly byte[] LinecastShapeEdgeLookup;

		public abstract float TileWorldSizeX { get; }

		public abstract float TileWorldSizeZ { get; }

		protected abstract float MaxTileConnectionEdgeDistance { get; }

		GraphTransform ITransformedGraph.transform => null;

		protected abstract bool RecalculateNormals { get; }

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

		public Int2 GetTileCoordinates(Vector3 position)
		{
			return default(Int2);
		}

		protected override void OnDestroy()
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

		public IntRect GetTouchingTiles(Bounds bounds, float margin = 0f)
		{
			return default(IntRect);
		}

		public IntRect GetTouchingTilesInGraphSpace(Rect rect)
		{
			return default(IntRect);
		}

		public IntRect GetTouchingTilesRound(Bounds bounds)
		{
			return default(IntRect);
		}

		protected void ConnectTileWithNeighbours(NavmeshTile tile, bool onlyUnflagged = false)
		{
		}

		protected void RemoveConnectionsFromTile(NavmeshTile tile)
		{
		}

		protected void RemoveConnectionsFromTo(NavmeshTile a, NavmeshTile b)
		{
		}

		public override NNInfoInternal GetNearest(Vector3 position, NNConstraint constraint, GraphNode hint)
		{
			return default(NNInfoInternal);
		}

		public override NNInfoInternal GetNearestForce(Vector3 position, NNConstraint constraint)
		{
			return default(NNInfoInternal);
		}

		public GraphNode PointOnNavmesh(Vector3 position, NNConstraint constraint)
		{
			return null;
		}

		protected void FillWithEmptyTiles()
		{
		}

		protected static void CreateNodeConnections(TriangleMeshNode[] nodes)
		{
		}

		protected void ConnectTiles(NavmeshTile tile1, NavmeshTile tile2)
		{
		}

		public void StartBatchTileUpdate()
		{
		}

		private void DestroyNodes(List<MeshNode> nodes)
		{
		}

		private void TryConnect(int tileIdx1, int tileIdx2)
		{
		}

		public void EndBatchTileUpdate()
		{
		}

		protected void ClearTile(int x, int z)
		{
		}

		private void PrepareNodeRecycling(int x, int z, Int3[] verts, int[] tris, TriangleMeshNode[] recycledNodeBuffer)
		{
		}

		public void ReplaceTile(int x, int z, Int3[] verts, int[] tris)
		{
		}

		protected void CreateNodes(TriangleMeshNode[] buffer, int[] tris, int tileIndex, uint graphIndex)
		{
		}

		public NavmeshBase()
		{
		}

		public bool Linecast(Vector3 origin, Vector3 end)
		{
			return false;
		}

		public bool Linecast(Vector3 origin, Vector3 end, GraphNode hint, out GraphHitInfo hit)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		public bool Linecast(Vector3 origin, Vector3 end, GraphNode hint)
		{
			return false;
		}

		public bool Linecast(Vector3 origin, Vector3 end, GraphNode hint, out GraphHitInfo hit, List<GraphNode> trace)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		public bool Linecast(Vector3 origin, Vector3 end, out GraphHitInfo hit, List<GraphNode> trace, Func<GraphNode, bool> filter)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		public static bool Linecast(NavmeshBase graph, Vector3 origin, Vector3 end, GraphNode hint, out GraphHitInfo hit)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		static NavmeshBase()
		{
		}

		public static bool Linecast(NavmeshBase graph, Vector3 origin, Vector3 end, GraphNode hint, out GraphHitInfo hit, List<GraphNode> trace, Func<GraphNode, bool> filter = null)
		{
			hit = default(GraphHitInfo);
			return false;
		}

		public override void OnDrawGizmos(RetainedGizmos gizmos, bool drawNodes)
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
