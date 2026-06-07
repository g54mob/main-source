using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
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
		}
	}
}
