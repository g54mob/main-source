using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Pathfinding
{
	[BurstCompile]
	internal static class NavmeshCutJobs
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate void CalculateContourDelegate(JobCalculateContour* job);

		public struct JobCalculateContour
		{
			public unsafe UnsafeList<float2>* outputVertices;

			public unsafe UnsafeList<NavmeshCut.ContourBurst>* outputContours;

			public unsafe UnsafeList<NavmeshCut.ContourBurst>* meshContours;

			public unsafe UnsafeList<float3>* meshContourVertices;

			public float4x4 matrix;

			public float4x4 localToWorldMatrix;

			public float radiusMargin;

			public int circleResolution;

			public float circleRadius;

			public float2 rectangleSize;

			public float height;

			public float meshScale;

			public NavmeshCut.MeshType meshType;

			public unsafe void Execute()
			{
				circleResolution = math.max(circleResolution, 3);
				float4x4 a = math.mul(matrix, localToWorldMatrix);
				float num = math.length(a.c0);
				float num2 = math.length(a.c1);
				float num3 = math.length(a.c2);
				switch (meshType)
				{
				case NavmeshCut.MeshType.Rectangle:
				{
					rectangleSize = new float2(math.abs(rectangleSize.x), math.abs(rectangleSize.y)) + math.rcp(new float2(num, num3)) * radiusMargin * 2f;
					outputVertices->Add(math.transform(a, new float3(0f - rectangleSize.x, 0f, 0f - rectangleSize.y) * 0.5f).xz);
					outputVertices->Add(math.transform(a, new float3(rectangleSize.x, 0f, 0f - rectangleSize.y) * 0.5f).xz);
					outputVertices->Add(math.transform(a, new float3(rectangleSize.x, 0f, rectangleSize.y) * 0.5f).xz);
					outputVertices->Add(math.transform(a, new float3(0f - rectangleSize.x, 0f, rectangleSize.y) * 0.5f).xz);
					float y4 = a.c3.y;
					UnsafeList<NavmeshCut.ContourBurst>* intPtr5 = outputContours;
					NavmeshCut.ContourBurst value = new NavmeshCut.ContourBurst
					{
						ymin = y4 - height * 0.5f * num2,
						ymax = y4 + height * 0.5f * num2,
						startIndex = outputVertices->Length - 4,
						endIndex = outputVertices->Length
					};
					intPtr5->Add(in value);
					break;
				}
				case NavmeshCut.MeshType.Sphere:
				{
					circleRadius = math.abs(circleRadius);
					a = math.mul(matrix, float4x4.Translate(localToWorldMatrix.c3.xyz));
					float num9 = math.max(num, math.max(num2, num3));
					num2 = (num3 = num9);
					a = math.mul(a, float4x4.Scale(num9));
					float radius2 = circleRadius + radiusMargin / num9;
					radius2 = ApproximateCircleWithPolylineRadius(radius2, circleResolution);
					float num10 = MathF.PI * 2f / (float)circleResolution;
					for (int l = 0; l < circleResolution; l++)
					{
						math.sincos((float)l * num10, out var s2, out var c2);
						outputVertices->Add(math.transform(a, new float3(c2 * radius2, 0f, s2 * radius2)).xz);
					}
					float y3 = a.c3.y;
					UnsafeList<NavmeshCut.ContourBurst>* intPtr4 = outputContours;
					NavmeshCut.ContourBurst value = new NavmeshCut.ContourBurst
					{
						ymin = y3 - radius2 * num9,
						ymax = y3 + radius2 * num9,
						startIndex = outputVertices->Length - circleResolution,
						endIndex = outputVertices->Length
					};
					intPtr4->Add(in value);
					break;
				}
				case NavmeshCut.MeshType.Circle:
				{
					circleRadius = math.abs(circleRadius);
					float num5 = height + radiusMargin / num2;
					float num6 = circleRadius + radiusMargin / num;
					float num7 = circleRadius + radiusMargin / num3;
					float num8 = MathF.PI * 2f / (float)circleResolution;
					for (int k = 0; k < circleResolution; k++)
					{
						math.sincos((float)k * num8, out var s, out var c);
						outputVertices->Add(math.transform(a, new float3(c * num6, 0f, s * num7)).xz);
					}
					float y2 = a.c3.y;
					UnsafeList<NavmeshCut.ContourBurst>* intPtr3 = outputContours;
					NavmeshCut.ContourBurst value = new NavmeshCut.ContourBurst
					{
						ymin = y2 - num5 * 0.5f * num2,
						ymax = y2 + num5 * 0.5f * num2,
						startIndex = outputVertices->Length - circleResolution,
						endIndex = outputVertices->Length
					};
					intPtr3->Add(in value);
					break;
				}
				case NavmeshCut.MeshType.CustomMesh:
					if (meshContours != null && meshContourVertices != null && meshScale > 0f)
					{
						a = math.mul(a, float4x4.Scale(new float3(meshScale)));
						int length = outputVertices->Length;
						for (int i = 0; i < meshContourVertices->Length; i++)
						{
							outputVertices->Add(math.transform(a, meshContourVertices->ElementAt(i)).xz);
						}
						float y = a.c3.y;
						for (int j = 0; j < meshContours->Length; j++)
						{
							outputContours->Add(new NavmeshCut.ContourBurst
							{
								ymin = y - height * 0.5f * num2,
								ymax = y + height * 0.5f * num2,
								startIndex = length + meshContours->ElementAt(j).startIndex,
								endIndex = length + meshContours->ElementAt(j).endIndex
							});
						}
					}
					break;
				case NavmeshCut.MeshType.Box:
				{
					float3 scales = new float3(rectangleSize.x, height, rectangleSize.y) + math.rcp(new float3(num, num2, num3)) * radiusMargin * 2f;
					a = math.mul(a, float4x4.Scale(scales));
					BoxConvexHullXZ(a, outputVertices, out var numPoints2, out var minY2, out var maxY2);
					UnsafeList<NavmeshCut.ContourBurst>* intPtr2 = outputContours;
					NavmeshCut.ContourBurst value = new NavmeshCut.ContourBurst
					{
						ymin = minY2,
						ymax = maxY2,
						startIndex = outputVertices->Length - numPoints2,
						endIndex = outputVertices->Length
					};
					intPtr2->Add(in value);
					break;
				}
				case NavmeshCut.MeshType.Capsule:
				{
					circleResolution = math.max(circleResolution, 6);
					float radius = circleRadius;
					float num4 = height;
					num4 *= num2;
					a = math.mul(a, float4x4.Scale(new float3(1f, 1f / num2, 1f)));
					CapsuleConvexHullXZ(a, outputVertices, num4, radius, radiusMargin, circleResolution, out var numPoints, out var minY, out var maxY);
					UnsafeList<NavmeshCut.ContourBurst>* intPtr = outputContours;
					NavmeshCut.ContourBurst value = new NavmeshCut.ContourBurst
					{
						ymin = minY,
						ymax = maxY,
						startIndex = outputVertices->Length - numPoints,
						endIndex = outputVertices->Length
					};
					intPtr->Add(in value);
					break;
				}
				}
				for (int m = 0; m < outputContours->Length; m++)
				{
					NavmeshCut.ContourBurst contourBurst = outputContours->ElementAt(m);
					WindCounterClockwise(outputVertices, contourBurst.startIndex, contourBurst.endIndex);
				}
			}

			private unsafe void WindCounterClockwise(UnsafeList<float2>* vertices, int startIndex, int endIndex)
			{
				int num = 0;
				float2 float5 = new float2(float.PositiveInfinity, float.PositiveInfinity);
				for (int i = startIndex; i < endIndex; i++)
				{
					float2 float6 = vertices->ElementAt(i);
					if (float6.x < float5.x || (float6.x == float5.x && float6.y < float5.y))
					{
						num = i;
						float5 = float6;
					}
				}
				int num2 = endIndex - startIndex;
				float2 float7 = (*vertices)[(num - 1 - startIndex + num2) % num2 + startIndex];
				float2 float8 = float5;
				float2 float9 = (*vertices)[(num + 1 - startIndex) % num2 + startIndex];
				if ((float8.x - float7.x) * (float9.y - float7.y) - (float9.x - float7.x) * (float8.y - float7.y) > 0f)
				{
					int num3 = startIndex;
					int num4 = endIndex - 1;
					while (num3 < num4)
					{
						float2 float10 = vertices->ElementAt(num3);
						vertices->ElementAt(num3) = vertices->ElementAt(num4);
						vertices->ElementAt(num4) = float10;
						num3++;
						num4--;
					}
				}
			}
		}

		private struct AngleComparator : IComparer<float2>
		{
			public float2 origin;

			public int Compare(float2 lhs, float2 rhs)
			{
				float2 x = lhs - origin;
				float2 x2 = rhs - origin;
				float num = x.x * x2.y - x.y * x2.x;
				if (num == 0f)
				{
					float num2 = math.lengthsq(x);
					float num3 = math.lengthsq(x2);
					if (!(num2 < num3))
					{
						if (!(num3 < num2))
						{
							return 0;
						}
						return -1;
					}
					return 1;
				}
				if (!(num < 0f))
				{
					return -1;
				}
				return 1;
			}
		}

		public unsafe delegate void CalculateContour_000008A0_0024PostfixBurstDelegate(JobCalculateContour* job);

		internal static class CalculateContour_000008A0_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(CalculateContour_000008A0_0024PostfixBurstDelegate).TypeHandle);
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

			static CalculateContour_000008A0_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(JobCalculateContour* job)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<JobCalculateContour*, void>)functionPointer)(job);
						return;
					}
				}
				CalculateContour_0024BurstManaged(job);
			}
		}

		private static readonly float4[] BoxCorners = new float4[8]
		{
			new float4(-0.5f, -0.5f, -0.5f, 1f),
			new float4(0.5f, -0.5f, -0.5f, 1f),
			new float4(-0.5f, 0.5f, -0.5f, 1f),
			new float4(0.5f, 0.5f, -0.5f, 1f),
			new float4(-0.5f, -0.5f, 0.5f, 1f),
			new float4(0.5f, -0.5f, 0.5f, 1f),
			new float4(-0.5f, 0.5f, 0.5f, 1f),
			new float4(0.5f, 0.5f, 0.5f, 1f)
		};

		[BurstCompile(FloatPrecision.Standard, FloatMode.Fast)]
		[MonoPInvokeCallback(typeof(CalculateContourDelegate))]
		public unsafe static void CalculateContour(JobCalculateContour* job)
		{
			CalculateContour_000008A0_0024BurstDirectCall.Invoke(job);
		}

		private static float ApproximateCircleWithPolylineRadius(float radius, int resolution)
		{
			return radius / (1f - (1f - math.cos(MathF.PI / (float)resolution)) * 0.5f);
		}

		public unsafe static void CapsuleConvexHullXZ(float4x4 matrix, UnsafeList<float2>* points, float height, float radius, float radiusMargin, int circleResolution, out int numPoints, out float minY, out float maxY)
		{
			height = math.max(height, radius * 2f);
			int num = circleResolution / 2;
			radius = ApproximateCircleWithPolylineRadius(radius, num * 2);
			float x = math.length(matrix.c0.xyz);
			float y = math.length(matrix.c2.xyz);
			radius *= math.max(x, y);
			float3 float5 = math.normalizesafe(matrix.c1.xyz);
			float3 float6 = math.transform(matrix, new float3(0f, (0f - height) * 0.5f, 0f)) + float5 * radius;
			float3 float7 = math.transform(matrix, new float3(0f, height * 0.5f, 0f)) - float5 * radius;
			float2 xz = float6.xz;
			float2 xz2 = float7.xz;
			bool flag = false;
			float2 float8;
			if (math.lengthsq(xz - xz2) < 0.005f)
			{
				float8 = new float2(1f, 0f);
				flag = true;
			}
			else
			{
				float8 = math.normalize(xz2 - xz);
			}
			float2 float9 = new float2(0f - float8.y, float8.x);
			radius += radiusMargin;
			float8 *= radius;
			float9 *= radius;
			minY = math.min(float6.y, float7.y) - radius;
			maxY = math.max(float6.y, float7.y) + radius;
			float num2 = MathF.PI / (float)num;
			if (flag)
			{
				numPoints = num * 2;
				int length = points->Length;
				points->Resize(points->Length + numPoints);
				for (int i = 0; i < num; i++)
				{
					math.sincos((float)i * num2, out var s, out var c);
					float2 float10 = s * float8 + c * float9;
					float2 float11 = xz - float10;
					float2 float12 = xz2 + float10;
					points->ElementAt(length + i) = float11;
					points->ElementAt(length + i + num) = float12;
				}
			}
			else
			{
				numPoints = (num + 1) * 2;
				int length2 = points->Length;
				points->Resize(points->Length + numPoints);
				for (int j = 0; j < num + 1; j++)
				{
					math.sincos((float)j * num2, out var s2, out var c2);
					float2 float13 = s2 * float8 + c2 * float9;
					float2 float14 = xz - float13;
					float2 float15 = xz2 + float13;
					points->ElementAt(length2 + j) = float14;
					points->ElementAt(length2 + j + num + 1) = float15;
				}
			}
		}

		public unsafe static void BoxConvexHullXZ(float4x4 matrix, UnsafeList<float2>* points, out int numPoints, out float minY, out float maxY)
		{
			minY = float.PositiveInfinity;
			maxY = float.NegativeInfinity;
			int length = points->Length;
			points->Resize(points->Length + BoxCorners.Length);
			for (int i = 0; i < BoxCorners.Length; i++)
			{
				float4 float5 = math.mul(matrix, BoxCorners[i]);
				minY = math.min(minY, float5.y);
				maxY = math.max(maxY, float5.y);
				points->ElementAt(length + i) = float5.xz;
			}
			numPoints = ConvexHull(points->Ptr + length, BoxCorners.Length, 0.01f);
			points->Length = length + numPoints;
		}

		public unsafe static int ConvexHull(float2* points, int nPoints, float vertexMergeDistance)
		{
			int num = 0;
			for (int i = 0; i < nPoints; i++)
			{
				if (points[i].x < points[num].x || (points[i].x == points[num].x && points[i].y < points[num].y))
				{
					num = i;
				}
			}
			NativeSortExtension.Sort(points, nPoints, new AngleComparator
			{
				origin = points[num]
			});
			int num2 = 0;
			for (int j = 0; j < nPoints; j++)
			{
				float2 float5 = points[j];
				while (num2 >= 2)
				{
					float2 x = points[num2 - 1] - float5;
					float2 float6 = points[num2 - 2] - float5;
					if (!(x.x * float6.y - x.y * float6.x >= 0f) && !(math.lengthsq(x) < vertexMergeDistance))
					{
						break;
					}
					num2--;
				}
				if (num2 == 1 && math.lengthsq(points[num2 - 1] - float5) < vertexMergeDistance)
				{
					num2--;
				}
				points[num2] = float5;
				num2++;
			}
			return num2;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile(FloatPrecision.Standard, FloatMode.Fast)]
		[MonoPInvokeCallback(typeof(CalculateContourDelegate))]
		public unsafe static void CalculateContour_0024BurstManaged(JobCalculateContour* job)
		{
			job->Execute();
		}
	}
}
