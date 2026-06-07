using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.Jobs
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct VoxelFillSurfaceJob : IJobParallelFor
	{
		public float ChunkAltitude;

		public int SizeVox;

		public int SizeVox2;

		public float3 HeightmapScale;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float> Heights;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<int> Holes;

		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> Voxels;

		public void Execute(int index)
		{
			int3 int5 = Utils.IndexToXYZ(index, SizeVox, SizeVox2);
			float3 float5 = int5 * HeightmapScale;
			Voxel value = Voxels[index];
			if (value.Alteration == 0 && Utils.IsOnHole(int5, SizeVox, Holes) && Utils.IsOnSurface(int5, HeightmapScale.y, float5.y + ChunkAltitude, SizeVox, Heights))
			{
				value.Alteration = 1u;
				Voxels[index] = value;
			}
		}
	}
}
