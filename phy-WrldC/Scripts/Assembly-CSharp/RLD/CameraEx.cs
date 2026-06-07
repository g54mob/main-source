using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class CameraEx
	{
		public static bool IsCurrent(this Camera camera)
		{
			return Camera.current == camera;
		}

		public static float GetFrustumDistanceFromHeight(this Camera camera, float frustumHeight)
		{
			return frustumHeight * 0.5f / Mathf.Tan(camera.fieldOfView * 0.5f * ((float)Math.PI / 180f));
		}

		public static float GetFOVFromDistanceAndHeight(this Camera camera, float frustumHeight, float distance)
		{
			return 2f * Mathf.Atan2(frustumHeight * 0.5f, distance) * 57.29578f;
		}

		public static float GetFrustumWidthFromDistance(this Camera camera, float distance)
		{
			return 2f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * ((float)Math.PI / 180f)) * camera.aspect;
		}

		public static float GetFrustumHeightFromDistance(this Camera camera, float distance)
		{
			return 2f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * ((float)Math.PI / 180f));
		}

		public static AABB CalculateVolumeAABB(this Camera camera)
		{
			if (!camera.orthographic)
			{
				return camera.CalculateFrustumAABB();
			}
			return camera.CalculateOrthoAABB();
		}

		public static AABB CalculateFrustumAABB(this Camera camera)
		{
			Transform transform = camera.transform;
			float frustumWidthFromDistance = camera.GetFrustumWidthFromDistance(camera.farClipPlane);
			float frustumHeightFromDistance = camera.GetFrustumHeightFromDistance(camera.farClipPlane);
			Vector3 vector = transform.position + transform.forward * camera.farClipPlane - transform.right * frustumWidthFromDistance * 0.5f + transform.up * frustumHeightFromDistance * 0.5f;
			Vector3 vector2 = vector + transform.right * frustumWidthFromDistance;
			Vector3 vector3 = vector - transform.up * frustumHeightFromDistance;
			Vector3 vector4 = vector3 + transform.right * frustumWidthFromDistance;
			return new AABB(new Vector3[5] { transform.position, vector, vector2, vector3, vector4 });
		}

		public static AABB CalculateOrthoAABB(this Camera camera)
		{
			float num = camera.orthographicSize * 2f;
			float num2 = num * camera.aspect;
			Transform transform = camera.transform;
			Vector3 vector = transform.position + transform.forward * camera.nearClipPlane - transform.right * num2 * 0.5f + transform.up * num * 0.5f;
			Vector3 vector2 = vector + transform.right * num2;
			Vector3 vector3 = vector2 - transform.up * num;
			Vector3 vector4 = vector3 - transform.right * num2;
			Vector3 vector5 = transform.position + transform.forward * camera.farClipPlane - transform.right * num2 * 0.5f + transform.up * num * 0.5f;
			Vector3 vector6 = vector5 + transform.right * num2;
			Vector3 vector7 = vector6 - transform.up * num;
			Vector3 vector8 = vector7 - transform.right * num2;
			return new AABB(new Vector3[8] { vector, vector2, vector3, vector4, vector5, vector6, vector7, vector8 });
		}

		public static bool IsPointInFrontNearPlane(this Camera camera, Vector3 position)
		{
			return camera.GetNearPlaneForward().GetDistanceToPoint(position) > 0f;
		}

		public static Plane GetNearPlaneForward(this Camera camera)
		{
			Transform transform = camera.transform;
			return new Plane(transform.forward, transform.position + transform.forward * camera.nearClipPlane);
		}

		public static Vector3 GetFarMidPoint(this Camera camera)
		{
			Transform transform = camera.transform;
			return transform.position + transform.forward * camera.farClipPlane;
		}

		public static Vector3 GetFarMidOrthoTop(this Camera camera)
		{
			return camera.GetFarMidPoint() + camera.transform.up * camera.orthographicSize;
		}

		public static float GetOrthoFOV(this Camera camera)
		{
			Vector3 position = camera.transform.position;
			Vector3 vector = camera.GetFarMidPoint() - position;
			Vector3 to = camera.GetFarMidOrthoTop() - position;
			return Vector3.Angle(vector, to) * 2f;
		}

		public static bool IsPointFacingCamera(this Camera camera, Vector3 point, Vector3 pointNormal)
		{
			Vector3 lhs = point - camera.transform.position;
			if (camera.orthographic)
			{
				lhs = camera.transform.forward;
			}
			return Vector3.Dot(lhs, pointNormal) < 0f;
		}

		public static float GetPointZDistance(this Camera camera, Vector3 point)
		{
			Transform transform = camera.transform;
			return Vector3.Dot(point - transform.position, transform.forward);
		}

		public static List<Vector3> GetVisibleSphereExtents(this Camera camera, Sphere sphere)
		{
			Transform transform = camera.transform;
			List<Vector3> rightUpExtents = sphere.GetRightUpExtents(transform.right, transform.up);
			if (!camera.orthographic)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector3 vector = sphere.Center.ProjectOnSegment(transform.position, rightUpExtents[i]);
					rightUpExtents[i] = sphere.Center + (vector - sphere.Center).normalized * sphere.Radius;
				}
			}
			return rightUpExtents;
		}

		public static List<Vector2> ConvertWorldToScreenPoints(this Camera camera, List<Vector3> worldPoints)
		{
			if (worldPoints.Count == 0)
			{
				return new List<Vector2>();
			}
			List<Vector2> list = new List<Vector2>(worldPoints.Count);
			foreach (Vector3 worldPoint in worldPoints)
			{
				list.Add(camera.WorldToScreenPoint(worldPoint));
			}
			return list;
		}

		public static float ScreenToEstimatedWorldSize(this Camera camera, Vector3 worldPos, float screenSize)
		{
			float num = camera.pixelHeight;
			if (camera.orthographic)
			{
				return screenSize * (camera.orthographicSize * 2f / num);
			}
			Transform transform = camera.transform;
			float num2 = Vector3.Dot(transform.forward, worldPos - transform.position);
			float num3 = 2f * num2 * Mathf.Tan(camera.fieldOfView * 0.5f * ((float)Math.PI / 180f));
			return screenSize * (num3 / num);
		}

		public static float EstimateZoomFactor(this Camera camera, Vector3 worldPos)
		{
			if (camera.orthographic)
			{
				return camera.orthographicSize * 2f / (0.071f * (float)camera.pixelHeight);
			}
			Transform transform = camera.transform;
			return Vector3.Dot(transform.forward, worldPos - transform.position) / (0.046f * (float)camera.pixelHeight * 90f / camera.fieldOfView);
		}

		public static float EstimateZoomFactorSpherical(this Camera camera, Vector3 worldPos)
		{
			if (camera.orthographic)
			{
				return camera.orthographicSize * 2f / (0.071f * (float)camera.pixelHeight);
			}
			Transform transform = camera.transform;
			return (worldPos - transform.position).magnitude / (0.046f * (float)camera.pixelHeight * 90f / camera.fieldOfView);
		}

		public static List<GameObject> GetVisibleObjects(this Camera camera, CameraViewVolume viewVolume)
		{
			List<GameObject> list = MonoSingleton<RTScene>.Get.OverlapBox(viewVolume.WorldOBB);
			if (list.Count == 0)
			{
				return new List<GameObject>();
			}
			ObjectBounds.QueryConfig queryConfig = new ObjectBounds.QueryConfig
			{
				ObjectTypes = GameObjectTypeHelper.AllCombined,
				NoVolumeSize = Vector3Ex.FromValue(1E-05f)
			};
			List<GameObject> list2 = new List<GameObject>(list.Count);
			foreach (GameObject item in list)
			{
				AABB aabb = ObjectBounds.CalcWorldAABB(item, queryConfig);
				if (aabb.IsValid && viewVolume.CheckAABB(aabb))
				{
					list2.Add(item);
				}
			}
			return list2;
		}
	}
}
