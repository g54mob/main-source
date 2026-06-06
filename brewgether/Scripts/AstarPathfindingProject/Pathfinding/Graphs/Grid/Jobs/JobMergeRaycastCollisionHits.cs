using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobMergeRaycastCollisionHits : IJob
	{
		[ReadOnly]
		public NativeArray<RaycastHit> hit1;

		[ReadOnly]
		public NativeArray<RaycastHit> hit2;

		[WriteOnly]
		public NativeArray<bool> result;

		public void Execute()
		{
		}
	}
}
