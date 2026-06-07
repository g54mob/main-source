using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Drawing
{
	[BurstCompile]
	internal struct StreamSplitter : IJob
	{
		public NativeArray<UnsafeAppendBuffer> inputBuffers;

		[NativeDisableUnsafePtrRestriction]
		public unsafe UnsafeAppendBuffer* staticBuffer;

		[NativeDisableUnsafePtrRestriction]
		public unsafe UnsafeAppendBuffer* dynamicBuffer;

		[NativeDisableUnsafePtrRestriction]
		public unsafe UnsafeAppendBuffer* persistentBuffer;

		internal static readonly int PushCommands;

		internal static readonly int PopCommands;

		internal static readonly int MetaCommands;

		internal static readonly int DynamicCommands;

		internal static readonly int StaticCommands;

		internal static readonly int[] CommandSizes;

		static StreamSplitter()
		{
		}

		public void Execute()
		{
		}
	}
}
