using System.Runtime.CompilerServices;
using Pathfinding.Graphs.Grid;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.Jobs
{
	internal static class NativeArrayExtensions
	{
		public static JobMemSet<T> MemSet<T>(this NativeArray<T> self, T value) where T : unmanaged
		{
			return new JobMemSet<T>
			{
				data = self,
				value = value
			};
		}

		public static JobAND BitwiseAndWith(this NativeArray<bool> self, NativeArray<bool> other)
		{
			return new JobAND
			{
				result = self,
				data = other
			};
		}

		public static JobCopy<T> CopyToJob<T>(this NativeArray<T> from, NativeArray<T> to) where T : struct
		{
			return new JobCopy<T>
			{
				from = from,
				to = to
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SliceActionJob<T> WithSlice<T>(this T action, Slice3D slice) where T : struct, GridIterationUtilities.ISliceAction
		{
			return new SliceActionJob<T>
			{
				action = action,
				slice = slice
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IndexActionJob<T> WithLength<T>(this T action, int length) where T : struct, GridIterationUtilities.ISliceAction
		{
			return new IndexActionJob<T>
			{
				action = action,
				length = length
			};
		}

		public static JobRotate3DArray<T> Rotate3D<T>(this NativeArray<T> arr, int3 size, int dx, int dz) where T : unmanaged
		{
			return new JobRotate3DArray<T>
			{
				arr = arr,
				size = size,
				dx = dx,
				dz = dz
			};
		}
	}
}
