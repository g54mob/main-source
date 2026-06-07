using System.Runtime.CompilerServices;
using Pathfinding.Graphs.Grid;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.Jobs
{
	internal static class NativeArrayExtensions
	{
		public static JobMemSet<T> MemSet<T>(this NativeArray<T> self, T value) where T : struct
		{
			return default(JobMemSet<T>);
		}

		public static JobAND BitwiseAndWith(this NativeArray<bool> self, NativeArray<bool> other)
		{
			return default(JobAND);
		}

		public static JobCopy<T> CopyToJob<T>(this NativeArray<T> from, NativeArray<T> to) where T : struct
		{
			return default(JobCopy<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SliceActionJob<T> WithSlice<T>(this T action, Slice3D slice) where T : struct, GridIterationUtilities.ISliceAction
		{
			return default(SliceActionJob<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IndexActionJob<T> WithLength<T>(this T action, int length) where T : struct, GridIterationUtilities.ISliceAction
		{
			return default(IndexActionJob<T>);
		}

		public static JobRotate3DArray<T> Rotate3D<T>(this NativeArray<T> arr, int3 size, int dx, int dz) where T : struct
		{
			return default(JobRotate3DArray<T>);
		}
	}
}
