using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Drawing
{
	[BurstCompile]
	internal struct PersistentFilterJob : IJob
	{
		[NativeDisableUnsafePtrRestriction]
		public unsafe UnsafeAppendBuffer* buffer;

		public float time;

		public void Execute()
		{
		}
	}
}
