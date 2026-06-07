using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobColliderHitsToBooleans : IJob
	{
		[ReadOnly]
		public NativeArray<ColliderHit> hits;

		[WriteOnly]
		public NativeArray<bool> result;

		public void Execute()
		{
			for (int i = 0; i < hits.Length; i++)
			{
				result[i] = hits[i].instanceID == 0;
			}
		}
	}
}
