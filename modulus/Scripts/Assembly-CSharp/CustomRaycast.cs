using System.Collections.Generic;
using UnityEngine;

public static class CustomRaycast
{
	public class MeshRaycastHit
	{
		public Vector3 Point;

		public Transform Transform;

		public Vector3 Normal;
	}

	private static List<Bounds> _boundsToDraw = new List<Bounds>();

	public static bool MeshRaycast(Ray ray, out MeshRaycastHit hitInfo, List<MeshFilter> meshFilters, bool ignoreInactive = true)
	{
		hitInfo = new MeshRaycastHit();
		bool result = false;
		_boundsToDraw.Clear();
		List<MeshRaycastHit> list = new List<MeshRaycastHit>();
		foreach (MeshFilter meshFilter in meshFilters)
		{
			if ((!ignoreInactive || !meshFilter.gameObject.activeSelf) && ignoreInactive)
			{
				continue;
			}
			Bounds item = TransformBounds(meshFilter.sharedMesh.bounds, meshFilter.transform);
			if (item.IntersectRay(ray))
			{
				_boundsToDraw.Add(item);
				if (IntersectMesh(ray, meshFilter, out var hitInfo2))
				{
					result = true;
					list.Add(hitInfo2);
				}
			}
		}
		if (list.Count == 0)
		{
			return false;
		}
		MeshRaycastHit meshRaycastHit = list[0];
		float num = Vector3.Distance(ray.origin, meshRaycastHit.Point);
		foreach (MeshRaycastHit item2 in list)
		{
			float num2 = Vector3.Distance(ray.origin, item2.Point);
			if (num2 < num)
			{
				num = num2;
				meshRaycastHit = item2;
			}
		}
		hitInfo = meshRaycastHit;
		return result;
	}

	public static Bounds TransformBounds(Bounds bounds, Transform transform)
	{
		Vector3 center = transform.TransformPoint(bounds.center);
		Vector3 extents = bounds.extents;
		Vector3 vector = transform.TransformVector(new Vector3(extents.x, 0f, 0f));
		Vector3 vector2 = transform.TransformVector(new Vector3(0f, extents.y, 0f));
		Vector3 vector3 = transform.TransformVector(new Vector3(0f, 0f, extents.z));
		extents.x = Mathf.Abs(vector.x) + Mathf.Abs(vector2.x) + Mathf.Abs(vector3.x);
		extents.y = Mathf.Abs(vector.y) + Mathf.Abs(vector2.y) + Mathf.Abs(vector3.y);
		extents.z = Mathf.Abs(vector.z) + Mathf.Abs(vector2.z) + Mathf.Abs(vector3.z);
		return new Bounds(center, extents * 2f);
	}

	private static bool IntersectMesh(Ray ray, MeshFilter meshFilter, out MeshRaycastHit hitInfo)
	{
		hitInfo = new MeshRaycastHit();
		Mesh sharedMesh = meshFilter.sharedMesh;
		if (sharedMesh == null)
		{
			return false;
		}
		bool result = false;
		Transform transform = meshFilter.transform;
		Vector3[] vertices = sharedMesh.vertices;
		int[] triangles = sharedMesh.triangles;
		float num = 999f;
		for (int i = 0; i < triangles.Length; i += 3)
		{
			Vector3 vector = transform.TransformPoint(vertices[triangles[i]]);
			Vector3 vector2 = transform.TransformPoint(vertices[triangles[i + 1]]);
			Vector3 vector3 = transform.TransformPoint(vertices[triangles[i + 2]]);
			if (RayIntersectsTriangle(ray, vector, vector2, vector3, out var distance))
			{
				result = true;
				float num2 = Vector3.Distance(ray.GetPoint(distance), ray.origin);
				if (num2 < num)
				{
					num = num2;
					hitInfo.Point = ray.GetPoint(distance);
					hitInfo.Transform = transform;
					hitInfo.Normal = Vector3.Cross(vector2 - vector, vector3 - vector).normalized;
				}
			}
		}
		return result;
	}

	private static bool RayIntersectsTriangle(Ray ray, Vector3 v0, Vector3 v1, Vector3 v2, out float distance)
	{
		distance = 0f;
		Vector3 vector = v1 - v0;
		Vector3 vector2 = v2 - v0;
		Vector3 rhs = Vector3.Cross(ray.direction, vector2);
		float num = Vector3.Dot(vector, rhs);
		if (num > -1E-05f && num < 1E-05f)
		{
			return false;
		}
		float num2 = 1f / num;
		Vector3 lhs = ray.origin - v0;
		float num3 = num2 * Vector3.Dot(lhs, rhs);
		if (num3 < 0f || num3 > 1f)
		{
			return false;
		}
		Vector3 rhs2 = Vector3.Cross(lhs, vector);
		float num4 = num2 * Vector3.Dot(ray.direction, rhs2);
		if (num4 < 0f || num3 + num4 > 1f)
		{
			return false;
		}
		distance = num2 * Vector3.Dot(vector2, rhs2);
		return distance > 1E-05f;
	}
}
