using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MemoryPack.Internal
{
	internal static class TypeHelpers
	{
		private static class Cache<T>
		{
			public static bool IsReferenceOrNullable;

			public static bool IsUnmanagedSZArray;

			public static int UnmanagedSZArrayElementSize;

			public static bool IsFixedSizeMemoryPackable;

			public static int MemoryPackableFixedSize;

			static Cache()
			{
			}
		}

		internal enum TypeKind : byte
		{
			None = 0,
			UnmanagedSZArray = 1,
			FixedSizeMemoryPackable = 2
		}

		private static readonly MethodInfo isReferenceOrContainsReferences;

		private static readonly MethodInfo unsafeSizeOf;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsReferenceOrNullable<T>()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TypeKind TryGetUnmanagedSZArrayElementSizeOrMemoryPackableFixedSize<T>(out int size)
		{
			size = default(int);
			return default(TypeKind);
		}

		public static bool IsAnonymous(Type type)
		{
			return false;
		}
	}
}
