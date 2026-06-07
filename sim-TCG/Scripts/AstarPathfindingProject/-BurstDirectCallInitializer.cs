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
		Polygon.ContainsPoint_000002C7_0024BurstDirectCall.Initialize();
		Polygon.ClosestPointOnTriangleByRef_000002CE_0024BurstDirectCall.Initialize();
		Polygon.ClosestPointOnTriangleProjected_000002D0_0024BurstDirectCall.Initialize();
		BinaryHeap.Add_000002E0_0024BurstDirectCall.Initialize();
		BinaryHeap.Remove_000002E3_0024BurstDirectCall.Initialize();
		HeuristicObjective.Calculate_000004C2_0024BurstDirectCall.Initialize();
		Path.OpenCandidateConnectionBurst_000004FE_0024BurstDirectCall.Initialize();
		TriangleMeshNode.InterpolateEdge_0000075A_0024BurstDirectCall.Initialize();
		TriangleMeshNode.OpenSingleEdgeBurst_0000075F_0024BurstDirectCall.Initialize();
		TriangleMeshNode.CalculateBestEdgePosition_00000760_0024BurstDirectCall.Initialize();
		NavmeshCutJobs.CalculateContour_0000088B_0024BurstDirectCall.Initialize();
		Funnel.Calculate_00000921_0024BurstDirectCall.Initialize();
		Funnel.FunnelState.PushStart_0000092D_0024BurstDirectCall.Initialize();
		Funnel.FunnelState.ConvertCornerIndicesToPathProjected_00000937_0024BurstDirectCall.Initialize();
		PathTracer.ContainsAndProject_0000095F_0024BurstDirectCall.Initialize();
		PathTracer.EstimateRemainingPath_00000973_0024BurstDirectCall.Initialize();
		PathTracer.RemainingDistanceLowerBound_00000977_0024BurstDirectCall.Initialize();
		BBTree.Build_00000A8E_0024BurstDirectCall.Initialize();
		BBTree.ProjectionParams.SquaredRectPointDistanceOnPlane_00000A99_0024BurstDirectCall.Initialize();
		BBTree.Initialize_0024NearbyNodesIterator_MoveNext_00000AA0_0024BurstDirectCall();
		ColliderMeshBuilder2D.GenerateMeshesFromShapes_00000AA8_0024BurstDirectCall.Initialize();
		RecastMeshGatherer.CalculateBounds_00000AB4_0024BurstDirectCall.Initialize();
		HierarchicalBitset.Iterator.MoveNextBurst_00000CFB_0024BurstDirectCall.Initialize();
		MeshUtility.MakeTrianglesClockwise_00000E33_0024BurstDirectCall.Initialize();
		RVOObstacleCache.TraceContours_00000F0E_0024BurstDirectCall.Initialize();
	}
}
