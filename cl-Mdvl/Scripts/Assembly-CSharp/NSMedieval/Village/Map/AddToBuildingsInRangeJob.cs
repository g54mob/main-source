using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace NSMedieval.Village.Map
{
	[BurstCompile]
	internal struct AddToBuildingsInRangeJob : IJob
	{
		public NativeArray<int> BuildingsInRange;

		public NativeParallelHashSet<int> IndicesToRefresh;

		[ReadOnly]
		public NativeArray<int> AreaX;

		[ReadOnly]
		public NativeArray<int> AreaZ;

		[ReadOnly]
		public bool StoreRefreshIndices;

		[ReadOnly]
		public int SizeXCache;

		[ReadOnly]
		public int SizeYCache;

		[ReadOnly]
		public int SizeZCache;

		[ReadOnly]
		public int NodePosX;

		[ReadOnly]
		public int NodePosY;

		[ReadOnly]
		public int NodePosZ;

		[ReadOnly]
		public int ValueToAdd;

		public void Execute()
		{
			int length = AreaX.Length;
			for (int i = 0; i < length; i++)
			{
				int num = NodePosX + AreaX[i];
				if (num < 0 || num >= SizeXCache)
				{
					continue;
				}
				int num2 = NodePosZ + AreaZ[i];
				if (num2 >= 0 && num2 < SizeZCache)
				{
					int num3 = FastTo1DIndex(num, NodePosY, num2);
					BuildingsInRange[num3] = Math.Max(BuildingsInRange[num3] + ValueToAdd, 0);
					if (StoreRefreshIndices)
					{
						IndicesToRefresh.Add(num3);
					}
				}
			}
		}

		private int FastTo1DIndex(int x, int y, int z)
		{
			return x + y * SizeXCache + z * SizeXCache * SizeYCache;
		}
	}
}
