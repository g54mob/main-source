using System;

namespace ZLinq.Internal
{
	public static class EnumeratorHelper
	{
		public static bool TryGetSliceRange(int sourceLength, Index offset, int destinationLength, out int start, out int count)
		{
			start = default(int);
			count = default(int);
			return false;
		}

		public static bool TryGetSlice<T>(ReadOnlySpan<T> source, Index offset, int destinationLength, out ReadOnlySpan<T> slice)
		{
			slice = default(ReadOnlySpan<T>);
			return false;
		}

		public static bool TryConsumeGetAt<TEnumerator, T>(ref TEnumerator enumerator, Index offset, out T value) where TEnumerator : struct, IValueEnumerator<T>
		{
			value = default(T);
			return false;
		}

		private static bool TryConsumeGetFirst<TEnumerator, T>(ref TEnumerator enumerator, out T first) where TEnumerator : struct, IValueEnumerator<T>
		{
			first = default(T);
			return false;
		}

		private static bool TryConsumeGetAt<TEnumerator, T>(ref TEnumerator enumerator, int index, out T value) where TEnumerator : struct, IValueEnumerator<T>
		{
			value = default(T);
			return false;
		}

		private static bool TryConsumeGetLast<TEnumerator, T>(ref TEnumerator enumerator, out T last) where TEnumerator : struct, IValueEnumerator<T>
		{
			last = default(T);
			return false;
		}

		private static bool TryConsumeGetFromLast<TEnumerator, T>(ref TEnumerator enumerator, int indexFromEnd, out T value) where TEnumerator : struct, IValueEnumerator<T>
		{
			value = default(T);
			return false;
		}
	}
}
