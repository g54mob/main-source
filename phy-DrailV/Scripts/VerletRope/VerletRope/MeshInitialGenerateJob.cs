using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace VerletRope
{
	[BurstCompile]
	public struct MeshInitialGenerateJob : IJob
	{
		[WriteOnly]
		public NativeArray<RopeMeshVertex> vertices;

		[WriteOnly]
		public NativeArray<int> triangles;

		[WriteOnly]
		public NativeArray<BurstBounds> bounds;

		[ReadOnly]
		public NativeArray<bool> isMeshInFrustum;

		[ReadOnly]
		private NativeArray<Point> ropePoints;

		private readonly float uvScale;

		private readonly int numInterpolatedPoints;

		private readonly float thickness;

		internal const float MESH_BOUNDS_EXPAND = 0.1f;

		internal static readonly float3[] shapePoints = new float3[9]
		{
			new float3(0f, 0.5f, 0f),
			new float3(0.36f, 0.36f, 0f),
			new float3(0.5f, 0f, 0f),
			new float3(0.36f, -0.36f, 0f),
			new float3(0f, -0.5f, 0f),
			new float3(-0.36f, -0.36f, 0f),
			new float3(-0.5f, 0f, 0f),
			new float3(-0.36f, 0.36f, 0f),
			new float3(0f, 0.5f, 0f)
		};

		public MeshInitialGenerateJob(NativeArray<Point> ropePoints, float uvScale, float thickness, int numInterpolatedPoints, NativeArray<bool> isMeshInFrustum, NativeArray<RopeMeshVertex> vertices, NativeArray<int> triangles, NativeArray<BurstBounds> bounds)
		{
			this.ropePoints = ropePoints;
			this.uvScale = uvScale;
			this.thickness = thickness;
			this.numInterpolatedPoints = numInterpolatedPoints;
			this.isMeshInFrustum = isMeshInFrustum;
			this.vertices = vertices;
			this.triangles = triangles;
			this.bounds = bounds;
		}

		public void Dispose()
		{
		}

		public static int GetTotalInterpolatedPoints(int ropePoints, int numInterpolatedPoints)
		{
			return (ropePoints - 1) * (numInterpolatedPoints + 1) + 1;
		}

		public void Execute()
		{
			if (!isMeshInFrustum[0])
			{
				return;
			}
			int totalInterpolatedPoints = GetTotalInterpolatedPoints(ropePoints.Length, numInterpolatedPoints);
			NativeArray<Point> nativeArray = new NativeArray<Point>(totalInterpolatedPoints, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			nativeArray[totalInterpolatedPoints - 1] = ropePoints[ropePoints.Length - 1];
			int num = numInterpolatedPoints + 1;
			for (int i = 0; i < ropePoints.Length - 1; i++)
			{
				Point point = ropePoints[i];
				float3 curPos = point.curPos;
				nativeArray[i * num] = point;
				for (int j = 1; j <= numInterpolatedPoints; j++)
				{
					Point value = point;
					Point point2 = ropePoints[i + 1];
					float3 localForward = point.localForward;
					float3 p = ((i == 0) ? (curPos - localForward) : ropePoints[i - 1].curPos);
					float3 p2 = curPos;
					float3 curPos2 = point2.curPos;
					float3 p3 = ((i >= ropePoints.Length - 2) ? (curPos + localForward * 2f) : ropePoints[i + 2].curPos);
					float t = (float)j / ((float)numInterpolatedPoints + 1f);
					float3 curPos3 = CatmulRom(p, p2, curPos2, p3, t);
					value.curPos = curPos3;
					value.localForward = math.lerp(point.localForward, point2.localForward, t);
					value.localUp = math.lerp(point.localUp, point2.localUp, t);
					nativeArray[i * num + j] = value;
				}
			}
			BurstBounds value2 = default(BurstBounds);
			for (int k = 0; k < nativeArray.Length; k++)
			{
				Point point3 = nativeArray[k];
				quaternion q = Quaternion.LookRotation(point3.localForward, point3.localUp);
				float3 curPos4 = point3.curPos;
				for (int l = 0; l < shapePoints.Length; l++)
				{
					int num2 = k * shapePoints.Length + l;
					float3 float5 = math.mul(q, shapePoints[l]);
					float3 float6 = curPos4 + float5 * thickness;
					float4 tangent = math.float4(math.normalize((l == 0) ? (math.mul(q, shapePoints[l + 1] * thickness) - float5) : (float5 - math.mul(q, shapePoints[l - 1] * thickness))), -1f);
					float3 normal = math.normalize(float6 - curPos4);
					if (k > 0 && l > 0)
					{
						int num3 = num2 - shapePoints.Length;
						int num4 = ((k - 1) * (shapePoints.Length - 1) + (l - 1)) * 6;
						triangles[num4++] = num3 - 1;
						triangles[num4++] = num2 - 1;
						triangles[num4++] = num3;
						triangles[num4++] = num3;
						triangles[num4++] = num2 - 1;
						triangles[num4++] = num2;
					}
					float2 uv = new float2((float)l / ((float)shapePoints.Length - 1f), uvScale * (float)k / (float)(nativeArray.Length - 1));
					vertices[num2] = new RopeMeshVertex(float6, normal, tangent, uv);
					if (k == 0 && l == 0)
					{
						value2 = new BurstBounds(float6);
					}
					else
					{
						value2.Encapsulate(float6);
					}
				}
			}
			bounds[0] = value2;
			nativeArray.Dispose();
		}

		public static bool FrustumIntersectsBounds(NativeArray<BurstPlane> cameraPlanes, BurstBounds bounds)
		{
			float3 min = bounds.min;
			float3 max = bounds.max;
			NativeArray<float3> nativeArray = new NativeArray<float3>(8, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			nativeArray[0] = new float3(min.x, min.y, min.z);
			nativeArray[1] = new float3(min.x, min.y, max.z);
			nativeArray[2] = new float3(min.x, max.y, min.z);
			nativeArray[3] = new float3(max.x, min.y, min.z);
			nativeArray[4] = new float3(max.x, min.y, max.z);
			nativeArray[5] = new float3(max.x, max.y, min.z);
			nativeArray[6] = new float3(min.x, max.y, max.z);
			nativeArray[7] = new float3(max.x, max.y, max.z);
			for (int i = 0; i < 6; i++)
			{
				int num = 8;
				for (int j = 0; j < 8; j++)
				{
					if (!cameraPlanes[i].GetSide(nativeArray[j]))
					{
						num--;
					}
				}
				if (num == 0)
				{
					nativeArray.Dispose();
					return false;
				}
			}
			nativeArray.Dispose();
			return true;
		}

		private static float3 CatmulRom(float3 p1, float3 p2, float3 p3, float3 p4, float t)
		{
			float t2 = GetT(0f, p1, p2);
			float t3 = GetT(t2, p2, p3);
			float t4 = GetT(t3, p3, p4);
			t = math.lerp(t2, t3, t);
			float3 float5 = (t2 - t) / (t2 - 0f) * p1 + (t - 0f) / (t2 - 0f) * p2;
			float3 float6 = (t3 - t) / (t3 - t2) * p2 + (t - t2) / (t3 - t2) * p3;
			float3 float7 = (t4 - t) / (t4 - t3) * p3 + (t - t3) / (t4 - t3) * p4;
			float3 float8 = (t3 - t) / (t3 - 0f) * float5 + (t - 0f) / (t3 - 0f) * float6;
			float3 float9 = (t4 - t) / (t4 - t2) * float6 + (t - t2) / (t4 - t2) * float7;
			return (t3 - t) / (t3 - t2) * float8 + (t - t2) / (t3 - t2) * float9;
		}

		private static float GetT(float t, float3 p0, float3 p1)
		{
			return math.pow(math.pow(math.pow(p1.x - p0.x, 2f) + math.pow(p1.y - p0.y, 2f) + math.pow(p1.z - p0.z, 2f), 0.5f), 0.5f) + t;
		}
	}
}
