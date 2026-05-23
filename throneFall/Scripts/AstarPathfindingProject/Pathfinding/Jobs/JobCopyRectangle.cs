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
			Copy(input, output, inputSlice, outputSlice);
		}

		public static void Copy(NativeArray<T> input, NativeArray<T> output, Slice3D inputSlice, Slice3D outputSlice)
		{
			inputSlice.AssertMatchesOuter(input);
			outputSlice.AssertMatchesOuter(output);
			inputSlice.AssertSameSize(outputSlice);
			if (inputSlice.coversEverything && outputSlice.coversEverything)
			{
				input.CopyTo(output);
				return;
			}
			for (int i = 0; i < outputSlice.slice.size.y; i++)
			{
				for (int j = 0; j < outputSlice.slice.size.z; j++)
				{
					int srcIndex = inputSlice.InnerCoordinateToOuterIndex(0, i, j);
					int dstIndex = outputSlice.InnerCoordinateToOuterIndex(0, i, j);
					NativeArray<T>.Copy(input, srcIndex, output, dstIndex, outputSlice.slice.size.x);
				}
			}
		}
	}
}
