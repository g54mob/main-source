using System;
using System.Text;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;

namespace Assets.Scripts.Craft.MeshGen
{
	public static class Utils
	{
		public static ProceduralPartMeshRenderer[] Resize(this ProceduralPartMeshRenderer[] array, int newLength, Func<int, ProceduralPartMeshRenderer> create, Action<ProceduralPartMeshRenderer> onPreDestroy = null)
		{
			if (array == null || array.Length < newLength)
			{
				ProceduralPartMeshRenderer[] array2 = new ProceduralPartMeshRenderer[newLength];
				array?.CopyTo(array2.AsSpan(array.Length));
				for (int i = ((array != null) ? array.Length : 0); i < array2.Length; i++)
				{
					array2[i] = create(i);
				}
				return array2;
			}
			if (array.Length > newLength)
			{
				for (int j = newLength; j < array.Length; j++)
				{
					onPreDestroy?.Invoke(array[j]);
					array[j].Destroy();
				}
				ProceduralPartMeshRenderer[] array3 = new ProceduralPartMeshRenderer[newLength];
				array.AsSpan(0, newLength).CopyTo(array3);
				return array3;
			}
			return array;
		}

		public static void Swap<T>(ref T a, ref T b)
		{
			T val = a;
			T val2 = b;
			b = val;
			a = val2;
		}

		public unsafe static void Reverse<T>(this NativeArray<T> array) where T : unmanaged
		{
			int num = array.Length - 1;
			T* unsafePtr = (T*)array.GetUnsafePtr();
			for (int num2 = array.Length / 2 - 1; num2 >= 0; num2--)
			{
				Swap(ref unsafePtr[num2], ref unsafePtr[num - num2]);
			}
		}

		public static RigidTransform GetLocalRigidTransform(this Transform t)
		{
			t.GetLocalPositionAndRotation(out var localPosition, out var localRotation);
			return new RigidTransform
			{
				pos = localPosition,
				rot = localRotation
			};
		}

		public static RigidTransform GetWorldRigidTransform(this Transform t)
		{
			t.GetPositionAndRotation(out var position, out var rotation);
			return new RigidTransform
			{
				pos = position,
				rot = rotation
			};
		}

		public static void SetLocalRigidTransform(this Transform t, RigidTransform rt)
		{
			t.SetLocalPositionAndRotation(rt.pos, rt.rot);
		}

		public static Bounds ToBounds(this MinMaxAABB aabb)
		{
			return new Bounds(aabb.Center, aabb.Max - aabb.Min);
		}

		[BurstDiscard]
		public static string DumpPointList(NativeList<float3> points)
		{
			StringBuilder stringBuilder = new StringBuilder("[");
			for (int i = 0; i < points.Length; i++)
			{
				stringBuilder.Append('(');
				stringBuilder.Append(points[i].x);
				stringBuilder.Append(", ");
				stringBuilder.Append(points[i].y);
				stringBuilder.Append(", ");
				stringBuilder.Append(points[i].z);
				stringBuilder.Append(')');
				if (i < points.Length - 1)
				{
					stringBuilder.Append(", ");
				}
			}
			return stringBuilder.ToString();
		}

		[BurstDiscard]
		public static string DumpPointList(NativeList<float2> points)
		{
			StringBuilder stringBuilder = new StringBuilder("[");
			for (int i = 0; i < points.Length; i++)
			{
				stringBuilder.Append('(');
				stringBuilder.Append(points[i].x);
				stringBuilder.Append(", ");
				stringBuilder.Append(points[i].y);
				stringBuilder.Append(')');
				if (i < points.Length - 1)
				{
					stringBuilder.Append(", ");
				}
			}
			return stringBuilder.ToString();
		}

		[BurstDiscard]
		public static string PointsToCSV(float2[] points)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < points.Length; i++)
			{
				float2 float5 = points[i];
				stringBuilder.AppendLine($"{float5.x:F10},{float5.y:F10}");
			}
			return stringBuilder.ToString();
		}

		[BurstDiscard]
		public static string PointsToCSV(float3[] points)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < points.Length; i++)
			{
				float3 float5 = points[i];
				stringBuilder.AppendLine($"{float5.x:F10},{float5.y:F10},{float5.z:F10}");
			}
			return stringBuilder.ToString();
		}

		[BurstDiscard]
		public static string PointsToCSV(NativeArray<float3> points)
		{
			return PointsToCSV(points.ToArray());
		}

		[BurstDiscard]
		public static string PointsToCSV(NativeArray<float2> points)
		{
			return PointsToCSV(points.ToArray());
		}

		[BurstDiscard]
		public static string PointsToCSV(NativeSlice<float3> points)
		{
			return PointsToCSV(points.ToArray());
		}

		[BurstDiscard]
		public static string PointsToCSV(NativeSlice<float2> points)
		{
			return PointsToCSV(points.ToArray());
		}

		[BurstDiscard]
		public static string PointsToCSV(NativeList<float3> points)
		{
			return PointsToCSV(points.AsArray().ToArray());
		}

		[BurstDiscard]
		public static string PointsToCSV(NativeList<float2> points)
		{
			return PointsToCSV(points.AsArray().ToArray());
		}
	}
}
