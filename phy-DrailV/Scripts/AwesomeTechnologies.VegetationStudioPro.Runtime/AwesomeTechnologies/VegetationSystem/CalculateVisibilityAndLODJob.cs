using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public class CalculateVisibilityAndLODJob : IJob
	{
		[ReadOnly]
		public NativeList<Matrix4x4> InstanceList;

		[ReadOnly]
		public NativeArray<Plane> FrustumPlanes;

		public NativeList<Matrix4x4> LOD0InstanceList;

		public NativeList<Matrix4x4> LOD1InstanceList;

		public NativeList<Matrix4x4> LOD2InstanceList;

		public NativeList<Matrix4x4> LOD0ShadowInstanceList;

		public NativeList<Matrix4x4> LOD1ShadowInstanceList;

		public NativeList<Matrix4x4> LOD2ShadowInstanceList;

		public NativeList<float> LOD0LODFadeList;

		public NativeList<float> LOD1LODFadeList;

		public NativeList<float> LOD2LODFadeList;

		public NativeList<float> LOD0ShadowLODFadeList;

		public NativeList<float> LOD1ShadowLODFadeList;

		public NativeList<float> LOD2ShadowLODFadeList;

		public Vector3 LightDirection;

		public Vector3 PlaneOrigin;

		public Vector3 CameraPosition;

		public Vector3 ItemBoundSize;

		public float LOD1Distance;

		public float LOD2Distance;

		public float CullDistance;

		public float LODFadeDistance;

		public bool DisableLOD;

		private void ClearLists()
		{
			LOD0InstanceList.Clear();
			LOD1InstanceList.Clear();
			LOD2InstanceList.Clear();
			LOD0ShadowInstanceList.Clear();
			LOD1ShadowInstanceList.Clear();
			LOD2ShadowInstanceList.Clear();
			LOD0LODFadeList.Clear();
			LOD1LODFadeList.Clear();
			LOD2LODFadeList.Clear();
			LOD0ShadowLODFadeList.Clear();
			LOD1ShadowLODFadeList.Clear();
			LOD2ShadowLODFadeList.Clear();
		}

		public void Execute()
		{
			ClearLists();
			for (int i = 0; i <= InstanceList.Length - 1; i++)
			{
				float3 float5 = ExtractTranslationFromMatrix(InstanceList[i]);
				float num = math.distance(float5, CameraPosition);
				if (num <= CullDistance)
				{
					continue;
				}
				switch (CheckItemVisibility(float5, ItemBoundSize))
				{
				case 2:
					if (LOD1Distance < 0f || DisableLOD)
					{
						LOD0ShadowInstanceList.Add(InstanceList[i]);
					}
					else if (num > LOD2Distance)
					{
						LOD2ShadowInstanceList.Add(InstanceList[i]);
					}
					else if (num > LOD1Distance)
					{
						LOD1ShadowInstanceList.Add(InstanceList[i]);
						LOD1ShadowLODFadeList.Add(CalculateLODFade(num, LOD2Distance));
					}
					else
					{
						LOD0ShadowInstanceList.Add(InstanceList[i]);
						LOD0ShadowLODFadeList.Add(CalculateLODFade(num, LOD1Distance));
					}
					break;
				case 1:
					if (LOD1Distance < 0f || DisableLOD)
					{
						LOD0InstanceList.Add(InstanceList[i]);
					}
					else if (num > LOD2Distance)
					{
						LOD2InstanceList.Add(InstanceList[i]);
					}
					else if (num > LOD1Distance)
					{
						LOD1InstanceList.Add(InstanceList[i]);
						LOD1LODFadeList.Add(CalculateLODFade(num, LOD2Distance));
					}
					else
					{
						LOD0InstanceList.Add(InstanceList[i]);
						LOD0LODFadeList.Add(CalculateLODFade(num, LOD1Distance));
					}
					break;
				}
			}
		}

		private int CheckItemVisibility(float3 position, float3 boundSize)
		{
			float3 float5 = position + new float3(0f, boundSize.y / 2f, 0f);
			Bounds bounds = new Bounds(float5, boundSize);
			if (BoundsIntersectsFrustum(bounds))
			{
				return 1;
			}
			if (IsShadowVisible(bounds, LightDirection, PlaneOrigin, FrustumPlanes))
			{
				return 2;
			}
			return 0;
		}

		private float3 ExtractTranslationFromMatrix(Matrix4x4 matrix)
		{
			float3 result = default(float3);
			result.x = matrix.m03;
			result.y = matrix.m13;
			result.z = matrix.m23;
			return result;
		}

		public bool BoundsIntersectsFrustum(Bounds bounds)
		{
			Vector3 center = bounds.center;
			Vector3 extents = bounds.extents;
			for (int i = 0; i <= FrustumPlanes.Length - 1; i++)
			{
				float3 float5 = FrustumPlanes[i].normal;
				float distance = FrustumPlanes[i].distance;
				float3 float6 = math.abs(FrustumPlanes[i].normal);
				float num = extents.x * float6.x + extents.y * float6.y + extents.z * float6.z;
				if (float5.x * center.x + float5.y * center.y + float5.z * center.z + num < 0f - distance)
				{
					return false;
				}
			}
			return true;
		}

		public bool IsShadowVisible(Bounds objectBounds, Vector3 lightDirection, Vector3 planeOrigin, NativeArray<Plane> frustumPlanes)
		{
			bool hitPlane;
			Bounds shadowBounds = GetShadowBounds(objectBounds, lightDirection, planeOrigin, out hitPlane);
			if (hitPlane)
			{
				return BoundsIntersectsFrustum(shadowBounds);
			}
			return false;
		}

		public Bounds GetShadowBounds(Bounds objectBounds, float3 lightDirection, float3 planeOrigin, out bool hitPlane)
		{
			Ray ray = new Ray(new float3(objectBounds.min.x, objectBounds.max.y, objectBounds.min.z), lightDirection);
			Ray ray2 = new Ray(new float3(objectBounds.min.x, objectBounds.max.y, objectBounds.max.z), lightDirection);
			Ray ray3 = new Ray(new float3(objectBounds.max.x, objectBounds.max.y, objectBounds.min.z), lightDirection);
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

		public bool IntersectPlane(Ray ray, float3 planeOrigin, out float3 hitPoint)
		{
			float3 y = -Vector3.up;
			float3 float5 = ray.origin;
			float num = math.dot(ray.direction, y);
			if (num > 1E-05f)
			{
				float num2 = math.dot(planeOrigin - float5, y) / num;
				hitPoint = ray.origin + ray.direction * num2;
				return true;
			}
			hitPoint = Vector3.zero;
			return false;
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
	}
}
