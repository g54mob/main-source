using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	public struct JobBuildRegions : IJob
	{
		public struct RelevantGraphSurfaceInfo
		{
			public float3 position;

			public float range;
		}

		public CompactVoxelField field;

		public NativeList<ushort> distanceField;

		public int borderSize;

		public int minRegionSize;

		public NativeQueue<Int3> srcQue;

		public NativeQueue<Int3> dstQue;

		public RecastGraph.RelevantGraphSurfaceMode relevantGraphSurfaceMode;

		public NativeArray<RelevantGraphSurfaceInfo> relevantGraphSurfaces;

		public float cellSize;

		public float cellHeight;

		public Matrix4x4 graphTransform;

		public Bounds graphSpaceBounds;

		private void MarkRectWithRegion(int minx, int maxx, int minz, int maxz, ushort region, NativeArray<ushort> srcReg)
		{
		}

		public static bool FloodRegion(int x, int z, int i, uint level, ushort r, CompactVoxelField field, NativeArray<ushort> distanceField, NativeArray<ushort> srcReg, NativeArray<ushort> srcDist, NativeArray<Int3> stack, NativeArray<int> flags, NativeArray<bool> closed)
		{
			return false;
		}

		public void Execute()
		{
		}

		private static int union_find_find(NativeArray<int> arr, int x)
		{
			return 0;
		}

		private static void union_find_union(NativeArray<int> arr, int a, int b)
		{
		}

		public static void FilterSmallRegions(CompactVoxelField field, NativeArray<ushort> reg, int minRegionSize, int maxRegions, NativeArray<RelevantGraphSurfaceInfo> relevantGraphSurfaces, RecastGraph.RelevantGraphSurfaceMode relevantGraphSurfaceMode, float4x4 voxel2worldMatrix)
		{
		}
	}
}
