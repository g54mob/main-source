using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public static class Polygon
	{
		public delegate bool ContainsPoint_000002C7_0024PostfixBurstDelegate(ref int3 aWorld, ref int3 bWorld, ref int3 cWorld, ref int3 pWorld, ref NativeMovementPlane movementPlane);

		internal static class ContainsPoint_000002C7_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(ContainsPoint_000002C7_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static ContainsPoint_000002C7_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static bool Invoke(ref int3 aWorld, ref int3 bWorld, ref int3 cWorld, ref int3 pWorld, ref NativeMovementPlane movementPlane)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref int3, ref int3, ref int3, ref int3, ref NativeMovementPlane, bool>)functionPointer)(ref aWorld, ref bWorld, ref cWorld, ref pWorld, ref movementPlane);
					}
				}
				return ContainsPoint_0024BurstManaged(ref aWorld, ref bWorld, ref cWorld, ref pWorld, ref movementPlane);
			}
		}

		public delegate bool ClosestPointOnTriangleByRef_000002CE_0024PostfixBurstDelegate(in float3 a, in float3 b, in float3 c, in float3 p, [NoAlias] out float3 output);

		internal static class ClosestPointOnTriangleByRef_000002CE_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(ClosestPointOnTriangleByRef_000002CE_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static ClosestPointOnTriangleByRef_000002CE_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static bool Invoke(in float3 a, in float3 b, in float3 c, in float3 p, [NoAlias] out float3 output)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref float3, ref float3, ref float3, ref float3, ref float3, bool>)functionPointer)(ref a, ref b, ref c, ref p, ref output);
					}
				}
				return ClosestPointOnTriangleByRef_0024BurstManaged(in a, in b, in c, in p, out output);
			}
		}

		public delegate void ClosestPointOnTriangleProjected_000002D0_0024PostfixBurstDelegate(ref Int3 vi1, ref Int3 vi2, ref Int3 vi3, ref BBTree.ProjectionParams projection, ref float3 point, [NoAlias] out float3 closest, [NoAlias] out float sqrDist, [NoAlias] out float distAlongProjection);

		internal static class ClosestPointOnTriangleProjected_000002D0_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(ClosestPointOnTriangleProjected_000002D0_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static ClosestPointOnTriangleProjected_000002D0_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref Int3 vi1, ref Int3 vi2, ref Int3 vi3, ref BBTree.ProjectionParams projection, ref float3 point, [NoAlias] out float3 closest, [NoAlias] out float sqrDist, [NoAlias] out float distAlongProjection)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref Int3, ref Int3, ref Int3, ref BBTree.ProjectionParams, ref float3, ref float3, ref float, ref float, void>)functionPointer)(ref vi1, ref vi2, ref vi3, ref projection, ref point, ref closest, ref sqrDist, ref distAlongProjection);
						return;
					}
				}
				ClosestPointOnTriangleProjected_0024BurstManaged(ref vi1, ref vi2, ref vi3, ref projection, ref point, out closest, out sqrDist, out distAlongProjection);
			}
		}

		private static readonly Dictionary<Int3, int> cached_Int3_int_dict = new Dictionary<Int3, int>();

		public static bool ContainsPointXZ(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
		{
			if (VectorMath.IsClockwiseMarginXZ(a, b, p) && VectorMath.IsClockwiseMarginXZ(b, c, p))
			{
				return VectorMath.IsClockwiseMarginXZ(c, a, p);
			}
			return false;
		}

		public static bool ContainsPointXZ(Int3 a, Int3 b, Int3 c, Int3 p)
		{
			if (VectorMath.IsClockwiseOrColinearXZ(a, b, p) && VectorMath.IsClockwiseOrColinearXZ(b, c, p))
			{
				return VectorMath.IsClockwiseOrColinearXZ(c, a, p);
			}
			return false;
		}

		public static bool ContainsPoint(Int2 a, Int2 b, Int2 c, Int2 p)
		{
			if (VectorMath.IsClockwiseOrColinear(a, b, p) && VectorMath.IsClockwiseOrColinear(b, c, p))
			{
				return VectorMath.IsClockwiseOrColinear(c, a, p);
			}
			return false;
		}

		public static bool ContainsPoint(Vector2[] polyPoints, Vector2 p)
		{
			int num = polyPoints.Length - 1;
			bool flag = false;
			int num2 = 0;
			while (num2 < polyPoints.Length)
			{
				if (((polyPoints[num2].y <= p.y && p.y < polyPoints[num].y) || (polyPoints[num].y <= p.y && p.y < polyPoints[num2].y)) && p.x < (polyPoints[num].x - polyPoints[num2].x) * (p.y - polyPoints[num2].y) / (polyPoints[num].y - polyPoints[num2].y) + polyPoints[num2].x)
				{
					flag = !flag;
				}
				num = num2++;
			}
			return flag;
		}

		public static bool ContainsPointXZ(Vector3[] polyPoints, Vector3 p)
		{
			int num = polyPoints.Length - 1;
			bool flag = false;
			int num2 = 0;
			while (num2 < polyPoints.Length)
			{
				if (((polyPoints[num2].z <= p.z && p.z < polyPoints[num].z) || (polyPoints[num].z <= p.z && p.z < polyPoints[num2].z)) && p.x < (polyPoints[num].x - polyPoints[num2].x) * (p.z - polyPoints[num2].z) / (polyPoints[num].z - polyPoints[num2].z) + polyPoints[num2].x)
				{
					flag = !flag;
				}
				num = num2++;
			}
			return flag;
		}

		[BurstCompile]
		public static bool ContainsPoint(ref int3 aWorld, ref int3 bWorld, ref int3 cWorld, ref int3 pWorld, ref NativeMovementPlane movementPlane)
		{
			return ContainsPoint_000002C7_0024BurstDirectCall.Invoke(ref aWorld, ref bWorld, ref cWorld, ref pWorld, ref movementPlane);
		}

		public static bool ContainsPoint(ref int3 aWorld, ref int3 bWorld, ref int3 cWorld, ref int3 pWorld, in float2x3 planeProjection)
		{
			int2x3 int2x5 = new int2x3(planeProjection * 1024f);
			int4 obj = new int4(aWorld.x, bWorld.x, cWorld.x, pWorld.x);
			int4 int5 = new int4(aWorld.y, bWorld.y, cWorld.y, pWorld.y);
			int4 int6 = new int4(aWorld.z, bWorld.z, cWorld.z, pWorld.z);
			int4 obj2 = obj - obj.x;
			int5 -= int5.x;
			int6 -= int6.x;
			int4 int7 = (obj2 * int2x5.c0.x + int5 * int2x5.c1.x + int6 * int2x5.c2.x) / 1024;
			int4 int8 = (obj2 * int2x5.c0.y + int5 * int2x5.c1.y + int6 * int2x5.c2.y) / 1024;
			int3 obj3 = int7.yzx - int7.xyz;
			int3 int9 = int8.www - int8.xyz;
			int3 int10 = int7.www - int7.xyz;
			int3 int11 = int8.yzx - int8.xyz;
			long num = (long)obj3.x * (long)int9.x - (long)int10.x * (long)int11.x;
			long num2 = (long)obj3.y * (long)int9.y - (long)int10.y * (long)int11.y;
			long num3 = (long)obj3.z * (long)int9.z - (long)int10.z * (long)int11.z;
			return (num >= 0 && num2 >= 0 && num3 >= 0) || (num <= 0 && num2 <= 0 && num3 <= 0);
		}

		public static int SampleYCoordinateInTriangle(Int3 p1, Int3 p2, Int3 p3, Int3 p)
		{
			double num = (double)(p2.z - p3.z) * (double)(p1.x - p3.x) + (double)(p3.x - p2.x) * (double)(p1.z - p3.z);
			double num2 = ((double)(p2.z - p3.z) * (double)(p.x - p3.x) + (double)(p3.x - p2.x) * (double)(p.z - p3.z)) / num;
			double num3 = ((double)(p3.z - p1.z) * (double)(p.x - p3.x) + (double)(p1.x - p3.x) * (double)(p.z - p3.z)) / num;
			return (int)Math.Round(num2 * (double)p1.y + num3 * (double)p2.y + (1.0 - num2 - num3) * (double)p3.y);
		}

		public static Vector3[] ConvexHullXZ(Vector3[] points)
		{
			if (points.Length == 0)
			{
				return new Vector3[0];
			}
			List<Vector3> list = ListPool<Vector3>.Claim();
			int num = 0;
			for (int i = 1; i < points.Length; i++)
			{
				if (points[i].x < points[num].x)
				{
					num = i;
				}
			}
			int num2 = num;
			int num3 = 0;
			do
			{
				list.Add(points[num]);
				int num4 = 0;
				for (int j = 0; j < points.Length; j++)
				{
					if (num4 == num || !VectorMath.RightOrColinearXZ(points[num], points[num4], points[j]))
					{
						num4 = j;
					}
				}
				num = num4;
				num3++;
				if (num3 > 10000)
				{
					Debug.LogWarning("Infinite Loop in Convex Hull Calculation");
					break;
				}
			}
			while (num != num2);
			Vector3[] result = list.ToArray();
			ListPool<Vector3>.Release(list);
			return result;
		}

		public static Vector2 ClosestPointOnTriangle(Vector2 a, Vector2 b, Vector2 c, Vector2 p)
		{
			Vector2 vector = b - a;
			Vector2 vector2 = c - a;
			Vector2 rhs = p - a;
			float num = Vector2.Dot(vector, rhs);
			float num2 = Vector2.Dot(vector2, rhs);
			if (num <= 0f && num2 <= 0f)
			{
				return a;
			}
			Vector2 rhs2 = p - b;
			float num3 = Vector2.Dot(vector, rhs2);
			float num4 = Vector2.Dot(vector2, rhs2);
			if (num3 >= 0f && num4 <= num3)
			{
				return b;
			}
			if (num >= 0f && num3 <= 0f && num * num4 - num3 * num2 <= 0f)
			{
				float num5 = num / (num - num3);
				return a + vector * num5;
			}
			Vector2 rhs3 = p - c;
			float num6 = Vector2.Dot(vector, rhs3);
			float num7 = Vector2.Dot(vector2, rhs3);
			if (num7 >= 0f && num6 <= num7)
			{
				return c;
			}
			if (num2 >= 0f && num7 <= 0f && num6 * num2 - num * num7 <= 0f)
			{
				float num8 = num2 / (num2 - num7);
				return a + vector2 * num8;
			}
			if (num4 - num3 >= 0f && num6 - num7 >= 0f && num3 * num7 - num6 * num4 <= 0f)
			{
				float num9 = (num4 - num3) / (num4 - num3 + (num6 - num7));
				return b + (c - b) * num9;
			}
			return p;
		}

		public static Vector3 ClosestPointOnTriangleXZ(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
		{
			Vector2 lhs = new Vector2(b.x - a.x, b.z - a.z);
			Vector2 lhs2 = new Vector2(c.x - a.x, c.z - a.z);
			Vector2 rhs = new Vector2(p.x - a.x, p.z - a.z);
			float num = Vector2.Dot(lhs, rhs);
			float num2 = Vector2.Dot(lhs2, rhs);
			if (num <= 0f && num2 <= 0f)
			{
				return a;
			}
			Vector2 rhs2 = new Vector2(p.x - b.x, p.z - b.z);
			float num3 = Vector2.Dot(lhs, rhs2);
			float num4 = Vector2.Dot(lhs2, rhs2);
			if (num3 >= 0f && num4 <= num3)
			{
				return b;
			}
			float num5 = num * num4 - num3 * num2;
			if (num >= 0f && num3 <= 0f && num5 <= 0f)
			{
				float num6 = num / (num - num3);
				return (1f - num6) * a + num6 * b;
			}
			Vector2 rhs3 = new Vector2(p.x - c.x, p.z - c.z);
			float num7 = Vector2.Dot(lhs, rhs3);
			float num8 = Vector2.Dot(lhs2, rhs3);
			if (num8 >= 0f && num7 <= num8)
			{
				return c;
			}
			float num9 = num7 * num2 - num * num8;
			if (num2 >= 0f && num8 <= 0f && num9 <= 0f)
			{
				float num10 = num2 / (num2 - num8);
				return (1f - num10) * a + num10 * c;
			}
			float num11 = num3 * num8 - num7 * num4;
			if (num4 - num3 >= 0f && num7 - num8 >= 0f && num11 <= 0f)
			{
				float num12 = (num4 - num3) / (num4 - num3 + (num7 - num8));
				return b + (c - b) * num12;
			}
			float num13 = 1f / (num11 + num9 + num5);
			float num14 = num9 * num13;
			float num15 = num5 * num13;
			return new Vector3(p.x, (1f - num14 - num15) * a.y + num14 * b.y + num15 * c.y, p.z);
		}

		public static float3 ClosestPointOnTriangle(float3 a, float3 b, float3 c, float3 p)
		{
			ClosestPointOnTriangleByRef(in a, in b, in c, in p, out var output);
			return output;
		}

		[BurstCompile]
		public static bool ClosestPointOnTriangleByRef(in float3 a, in float3 b, in float3 c, in float3 p, [NoAlias] out float3 output)
		{
			return ClosestPointOnTriangleByRef_000002CE_0024BurstDirectCall.Invoke(in a, in b, in c, in p, out output);
		}

		public static float3 ClosestPointOnTriangleBarycentric(float2 a, float2 b, float2 c, float2 p)
		{
			float2 x = b - a;
			float2 x2 = c - a;
			float2 y = p - a;
			float num = math.dot(x, y);
			float num2 = math.dot(x2, y);
			if (num <= 0f && num2 <= 0f)
			{
				return new float3(1f, 0f, 0f);
			}
			float2 y2 = p - b;
			float num3 = math.dot(x, y2);
			float num4 = math.dot(x2, y2);
			if (num3 >= 0f && num4 <= num3)
			{
				return new float3(0f, 1f, 0f);
			}
			float num5 = num * num4 - num3 * num2;
			if (num >= 0f && num3 <= 0f && num5 <= 0f)
			{
				float num6 = num / (num - num3);
				return new float3(1f - num6, num6, 0f);
			}
			float2 y3 = p - c;
			float num7 = math.dot(x, y3);
			float num8 = math.dot(x2, y3);
			if (num8 >= 0f && num7 <= num8)
			{
				return new float3(0f, 0f, 1f);
			}
			float num9 = num7 * num2 - num * num8;
			if (num2 >= 0f && num8 <= 0f && num9 <= 0f)
			{
				float num10 = num2 / (num2 - num8);
				return new float3(1f - num10, 0f, num10);
			}
			float num11 = num3 * num8 - num7 * num4;
			if (num4 - num3 >= 0f && num7 - num8 >= 0f && num11 <= 0f)
			{
				float num12 = (num4 - num3) / (num4 - num3 + (num7 - num8));
				return new float3(0f, 1f - num12, num12);
			}
			float num13 = 1f / (num11 + num9 + num5);
			float num14 = num9 * num13;
			float num15 = num5 * num13;
			return new float3(1f - num14 - num15, num14, num15);
		}

		[BurstCompile]
		public static void ClosestPointOnTriangleProjected(ref Int3 vi1, ref Int3 vi2, ref Int3 vi3, ref BBTree.ProjectionParams projection, ref float3 point, [NoAlias] out float3 closest, [NoAlias] out float sqrDist, [NoAlias] out float distAlongProjection)
		{
			ClosestPointOnTriangleProjected_000002D0_0024BurstDirectCall.Invoke(ref vi1, ref vi2, ref vi3, ref projection, ref point, out closest, out sqrDist, out distAlongProjection);
		}

		public static void CompressMesh(List<Int3> vertices, List<int> triangles, List<uint> tags, out Int3[] outVertices, out int[] outTriangles, out uint[] outTags)
		{
			Dictionary<Int3, int> dictionary = cached_Int3_int_dict;
			dictionary.Clear();
			int[] array = ArrayPool<int>.Claim(vertices.Count);
			int num = 0;
			for (int i = 0; i < vertices.Count; i++)
			{
				if (!dictionary.TryGetValue(vertices[i], out var value) && !dictionary.TryGetValue(vertices[i] + new Int3(0, 1, 0), out value) && !dictionary.TryGetValue(vertices[i] + new Int3(0, -1, 0), out value))
				{
					dictionary.Add(vertices[i], num);
					array[i] = num;
					vertices[num] = vertices[i];
					num++;
				}
				else
				{
					array[i] = value;
				}
			}
			outTriangles = new int[triangles.Count];
			for (int j = 0; j < outTriangles.Length; j++)
			{
				outTriangles[j] = array[triangles[j]];
			}
			outVertices = new Int3[num];
			for (int k = 0; k < num; k++)
			{
				outVertices[k] = vertices[k];
			}
			ArrayPool<int>.Release(ref array);
			outTags = tags.ToArray();
		}

		public static void TraceContours(Dictionary<int, int> outline, HashSet<int> hasInEdge, Action<List<int>, bool> results)
		{
			List<int> list = ListPool<int>.Claim();
			List<int> list2 = ListPool<int>.Claim();
			list2.AddRange(outline.Keys);
			for (int i = 0; i <= 1; i++)
			{
				bool flag = i == 1;
				for (int j = 0; j < list2.Count; j++)
				{
					int num = list2[j];
					if (!flag && hasInEdge.Contains(num))
					{
						continue;
					}
					int num2 = num;
					list.Clear();
					list.Add(num2);
					while (outline.ContainsKey(num2))
					{
						int num3 = outline[num2];
						outline.Remove(num2);
						list.Add(num3);
						if (num3 == num)
						{
							break;
						}
						num2 = num3;
					}
					if (list.Count > 1)
					{
						results(list, flag);
					}
				}
			}
			ListPool<int>.Release(ref list2);
			ListPool<int>.Release(ref list);
		}

		public static void Subdivide(List<Vector3> points, List<Vector3> result, int subSegments)
		{
			for (int i = 0; i < points.Count - 1; i++)
			{
				for (int j = 0; j < subSegments; j++)
				{
					result.Add(Vector3.Lerp(points[i], points[i + 1], (float)j / (float)subSegments));
				}
			}
			result.Add(points[points.Count - 1]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static bool ContainsPoint_0024BurstManaged(ref int3 aWorld, ref int3 bWorld, ref int3 cWorld, ref int3 pWorld, ref NativeMovementPlane movementPlane)
		{
			float3x3 float3x5 = new float3x3(movementPlane.rotation.value);
			return ContainsPoint(ref aWorld, ref bWorld, ref cWorld, ref pWorld, math.transpose(new float3x2(float3x5.c0, float3x5.c2)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static bool ClosestPointOnTriangleByRef_0024BurstManaged(in float3 a, in float3 b, in float3 c, in float3 p, [NoAlias] out float3 output)
		{
			float3 float5 = b - a;
			float3 float6 = c - a;
			float3 y = p - a;
			float num = math.dot(float5, y);
			float num2 = math.dot(float6, y);
			if (num <= 0f && num2 <= 0f)
			{
				output = a;
				return false;
			}
			float3 y2 = p - b;
			float num3 = math.dot(float5, y2);
			float num4 = math.dot(float6, y2);
			if (num3 >= 0f && num4 <= num3)
			{
				output = b;
				return false;
			}
			float num5 = num * num4 - num3 * num2;
			if (num >= 0f && num3 <= 0f && num5 <= 0f)
			{
				float num6 = num / (num - num3);
				output = a + float5 * num6;
				return false;
			}
			float3 y3 = p - c;
			float num7 = math.dot(float5, y3);
			float num8 = math.dot(float6, y3);
			if (num8 >= 0f && num7 <= num8)
			{
				output = c;
				return false;
			}
			float num9 = num7 * num2 - num * num8;
			if (num2 >= 0f && num8 <= 0f && num9 <= 0f)
			{
				float num10 = num2 / (num2 - num8);
				output = a + float6 * num10;
				return false;
			}
			float num11 = num3 * num8 - num7 * num4;
			if (num4 - num3 >= 0f && num7 - num8 >= 0f && num11 <= 0f)
			{
				float num12 = (num4 - num3) / (num4 - num3 + (num7 - num8));
				output = b + (c - b) * num12;
				return false;
			}
			float num13 = 1f / (num11 + num9 + num5);
			float num14 = num9 * num13;
			float num15 = num5 * num13;
			output = a + float5 * num14 + float6 * num15;
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void ClosestPointOnTriangleProjected_0024BurstManaged(ref Int3 vi1, ref Int3 vi2, ref Int3 vi3, ref BBTree.ProjectionParams projection, ref float3 point, [NoAlias] out float3 closest, [NoAlias] out float sqrDist, [NoAlias] out float distAlongProjection)
		{
			float3 float5 = (float3)vi1;
			float3 float6 = (float3)vi2;
			float3 float7 = (float3)vi3;
			float2 obj = math.mul(projection.planeProjection, float5);
			float2 float8 = math.mul(projection.planeProjection, float6);
			float2 float9 = math.mul(projection.planeProjection, float7);
			float2 float10 = math.mul(projection.planeProjection, point);
			float3 float11 = ClosestPointOnTriangleBarycentric(obj, float8, float9, float10);
			closest = float5 * float11.x + float6 * float11.y + float7 * float11.z;
			float2 obj2 = obj * float11.x + float8 * float11.y + float9 * float11.z;
			distAlongProjection = math.abs(math.dot(closest - point, projection.projectionAxis));
			float num = math.length(obj2 - float10);
			if (num < 0.01f)
			{
				int3 aWorld = (int3)vi1;
				int3 bWorld = (int3)vi2;
				int3 cWorld = (int3)vi3;
				int3 pWorld = (int3)(Int3)(Vector3)point;
				if (ContainsPoint(ref aWorld, ref bWorld, ref cWorld, ref pWorld, in projection.planeProjection))
				{
					num = 0f;
				}
			}
			float num2 = num + distAlongProjection * projection.distanceScaleAlongProjectionAxis;
			sqrDist = num2 * num2;
		}
	}
}
