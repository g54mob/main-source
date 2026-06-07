using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.Jobs
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct SimpleVoxelGenerationJob : IJobParallelFor
	{
		public int3 ChunkPosition;

		public int SizeVox;

		public int SizeVox2;

		public float3 HeightmapScale;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float> Heights;

		public NativeArray<Voxel> Voxels;

		public int RefreshOnly;

		public void Execute(int index)
		{
			if (RefreshOnly != 1 || !Voxels[index].IsAlteredFarOrNearSurface)
			{
				int3 int5 = Utils.IndexToXYZ(index, SizeVox, SizeVox2);
				float num = Heights[Utils.XYZToHeightIndex(int5, SizeVox)];
				float3 float5 = Utils.ChunkVoxelToUnityPosition(ChunkPosition, int5, HeightmapScale);
				if (RefreshOnly == 1 && !Voxels[index].IsAlteredFarOrNearSurface)
				{
					Voxels[index].SetValue(float5.y - num, HeightmapScale.y);
				}
				else
				{
					Voxels[index] = new Voxel(float5.y - num, HeightmapScale.y);
				}
			}
		}
	}
}
