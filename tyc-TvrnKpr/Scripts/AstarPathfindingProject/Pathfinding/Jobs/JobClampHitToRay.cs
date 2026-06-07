using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobClampHitToRay : IJob
	{
		[ReadOnly]
		public NativeArray<SpherecastCommand> commands;

		public NativeArray<RaycastHit> hits;

		public void Execute()
		{
		}
	}
}
