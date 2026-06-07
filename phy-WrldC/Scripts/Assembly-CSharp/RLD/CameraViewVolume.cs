using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class CameraViewVolume
	{
		public enum VPoint
		{
			NearTopLeft = 0,
			NearTopRight = 1,
			NearBottomRight = 2,
			NearBottomLeft = 3,
			FarTopLeft = 4,
			FarTopRight = 5,
			FarBottomRight = 6,
			FarBottomLeft = 7
		}

		public enum VPlane
		{
			Left = 0,
			Right = 1,
			Bottom = 2,
			Top = 3,
			Near = 4,
			Far = 5
		}

		private const int _numWorldPoints = 8;

		private const int _numWorldPlanes = 6;

		private Vector3[] _worldPoints = new Vector3[8];

		private Plane[] _worldPlanes = new Plane[6];

		private Vector2 _farPlaneSize = Vector2.zero;

		private Vector2 _nearPlaneSize = Vector2.zero;

		private AABB _worldAABB;

		private OBB _worldOBB;

		public Plane LeftPlane => _worldPlanes[0];

		public Plane RightPlane => _worldPlanes[1];

		public Plane BottomPlane => _worldPlanes[2];

		public Plane TopPlane => _worldPlanes[3];

		public Plane NearPlane => _worldPlanes[4];

		public Plane FarPlane => _worldPlanes[5];

		public Vector3 NearTopLeft => _worldPoints[0];

		public Vector3 NearTopRight => _worldPoints[1];

		public Vector3 NearBottomRight => _worldPoints[2];

		public Vector3 NearBottomLeft => _worldPoints[3];

		public Vector3 FarTopLeft => _worldPoints[4];

		public Vector3 FarTopRight => _worldPoints[5];

		public Vector3 FarBottomRight => _worldPoints[6];

		public Vector3 FarBottomLeft => _worldPoints[7];

		public Vector2 FarPlaneSize => _farPlaneSize;

		public Vector2 NearPlaneSize => _nearPlaneSize;

		public AABB WorldAABB => _worldAABB;

		public OBB WorldOBB => _worldOBB;

		public CameraViewVolume()
		{
		}

		public CameraViewVolume(Camera camera)
		{
			FromCamera(camera);
		}

		public void FromCamera(Camera camera)
		{
			_worldPlanes = GeometryUtility.CalculateFrustumPlanes(camera.projectionMatrix * camera.worldToCameraMatrix);
			CalculateWorldPoints(camera);
			_farPlaneSize.x = (FarTopLeft - FarTopRight).magnitude;
			_farPlaneSize.y = (FarTopLeft - FarBottomLeft).magnitude;
			_nearPlaneSize.x = (NearTopLeft - NearTopRight).magnitude;
			_nearPlaneSize.y = (NearTopLeft - NearBottomLeft).magnitude;
			_worldAABB = new AABB(_worldPoints);
			Vector3 size = new Vector3
			{
				x = _farPlaneSize.x,
				y = _farPlaneSize.y,
				z = camera.farClipPlane - camera.nearClipPlane
			};
			Transform transform = camera.transform;
			Vector3 center = transform.position + transform.forward * (camera.nearClipPlane + size.z * 0.5f);
			_worldOBB = new OBB(center, size, transform.rotation);
		}

		public List<Vector3> GetNearPlanePoints()
		{
			return new List<Vector3> { NearTopLeft, NearTopRight, NearBottomRight, NearBottomLeft };
		}

		public static Plane[] GetCameraWorldPlanes(Camera camera)
		{
			return GeometryUtility.CalculateFrustumPlanes(camera.projectionMatrix * camera.worldToCameraMatrix);
		}

		public bool CheckAABB(AABB aabb)
		{
			return GeometryUtility.TestPlanesAABB(_worldPlanes, aabb.ToBounds());
		}

		public static bool CheckAABB(Camera camera, AABB aabb)
		{
			return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(camera.projectionMatrix * camera.worldToCameraMatrix), aabb.ToBounds());
		}

		public static bool CheckAABB(Camera camera, AABB aabb, Plane[] cameraWorldPlanes)
		{
			return GeometryUtility.TestPlanesAABB(cameraWorldPlanes, aabb.ToBounds());
		}

		private void CalculateWorldPoints(Camera camera)
		{
			Transform transform = camera.transform;
			Plane farPlane = FarPlane;
			Ray ray = new Ray(transform.position, -farPlane.normal);
			if (farPlane.Raycast(ray, out var enter))
			{
				Vector3 point = ray.GetPoint(enter);
				Vector3 vector = Vector3.zero;
				Vector3 vector2 = Vector3.zero;
				ray = new Ray(point, transform.up);
				if (TopPlane.Raycast(ray, out enter))
				{
					vector = ray.GetPoint(enter);
				}
				ray = new Ray(point, transform.right);
				if (RightPlane.Raycast(ray, out enter))
				{
					vector2 = ray.GetPoint(enter);
				}
				float magnitude = (vector2 - point).magnitude;
				float magnitude2 = (vector - point).magnitude;
				_worldPoints[4] = point - transform.right * magnitude + transform.up * magnitude2;
				_worldPoints[5] = point + transform.right * magnitude + transform.up * magnitude2;
				_worldPoints[6] = point + transform.right * magnitude - transform.up * magnitude2;
				_worldPoints[7] = point - transform.right * magnitude - transform.up * magnitude2;
			}
			Plane nearPlane = NearPlane;
			Vector3 direction = ((nearPlane.GetDistanceToPoint(transform.position) >= 0f) ? (-nearPlane.normal) : nearPlane.normal);
			ray = new Ray(transform.position, direction);
			if (nearPlane.Raycast(ray, out enter))
			{
				Vector3 point2 = ray.GetPoint(enter);
				Vector3 vector3 = Vector3.zero;
				Vector3 vector4 = Vector3.zero;
				ray = new Ray(point2, transform.up);
				if (TopPlane.Raycast(ray, out enter))
				{
					vector3 = ray.GetPoint(enter);
				}
				ray = new Ray(point2, transform.right);
				if (RightPlane.Raycast(ray, out enter))
				{
					vector4 = ray.GetPoint(enter);
				}
				float magnitude3 = (vector4 - point2).magnitude;
				float magnitude4 = (vector3 - point2).magnitude;
				_worldPoints[0] = point2 - transform.right * magnitude3 + transform.up * magnitude4;
				_worldPoints[1] = point2 + transform.right * magnitude3 + transform.up * magnitude4;
				_worldPoints[2] = point2 + transform.right * magnitude3 - transform.up * magnitude4;
				_worldPoints[3] = point2 - transform.right * magnitude3 - transform.up * magnitude4;
			}
		}
	}
}
