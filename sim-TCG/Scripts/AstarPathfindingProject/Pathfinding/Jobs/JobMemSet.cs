using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	[BurstCompile]
	public struct JobMemSet<T> : IJob where T : unmanaged
	{
		[WriteOnly]
		public NativeArray<T> data;

		public T value;

		public void Execute()
		{
			data.AsUnsafeSpan().Fill(value);
		}
	}
}
