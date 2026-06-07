using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace JBooth.MicroVerseCore
{
	[BurstCompile]
	internal struct UnityAPISucksJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<byte> source;

		[WriteOnly]
		public NativeArray<int> target;

		public void Execute(int i)
		{
			target[i] = source[i];
		}
	}
}
