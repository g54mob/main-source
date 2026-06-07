using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	[BurstCompile]
	public struct JobCopyRectangle<T> : IJob where T : struct
	{
		[ReadOnly]
		[DisableUninitializedReadCheck]
		public NativeArray<T> input;

		[WriteOnly]
		public NativeArray<T> output;

		public Slice3D inputSlice;

		public Slice3D outputSlice;

		public void Execute()
		{
		}

		public static void Copy(NativeArray<T> input, NativeArray<T> output, Slice3D inputSlice, Slice3D outputSlice)
		{
		}
	}
}
