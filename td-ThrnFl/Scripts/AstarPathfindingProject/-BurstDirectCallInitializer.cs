using Pathfinding;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.RVO;
using Pathfinding.Util;
using UnityEngine;

internal static class _0024BurstDirectCallInitializer
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	private static void Initialize()
	{
		Polygon.ContainsPoint_000002D5_0024BurstDirectCall.Initialize();
		Polygon.ClosestPointOnTriangleByRef_000002DC_0024BurstDirectCall.Initialize();
		Polygon.ClosestPointOnTriangleProjected_000002DF_0024BurstDirectCall.Initialize();
		BinaryHeap.Add_000002EF_0024BurstDirectCall.Initialize();
		BinaryHeap.Remove_000002F2_0024BurstDirectCall.Initialize();
		HeuristicObjective.Calculate_000004D2_0024BurstDirectCall.Initialize();
		Path.OpenCandidateConnectionBurst_0000050F_0024BurstDirectCall.Initialize();
		TriangleMeshNode.InterpolateEdge_0000076E_0024BurstDirectCall.Initialize();
		TriangleMeshNode.OpenSingleEdgeBurst_00000773_0024BurstDirectCall.Initialize();
		TriangleMeshNode.CalculateBestEdgePosition_00000774_0024BurstDirectCall.Initialize();
		NavmeshCutJobs.CalculateContour_000008A0_0024BurstDirectCall.Initialize();
		Funnel.Calculate_00000936_0024BurstDirectCall.Initialize();
		Funnel.FunnelState.PushStart_00000942_0024BurstDirectCall.Initialize();
		Funnel.FunnelState.ConvertCornerIndicesToPathProjected_0000094C_0024BurstDirectCall.Initialize();
		PathTracer.ContainsAndProject_00000974_0024BurstDirectCall.Initialize();
		PathTracer.EstimateRemainingPath_00000988_0024BurstDirectCall.Initialize();
		PathTracer.RemainingDistanceLowerBound_0000098C_0024BurstDirectCall.Initialize();
		BBTree.Build_00000AA8_0024BurstDirectCall.Initialize();
		BBTree.ProjectionParams.SquaredRectPointDistanceOnPlane_00000AB3_0024BurstDirectCall.Initialize();
		BBTree.Initialize_0024NearbyNodesIterator_MoveNext_00000ABA_0024BurstDirectCall();
		ColliderMeshBuilder2D.GenerateMeshesFromShapes_00000AC3_0024BurstDirectCall.Initialize();
		RecastMeshGatherer.CalculateBounds_00000ACF_0024BurstDirectCall.Initialize();
		RecastMeshGatherer.GenerateHeightmapChunk_00000AE0_0024BurstDirectCall.Initialize();
		HierarchicalBitset.Iterator.MoveNextBurst_00000D1D_0024BurstDirectCall.Initialize();
		MeshUtility.MakeTrianglesClockwise_00000E58_0024BurstDirectCall.Initialize();
		RVOObstacleCache.TraceContours_00000F33_0024BurstDirectCall.Initialize();
	}
}
