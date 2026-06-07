using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobBuildDistanceField : IJob
	{
		public CompactVoxelField field;

		public NativeList<ushort> output;

		public void Execute()
		{
			NativeArray<ushort> src = new NativeArray<ushort>(field.spans.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			VoxelUtilityBurst.CalculateDistanceField(field, src);
			output.ResizeUninitialized(field.spans.Length);
			VoxelUtilityBurst.BoxBlur(field, src, output.AsArray());
		}
	}
}
