using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public struct Sphere
	{
		private Vector3 _center;

		private float _radius;

		public Vector3 Center
		{
			get
			{
				return _center;
			}
			set
			{
				_center = value;
			}
		}

		public float Radius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = Mathf.Max(0f, value);
			}
		}

		public Sphere(Vector3 center, float radius)
		{
			_center = center;
			_radius = Mathf.Max(0f, radius);
		}

		public Sphere(AABB aabb)
		{
			_center = aabb.Center;
			_radius = aabb.Extents.magnitude;
		}

		public Sphere(IEnumerable<Vector3> pointCloud)
		{
			Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			foreach (Vector3 item in pointCloud)
			{
				vector = Vector3.Min(item, vector);
				vector2 = Vector3.Max(item, vector2);
			}
			_center = (vector + vector2) * 0.5f;
			_radius = (vector2 - vector).magnitude * 0.5f;
		}

		public bool ContainsPoint(Vector3 point)
		{
			return (_center - point).sqrMagnitude <= _radius * _radius;
		}

		public List<Vector3> GetRightUpExtents(Vector3 right, Vector3 up)
		{
			return SphereMath.CalcRightUpExtents(_center, _radius, right, up);
		}

		public void Encapsulate(Sphere sphere)
		{
			Vector3 vector = Vector3.Normalize(sphere.Center - _center);
			Vector3 vector2 = sphere.Center + vector * sphere.Radius;
			if (!ContainsPoint(vector2))
			{
				Vector3 vector3 = _center - vector * _radius;
				Radius = (vector2 - vector3).magnitude * 0.5f;
				Center = vector2 - vector * _radius;
			}
		}
	}
}
