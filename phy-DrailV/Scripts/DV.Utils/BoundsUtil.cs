using System.Collections.Generic;
using UnityEngine;

public static class BoundsUtil
{
	public static Bounds FromPoints(List<Vector3> points)
	{
		if (points == null || points.Count == 0)
		{
			return default(Bounds);
		}
		Bounds result = new Bounds(points[0], Vector3.zero);
		foreach (Vector3 point in points)
		{
			result.Encapsulate(point);
		}
		return result;
	}

	public static Bounds Merged(List<Bounds> bounds)
	{
		if (bounds == null || bounds.Count == 0)
		{
			return default(Bounds);
		}
		Bounds result = bounds[0];
		foreach (Bounds bound in bounds)
		{
			result.Encapsulate(bound);
		}
		return result;
	}

	public static Bounds BoxColliderAABB(BoxCollider collider, Transform relativeTo)
	{
		Matrix4x4 matrix4x = (relativeTo ? relativeTo.localToWorldMatrix.inverse : Matrix4x4.identity) * collider.transform.localToWorldMatrix * Matrix4x4.TRS(collider.center, Quaternion.identity, collider.size);
		Vector3 vector = new Vector3(matrix4x.m03, matrix4x.m13, matrix4x.m23);
		Bounds result = new Bounds(vector, Vector3.zero);
		result.Encapsulate(vector + (Vector3)(matrix4x * new Vector3(-0.5f, 0.5f, 0.5f)));
		result.Encapsulate(vector + (Vector3)(matrix4x * new Vector3(-0.5f, 0.5f, -0.5f)));
		result.Encapsulate(vector + (Vector3)(matrix4x * new Vector3(-0.5f, -0.5f, 0.5f)));
		result.Encapsulate(vector + (Vector3)(matrix4x * new Vector3(-0.5f, -0.5f, -0.5f)));
		result.Encapsulate(vector + (Vector3)(matrix4x * new Vector3(0.5f, 0.5f, 0.5f)));
		result.Encapsulate(vector + (Vector3)(matrix4x * new Vector3(0.5f, 0.5f, -0.5f)));
		result.Encapsulate(vector + (Vector3)(matrix4x * new Vector3(0.5f, -0.5f, 0.5f)));
		result.Encapsulate(vector + (Vector3)(matrix4x * new Vector3(0.5f, -0.5f, -0.5f)));
		return result;
	}
}
