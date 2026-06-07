using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Digger.Modules.Core.Sources.VoxelPhysics
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct LinkLabelOfNeighborChunksYJob : IJob
	{
		public int SizeVox;

		public int SizeVox2;

		[ReadOnly]
		public NativeArray<int> Labels1;

		[ReadOnly]
		public NativeArray<int> Labels2;

		[WriteOnly]
		public NativeParallelMultiHashMap<int, int> LinksFrom1To2;

		[WriteOnly]
		public NativeParallelMultiHashMap<int, int> LinksFrom2To1;

		[WriteOnly]
		public NativeParallelHashSet<int> LabelsConnectedToTheGround;

		public void Execute()
		{
			for (int i = 0; i < SizeVox; i++)
			{
				for (int j = 0; j < SizeVox; j++)
				{
					int index = i * SizeVox2 + (SizeVox - 2) * SizeVox + j;
					int index2 = i * SizeVox2 + 0 + j;
					int num = Labels1[index];
					int num2 = Labels2[index2];
					if (num > 0 && num2 > 0)
					{
						LinksFrom1To2.Add(num, num2);
						LinksFrom2To1.Add(num2, num);
					}
					else if (num > 0 && num2 == 0)
					{
						LabelsConnectedToTheGround.Add(num);
					}
					else if (num == 0 && num2 > 0)
					{
						LabelsConnectedToTheGround.Add(num2);
					}
				}
			}
		}
	}
}
