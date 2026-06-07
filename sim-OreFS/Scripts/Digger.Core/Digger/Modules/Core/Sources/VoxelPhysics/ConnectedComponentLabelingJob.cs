using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.VoxelPhysics
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct ConnectedComponentLabelingJob : IJob
	{
		public int SizeVox;

		public int SizeVox2;

		public int3 ChunkVoxelPosition;

		[ReadOnly]
		public NativeArray<Voxel> Voxels;

		public NativeArray<int> Labels;

		public NativeQueue<int> QueuedVoxelIndices;

		public NativeParallelHashMap<int, ConnectedComponentLabeling.AABB> LabelMap;

		private int lastLabel;

		public void Execute()
		{
			lastLabel = 0;
			for (int i = 0; i < Voxels.Length; i++)
			{
				lastLabel++;
				Execute(i);
				int item;
				while (QueuedVoxelIndices.TryDequeue(out item))
				{
					int3 int5 = Utils.IndexToXYZ(item, SizeVox, SizeVox2);
					if (int5.x > 0)
					{
						Execute((int5.x - 1) * SizeVox2 + int5.y * SizeVox + int5.z);
					}
					if (int5.y > 0)
					{
						Execute(int5.x * SizeVox2 + (int5.y - 1) * SizeVox + int5.z);
					}
					if (int5.z > 0)
					{
						Execute(int5.x * SizeVox2 + int5.y * SizeVox + (int5.z - 1));
					}
					if (int5.x < SizeVox - 1)
					{
						Execute((int5.x + 1) * SizeVox2 + int5.y * SizeVox + int5.z);
					}
					if (int5.y < SizeVox - 1)
					{
						Execute(int5.x * SizeVox2 + (int5.y + 1) * SizeVox + int5.z);
					}
					if (int5.z < SizeVox - 1)
					{
						Execute(int5.x * SizeVox2 + int5.y * SizeVox + (int5.z + 1));
					}
				}
			}
		}

		private void Execute(int index)
		{
			if (!Voxels[index].IsInside)
			{
				Labels[index] = -2;
			}
			else if (Labels[index] == 0)
			{
				ConnectedComponentLabeling.AABB item;
				ConnectedComponentLabeling.AABB value = (LabelMap.TryGetValue(lastLabel, out item) ? item : new ConnectedComponentLabeling.AABB
				{
					Min = new int3(int.MaxValue),
					Max = new int3(int.MinValue)
				});
				value.Expand(Utils.IndexToWorldXYZ(index, SizeVox, SizeVox2, ChunkVoxelPosition));
				LabelMap[lastLabel] = value;
				Labels[index] = lastLabel;
				QueuedVoxelIndices.Enqueue(index);
			}
		}
	}
}
