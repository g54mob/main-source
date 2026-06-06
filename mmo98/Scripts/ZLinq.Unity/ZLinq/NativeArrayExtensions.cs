using Unity.Collections;
using ZLinq.Linq;

namespace ZLinq
{
	public static class NativeArrayExtensions
	{
		public static ValueEnumerable<FromNativeArray<T>, T> AsValueEnumerable<T>(this NativeArray<T> source) where T : struct
		{
			return new ValueEnumerable<FromNativeArray<T>, T>(new FromNativeArray<T>(source.AsReadOnly()));
		}

		public static ValueEnumerable<FromNativeArray<T>, T> AsValueEnumerable<T>(this NativeArray<T>.ReadOnly source) where T : struct
		{
			return new ValueEnumerable<FromNativeArray<T>, T>(new FromNativeArray<T>(source));
		}

		public static ValueEnumerable<FromNativeSlice<T>, T> AsValueEnumerable<T>(this NativeSlice<T> source) where T : struct
		{
			return new ValueEnumerable<FromNativeSlice<T>, T>(new FromNativeSlice<T>(source));
		}
	}
}
