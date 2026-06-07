using Digger.Modules.Core.Sources.NativeCollections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.VoxelPhysics
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct RemoveFloatingVoxelsJob : IJobParallelFor
	{
		[WriteOnly]
		public NativeArray<Voxel> Voxels;

		public NativeArray<int> Labels;

		[ReadOnly]
		public NativeParallelHashSet<int> LabelsConnectedToTheGround;

		[ReadOnly]
		public NativeArray<float> Heights;

		public float ChunkAltitude;

		public float3 HeightmapScale;

		public int SizeVox;

		public int SizeVox2;

		[WriteOnly]
		public NativeArray<int> Holes;

		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<int> NewHolesConcurrentCounter;

		public void Execute(int index)
		{
			int num = Labels[index];
			if (num <= 0 || LabelsConnectedToTheGround.Contains(num))
			{
				return;
			}
			int3 int5 = Utils.IndexToXYZ(index, SizeVox, SizeVox2);
			float3 float5 = int5 * HeightmapScale;
			Voxel value = new Voxel(HeightmapScale.y, HeightmapScale.y);
			value.Alteration = 5u;
			Voxels[index] = value;
			Labels[index] = -2;
			if (!Utils.IsOnSurface(int5, HeightmapScale.y, float5.y + ChunkAltitude, SizeVox, Heights))
			{
				return;
			}
			Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(NewHolesConcurrentCounter, 0);
			Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Utils.XZToHoleIndex(int5.x, int5.z, SizeVox));
			if (int5.x >= 1)
			{
				Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Utils.XZToHoleIndex(int5.x - 1, int5.z, SizeVox));
				if (int5.z >= 1)
				{
					Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Utils.XZToHoleIndex(int5.x - 1, int5.z - 1, SizeVox));
				}
			}
			if (int5.z >= 1)
			{
				Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Utils.XZToHoleIndex(int5.x, int5.z - 1, SizeVox));
			}
		}
	}
}
