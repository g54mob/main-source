using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	[BurstCompile]
	public struct JobCopy<T> : IJob where T : struct
	{
		[ReadOnly]
		public NativeArray<T> from;

		[WriteOnly]
		public NativeArray<T> to;

		public void Execute()
		{
		}
	}
}
