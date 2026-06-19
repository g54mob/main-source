using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Aggro.Core
{
	public static class Hash
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Calculate(int value1, int value2)
		{
			return (int)((((((((((((((uint)((0x50C5D1F ^ (value1 & 0xFF)) * 16777619) ^ ((uint)(value1 & 0xFF00) >> 8)) * 16777619) ^ ((uint)(value1 & 0xFF0000) >> 16)) * 16777619) ^ ((uint)(value1 & -16777216) >> 24)) * 16777619) ^ (uint)(value2 & 0xFF)) * 16777619) ^ ((uint)(value2 & 0xFF00) >> 8)) * 16777619) ^ ((uint)(value2 & 0xFF0000) >> 16)) * 16777619) ^ ((uint)(value2 & -16777216) >> 24));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Calculate(int value1, int value2, int value3)
		{
			return Calculate(value1, Calculate(value2, value3));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Calculate(int value1, int value2, int value3, int value4)
		{
			return Calculate(Calculate(value1, value2), Calculate(value3, value4));
		}

		public unsafe static int CalculateStruct<T>(T value) where T : struct
		{
			return Calculate(UnsafeUtility.AddressOf(ref value), UnsafeUtility.SizeOf<T>());
		}

		public unsafe static int Calculate<T>(NativeArray<T> array, int seed = 0) where T : struct
		{
			return Calculate(array.GetUnsafeReadOnlyPtr(), UnsafeUtility.SizeOf<T>() * array.Length, seed);
		}

		public unsafe static int Calculate(void* ptr, int sizeInBytes, int seed = 0)
		{
			return (int)XXHash.Hash32((byte*)ptr, sizeInBytes, (uint)seed);
		}

		public unsafe static int Calculate(string s, int seed = 0)
		{
			if (string.IsNullOrEmpty(s))
			{
				return seed;
			}
			fixed (void* buffer = s)
			{
				return Calculate(s.Length, (int)XXHash.Hash32((byte*)buffer, s.Length * 2, (uint)seed));
			}
		}

		public static int Calculate(Type type, int seed = 0)
		{
			if (type == null)
			{
				return seed;
			}
			return Calculate(type.AssemblyQualifiedName, seed);
		}
	}
}
