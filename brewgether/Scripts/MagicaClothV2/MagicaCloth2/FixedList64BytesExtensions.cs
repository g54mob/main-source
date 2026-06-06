using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace MagicaCloth2
{
	public static class FixedList64BytesExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool MC2IsCapacity<T>(this ref FixedList64Bytes<T> fixedList) where T : struct, IEquatable<T>
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MC2Set<T>(this ref FixedList64Bytes<T> fixedList, T item) where T : struct, IEquatable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MC2SetLimit<T>(this ref FixedList64Bytes<T> fixedList, T item) where T : struct, IEquatable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MC2RemoveItemAtSwapBack<T>(this ref FixedList64Bytes<T> fixedList, T item) where T : struct, IEquatable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MC2Push<T>(this ref FixedList64Bytes<T> fixedList, T item) where T : struct, IEquatable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T MC2Pop<T>(this ref FixedList64Bytes<T> fixedList) where T : struct, IEquatable<T>
		{
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MC2Enqueue<T>(this ref FixedList64Bytes<T> fixedList, T item) where T : struct, IEquatable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T MC2Dequque<T>(this ref FixedList64Bytes<T> fixedList) where T : struct, IEquatable<T>
		{
			return default(T);
		}
	}
}
