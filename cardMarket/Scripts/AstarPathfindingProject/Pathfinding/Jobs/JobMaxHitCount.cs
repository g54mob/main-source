using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Jobs
{
	[BurstCompile]
	public struct JobMaxHitCount : IJob
	{
		[ReadOnly]
		public NativeArray<RaycastHit> hits;

		public int maxHits;

		public int layerStride;

		[WriteOnly]
		public NativeArray<int> maxHitCount;

		public void Execute()
		{
			int i;
			for (i = 0; i < maxHits; i++)
			{
				int num = i * layerStride;
				bool flag = false;
				for (int j = num; j < num + layerStride; j++)
				{
					if (math.any(hits[j].normal))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			maxHitCount[0] = math.max(1, i);
		}
	}
}
