using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobErodeWalkableArea : IJob
	{
		public CompactVoxelField field;

		public int radius;

		public void Execute()
		{
			NativeArray<ushort> output = new NativeArray<ushort>(field.spans.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			VoxelUtilityBurst.CalculateDistanceField(field, output);
			for (int i = 0; i < output.Length; i++)
			{
				if (output[i] < radius * 2)
				{
					field.areaTypes[i] = 0;
				}
			}
		}
	}
}
