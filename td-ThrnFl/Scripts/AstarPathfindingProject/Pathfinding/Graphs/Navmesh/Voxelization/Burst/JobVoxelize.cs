using System;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	public struct JobVoxelize : IJob
	{
		[ReadOnly]
		public NativeArray<RasterizationMesh> inputMeshes;

		[ReadOnly]
		public NativeArray<int> bucket;

		public int voxelWalkableClimb;

		public uint voxelWalkableHeight;

		public float cellSize;

		public float cellHeight;

		public float maxSlope;

		public Matrix4x4 graphTransform;

		public Bounds graphSpaceBounds;

		public Vector2 graphSpaceLimits;

		public LinkedVoxelField voxelArea;

		public unsafe void Execute()
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(graphSpaceBounds.min, Quaternion.identity, Vector3.one) * Matrix4x4.Scale(new Vector3(cellSize, cellHeight, cellSize));
			Matrix4x4 inverse = (graphTransform * matrix4x * Matrix4x4.Translate(new Vector3(0.5f, 0f, 0.5f))).inverse;
			float num = math.cos(math.atan(cellSize / cellHeight * math.tan(maxSlope * (MathF.PI / 180f))));
			VoxelPolygonClipper voxelPolygonClipper = default(VoxelPolygonClipper);
			VoxelPolygonClipper result = default(VoxelPolygonClipper);
			VoxelPolygonClipper result2 = default(VoxelPolygonClipper);
			VoxelPolygonClipper result3 = default(VoxelPolygonClipper);
			VoxelPolygonClipper result4 = default(VoxelPolygonClipper);
			int num2 = 0;
			for (int i = 0; i < bucket.Length; i++)
			{
				num2 = math.max(inputMeshes[bucket[i]].vertices.Length, num2);
			}
			NativeArray<float3> nativeArray = new NativeArray<float3>(num2, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			int width = voxelArea.width;
			int depth = voxelArea.depth;
			int num3 = Mathf.Min(width - 1, float.IsPositiveInfinity(graphSpaceLimits.x) ? int.MaxValue : Mathf.CeilToInt((graphSpaceLimits.x - graphSpaceBounds.min.x) / cellSize));
			int num4 = Mathf.Min(depth - 1, float.IsPositiveInfinity(graphSpaceLimits.y) ? int.MaxValue : Mathf.CeilToInt((graphSpaceLimits.y - graphSpaceBounds.min.z) / cellSize));
			for (int j = 0; j < bucket.Length; j++)
			{
				RasterizationMesh rasterizationMesh = inputMeshes[bucket[j]];
				bool flag = VectorMath.ReversesFaceOrientations(rasterizationMesh.matrix);
				UnsafeSpan<float3> vertices = rasterizationMesh.vertices;
				UnsafeSpan<int> triangles = rasterizationMesh.triangles;
				float4x4 a = inverse * rasterizationMesh.matrix;
				for (int k = 0; k < vertices.Length; k++)
				{
					nativeArray[k] = math.transform(a, vertices[k]);
				}
				int num5 = rasterizationMesh.area;
				if (rasterizationMesh.areaIsTag)
				{
					num5 |= 0x4000;
				}
				IntRect intRect = default(IntRect);
				for (int l = 0; l < triangles.Length; l += 3)
				{
					float3 float5 = nativeArray[triangles[l]];
					float3 float6 = nativeArray[triangles[l + 1]];
					float3 float7 = nativeArray[triangles[l + 2]];
					if (flag)
					{
						float3 obj = float5;
						float5 = float7;
						float7 = obj;
					}
					int num6 = (int)math.min(math.min(float5.x, float6.x), float7.x);
					int num7 = (int)math.min(math.min(float5.z, float6.z), float7.z);
					int num8 = (int)math.ceil(math.max(math.max(float5.x, float6.x), float7.x));
					int num9 = (int)math.ceil(math.max(math.max(float5.z, float6.z), float7.z));
					if (num6 > num3 || num7 > num4 || num8 < 0 || num9 < 0)
					{
						continue;
					}
					num6 = math.clamp(num6, 0, num3);
					num8 = math.clamp(num8, 0, num3);
					num7 = math.clamp(num7, 0, num4);
					num9 = math.clamp(num9, num4, num4);
					if (l == 0)
					{
						intRect = new IntRect(num6, num7, num6, num7);
					}
					intRect.xmin = math.min(intRect.xmin, num6);
					intRect.xmax = math.max(intRect.xmax, num8);
					intRect.ymin = math.min(intRect.ymin, num7);
					intRect.ymax = math.max(intRect.ymax, num9);
					float num10 = math.normalizesafe(math.cross(float6 - float5, float7 - float5)).y;
					if (rasterizationMesh.doubleSided)
					{
						num10 = math.abs(num10);
					}
					int area = ((!(num10 < num)) ? (1 + num5) : 0);
					voxelPolygonClipper[0] = float5;
					voxelPolygonClipper[1] = float6;
					voxelPolygonClipper[2] = float7;
					voxelPolygonClipper.n = 3;
					for (int m = num6; m <= num8; m++)
					{
						voxelPolygonClipper.ClipPolygonAlongX(ref result, 1f, (float)(-m) + 0.5f);
						if (result.n < 3)
						{
							continue;
						}
						result.ClipPolygonAlongX(ref result2, -1f, (float)m + 0.5f);
						if (result2.n < 3)
						{
							continue;
						}
						float x2;
						float x = (x2 = result2.z[0]);
						for (int n = 1; n < result2.n; n++)
						{
							float y = result2.z[n];
							x = math.min(x, y);
							x2 = math.max(x2, y);
						}
						int num11 = math.clamp((int)math.round(x), 0, num3);
						int num12 = math.clamp((int)math.round(x2), 0, num4);
						for (int num13 = num11; num13 <= num12; num13++)
						{
							result2.ClipPolygonAlongZWithYZ(ref result3, 1f, (float)(-num13) + 0.5f);
							if (result3.n < 3)
							{
								continue;
							}
							result3.ClipPolygonAlongZWithY(ref result4, -1f, (float)num13 + 0.5f);
							if (result4.n < 3)
							{
								continue;
							}
							if (rasterizationMesh.flatten)
							{
								voxelArea.AddFlattenedSpan(num13 * width + m, area);
								continue;
							}
							float x3;
							float num14 = (x3 = result4.y[0]);
							for (int num15 = 1; num15 < result4.n; num15++)
							{
								float y2 = result4.y[num15];
								num14 = math.min(num14, y2);
								x3 = math.max(x3, y2);
							}
							int y3 = (int)math.ceil(x3);
							int num16 = (int)num14;
							y3 = math.max(num16 + 1, y3);
							voxelArea.AddLinkedSpan(num13 * width + m, num16, y3, area, voxelWalkableClimb, j);
						}
					}
				}
				if (!rasterizationMesh.solid)
				{
					continue;
				}
				for (int num17 = intRect.ymin; num17 <= intRect.ymax; num17++)
				{
					for (int num18 = intRect.xmin; num18 <= intRect.xmax; num18++)
					{
						voxelArea.ResolveSolid(num17 * voxelArea.width + num18, j, voxelWalkableClimb);
					}
				}
			}
		}
	}
}
