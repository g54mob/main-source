using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	[BurstCompile]
	public struct JobMemSet<T> : IJob where T : struct
	{
		[WriteOnly]
		public NativeArray<T> data;

		public T value;

		public void Execute()
		{
		}
	}
}
