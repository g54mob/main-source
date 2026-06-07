using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.MeshGen
{
	public static class Extensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 With(this float3 v, float? x = null, float? y = null, float? z = null)
		{
			return new float3(x ?? v.x, y ?? v.y, z ?? v.z);
		}

		public static void InsertRange<T>(this NativeList<T> list, int insertBefore, NativeSlice<T> insert) where T : unmanaged
		{
			list.InsertRangeWithBeginEnd(insertBefore, insertBefore + insert.Length);
			list.AsArray().Slice(insertBefore, insert.Length).CopyFrom(insert);
		}

		public static void InsertRange<T>(this NativeList<T> list, int insertBefore, NativeArray<T> insert) where T : unmanaged
		{
			list.InsertRangeWithBeginEnd(insertBefore, insertBefore + insert.Length);
			NativeArray<T>.Copy(insert, 0, list.AsArray(), insertBefore, insert.Length);
		}

		public unsafe static void ReplaceRange<T>(this NativeList<T> list, int start, int length, NativeSlice<T> replaceWith) where T : unmanaged
		{
			int length2 = list.Length;
			int num = length2 - length + replaceWith.Length;
			if (num > list.Length)
			{
				list.Length = num;
			}
			NativeArray<T> nativeArray = list.AsArray();
			int num2 = start + length;
			int num3 = length2 - num2;
			if (num3 > 0)
			{
				int num4 = num2;
				int num5 = num - num3;
				byte* unsafePtr = (byte*)nativeArray.GetUnsafePtr();
				UnsafeUtility.MemMove(unsafePtr + num5 * UnsafeUtility.SizeOf<T>(), unsafePtr + num4 * UnsafeUtility.SizeOf<T>(), num3 * UnsafeUtility.SizeOf<T>());
			}
			nativeArray.Slice(start, replaceWith.Length).CopyFrom(replaceWith);
			if (num != list.Length)
			{
				list.Length = num;
			}
		}

		public static void Reverse<T>(this NativeSlice<T> slice) where T : unmanaged
		{
			int num = 0;
			int num2 = slice.Length - 1;
			while (num < num2)
			{
				int index = num2;
				int index2 = num;
				T val = slice[num];
				T val2 = slice[num2];
				T val3 = (slice[index] = val);
				val3 = (slice[index2] = val2);
				num++;
				num2--;
			}
		}

		public static string ShortStr(this float2 v)
		{
			return $"({v.x},{v.y})";
		}

		public static string ShortStr(this float3 v)
		{
			return $"({v.x},{v.y},{v.z})";
		}

		public static void DisposeIfCreated<T>(this ref NativeList<T> list) where T : unmanaged
		{
			if (list.IsCreated)
			{
				list.Dispose();
				list = default(NativeList<T>);
			}
		}

		public static void DisposeIfCreated<T>(this NativeArray<T> array) where T : unmanaged
		{
			if (array.IsCreated)
			{
				array.Dispose();
			}
		}

		public unsafe static void CopyAttributeToSlice<T>(this Mesh.MeshData meshData, VertexAttribute attribute, NativeSlice<T> dest) where T : unmanaged
		{
			int vertexAttributeStream = meshData.GetVertexAttributeStream(attribute);
			void* source = (void*)((IntPtr)meshData.GetVertexData<byte>(vertexAttributeStream).GetUnsafeReadOnlyPtr() + meshData.GetVertexAttributeOffset(attribute));
			int vertexBufferStride = meshData.GetVertexBufferStride(vertexAttributeStream);
			UnsafeUtility.MemCpyStride(dest.GetUnsafePtr(), dest.Stride, source, vertexBufferStride, sizeof(T), meshData.vertexCount);
		}

		public unsafe static void CopyAttributeFromSlice<T>(this Mesh.MeshData meshData, VertexAttribute attribute, NativeSlice<T> src) where T : unmanaged
		{
			int vertexAttributeStream = meshData.GetVertexAttributeStream(attribute);
			void* destination = (void*)((IntPtr)meshData.GetVertexData<byte>(vertexAttributeStream).GetUnsafeReadOnlyPtr() + meshData.GetVertexAttributeOffset(attribute));
			int vertexBufferStride = meshData.GetVertexBufferStride(vertexAttributeStream);
			UnsafeUtility.MemCpyStride(destination, vertexBufferStride, src.GetUnsafePtr(), src.Stride, sizeof(T), meshData.vertexCount);
		}
	}
}
