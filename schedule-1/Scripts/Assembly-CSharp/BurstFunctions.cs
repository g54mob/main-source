using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;

[BurstCompile]
public static class BurstFunctions
{
	public delegate void Average_0000004B_0024PostfixBurstDelegate(ref NativeArray<float> arr, out float result);

	internal static class Average_0000004B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		private static IntPtr DeferredCompilation;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
		}

		private static IntPtr GetFunctionPointer()
		{
			return (IntPtr)0;
		}

		public static void Constructor()
		{
		}

		public static void Initialize()
		{
		}

		public static void Invoke(ref NativeArray<float> arr, out float result)
		{
			result = default(float);
		}
	}

	public delegate void Average_0000004C_0024PostfixBurstDelegate(ref NativeArray<Vector3> arr, out Vector3 result);

	internal static class Average_0000004C_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		private static IntPtr DeferredCompilation;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
		}

		private static IntPtr GetFunctionPointer()
		{
			return (IntPtr)0;
		}

		public static void Constructor()
		{
		}

		public static void Initialize()
		{
		}

		public static void Invoke(ref NativeArray<Vector3> arr, out Vector3 result)
		{
			result = default(Vector3);
		}
	}

	[BurstCompile]
	public static void Average(ref NativeArray<float> arr, out float result)
	{
		result = default(float);
	}

	[BurstCompile]
	public static void Average(ref NativeArray<Vector3> arr, out Vector3 result)
	{
		result = default(Vector3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	public static void Average_0024BurstManaged(ref NativeArray<float> arr, out float result)
	{
		result = default(float);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	public static void Average_0024BurstManaged(ref NativeArray<Vector3> arr, out Vector3 result)
	{
		result = default(Vector3);
	}
}
