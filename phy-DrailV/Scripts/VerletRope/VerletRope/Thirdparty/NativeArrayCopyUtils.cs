using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace VerletRope.Thirdparty
{
	public static class NativeArrayCopyUtils
	{
		public unsafe static NativeArray<int> GetNativeArray(int[] source)
		{
			NativeArray<int> nativeArray = new NativeArray<int>(source.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			fixed (int* ptr = source)
			{
				void* source2 = ptr;
				UnsafeUtility.MemCpy(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(nativeArray), source2, (long)source.Length * (long)UnsafeUtility.SizeOf<int>());
			}
			return nativeArray;
		}

		public unsafe static void CopyFromNativeArray(NativeArray<int> source, int[] target)
		{
			fixed (int* ptr = target)
			{
				void* destination = ptr;
				UnsafeUtility.MemCpy(destination, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(source), (long)target.Length * (long)UnsafeUtility.SizeOf<int>());
			}
		}

		public unsafe static NativeArray<float> GetNativeArray(float[] source)
		{
			NativeArray<float> nativeArray = new NativeArray<float>(source.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			fixed (float* ptr = source)
			{
				void* source2 = ptr;
				UnsafeUtility.MemCpy(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(nativeArray), source2, (long)source.Length * (long)UnsafeUtility.SizeOf<float>());
			}
			return nativeArray;
		}

		public unsafe static void CopyFromNativeArray(NativeArray<float> source, float[] target)
		{
			fixed (float* ptr = target)
			{
				void* destination = ptr;
				UnsafeUtility.MemCpy(destination, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(source), (long)target.Length * (long)UnsafeUtility.SizeOf<float>());
			}
		}

		public unsafe static NativeArray<float2> GetNativeArray(Vector2[] source)
		{
			NativeArray<float2> nativeArray = new NativeArray<float2>(source.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			fixed (Vector2* ptr = source)
			{
				void* source2 = ptr;
				UnsafeUtility.MemCpy(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(nativeArray), source2, (long)source.Length * (long)UnsafeUtility.SizeOf<float2>());
			}
			return nativeArray;
		}

		public unsafe static void CopyFromNativeArray(NativeArray<float2> source, Vector2[] target)
		{
			fixed (Vector2* ptr = target)
			{
				void* destination = ptr;
				UnsafeUtility.MemCpy(destination, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(source), (long)target.Length * (long)UnsafeUtility.SizeOf<float2>());
			}
		}

		public unsafe static NativeArray<float3> GetNativeArray(Vector3[] source)
		{
			NativeArray<float3> nativeArray = new NativeArray<float3>(source.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			fixed (Vector3* ptr = source)
			{
				void* source2 = ptr;
				UnsafeUtility.MemCpy(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(nativeArray), source2, (long)source.Length * (long)UnsafeUtility.SizeOf<float3>());
			}
			return nativeArray;
		}

		public unsafe static void CopyFromNativeArray(NativeArray<float3> source, Vector3[] target)
		{
			fixed (Vector3* ptr = target)
			{
				void* destination = ptr;
				UnsafeUtility.MemCpy(destination, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(source), (long)target.Length * (long)UnsafeUtility.SizeOf<float3>());
			}
		}

		public unsafe static NativeArray<float4> GetNativeArray(Vector4[] source)
		{
			NativeArray<float4> nativeArray = new NativeArray<float4>(source.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			fixed (Vector4* ptr = source)
			{
				void* source2 = ptr;
				UnsafeUtility.MemCpy(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(nativeArray), source2, (long)source.Length * (long)UnsafeUtility.SizeOf<float4>());
			}
			return nativeArray;
		}

		public unsafe static void CopyFromNativeArray(NativeArray<float4> source, Vector4[] target)
		{
			fixed (Vector4* ptr = target)
			{
				void* destination = ptr;
				UnsafeUtility.MemCpy(destination, NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(source), (long)target.Length * (long)UnsafeUtility.SizeOf<float4>());
			}
		}

		public unsafe static void CopyToNativeArray(Plane[] source, NativeArray<BurstPlane> target)
		{
			fixed (Plane* ptr = source)
			{
				void* source2 = ptr;
				UnsafeUtility.MemCpy(NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(target), source2, (long)target.Length * (long)UnsafeUtility.SizeOf<Plane>());
			}
		}
	}
}
