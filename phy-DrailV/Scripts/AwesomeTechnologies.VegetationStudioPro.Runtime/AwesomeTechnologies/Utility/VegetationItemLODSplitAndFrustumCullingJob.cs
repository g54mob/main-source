using AwesomeTechnologies.VegetationSystem;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	[BurstCompile(CompileSynchronously = true)]
	public struct VegetationItemLODSplitAndFrustumCullingJob : IJob
	{
		[ReadOnly]
		public NativeList<MatrixInstance> VegetationItemMatrixList;

		[ReadOnly]
		public NativeArray<Plane> FrustumPlanes;

		public NativeList<Matrix4x4> VegetationItemLOD0MatrixList;

		public NativeList<Matrix4x4> VegetationItemLOD1MatrixList;

		public NativeList<Matrix4x4> VegetationItemLOD2MatrixList;

		public NativeList<Matrix4x4> VegetationItemLOD3MatrixList;

		public NativeList<Matrix4x4> VegetationItemLOD0ShadowMatrixList;

		public NativeList<Matrix4x4> VegetationItemLOD1ShadowMatrixList;

		public NativeList<Matrix4x4> VegetationItemLOD2ShadowMatrixList;

		public NativeList<Matrix4x4> VegetationItemLOD3ShadowMatrixList;

		public NativeList<Vector4> LOD0FadeList;

		public NativeList<Vector4> LOD1FadeList;

		public NativeList<Vector4> LOD2FadeList;

		public NativeList<Vector4> LOD3FadeList;

		public Vector3 LightDirection;

		public Vector3 PlaneOrigin;

		public Vector3 BoundsSize;

		public bool ShadowCulling;

		public bool NoFrustumCulling;

		public float CullDistance;

		public float3 CameraPosition;

		public float BoundingSphereRadius;

		public int VegetationItemDistanceBand;

		public float LODFactor;

		public float LODBias;

		public float LODFadeDistance;

		public float LOD1Distance;

		public float LOD2Distance;

		public float LOD3Distance;

		public int LODCount;

		public bool LODFadePercentage;

		public bool LODFadeCrossfade;

		public Vector3 FloatingOriginOffset;

		public void Execute()
		{
			for (int num = VegetationItemMatrixList.Length - 1; num >= 0; num--)
			{
				MatrixInstance matrixInstance = VegetationItemMatrixList[num];
				matrixInstance.Matrix = TranslateMatrix(matrixInstance.Matrix, FloatingOriginOffset);
				float distanceFalloff = matrixInstance.DistanceFalloff;
				float num2 = CullDistance * distanceFalloff;
				float num3 = math.clamp(LOD1Distance * LODFactor * LODBias, 0f, num2);
				float num4 = math.clamp(LOD2Distance * LODFactor * LODBias, 0f, num2);
				float num5 = math.clamp(LOD3Distance * LODFactor * LODBias, 0f, num2);
				switch (LODCount)
				{
				case 1:
					num3 = math.max(num3, num2);
					break;
				case 2:
					num4 = math.max(num4, num2);
					break;
				case 3:
					num5 = math.max(num5, num2);
					break;
				}
				bool flag = true;
				float3 float5 = ExtractTranslationFromMatrix(matrixInstance.Matrix);
				float num6 = math.distance(CameraPosition, float5);
				if (!(num6 > num2 + LODFadeDistance))
				{
					CalculateDistanceFade(num6, num2);
					if (NoFrustumCulling)
					{
						if (num6 <= num3 || LODCount == 1)
						{
							VegetationItemLOD0MatrixList.Add(matrixInstance.Matrix);
							if (flag)
							{
								float num7 = CalculateLODFade(num6, num3);
								float y = 1f - Mathf.Clamp((float)Mathf.RoundToInt(num7 * 16f) / 16f, 0.0625f, 1f);
								if (LODCount == 1)
								{
									num7 = 1f - num7;
								}
								LOD0FadeList.Add(new Vector4(num7, y, 0f, 0f));
							}
						}
						else if (num6 <= num4 || LODCount == 2)
						{
							VegetationItemLOD1MatrixList.Add(matrixInstance.Matrix);
							if (flag)
							{
								float num8 = CalculateLODFade(num6, num4);
								float y2 = 1f - Mathf.Clamp((float)Mathf.RoundToInt(num8 * 16f) / 16f, 0.0625f, 1f);
								if (LODCount == 2)
								{
									num8 = 1f - num8;
								}
								LOD1FadeList.Add(new Vector4(num8, y2, 0f, 0f));
							}
						}
						else if (num6 <= num5 || LODCount == 3)
						{
							VegetationItemLOD2MatrixList.Add(matrixInstance.Matrix);
							if (flag)
							{
								float num9 = CalculateLODFade(num6, num5);
								float y3 = 1f - Mathf.Clamp((float)Mathf.RoundToInt(num9 * 16f) / 16f, 0.0625f, 1f);
								if (LODCount == 3)
								{
									num9 = 1f - num9;
								}
								LOD2FadeList.Add(new Vector4(num9, y3, 0f, 0f));
							}
						}
						else
						{
							VegetationItemLOD3MatrixList.Add(matrixInstance.Matrix);
							if (flag)
							{
								float num10 = CalculateLODFade(num6, num2);
								float y4 = 1f - Mathf.Clamp((float)Mathf.RoundToInt(num10 * 16f) / 16f, 0.0625f, 1f);
								num10 = 1f - num10;
								LOD3FadeList.Add(new Vector4(num10, y4, 0f, 0f));
							}
						}
					}
					else
					{
						BoundingSphere boundingSphere = new BoundingSphere(float5, BoundingSphereRadius);
						if (SphereInFrustum(boundingSphere) == -1)
						{
							if (VegetationItemDistanceBand != 0 && ShadowCulling && IsShadowVisible(new Bounds(float5, BoundsSize), LightDirection, PlaneOrigin, FrustumPlanes))
							{
								if (num6 <= num3 || LODCount == 1)
								{
									VegetationItemLOD0ShadowMatrixList.Add(matrixInstance.Matrix);
								}
								else if (num6 <= num4 || LODCount == 2)
								{
									VegetationItemLOD1ShadowMatrixList.Add(matrixInstance.Matrix);
								}
								else if (num6 <= num5 || LODCount == 3)
								{
									VegetationItemLOD2ShadowMatrixList.Add(matrixInstance.Matrix);
								}
								else
								{
									VegetationItemLOD3ShadowMatrixList.Add(matrixInstance.Matrix);
								}
							}
						}
						else
						{
							if (LODCount == 1)
							{
								num3 = math.max(num3, num2);
							}
							else if (LODCount == 2)
							{
								num4 = math.max(num4, num2);
							}
							else if (LODCount == 3)
							{
								num5 = math.max(num5, num2);
							}
							if (num6 <= num3 + LODFadeDistance)
							{
								VegetationItemLOD0MatrixList.Add(matrixInstance.Matrix);
								if (flag)
								{
									float num11 = CalculateLODFadeFirst(num6, num3);
									float y5 = 1f - Mathf.Clamp((float)Mathf.RoundToInt(num11 * 16f) / 16f, 0.0625f, 1f);
									if (LODCount == 1)
									{
										num11 = 1f - num11;
									}
									LOD0FadeList.Add(new Vector4(num11, y5, 0f, 0f));
								}
							}
							if (num6 <= num4 + LODFadeDistance && num6 > num3)
							{
								VegetationItemLOD1MatrixList.Add(matrixInstance.Matrix);
								if (flag)
								{
									float num12 = CalculateLODFadeMiddle(num3, num6, num4);
									float y6 = 1f - Mathf.Clamp((float)Mathf.RoundToInt(num12 * 16f) / 16f, 0.0625f, 1f);
									if (LODCount == 2)
									{
										num12 = 1f - num12;
									}
									LOD1FadeList.Add(new Vector4(num12, y6, 0f, 0f));
								}
							}
							if (num6 <= num5 + LODFadeDistance && num6 > num4)
							{
								VegetationItemLOD2MatrixList.Add(matrixInstance.Matrix);
								if (flag)
								{
									float num13 = CalculateLODFadeMiddle(num4, num6, num5);
									float y7 = 1f - Mathf.Clamp((float)Mathf.RoundToInt(num13 * 16f) / 16f, 0.0625f, 1f);
									if (LODCount == 3)
									{
										num13 = 1f - num13;
									}
									LOD2FadeList.Add(new Vector4(num13, y7, 0f, 0f));
								}
							}
							if (num6 > num5)
							{
								VegetationItemLOD3MatrixList.Add(matrixInstance.Matrix);
								if (flag)
								{
									float num14 = CalculateLODFadeMiddle(num5, num6, num2);
									float y8 = 1f - Mathf.Clamp((float)Mathf.RoundToInt(num14 * 16f) / 16f, 0.0625f, 1f);
									num14 = 1f - num14;
									LOD3FadeList.Add(new Vector4(num14, y8, 0f, 0f));
								}
							}
						}
					}
				}
			}
		}

		private float CalculateDistanceFade(float cameraDistance, float cullDistance)
		{
			return 0f;
		}

		private int SphereInFrustum(BoundingSphere boundingSphere)
		{
			for (int i = 0; i <= FrustumPlanes.Length - 1; i++)
			{
				if (FrustumPlanes[i].normal.x * boundingSphere.position.x + FrustumPlanes[i].normal.y * boundingSphere.position.y + FrustumPlanes[i].normal.z * boundingSphere.position.z + FrustumPlanes[i].distance < 0f - boundingSphere.radius)
				{
					return -1;
				}
			}
			return 1;
		}

		private float3 ExtractTranslationFromMatrix(Matrix4x4 matrix)
		{
			float3 result = default(float3);
			result.x = matrix.m03;
			result.y = matrix.m13;
			result.z = matrix.m23;
			return result;
		}

		private Matrix4x4 TranslateMatrix(Matrix4x4 matrix, float3 offset)
		{
			Matrix4x4 result = matrix;
			result.m03 = matrix.m03 + offset.x;
			result.m13 = matrix.m13 + offset.y;
			result.m23 = matrix.m23 + offset.z;
			return result;
		}

		private float CalculateLODFade(float cameraDistance, float nextLODDistance)
		{
			float num = nextLODDistance - cameraDistance;
			if (num <= LODFadeDistance)
			{
				return Mathf.Clamp01(1f - num / LODFadeDistance);
			}
			return 0f;
		}

		private float CalculateLODFadeFirst(float cameraDistance, float nextLODDistance)
		{
			float num = nextLODDistance + LODFadeDistance - cameraDistance;
			if (num <= LODFadeDistance)
			{
				return math.clamp(num / LODFadeDistance, 0f, 1f) * 2f;
			}
			return 1f;
		}

		private float CalculateLODFadeMiddle(float thisLODDistance, float cameraDistance, float nextLODDistance)
		{
			if (cameraDistance - thisLODDistance < LODFadeDistance)
			{
				return math.clamp((cameraDistance - thisLODDistance) / LODFadeDistance, 0f, 1f) * 2f;
			}
			if (nextLODDistance + LODFadeDistance - cameraDistance <= LODFadeDistance)
			{
				return math.clamp((nextLODDistance + LODFadeDistance - cameraDistance) / LODFadeDistance, 0f, 1f) * 2f;
			}
			return 1f;
		}

		public static bool IsShadowVisible(Bounds objectBounds, Vector3 lightDirection, Vector3 planeOrigin, NativeArray<Plane> frustumPlanes)
		{
			bool hitPlane;
			Bounds shadowBounds = GetShadowBounds(objectBounds, lightDirection, planeOrigin, out hitPlane);
			if (hitPlane)
			{
				return BoundsIntersectsFrustum(frustumPlanes, shadowBounds);
			}
			return false;
		}

		public static Bounds GetShadowBounds(Bounds objectBounds, Vector3 lightDirection, Vector3 planeOrigin, out bool hitPlane)
		{
			Ray ray = new Ray(new Vector3(objectBounds.min.x, objectBounds.max.y, objectBounds.min.z), lightDirection);
			Ray ray2 = new Ray(new Vector3(objectBounds.min.x, objectBounds.max.y, objectBounds.max.z), lightDirection);
			Ray ray3 = new Ray(new Vector3(objectBounds.max.x, objectBounds.max.y, objectBounds.min.z), lightDirection);
			Ray ray4 = new Ray(objectBounds.max, lightDirection);
			hitPlane = false;
			if (IntersectPlane(ray, planeOrigin, out var hitPoint))
			{
				objectBounds.Encapsulate(hitPoint);
				hitPlane = true;
			}
			if (IntersectPlane(ray2, planeOrigin, out hitPoint))
			{
				objectBounds.Encapsulate(hitPoint);
				hitPlane = true;
			}
			if (IntersectPlane(ray3, planeOrigin, out hitPoint))
			{
				objectBounds.Encapsulate(hitPoint);
				hitPlane = true;
			}
			if (IntersectPlane(ray4, planeOrigin, out hitPoint))
			{
				objectBounds.Encapsulate(hitPoint);
				hitPlane = true;
			}
			return objectBounds;
		}

		public static bool IntersectPlane(Ray ray, Vector3 planeOrigin, out Vector3 hitPoint)
		{
			Vector3 rhs = -Vector3.up;
			float num = Vector3.Dot(ray.direction, rhs);
			if (num > 1E-05f)
			{
				float num2 = Vector3.Dot(planeOrigin - ray.origin, rhs) / num;
				hitPoint = ray.origin + ray.direction * num2;
				return true;
			}
			hitPoint = Vector3.zero;
			return false;
		}

		public static bool BoundsIntersectsFrustum(NativeArray<Plane> planes, Bounds bounds)
		{
			Vector3 center = bounds.center;
			Vector3 extents = bounds.extents;
			for (int i = 0; i <= planes.Length - 1; i++)
			{
				Vector3 normal = planes[i].normal;
				float distance = planes[i].distance;
				Vector3 vector = new Vector3(Mathf.Abs(normal.x), Mathf.Abs(normal.y), Mathf.Abs(normal.z));
				float num = extents.x * vector.x + extents.y * vector.y + extents.z * vector.z;
				if (normal.x * center.x + normal.y * center.y + normal.z * center.z + num < 0f - distance)
				{
					return false;
				}
			}
			return true;
		}
	}
}
