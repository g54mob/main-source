using System;
using PajamaLlama.Math;
using UnityEngine;

[Serializable]
public class AxisAllignedRectangle
{
	public static Vector2 NormalUp = Vector2.up;

	public static Vector2 NormalRight = Vector2.right;

	public Vector2 _center;

	private Vector2 _boundsMin;

	private Vector2 _boundsMax;

	public Vector2 Position => _center;

	public AxisAllignedRectangle(Vector2 center, Vector2 size)
	{
		_center = center;
		Vector2 vector = size / 2f;
		_boundsMin = _center - vector;
		_boundsMax = _center + vector;
	}

	public bool ReturnIsPolygonOverlapping(Polygon polygon)
	{
		Vector2[] vertices = polygon.ReturnPolygon();
		if (ReturnAreProjectionsOverlapping(vertices, NormalUp, _boundsMin.y, _boundsMax.y) && ReturnAreProjectionsOverlapping(vertices, NormalRight, _boundsMin.x, _boundsMax.x))
		{
			return polygon.ReturnIsAxisAllignedRectangleOverlapping(_boundsMin, _boundsMax);
		}
		return false;
	}

	public bool ReturnIsSphereOverlapping(Vector2 center, float radius)
	{
		if (ReturnIsSphereProjectionOverlapping(center, radius, NormalUp, _boundsMin.y, _boundsMax.y) && ReturnIsSphereProjectionOverlapping(center, radius, NormalRight, _boundsMin.x, _boundsMax.x))
		{
			Vector2 normalized = (ReturnClosestVertex(center) - center).normalized;
			Vector2 vector = ReturnProjectionOnAxis(normalized);
			return ReturnIsSphereProjectionOverlapping(center, radius, normalized, vector.x, vector.y);
		}
		return false;
	}

	public bool ReturnIsContainedBySphere(Vector2 center, float radius)
	{
		float num = radius * radius;
		if (center.DistanceToSquared(_boundsMin.x, _boundsMax.y) < num && center.DistanceToSquared(_boundsMax.x, _boundsMax.y) < num && center.DistanceToSquared(_boundsMax.x, _boundsMin.y) < num)
		{
			return center.DistanceToSquared(_boundsMin.x, _boundsMin.y) < num;
		}
		return false;
	}

	private bool ReturnAreProjectionsOverlapping(Vector2[] vertices, Vector2 axis, float min, float max)
	{
		Vector2 vector = vertices[0];
		float num = axis.x * vector.x + axis.y * vector.y;
		float num2 = num;
		float num3 = num;
		int num4 = vertices.Length;
		for (int i = 1; i < num4; i++)
		{
			vector = vertices[i];
			num = axis.x * vector.x + axis.y * vector.y;
			if (num < num2)
			{
				num2 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
		}
		if (!(num3 < min))
		{
			return !(max < num2);
		}
		return false;
	}

	private bool ReturnIsSphereProjectionOverlapping(Vector2 sphereCenter, float sphereRadius, Vector2 axis, float min, float max)
	{
		float num = axis.x * sphereCenter.x + axis.y * sphereCenter.y;
		min -= sphereRadius;
		max += sphereRadius;
		if (!(num < min))
		{
			return !(max < num);
		}
		return false;
	}

	private Vector2 ReturnClosestVertex(Vector2 point)
	{
		Vector2 vector = new Vector2(_boundsMin.x, _boundsMax.y);
		float num = point.DistanceToSquared(vector);
		float num2 = num;
		num = point.DistanceToSquared(_boundsMax.x, _boundsMax.y);
		if (num < num2)
		{
			num2 = num;
			vector.x = _boundsMax.x;
			vector.y = _boundsMax.y;
		}
		num = point.DistanceToSquared(_boundsMax.x, _boundsMin.y);
		if (num < num2)
		{
			num2 = num;
			vector.x = _boundsMax.x;
			vector.y = _boundsMin.y;
		}
		num = point.DistanceToSquared(_boundsMin.x, _boundsMin.y);
		if (num < num2)
		{
			num2 = num;
			vector.x = _boundsMin.x;
			vector.y = _boundsMin.y;
		}
		return vector;
	}

	private Vector2 ReturnProjectionOnAxis(Vector2 axis)
	{
		float num = axis.x * _boundsMin.x + axis.y * _boundsMax.y;
		float num2 = num;
		float num3 = num;
		num = axis.x * _boundsMax.x + axis.y * _boundsMax.y;
		num2 = ((num < num2) ? num : num2);
		num3 = ((num3 < num) ? num : num3);
		num = axis.x * _boundsMax.x + axis.y * _boundsMin.y;
		num2 = ((num < num2) ? num : num2);
		num3 = ((num3 < num) ? num : num3);
		num = axis.x * _boundsMin.x + axis.y * _boundsMin.y;
		num2 = ((num < num2) ? num : num2);
		num3 = ((num3 < num) ? num : num3);
		return new Vector2(num2, num3);
	}
}
