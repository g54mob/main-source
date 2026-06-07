using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	public struct JobVoxelize : IJob
	{
		[ReadOnly]
		public NativeArray<RasterizationMesh> inputMeshes;

		[ReadOnly]
		public NativeArray<int> bucket;

		public int voxelWalkableClimb;

		public uint voxelWalkableHeight;

		public float cellSize;

		public float cellHeight;

		public float maxSlope;

		public Matrix4x4 graphTransform;

		public Bounds graphSpaceBounds;

		public Vector2 graphSpaceLimits;

		public LinkedVoxelField voxelArea;

		public void Execute()
		{
		}
	}
}
